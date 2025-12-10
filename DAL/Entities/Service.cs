using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DAL.BaseEntity;

namespace Beauty.Entities
{
    public class Service : BaseEntity
    {
        public int ServiceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double BasePrice { get; set; }

        public float Duration { get; set; }
    }
}
