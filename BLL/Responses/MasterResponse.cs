using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Responses
{
    public class MasterResponse
    {
        public int MasterId { get; set; }

        public int UserId { get; set; }

        public string Specialization { get; set; }

        public int ExperienceYears { get; set; }

        public string UserFullName { get; set; }

        public string Email { get; set; }
    }
}
