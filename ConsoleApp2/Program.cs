using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            //default constructor
            //Student student = new Student(); 
            //Student student10 = new Student();
            //Student student20 = new Student();
            //Student student30 = new Student();

            //overloaded constructor
            //Student student1 = new Student("John", "Doe");
            //Console.WriteLine(student1.GetFullName());

            Person Person1 = new Person();
            Person1.Name = "John1";
            Console.WriteLine(Person1.Name);
            Person1.Age = 15;
            Console.WriteLine(Person1.Age);

            //Person Person2 = new Person();
            //Person2.Name = "Mike";
            //Console.WriteLine(Person2.Name);

            Person Person3 = new Person("John", 14);
            Console.WriteLine(Person3.Name);
            Console.WriteLine(Person3.Age);
            Person3.Name = "David";
            Person3.Age = 16;
            Console.WriteLine(Person3.Name);
            Console.WriteLine(Person3.Age);
        }
    }
}
