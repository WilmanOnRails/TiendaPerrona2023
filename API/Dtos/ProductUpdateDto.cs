using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ProductUpdateDto
{
    public string ProductDescription { get; set; } = null!;
    public decimal ProductPrice { get; set; }
    public int ProductStock { get; set; }
}
