using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Entities
{
    public class Client: BaseEntity.BaseEntity
    {
        public int ClientId { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string Notes { get; set; }
    }
}
