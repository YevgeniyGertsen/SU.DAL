using SU.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU.DAL
{
    public class RepositorySQL<T> : IRepository<T>
         where T : class
    {
        public RepositorySQL(string path)
        {
            
        }
        ///TODO
        public ReturnResult<T> Create(T data)
        {
            throw new NotImplementedException();
        }

        public ReturnResult<T> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public ReturnResult<T> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public ReturnResult<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public ReturnResult<T> Update(T data)
        {
            throw new NotImplementedException();
        }
    }
}
