using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class TblBooking
{
    public int BookingId { get; set; }

    public int? UserId { get; set; }

    public int? RoomId { get; set; }

    public DateTime BookingDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual TblRoom? Room { get; set; }

    public virtual ICollection<SlotBooking> SlotBookings { get; } = new List<SlotBooking>();

    public virtual TblUser? User { get; set; }
}
