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
using System.Windows;

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
                    {
                        Console.Write("Введите емейл: ");
                        client.Email = Console.ReadLine();
                        Console.Write("Введите пароль: ");
                        client.Password = Console.ReadLine();
                        client = service.AuthClient(client);
                        if (client != null)
                        {
                            Console.Clear();
                            Console.WriteLine("Авторизация прошла успешно. Добро пожаловать {0}", client.ShortName);





                            Console.WriteLine("1. Отобразить счета");
                            Console.WriteLine("2. Содать счет");
                            
                            int ch = 0;
                            ch = Int32.Parse(Console.ReadLine());
                            ServiceAcount acc = 
                                new ServiceAcount(path);
                            acc.RegisterDeligeteEX(ShowMessage);
                            switch (ch)
                            {
                                case 1:
                                    {
                                        foreach (var item in acc.GetClientAcount(client.Id))
                                        {
                                            Console.WriteLine("-> {0}\t{1}", item.Number, item.Balance);
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;

                case "Регистрация":
                    {
                        Console.Write("Введите емейл: ");
                        client.Email = Console.ReadLine();
                        Console.Write("Введите пароль: ");
                        client.Password = Console.ReadLine();
                        Console.Write("Введите ФИО:");
                        client.FName = Console.ReadLine();
                        client.MName = Console.ReadLine();
                        client.SName = Console.ReadLine();


                        Gender gender;
                        for (gender = Gender.Female; gender <= Gender.Male; gender++)
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
                    }
                    break;

                case "Выход":
                    Console.WriteLine("Завершение процесса.");
                    break;
            }

            Console.ReadKey();
        }

        public static void ShowMessage(bool isError, string Message)
        {
            MessageBox.Show(Message, "Возникла ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
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
