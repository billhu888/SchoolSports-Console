using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Person
    {

        // private string name;  // field

        public string Name    // property
        {
            get;
            //{ return name; }

            set; 
            //{ name = value; }
        }

        public int Age
        {
            get;
            set;
        }

        public Person()
        {

        }

        public Person(string firstname, int age)
        {
            // name = "Mike";
            Name = firstname;
            Age = age;
        }
    }
}