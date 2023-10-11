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

namespace SU.BLL
{
    internal class ServiceAcount
    {
        private readonly string path = "";
        private Repository<Account> db = null;
        private ReturnResult<Account> result = null;
        private readonly IMapper _iMapper;


        public ServiceAcount(string path)
        {
            this.path = path;
            db = new Repository<Account>(path);
            result = new ReturnResult<Account>();
            _iMapper = SettingAutoMapper.Init().CreateMapper();
        }

        public List<AccountDTO> GetClientAcount(int ClientId)
        {
            result = db.GetAll();
            var data = result.ListData.Where(w=>w.ClientId == ClientId).ToList();

            return _iMapper.Map<List<AccountDTO>>(data);
        }

        public bool CreateAccount(AccountDTO account)
        {
            //collSomeMethod(account)
            result = db.Create(_iMapper.Map<Account>(account));
            return result.IsSeccess;
        }
    }
}
