using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shallow Copy");
            Student student = new Student() { Id = 1, Name = "Cengizhan" };
            student.Information = new Information() { PhoneNumber = "55555555" };
            Console.WriteLine($"Id : {student.Id} Adı : {student.Name} Telefon Numarası: {student.Information.PhoneNumber}");

            Student student2 = (Student)student.Clone();
            student2.Id = 2;
            student2.Name = "Ünal";
            student2.Information.PhoneNumber = "33333333";
            Console.WriteLine($"Id : {student.Id} Adı : {student.Name} Telefon Numarası: {student.Information.PhoneNumber}");
            Console.WriteLine("--------------");

            Console.WriteLine("Deep Copy");


            Student student3 = new Student() { Id = 1, Name = "Cengizhan" };
            student3.Information = new Information() { PhoneNumber = "55555555" };
            Console.WriteLine($"Id : {student3.Id} Adı : {student3.Name} Telefon Numarası: {student3.Information.PhoneNumber}");

            Student student4 = student3.DeepClone();
            student4.Id = 2;
            student4.Name = "Ünal";
            student4.Information.PhoneNumber = "33333333";
            Console.WriteLine($"Id : {student3.Id} Adı : {student3.Name} Telefon Numarası: {student3.Information.PhoneNumber}");

            Console.ReadLine();
        }
    }

    [Serializable]
    class Student : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Information Information { get; set; }

        public object Clone()
        {
            //Shallow copy
            return base.MemberwiseClone();
        }

        //Deep Copy
        public Student DeepClone()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;
                return (Student)formatter.Deserialize(ms);
            }
        }
    }

    [Serializable]
    class Information
    {
        public string PhoneNumber { get; set; }
    }
}
