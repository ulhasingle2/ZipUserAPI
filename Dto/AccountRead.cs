using System.ComponentModel.DataAnnotations;

namespace ZIPUSERAPI.Models
{
    public class AccountRead
    {
              
        public int? Account_no { get; set; }                  
        public string Email_id { get; set; }         
        public int  Account_amt { get; set; }

        
    }
    
}