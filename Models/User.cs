using System.ComponentModel.DataAnnotations;

namespace ZIPUSERAPI.Models
{
    public class User
    {
        [Key]
        public int? ID { get; set; }  
        
        [Required]
        public string Name { get; set; }     

        [Required]
        [RegularExpression(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b",ErrorMessage="Invalid Email format")]
        public string Email { get; set; }

        [Required]
        [Range(0, 200000000, ErrorMessage="Salar must be positive")]  
        public int  Salary { get; set; }

        [Required]
        [Range(0, 200000000, ErrorMessage="Expenses must be positive")]  
        public int Expenses { get; set; }
    }
    
}