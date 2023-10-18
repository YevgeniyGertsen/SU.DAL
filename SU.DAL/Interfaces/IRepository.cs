using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        ReturnResult<T> GetAll();
        ReturnResult<T> Get(int Id);
        ReturnResult<T> Create(T data);
        ReturnResult<T> Delete(int Id);
        ReturnResult<T> Update(T data);
    }
}
