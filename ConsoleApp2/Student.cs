using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    public class Student
    {
        private int _id;            // field
        private string _name;       // field
        private string _lastName;   // field

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name;  }
            set { _name = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value ; }
        }

        public Student(int id, string name, string lastName)
        {
            _id = id;
            _name = name;
            _lastName = lastName;
        }

        public string GetFullName()
        {
            return _name + ' ' + _lastName;
        }
    }
}
