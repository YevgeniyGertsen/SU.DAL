using SU.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU.DAL
{
    public class ReturnResult<T> where T : class
    {
        public bool IsSeccess { get; set; } = true;
        public Exception Exception { get; set; }
        public T Data { get; set; }
        public List<T> ListData { get; set; }
    }
}
