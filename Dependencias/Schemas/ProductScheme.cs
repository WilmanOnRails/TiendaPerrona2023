using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dependencias;

public class ProductScheme
{
    public int productId { get; set; }
    public string productName { get; set; } = null!;
    public string productDescription { get; set; } = null!;
    public decimal productPrice { get; set; }

    public int productStock { get; set; }

    public int productType { get; set; }
}


