using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class TblStatus
{
    public int StatusId { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual ICollection<SlotBooking> SlotBookings { get; } = new List<SlotBooking>();

    public virtual ICollection<TblRoom> TblRooms { get; } = new List<TblRoom>();
}
