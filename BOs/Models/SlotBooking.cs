using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class SlotBooking
{
    public int SlotBookingId { get; set; }

    public int BookingId { get; set; }

    public int SlotId { get; set; }

    public int StatusId { get; set; }

    public virtual TblBooking Booking { get; set; } = null!;

    public virtual TblSlot Slot { get; set; } = null!;

    public virtual TblStatus Status { get; set; } = null!;
}
