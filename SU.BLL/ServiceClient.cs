
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SU.DAL;
using SU.DAL.Model;

namespace SU.BLL
{
    public class ServiceClient
    {
        private readonly string path = "";
        public ServiceClient(string path)
        {
            this.path = path;
        }

        public (string message, bool result) RegisterClient(Client client)
        {
            RepositoryClient repository = new RepositoryClient(path);

            var result = repository.CreateClient(client);
           
            if (result.IsSeccess == true)
                return ("", true);
            else 
                return ("Возникла ошибка", false);
        }

        public (string message, bool result) AuthClient(Client client)
        {
            RepositoryClient rep = new RepositoryClient(path);

            ReturnResultClient result = rep.GetClient(client.Email, client.Password);
            client = result.Client;
            if (result.IsSeccess == true)
            {
                return ("", true);
            }
            else
            {
                return (result?.Exception.Message, result.IsSeccess);
            }
        }
    }
}
