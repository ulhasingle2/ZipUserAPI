using System;
using System.Collections.Generic;
using System.Linq;
using ZIPUSERAPI.Data;
using ZIPUSERAPI.Models;

namespace ZipUserAPI.Data
{
    public class AccountRepo : IAccountRepo
    {
        private readonly UserContext _context;

        public AccountRepo(UserContext context)
        {
                _context=context;
        }

        IEnumerable<Account> IAccountRepo.AccountList()
        {
            return  _context.Account.ToList();
        }

        void IAccountRepo.CreateAccount(Account account)
        {
            if(account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            _context.Account.Add(account);
        }

        bool IAccountRepo.SaveChanges()
        {
             return  (_context.SaveChanges() >=0);
        }
    }
}
