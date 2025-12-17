using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User : BaseEntity.BaseEntity
    {
        public int UserId { get; set; }
 
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
