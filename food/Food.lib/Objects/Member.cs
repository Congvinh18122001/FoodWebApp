using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Objects
{
    public partial class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<DateTime> Birthday { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public int? TypeMemberId { get; set; }
        [ForeignKey("TypeMemberId")]
        public virtual TypeMember TypeMember { get; set; }
    }
}
