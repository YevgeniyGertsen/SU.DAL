
using SU.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace SU.DAL
{
    public class RepositoryClient
    {
        /// <summary>
        /// Метод котррый возвращает список клиентов
        /// </summary>
        /// <returns></returns>
        public List<Client> GetAllClients()
        {
            List<Client> clients = null;

            using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
            {
                clients = db.GetCollection<Client>("Client")
                    .FindAll()
                    .ToList();
            }

            return clients;
        }

        public Client GetClient(int Id)
        {
            Client client = null;
            using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
            {
                client = db.GetCollection<Client>("Client")
                    .FindById(Id);
            }
            return client;
        }

        public bool CreateClient(Client client)
        {
            using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
            {
                var clients = db.GetCollection<Client>("Client");
                clients.Insert(client);
            }

            return true;
        }
    }
}