using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class TblBranch
{
    public int BranchId { get; set; }

    public string? BranchName { get; set; }

    public string? Location { get; set; }

    public string? PhoneNumber { get; set; }

    public int? PriceId { get; set; }

    public virtual TblPrice? Price { get; set; }

    public virtual ICollection<TblRoom> TblRooms { get; } = new List<TblRoom>();
}
