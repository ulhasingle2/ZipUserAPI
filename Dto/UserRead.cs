using System.ComponentModel.DataAnnotations;

namespace ZIPUSERAPI.Dto
{
    public class UserRead
    {
       
        public int ID { get; set; }  
        public string Name { get; set; }          
        public string Email { get; set; }         
        public int  Salary { get; set; }
        public int Expenses { get; set; }
    }
    
}