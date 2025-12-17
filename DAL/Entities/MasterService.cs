using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Entities
{
    public class MasterService : BaseEntity.BaseEntity
    {
        public int MasterServiceId { get; set; }

        public int MasterId { get; set; }

        public int ServiceId { get; set; }

        public virtual Master Master { get; set; }

        public virtual Service Service { get; set; }

        public double? PriceOverride { get; set; }

    }
}
