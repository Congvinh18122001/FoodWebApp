using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Objects
{
    public partial class Supplier
    {

        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string  Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
