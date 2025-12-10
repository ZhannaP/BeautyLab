using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DAL.BaseEntity;

namespace Beauty.Entities
{
    public class Client
    {
        public int ClientId { get; set; }

        public virtual User UserId { get; set; }

        public string Notes { get; set; }
    }
}
