using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DAL.BaseEntity;

namespace Beauty.Entities
{
    public class Payment : BaseEntity
    {
        public int PaymentId { get; set; }

        public virtual Appointment AppointmentId { get; set; }

        public double Amount { get; set; }

        public string Method { get; set; }

        public string Status { get; set; }

    }
}
