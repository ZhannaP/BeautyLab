using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Requests
{
    public class MasterServiceRequest
    {
        public int MasterId { get; set; }

        public int ServiceId { get; set; }

        public double PriceOverride { get; set; }
    }
}
