using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTRefreshToken.Auth
{
    public class RegisterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="User Name is Required")]
        public string? Username {  get; set; }
        [EmailAddress]
        public string? Email {  get; set; }
        [Required(ErrorMessage ="Password is Required")]
        public string? Password { get; set; }
    }
}
