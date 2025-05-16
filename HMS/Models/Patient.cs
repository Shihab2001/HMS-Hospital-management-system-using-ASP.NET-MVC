using System;
using System.Collections.Generic;

namespace HMS.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? CheckIn { get; set; }

    public string? Address { get; set; }

    public string? ProblemState { get; set; }

    public string? Status { get; set; }
}
