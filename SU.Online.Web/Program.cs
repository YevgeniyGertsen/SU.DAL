using SU.BLL;
using SU.DAL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
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
            Client client = new Client();

            switch(input)
            {
                case "Авторизация":
                    Console.Write("Введите емейл: ");
                    client.Email = Console.ReadLine();
                    Console.Write("Введите пароль: ");
                    client.Password = Console.ReadLine();
                    if(service.AuthClient(client).result)
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
                    service.RegisterClient(client);
                    break;

                case "Выход":
                    Console.WriteLine("Завершение процесса.");
                    break;
            }

            Console.ReadKey();  
        }
    }
}
