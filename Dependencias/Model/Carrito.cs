using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependencias.Model
{
    public class Carrito
    {
        [Key]
        public string ProductName { get; set; } = null!;

        public string ProductDescription { get; set; } = null!;

        [Column(TypeName = "decimal(6,2)")]
        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal Total { get; set; }
    }
}
