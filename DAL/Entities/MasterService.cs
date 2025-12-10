using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DAL.BaseEntity;

namespace Beauty.Entities
{
    public class MasterService : BaseEntity
    {
        public int MasterServiceId { get; set; }

        public virtual Master MasterId { get; set; }

        public virtual Service ServiceId { get; set; }

        public double PriceOverrride { get; set; }

    }
}
