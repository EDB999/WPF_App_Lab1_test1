using System;
using System.Collections.Generic;

namespace WPF_App_Lab1_test1;

public partial class Order
{
    public int IdOrder { get; set; }

    public string? Price { get; set; }

    public string? Time { get; set; }

    public string? Date { get; set; }

    public int IdClient { get; set; }

    public int IdDriver { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Driver IdDriverNavigation { get; set; } = null!;
}
