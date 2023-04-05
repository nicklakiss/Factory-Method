using System.Numerics;
using System;
using System.Xml.Linq;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Напишите тип доставки: 1 - Воздушная 2 - Наземная 3 - Морская");
            if (int.TryParse(Console.ReadLine(), out int deliveryresult))
            {
                Transporter transporter = null;
                switch (deliveryresult)
                {
                    case 1:
                        transporter = new PlaneFactory();
                        break;
                    case 2:
                        transporter = new TruckFactory();
                        break;
                    case 3:
                        transporter = new ShipFactory();
                        break;
                    default:
                        Console.WriteLine("Ты грёбанный валенок, напиши число от 1 до 3");
                        break;
                }

                if (transporter is not null)
                {
                    Transport transport = transporter.GetTransport();
                    Console.WriteLine($"Транспорт создан: {transport.GetType().Name}");
                }
            }
            else
            {
                Console.WriteLine("Ты грёбанный валенок, напиши число от 1 до 3");
            }
        }

        abstract class Transport
        {
            public int MaxEnginePower { get; set; }
            public int LoadCapacity { get; set; }
            public int Maxspeed { get; set; }
            public string Type { get; set; }

            public Transport(int maxEnginePower, int loadCapacity, int maxspeed, string type)
            {
                MaxEnginePower = maxEnginePower;
                LoadCapacity = loadCapacity;
                Maxspeed = maxspeed;
                Type = type;
            }
        }

        abstract class Transporter
        {
            public abstract Transport GetTransport();
        }

        class Ship : Transport
        {
            public Ship(int maxEnginePower, int loadCapacity, int maxspeed, string type) : base(maxEnginePower, loadCapacity, maxspeed, type)
            {
                Console.WriteLine("Корабль создан");
            }
        }

        class Truck : Transport
        {
            public Truck(int maxEnginePower, int loadCapacity, int maxspeed, string type) : base(maxEnginePower, loadCapacity, maxspeed, type)
            {
                Console.WriteLine("Грузовик создан");
            }
        }

        class Plane : Transport
        {
            public Plane(int maxEnginePower, int loadCapacity, int maxspeed, string type) : base(maxEnginePower, loadCapacity, maxspeed, type)
            {
                Console.WriteLine("Самолет создан");
            }
        }

        class ShipFactory : Transporter
        {
            public override Transport GetTransport()
            {
                return new Ship(1000, 5000, 50, "Морская");
            }
        }

        class TruckFactory : Transporter
        {
            public override Transport GetTransport()
            {
                return new Truck(500, 1000, 90, "Наземная");
            }
        }

        class PlaneFactory : Transporter
        {
            public override Transport GetTransport()
            {
                return new Plane(2000, 1000, 700, "Воздушная");
            }
        }
    }
}
