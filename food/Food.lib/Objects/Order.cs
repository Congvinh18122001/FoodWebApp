﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Objects
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public Nullable<bool> Shipped { get; set; }
        public Nullable<DateTime> ShippedDate { get; set; }
        public Nullable<bool> HadSold { get; set; }
        public Nullable<bool> Cancelled { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
