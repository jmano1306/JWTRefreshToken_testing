using System.ComponentModel.DataAnnotations;

namespace JWTRefreshToken.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage ="UserName is Required")]
        public string? Username {  get; set; }
        [Required(ErrorMessage ="Password is Required")]
        public string? Password { get; set; }
    }
}
