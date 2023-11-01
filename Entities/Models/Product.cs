﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public string? Summary { get; set; }
    public string? ImageUrl { get; set; }
    public int? CategoryId { get; set; }   // Foreing key
    public Category? Category { get; set; }   //Navigate property
}

