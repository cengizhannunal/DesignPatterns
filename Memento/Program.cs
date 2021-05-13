using System;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            CareTaker careTaker = new CareTaker();
            User user = new User()
            {
                IdentityNumber = "111111111",
                Name = "Cengizhan"
            };

            Console.WriteLine(user.ToString());

            careTaker.Memento = user.Save();

            user.IdentityNumber = "222222222";
            user.Name = "Ünal";

            Console.WriteLine(user.ToString());

            user.Restore(careTaker.Memento);

            Console.WriteLine(user.ToString());
            Console.ReadLine();
        }
    }

    //Originator
    class User
    {
        public string IdentityNumber { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Identity Number: {IdentityNumber} Name: {Name}";
        }

        public UserMemento Save()
        {
            return new UserMemento()
            {
                IdentityNumber = this.IdentityNumber,
                Name = this.Name
            };
        }

        public void Restore(UserMemento userMemento)
        {
            this.IdentityNumber = userMemento.IdentityNumber;
            this.Name = userMemento.Name;
        }
    }

    //Memonto
    class UserMemento
    {
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
    }


    //CareTake
    class CareTaker
    {
        public UserMemento Memento { get; set; }
    }
}
