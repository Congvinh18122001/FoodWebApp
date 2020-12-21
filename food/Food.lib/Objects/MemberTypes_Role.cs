using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Objects
{
    public partial class MemberTypes_Role
    {
        [Key, Column(Order = 0)]
        public string RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
        [Key, Column(Order = 1)]
        public int TypeMemberId { get; set; }
        [ForeignKey("TypeMemberId")]
        public virtual TypeMember TypeMember { get; set; }
    }
}
