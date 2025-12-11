using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Responses
{
    public class MasterServiceResponse
    {
        public int MasterServiceId { get; set; }

        public int MasterId { get; set; }

        public int ServiceId { get; set; }

        public double PriceOverride { get; set; }

        public string MasterName { get; set; }

        public string ServiceName { get; set; }
    }
}
