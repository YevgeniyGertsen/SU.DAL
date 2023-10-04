using SU.DAL.Model;
using SU.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SU.DAL.Model;

namespace SU.BLL
{
    internal class ServiceAcount
    {
        private readonly string path = "";
        private Repository<Account> db = null;
        private ReturnResult<Account> result = null;

        public ServiceAcount(string path)
        {
            this.path = path;
            db = new Repository<Acount>(path);
            result = new ReturnResult<Acount>();

        }

        public List<Account> GetClientAcount(int ClientId)
        {
            result = db.GetAll();
            return result.ListData.Where(w=>w.ClientId == ClientId).ToList();
        }
        public bool CreateAccount(Account account)
        {
            result = db.Create(account);
            return result.IsSeccess;

        }
    }
}
