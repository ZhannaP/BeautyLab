using DAL.BaseEntity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.Entities
{
    public class Appointment : BaseEntity
    {
        public int AppointmentId { get; set; }

        public virtual Client ClientId { get; set; }

        public virtual Master MasterId { get; set; }

        public virtual Service ServiceId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Status { get; set; }
    }
}
