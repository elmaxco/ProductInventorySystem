﻿namespace Resources.Models;

public class Customer
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Price { get; set; } = null!;
    public string Name { get; set; } = null!;
    
}
