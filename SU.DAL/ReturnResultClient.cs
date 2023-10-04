using SU.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU.DAL
{
    public class ReturnResultClient
    {
        public bool IsSeccess { get; set; } = true;
        public Exception Exception { get; set; }
        public Client Client { get; set; }
        public List<Client> Clients { get; set; }
    }
}
