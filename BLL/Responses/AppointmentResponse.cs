using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Responses
{
    public class AppointmentResponse
    {
        public int AppointmentId { get; set; }

        public int ClientId { get; set; }

        public int MasterId { get; set; }

        public int ServiceId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Status { get; set; }

        public string ClientName { get; set; }

        public string MasterName { get; set; }

        public string ServiceName { get; set; }
    }
}
