using StadiumApp.Data;
using StadiumApp.Models;
using System;

namespace StadiumApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool check = true;
            StadiumData stadiumData = new StadiumData();
            do
            {
                Console.WriteLine("1.Stadium Elave et");
                Console.WriteLine("2.Stadiuma Bax ");
                Console.WriteLine("3.Id-ye gore Stadiuma bax");
                Console.WriteLine("4.Id-ye gore Stadiuma sil");
                Console.WriteLine("0.Proqrami bitir");

                string answer = Console.ReadLine();
                switch (answer)
                {

                    case "1":
                        Console.WriteLine("Zehmet olmasa adi daxil et");
                        string name = Console.ReadLine();
                        Console.WriteLine(" Zehmet olmasa saatliq pulu daxil et");
                        int hourlyPrice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Zehmet olmasa cpacity  daxil et");
                        int capacity = Convert.ToInt32(Console.ReadLine());

                        Stadions stadiums = new Stadions()
                        {

                            Name = name,
                            HourlyPrice = hourlyPrice,
                            Capacity = capacity
                        };
                        stadiumData.Add(stadiums);
                        break;

                    case "2":
                        foreach (var item in stadiumData.GetStadiums())
                        {
                            Console.WriteLine($"{item.Id} {item.Name}  {item.Capacity}  {item.HourlyPrice}");
                        }
                        break;


                    case "3":
                        Console.WriteLine("Id daxil et daxil et");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(stadiumData.GetStadiumsId(id).Name);
                        break;

                    case "4":
                        Console.WriteLine("Id daxil et daxil et");
                        int idDel = Convert.ToInt32(Console.ReadLine());
                        stadiumData.DeleteById(idDel);
                        break;
                    case "0":
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Verilmish secimlerden birini secin");
                        break;
                }

            } while (check);

        }
    }
    }
}
