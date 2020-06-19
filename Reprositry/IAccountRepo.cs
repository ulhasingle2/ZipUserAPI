using System.Collections.Generic;
using ZIPUSERAPI.Models;

namespace ZIPUSERAPI.Data
{
    public interface IAccountRepo
    {
         bool SaveChanges();         
         IEnumerable<Account> AccountList();
         void CreateAccount(Account account);
    } 
    
}