using BOs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REPOs;

namespace BookingController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomRepository _roomRepository;
        public RoomController(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        [HttpGet]
        public ActionResult<List<TblRoom>> GetAllRooms()
        {
            return Ok(_roomRepository.GetAllRooms());
        }
        [HttpPost]
        public ActionResult AddRoom([FromBody] TblRoom room)
        {
            _roomRepository.AddRoom(room);
            return Ok("Room added successfully.");
        }
        [HttpPut("{id}")]
        public ActionResult UpdateRoom(int id, [FromBody] TblRoom room)
        {
            room.RoomId = id;
            _roomRepository.UpdateRoom(room);
            return Ok("Room updated successfully.");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteRoom(int id)
        {
            _roomRepository.DeleteRoom(id);
            return Ok("Room deleted successfully.");
        }
    }
}
