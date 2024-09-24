using BookingController.DTO;
using BOs.Models;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOs
{
    public interface IAccountRepo
    {
        Task<TblUser> CreateAccountAsync(AccountCreateDto accountDto);
        Task<TblUser?> GetAccountByIdAsync(int id);
    }
    public class AccountRepository : IAccountRepo
    {
        private readonly BookroomContext _context;

        public AccountRepository(BookroomContext context)
        {
            _context = context;
        }

        public async Task<TblUser> CreateAccountAsync(AccountCreateDto accountDto)
        {
            var newUser = new TblUser
            {
                UserName = accountDto.UserName,
                Email = accountDto.Email,
                Password = accountDto.Password,  // Lưu ý: Cần mã hóa mật khẩu trước khi lưu
                PhoneNumber = accountDto.PhoneNumber,
                RoleId = 1,  // Mặc định là RoleId = 1 (Customer)
                Status = true,
                CreateUser = DateTime.Now
            };

            _context.TblUsers.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<TblUser?> GetAccountByIdAsync(int id)
        {
            return await _context.TblUsers.FindAsync(id);
        }


    }
}
