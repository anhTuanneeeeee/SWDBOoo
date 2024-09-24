using BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class AccountDAO
    {
        private readonly BookroomContext _context;

        public AccountDAO(BookroomContext context)
        {
            _context = context;
        }

        
        public void AddAccount(TblUser account)
        {
            
            if (account.RoleId == null)
            {
                account.RoleId = 1;
            }

            _context.TblUsers.Add(account);
            _context.SaveChanges();
        }
        public TblUser GetAccountById(int accountId)
        {
            return _context.TblUsers.Find(accountId);
        }
    }
}
