using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU.DAL.Model
{
    public class Account
    {
        public Account() :this(0)
        {
            
        }        
        public Account(int Id) :this(Id, DateTime.Now)
        {
           
        }
        public Account(int Id, DateTime CreateDate)
            :this(Id, CreateDate, 0)
        {
           
        }
        public Account(int Id, DateTime CreateDate, double Balance)
        {
            this.Id = Id;
            this.CreateDate = CreateDate;
            this.Balance = Balance;
        }

        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        
        //account.Balance = 56; 
        //var temp = account.Balance;
        private double _balance = 0;
        public double Balance
        {
            get
            {
                return _balance;
            }
            set//(double value)
            {
                if (value < 0)
                    _balance = 0;
                else
                    _balance = value;
            }
        }

        public string Number { get; set; }
        public DateTime ExpireDate { get; set; }
        public int AccountType { get; set; }
        public int Currency { get; set; }//398
    }
}
