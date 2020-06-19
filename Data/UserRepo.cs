using System.Collections.Generic;
using ZIPUSERAPI.Data;
using ZIPUSERAPI.Models;

namespace ZipUserAPI.Data
{
    public class UserRepo : IUserRepo
    {

        void IUserRepo.CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        User IUserRepo.GetUser(int id)
        {
            return new User{ID=10,Email="abc@gmail.com",Salary=1000,Expenses=500};
        }

        bool IUserRepo.SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<User> IUserRepo.UserList()
        {
            var user=new List<User>
            {
                new User{ID=1,Email="abc@gmail.com",Salary=1000,Expenses=500},
                new User{ID=2,Email="xz@gmail.com",Salary=1000,Expenses=500},
                new User{ID=3,Email="pqr@gmail.com",Salary=1000,Expenses=500}
            };

            return user;
        }
    }
}
