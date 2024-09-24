using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class TblRoom
{
    public int RoomId { get; set; }

    public string? RoomName { get; set; }

    public int? RoomTypeId { get; set; }

    public int? BranchId { get; set; }

    public int? StatusId { get; set; }

    public bool? IsAvailable { get; set; }

    public virtual TblBranch? Branch { get; set; }

    public virtual TblRoomType? RoomType { get; set; }

    public virtual TblStatus? Status { get; set; }

    public virtual ICollection<TblBooking> TblBookings { get; } = new List<TblBooking>();
}
