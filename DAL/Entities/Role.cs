using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Entities
{
    public class Role : BaseEntity.BaseEntity
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }
}
