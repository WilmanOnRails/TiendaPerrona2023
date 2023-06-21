using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dependencias.Model;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    [Column(TypeName = "decimal(6,2)")]
    public decimal ProductPrice { get; set; }

    public int ProductStock { get; set; }
    public int ProductType { get; set; } 
}
