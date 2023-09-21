using SU.BLL;
using SU.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SU.Online.Web
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Email = "gersen.e.a@gmail.com";
            client.Password = "123";
            client.FName = "Yevgeniy";
            client.SName = "Gertsen";
            

            ServiceClient service = new ServiceClient();
            service.RegisterClient(client);
        }
    }
}
