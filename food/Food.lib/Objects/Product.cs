using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Objects
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName  { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal UnitsPrice { get; set; }
        public int Inventory { get; set; }
        public Nullable<int> HadSold { get; set; }
        public Nullable<bool> DisContinued { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }


    }
}
