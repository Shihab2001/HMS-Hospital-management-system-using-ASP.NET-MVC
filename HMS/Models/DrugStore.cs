using System;
using System.Collections.Generic;

namespace HMS.Models;

public partial class DrugStore
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public string DGroup { get; set; } = null!;

    public string Expire { get; set; } = null!;

    public int InStock { get; set; }
}
