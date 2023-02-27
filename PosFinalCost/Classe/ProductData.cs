using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosFinalCost.Classe
{
    class ProductData {
        public Barcode Barcode { get; set; }
        public Product Product { get; set; }
        public PrdMeasurment PrdMeasurment { get; set; }
        public GroupStr GroupStr { get; set; }
    }
}
