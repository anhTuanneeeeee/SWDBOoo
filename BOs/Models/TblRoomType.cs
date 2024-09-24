using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class TblRoomType
{
    public int RoomTypeId { get; set; }

    public string? TypeName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<TblRoom> TblRooms { get; } = new List<TblRoom>();
}
