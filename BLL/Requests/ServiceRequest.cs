using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Requests
{
    public class ServiceRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double BasePrice { get; set; }

        public int Duration { get; set; }
    }
}
