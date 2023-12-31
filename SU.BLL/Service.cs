﻿using AutoMapper;
using SU.DAL.Interfaces;
using SU.DAL.Model;
using SU.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU.BLL
{
    public delegate void DeleteEx(bool IsError, string Message);

    public abstract class Service<T> where T : class
    {
        protected readonly string path = "";
        protected IRepository<T> repo = null;
        protected ReturnResult<T> result = null;
        protected readonly IMapper _iMapper;

        protected DeleteEx deleteEx = null;

        public Service(string path)
        {
            this.path = path;
            repo = new Repository<T>(path);
            result = new ReturnResult<T>();
            _iMapper = SettingAutoMapper.Init().CreateMapper();
        }

        public virtual void RegisterDeligeteEX(DeleteEx deleteEx)
        {
            this.deleteEx = deleteEx;
        }
    }
}
