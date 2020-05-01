using AbstractFactory.Factory;
using AbstractFactoryMethod.Manager;
using System;

namespace AbstractFactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var userManager = new UserManager(new Factory1());
            userManager.GetAll();
            Console.ReadKey();
        }
    }
}
