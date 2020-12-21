using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.lib.Objects
{
    public partial class TypeMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MemberTypes_Role> MemberTypes_Roles { get; set; }
    }
}
