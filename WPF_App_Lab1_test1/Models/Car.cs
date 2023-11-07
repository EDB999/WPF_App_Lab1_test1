using System;
using System.Collections.Generic;

namespace WPF_App_Lab1_test1;

public partial class Car
{
    public int IdCar { get; set; }

    public string? Model { get; set; }

    public string? Number { get; set; }

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
}
