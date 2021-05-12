using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Automobile automobile = new Automobile();
            automobile.Produce("Unal Car");

            SunroofCar sunroofCar = new SunroofCar(automobile);
            sunroofCar.Produce("Sunroof");

            AdaptifCruiseControl adaptifCruiseControl = new AdaptifCruiseControl(automobile);
            adaptifCruiseControl.Produce("Adaptif Cruise Control");

            Console.ReadKey();
        }

        public abstract class Car
        {
            public abstract void Produce(string text);
        }

        public class Automobile : Car
        {
            public override void Produce(string text)
            {
                Console.WriteLine($"{text} üretildi.");
            }
        }

        public abstract class Dekorator : Car
        {
            protected Car _car;
            protected Dekorator(Car car)
            {
                _car = car;
            }
            public override void Produce(string text)
            {
                _car.Produce(text);
            }
        }

        public class SunroofCar : Dekorator
        {
            public SunroofCar(Car car) : base(car)
            {
                this._car = car;
            }

            public override void Produce(string text)
            {
                Console.WriteLine($"{text} eklendi.");
            }
        }

        public class AdaptifCruiseControl : Dekorator
        {
            public AdaptifCruiseControl(Car car) : base(car)
            {
                this._car = car;
            }

            public override void Produce(string text)
            {
                Console.WriteLine($"{text} eklendi.");
            }
        }
    }
}
