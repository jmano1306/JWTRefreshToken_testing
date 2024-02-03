using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JWTRefreshToken.Auth
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        public string? NationalIDNumber { get; set; }
        public string? EmployeeName { get; set; }
        public string? LoginID { get; set; }
        public string? JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public string? MaritalStatus { get; set; }
        //Manohar added code
        public string? Gender { get; set; }
      

        
    }
}
