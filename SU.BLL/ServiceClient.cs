
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SU.DAL;
using SU.DAL.Model;

namespace SU.BLL
{
    public class ServiceClient
    {
        public bool RegisterClient(Client client)
        {
            RepositoryClient repository = new RepositoryClient();
           return  repository.CreateClient(client);           
        }
    }
}
