using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Entities
{
    public class Service : BaseEntity.BaseEntity
    {
        public int ServiceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double BasePrice { get; set; }

        public int Duration { get; set; }
    }
}
