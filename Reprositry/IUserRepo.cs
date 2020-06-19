using System.Collections.Generic;
using ZIPUSERAPI.Models;

namespace ZIPUSERAPI.Data
{
    public interface IUserRepo
    {

         bool SaveChanges();
         
         IEnumerable<User> UserList();
         User GetUser(int id);
         void CreateUser(User user);
    } 
    
}