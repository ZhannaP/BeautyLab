using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Requests
{
    public class PaymentRequest
    {
        public int AppointmentId { get; set; }

        public double Amount { get; set; }

        public string Method { get; set; }

        public string Status { get; set; }
    }
}
