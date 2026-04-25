using Microsoft.AspNetCore.Mvc;
using System;

namespace FinalIntegrations
{
    // 292. JWT Refresh Token Rotation.
    // For high security, React apps shouldn't store long-lived tokens. 
    // This logic issues short-lived Access Tokens and a "Refresh Token" that 
    // is replaced (rotated) every time it is used.

    public record TokenRequest(string ExpiredToken, string RefreshToken);

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("refresh")]
        public IActionResult Refresh(TokenRequest request)
        {
            // 1. Validate old refresh token from Database
            // 2. Generate new Access Token
            // 3. Generate NEW Refresh Token and delete the old one (Rotation)
            return Ok(new { AccessToken = "new_jwt", RefreshToken = "new_refresh_id" });
        }
    }
}