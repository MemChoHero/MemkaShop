using MemkaShop.Application.Auth.Commands;
using MemkaShop.Application.Auth.Queries;
using MemkaShop.Application.Auth.UseCases;
using MemkaShop.WebApi.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace MemkaShop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(
    RegisterInteractor registerInteractor,
    LoginInteractor loginInteractor,
    ILogger<AuthController> logger,
    JwtProcessor jwtProcessor) : Controller
{
    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {
        var response = await registerInteractor.InvokeAsync(command);
        
        logger.LogInformation($"User {command.Email} registered successfully");

        return Ok(response);
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query)
    {
        var response = await loginInteractor.InvokeAsync(query);

        if (!response)
            return Unauthorized(new { Error = "Invalid credentials" });

        var accessToken = jwtProcessor.Encode(query.Email, TimeSpan.FromMinutes(15));
        var refreshToken = jwtProcessor.Encode(query.Email, TimeSpan.FromDays(30));

        var cookieOptions = new CookieOptions()
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddDays(30)
        };
        
        Response.Cookies.Append("refresh_token", refreshToken, cookieOptions);

        return Ok(new { AccessToken = accessToken });
    }

    [HttpPost("/refresh")]
    public IActionResult Refresh()
    {
        if (!Request.Cookies.TryGetValue("refreshToken", out var refreshToken))
            return Unauthorized(new { Error = "No refresh token provided" });

        var email = "";
        
        try
        {
            email = jwtProcessor.Validate(refreshToken);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { Error = ex.Message });
        }

        var accessToken = jwtProcessor.Encode(email, TimeSpan.FromMinutes(15));
        var newRefreshToken = jwtProcessor.Encode(email, TimeSpan.FromDays(30));

        var cookieOptions = new CookieOptions()
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddDays(30)
        };
        
        Response.Cookies.Append("refresh_token", newRefreshToken, cookieOptions);
        
        return Ok(new { AccessToken = accessToken });
    }
}