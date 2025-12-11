using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Responses
{
    public class ClientResponse
    {
        public int ClientId { get; set; }

        public int UserId { get; set; }

        public string Notes { get; set; }

        public string UserFullName { get; set; }

        public string Email { get; set; }
    }
}
