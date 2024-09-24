using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int BookingId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public int StatusId { get; set; }

    public virtual TblBooking Booking { get; set; } = null!;

    public virtual TblStatus Status { get; set; } = null!;
}
