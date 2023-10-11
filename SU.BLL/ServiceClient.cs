﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SU.BLL.Model;
using SU.DAL;
using SU.DAL.Model;

namespace SU.BLL
{
    public class ServiceClient
    {
        private readonly string path = "";
        private Repository<Client> repo = null;
        private ReturnResult<Client> result = null;
        private readonly IMapper _iMapper;
        public ServiceClient(string path)
        {
            this.path = path;
            repo = new Repository<Client>(path);
            result = new ReturnResult<Client>();
            _iMapper= SettingAutoMapper.Init().CreateMapper();
        }

        public (string message, bool result) RegisterClient(ClientDTO client)
        {
            var result = repo.Create(_iMapper.Map<Client>(client));
           
            if (result.IsSeccess == true)
                return ("", true);
            else 
                return ("Возникла ошибка", false);
        }

        public (string message, bool result) AuthClient(ClientDTO client)
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
