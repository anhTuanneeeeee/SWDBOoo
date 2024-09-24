using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class TblRole
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<TblUser> TblUsers { get; } = new List<TblUser>();
}
