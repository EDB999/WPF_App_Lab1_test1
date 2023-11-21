using System;
using System.Collections.Generic;

namespace WPF_App_Lab1_test1;

public partial class Driver
{
    public int IdDriver { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public int? Rating { get; set; }

    public int? IdCar { get; set; }

    public virtual Car? IdCarNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
