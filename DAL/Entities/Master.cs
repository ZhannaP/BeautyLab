using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DAL.BaseEntity;

namespace Beauty.Entities
{
    public class Master : BaseEntity
    {
        public int MasterId { get; set; }

        public virtual User UserId { get; set; }

        public string Specialization { get; set; }

        public int ExperienceYears { get; set; }
    }
}
