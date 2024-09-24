using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateUser { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Image { get; set; }

    public int? RoleId { get; set; }

    public virtual TblRole? Role { get; set; }

    public virtual ICollection<TblBooking> TblBookings { get; } = new List<TblBooking>();
}
