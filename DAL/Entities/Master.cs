using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Entities
{
    public class Master : BaseEntity.BaseEntity
    {
        public int MasterId { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string Specialization { get; set; }

        public int ExperienceYears { get; set; }
    }
}
