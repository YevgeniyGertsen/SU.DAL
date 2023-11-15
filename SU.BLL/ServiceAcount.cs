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
    public class ServiceAcount :Service<Account>
    {
        public ServiceAcount(string path):base(path)
        {
          
        }


        public List<AccountDTO> GetClientAcount(int ClientId)
        {
            result = repo.GetAll();
            var data = result.ListData.Where(w => w.ClientId == ClientId).ToList();

            if (deleteEx != null)
            {
                deleteEx(result.IsSeccess, "Error");
            }

            return _iMapper.Map<List<AccountDTO>>(data);
        }

        public bool CreateAccount(AccountDTO account)
        {
            result = repo.Create(_iMapper.Map<Account>(account));

            if (result.IsSeccess == false && deleteEx != null)
            {
                deleteEx(result.IsSeccess, result?.Exception.Message);
            }
            else
            {
                deleteEx(result.IsSeccess,
                    "Сет успешно создался");
            }


                
            

            //if (result.Exception != null)
            //    return result.Exception.Message;
            //else
            //    return "";




            return result.IsSeccess;
        }
    }
}
