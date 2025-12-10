
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Appointment : BaseEntity.BaseEntity
    {
        public int AppointmentId { get; set; }

        public int ClientId { get; set; }

        public int MasterId { get; set; }

        public int ServiceId { get; set; }

        public virtual Client Client { get; set; }

        public virtual Master Master { get; set; }

        public virtual Service Service { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Status { get; set; }
    }
}
