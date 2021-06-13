using System;
using System.Collections.Generic;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            CarGenerator carGenerator = new CarGenerator();

            carGenerator.GenerateCar("Toyota");
            carGenerator.GenerateCar("Honda");
            carGenerator.GenerateCar("Toyota");
            carGenerator.GenerateCar("Honda");

            Console.ReadLine();
        }
    }

    class Car
    {
        public string Name { get; set; }
        public Car(string name)
        {
            Name = name;
            Console.WriteLine(name + " üretimi tamamlandı.");
        }
    }

    class CarGenerator
    {
        readonly Dictionary<string, Car> Cars = new Dictionary<string, Car>();

        public Car GenerateCar(string carName)
        {
            if (!Cars.ContainsKey(carName))
            {
                Car car = new Car(carName);
                Cars.Add(carName, car);
            }

            return Cars[carName];
        }
    }
}
