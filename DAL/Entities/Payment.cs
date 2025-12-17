using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Entities
{
    public class Payment : BaseEntity.BaseEntity
    {
        public int PaymentId { get; set; }

        public int AppointmentId { get; set; }

        public virtual Appointment Appointment { get; set; }

        public double Amount { get; set; }

        public string Method { get; set; }

        public string Status { get; set; }

    }
}
