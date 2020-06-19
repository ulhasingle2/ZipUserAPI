using System;
using System.Collections.Generic;
using System.Linq;
using ZIPUSERAPI.Data;
using ZIPUSERAPI.Models;

namespace ZipUserAPI.Data
{
    public class UserRepos : IUserRepo
    {
        private readonly UserContext _context;

        public UserRepos(UserContext context)
        {
                _context=context;
        }

        IEnumerable<User> IUserRepo.UserList()
        {
          return  _context.Users.ToList();
        }

        User IUserRepo.GetUser(int id)
        {
              return  _context.Users.FirstOrDefault(x => x.ID ==id);
        }

        bool IUserRepo.SaveChanges()
        {
            return  (_context.SaveChanges() >=0);
        }

        void IUserRepo.CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Add(user);
        }
        
    }
}
