using LiteDB;
using SU.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU.DAL
{
    //Repository<Client> repo = new Repository<Client>();
    public class Repository<T> where T : class
    {
        public T obj = default(T);

        private readonly string path = "";
        private ReturnResult<T> result = null;
        public Repository(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("Путь к БД должен быть заполнен");

            this.path = path;
            result = new ReturnResult<T>();
        }

        public ReturnResult<T> GetAll()
        {
            try
            {
                using (var db = new LiteDatabase(path))
                {
                    result.ListData = db.GetCollection<T>
                         (typeof(T).Name)
                        .FindAll().ToList();
                }
            }
            catch (LiteException ex)
               when (string.IsNullOrWhiteSpace(path))
            {
                result.IsSeccess = false;
                result.Exception = ex;
            }
            catch (Exception ex)
            {
                result.IsSeccess = false;
                result.Exception = ex;
            }

            return result;
        }

        public ReturnResult<T> Get(int Id)
        {
            try
            {
                using (var db = new LiteDatabase(path))
                {
                    result.Data = db.GetCollection<T>
                        (typeof(T).Name)
                        .FindById(Id);
                }
            }
            catch (Exception ex)
            {
                result.IsSeccess = false;
                result.Exception = ex;
            }

            return result;
        }

        public ReturnResult<T> Create(T data)
        {
            try
            {
                if (data == null)
                    throw new Exception("Модель клиента пустая");

                using (var db = new LiteDatabase(path))
                {
                    var clients = db.GetCollection<T>
                        (typeof(T).Name);
                    clients.Insert(data);
                }
            }
            catch (Exception ex)
            {
                result.IsSeccess = false;
                result.Exception = ex;
            }


            return result;
        }

        public ReturnResult<T> Delete(int Id)
        {
            try
            {
                using (var db = new LiteDatabase(path))
                {
                    var clients = db.GetCollection<T>
                        (typeof(T).Name);
                    clients.Delete(Id);
                }
            }
            catch (Exception ex)
            {
                result.IsSeccess = false;
                result.Exception = ex;
            }


            return result;
        }

        public ReturnResult<T> Update(T data)
        {
            try
            {
                if (data == null)
                    throw new Exception("Модель клиента пустая");

                using (var db = new LiteDatabase(path))
                {
                    var clients = db.GetCollection<T>
                        (typeof(T).Name);
                    clients.Update(data);
                }
            }
            catch (Exception ex)
            {
                result.IsSeccess = false;
                result.Exception = ex;
            }


            return result;
        }
    }
}
