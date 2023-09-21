using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU.DAL.Model
{
    public class Client
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public string FName { get; set; }
        public string SName { get; set; }
        public string MName { get; set; }

        /// <summary>
        /// Свойство возвращает сокращенное ФИО
        /// </summary>
        public string ShortName
        {
            get
            {
                //Герцен Е.А.
                if (string.IsNullOrWhiteSpace(MName))
                    return string.Format("{0} {1}.",
                   FName, SName[0]);
                else
                    return string.Format("{0} {1}. {2}.",
                        FName, SName[0], MName[0]);
            }
        }

        public DateTime Dob { get; set; }
        public int Age
        {
            get
            {
                return (DateTime.Now.Year - Dob.Year);
            }
        }

        public string Iin { get; set; }
        public string PathPhoto { get; set; }
        public string  PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SecretWord { get; set; }

        public List<Address> Addreses { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
