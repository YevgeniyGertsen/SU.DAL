
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
        private Repository<Client> repo = null;
        private ReturnResult<Client> result = null;
        public ServiceClient(string path)
        {
            this.path = path;
            repo = new Repository<Client>(path);
            result = new ReturnResult<Client>();
        }

        public (string message, bool result) RegisterClient(Client client)
        {
            var result = repo.Create(client);
           
            if (result.IsSeccess == true)
                return ("", true);
            else 
                return ("Возникла ошибка", false);
        }

        public (string message, bool result) AuthClient(Client client)
        {

            var clients = repo.GetAll().ListData;
            result.Data = clients
                .FirstOrDefault(f => f.Email == client.Email
                && f.Password == client.Password);

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
