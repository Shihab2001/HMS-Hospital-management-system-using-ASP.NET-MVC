using System;
using System.Collections.Generic;

namespace HMS.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string DutyOn { get; set; } = null!;

    public string DutyOff { get; set; } = null!;

    public string DutyPlace { get; set; } = null!;

    public string DutyStatus { get; set; } = null!;

    public string Post { get; set; } = null!;
}
