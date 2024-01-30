using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JWTRefreshToken.Auth
{
    public class UserManagerResponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsSuccess {  get; set; }
        public string Message { get; set; }
        public string Errors {  get; set; }

    }
}
