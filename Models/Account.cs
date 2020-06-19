using System.ComponentModel.DataAnnotations;

namespace ZIPUSERAPI.Models
{
    public class Account
    {
        
        
        [Key] 
        public int? Account_no { get; set; }     

        [Required]        
        public string Email_id { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage="SAmount must be positive")]  
        public int  Account_amt { get; set; }

        
    }
    
}