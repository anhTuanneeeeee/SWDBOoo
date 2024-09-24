using BOs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class RoomDAO
    {
        public readonly BookroomContext _context;
        private static RoomDAO instance = null;

        
        public RoomDAO(BookroomContext context)
        {
            _context = context;
        }
        //lấy all
        public List<TblRoom> GetAllRooms()
        {
            return _context.TblRooms
                           .Include(r => r.Branch)
                           .Include(r => r.RoomType)
                           .Include(r => r.Status)
                           .ToList();
        }
        //thêm room
        public void AddRoom(TblRoom room)
        {
            _context.TblRooms.Add(room);
            _context.SaveChanges();
        }
        //sửa room(fix sau)
        public void UpdateRoom(TblRoom room)
        {
            _context.TblRooms.Update(room);
            _context.SaveChanges();
        }
        //xóa room
        public void DeleteRoom(int roomId)
        {
            var room = _context.TblRooms.Find(roomId);
            if (room != null)
            {
                _context.TblRooms.Remove(room);
                _context.SaveChanges();
            }
        }
    }
}
