using System;
using System.Collections.Generic;

namespace WPF_App_Lab1_test1;

public partial class Client
{
    public int IdClient { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
