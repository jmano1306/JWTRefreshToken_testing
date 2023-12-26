using System.ComponentModel.DataAnnotations;

namespace JWTRefreshToken.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="User Name is Required")]
        public string? Username {  get; set; }
        [EmailAddress]
        public string? Email {  get; set; }
        [Required(ErrorMessage ="Password is Required")]
        public string? Password { get; set; }
    }
}
