using BOs.Models;
using DAOs;
using System.Collections.Generic;

namespace REPOs
{
    public class RoomRepository
    {
        private readonly RoomDAO _roomDAO;

        public RoomRepository(RoomDAO roomDAO)
        {
            _roomDAO = roomDAO;
        }

        public List<TblRoom> GetAllRooms()
        {
            return _roomDAO.GetAllRooms();
        }

        public void AddRoom(TblRoom room)
        {
            _roomDAO.AddRoom(room);
        }

        public void UpdateRoom(TblRoom room)
        {
            _roomDAO.UpdateRoom(room);
        }

        public void DeleteRoom(int roomId)
        {
            _roomDAO.DeleteRoom(roomId);
        }
    }
    
}
