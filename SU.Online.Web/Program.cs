using SU.BLL;
using SU.BLL.Enums;
using SU.BLL.Model;
using SU.DAL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SU.Online.Web
{
    internal class Program
    {
        static string path = ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString;

        static void Main(string[] args)
        {
            Console.WriteLine("Введите действие, которое вы хотите выполнить (Авторизация, Регистрация, Выход:");
            string input = Console.ReadLine();

            ServiceClient service = new ServiceClient(path);
            ClientDTO client = new ClientDTO();

            switch (input)
            {
                case "Авторизация":
                    Console.Write("Введите емейл: ");
                    client.Email = Console.ReadLine();
                    Console.Write("Введите пароль: ");
                    client.Password = Console.ReadLine();
                    if (service.AuthClient(client).result)
                    {
                        Console.Clear();
                        Console.WriteLine("Авторизация прошла успешно. Добро пожаловать {0}", client.ShortName);
                    }

                    break;

                case "Регистрация":
                    Console.Write("Введите емейл: ");
                    client.Email = Console.ReadLine();
                    Console.Write("Введите пароль: ");
                    client.Password = Console.ReadLine();
                    Console.Write("Введите ФИО:");
                    client.FName = Console.ReadLine();
                    client.MName = Console.ReadLine();
                    client.SName = Console.ReadLine();


                    Gender gender;
  for (gender = Gender.Female; gender <=Gender.Male; gender++)
                    {
                        Console.WriteLine("{0}. {1}",
                            (int)gender, gender);
                    }

                    Console.Write(": ");
                    string chGender = Console.ReadLine();

                    if (Enum.IsDefined(typeof(Gender), chGender))
                    {
                        client.Gender =
                            (Gender)Enum.Parse(typeof(Gender), chGender);
                    }
                    else
                    {
                        Console.WriteLine("Укаэите корректно пол");
                    }

                     service.RegisterClient(client);
                    break;

                case "Выход":
                    Console.WriteLine("Завершение процесса.");
                    break;
            }

            Console.ReadKey();
        }
    }

    public class Money
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public decimal Amount { get; set; }
        public int Unit { get; set; }

        public static explicit operator Account(Money m)
        {
            return new Account() { Id = 0 };
        }
        public static implicit operator decimal(Money m)
        {
            return m.Amount;
        }


        public Money(decimal Amount, int Unit)
        {
            this.Amount = Amount;
            this.Unit = Unit;
        }

        public static Money operator +(Money a, Money b)
        {
            return new Money(a.Amount + b.Amount, a.Unit);
        }

        public static bool operator true(Money a)
        {
            return a.Amount > 0;
        }

        public static bool operator false(Money a)
        {
            return a.Amount > 0;
        }
    }
}
