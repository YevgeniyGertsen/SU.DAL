using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SU.BLL.Model;
using SU.DAL.Model;

namespace SU.BLL
{
    public static class SettingAutoMapper
    {
        public static MapperConfiguration Init()
        {
            return new MapperConfiguration(cfg=>
            {
                cfg.CreateMap<Client, ClientDTO>()
                .ReverseMap();
            });
        }
    }
}
