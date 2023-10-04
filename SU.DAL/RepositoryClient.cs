
using SU.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using System.CodeDom;

namespace SU.DAL
{
    public class RepositoryClient
    {
        private readonly string path="";
        public RepositoryClient(string path)
        {
            if(string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("Путь к БД должен быть заполнен");

            this.path = path;
        }

        /// <summary>
        /// Метод котррый возвращает список клиентов
        /// </summary>
        /// <returns></returns>
        public ReturnResultClient GetAllClients()
        {
            ReturnResultClient result = new ReturnResultClient();

            try
            {
                using (var db = new LiteDatabase(path))
                {
                    result.Clients = db.GetCollection<Client>("Client").FindAll().ToList();
                }
            }
            catch (LiteException ex)
               when(string.IsNullOrWhiteSpace(path))
            {
                result.IsSeccess = false;
                result.Exception = ex;
            }
            catch (Exception ex)
            {
                result.IsSeccess = false;
                result.Exception = ex;
            }          

            return result;
        }

        public ReturnResultClient GetClient(int Id)
        {
            ReturnResultClient result = new ReturnResultClient();

            try
            {
                using (var db = new LiteDatabase(path))
                {
                    result.Client = db.GetCollection<Client>("Client")
                        .FindById(Id);
                }

            }
            catch (Exception ex)
            {
                result.IsSeccess = false;
                result.Exception = ex;
            }

            return result;
        }

        public ReturnResultClient GetClient(string Email, string Password)
        {
            ReturnResultClient result = new ReturnResultClient();

            try
            {
                using (LiteDatabase db = new LiteDatabase(path))
                {
                    result.Clients = db.GetCollection<Client>().FindAll().ToList();

                    result.Client = result.Clients.First(f => f.Email == Email & f.Password == Password);

                }
            }
            catch (Exception ex) {
                result.IsSeccess = false;
                result.Exception = ex;
            }
            return result;
        }
        public ReturnResultClient CreateClient(Client client)
        {
            ReturnResultClient result = new ReturnResultClient();

            try
            {
                if (client == null)
                    throw new Exception("Модель клиента пустая");

                using (var db = new LiteDatabase(path))
                {
                    var clients = db.GetCollection<Client>("Client");
                    clients.Insert(client);
                }

            }
            catch (Exception ex)
            {
                result.IsSeccess = false;
                result.Exception = ex;
            }


            return result;
        }
    }
}