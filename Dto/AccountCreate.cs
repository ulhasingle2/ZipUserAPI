using System.ComponentModel.DataAnnotations;

namespace ZIPUSERAPI.Dto
{
    public class AccountCreate
    {           

         [Required]
        public string Email_id { get; set; }   

        [Required]
        [Range(0, 1000, ErrorMessage="Amount must be positive orit should be less than $1000 ")]  
        public int?  Account_amt { get; set; }

        [Required]
        [Range(0, 200000000, ErrorMessage="Salary must be positive")]  
        public int  Salary { get; set; }

        [Required]
        [Range(0, 200000000, ErrorMessage="Expenses must be positive")]  
        public int Expenses { get; set; }
       
    }
    
}