using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Requests
{
    public class MasterRequest
    {
        public int UserId { get; set; }

        public string Specialization { get; set; }

        public int ExperienceYears { get; set; }
    }
}
