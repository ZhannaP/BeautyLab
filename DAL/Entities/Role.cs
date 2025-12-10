using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DAL.BaseEntity;

namespace Beauty.Entities
{
    public class Role : BaseEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
