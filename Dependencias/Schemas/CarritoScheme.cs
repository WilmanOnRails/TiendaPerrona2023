using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependencias;

    public class CarritoScheme
    {
        public string productName { get; set; } = null!;
        public string productDescription { get; set; } = null!;
        public decimal productPrice { get; set; }
        public int quantity { get; set; }
        public decimal total { get; set; }
    }

