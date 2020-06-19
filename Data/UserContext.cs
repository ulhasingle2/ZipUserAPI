using Microsoft.EntityFrameworkCore;
using ZIPUSERAPI.Models;

namespace ZipUserAPI.Data 
{
    public class UserContext : DbContext
    {

        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users {get; set;}

        public DbSet<Account> Account {get; set;}

    }

}
