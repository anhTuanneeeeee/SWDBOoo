using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class TblPrice
{
    public int PriceId { get; set; }

    public int? RoomTypeId { get; set; }

    public string? DayOfWeek { get; set; }

    public string? Price { get; set; }

    public virtual ICollection<TblBranch> TblBranches { get; } = new List<TblBranch>();
}
