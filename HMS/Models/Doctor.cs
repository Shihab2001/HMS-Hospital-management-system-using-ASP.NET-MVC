using System;
using System.Collections.Generic;

namespace HMS.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public string Specialist { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string DutyTime { get; set; } = null!;

    public int RegisteredId { get; set; }
}
