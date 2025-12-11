using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Responses
{
    public class PaymentResponse
    {
        public int PaymentId { get; set; }

        public int AppointmentId { get; set; }

        public double Amount { get; set; }

        public string Method { get; set; }

        public string Status { get; set; }
    }
}
