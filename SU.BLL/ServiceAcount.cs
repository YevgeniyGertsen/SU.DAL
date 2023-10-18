using SU.DAL.Model;
using SU.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SU.DAL.Model;
using AutoMapper;
using SU.BLL.Model;
using SU.DAL.Interfaces;

namespace SU.BLL
{
    internal class ServiceAcount :Service<Account>
    {
        public ServiceAcount(string path):base(path)
        {
          
        }

        public List<AccountDTO> GetClientAcount(int ClientId)
        {
            result = repo.GetAll();
            var data = result.ListData.Where(w=>w.ClientId == ClientId).ToList();

            return _iMapper.Map<List<AccountDTO>>(data);
        }

        public bool CreateAccount(AccountDTO account)
        {
            //collSomeMethod(account)
            result = repo.Create(_iMapper.Map<Account>(account));
            return result.IsSeccess;
        }
    }
}
