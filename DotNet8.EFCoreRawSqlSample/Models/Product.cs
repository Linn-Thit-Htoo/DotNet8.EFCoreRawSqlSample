﻿using System;
using System.Collections.Generic;

namespace DotNet8.EFCoreRawSqlSample.Models;

public partial class Product
{
    public long ProductId { get; set; }

    public long CategoryId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Price { get; set; }

    public int Quantity { get; set; }

    public bool IsActive { get; set; }

    public virtual Category Category { get; set; } = null!;
}