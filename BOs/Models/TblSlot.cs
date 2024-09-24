using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class TblSlot
{
    public int SlotId { get; set; }

    public string? StartTime { get; set; }

    public string? EndTime { get; set; }

    public virtual ICollection<SlotBooking> SlotBookings { get; } = new List<SlotBooking>();
}
