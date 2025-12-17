using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Responses
{
    public class ServiceResponse
    {
        public int ServiceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double BasePrice { get; set; }

        public int Duration { get; set; }
    }
}
