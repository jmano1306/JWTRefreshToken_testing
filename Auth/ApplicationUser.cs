using Microsoft.AspNetCore.Identity;

namespace JWTRefreshToken.Auth
{
    public class ApplicationUser:IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string? ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordExpiry { get; set; }
    }
}
