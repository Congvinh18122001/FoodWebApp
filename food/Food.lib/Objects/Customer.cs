using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Objects
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
        public int? MemberId { get; set; }
        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }
    }
}
