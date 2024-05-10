using C_Practice20240304;
using CSharpPractice20240304;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice20240304
{
    public class MultipleStudentsController
    {
        public void ReadMultipleStudentsAction()
        {
            MultipleStudentsModel mStudentsModel = new MultipleStudentsModel();
            MultipleStudentsRepo mStudentsRepo = new MultipleStudentsRepo();

            mStudentsModel.StudentsList = new List<StudentModel>();

            Console.WriteLine("Enter First Name (optional, press Enter to skip): ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name (press Enter to skip): ");
            string lastName = Console.ReadLine();

            if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("Last Name is required.");
            }
            else
            {
                mStudentsRepo.ReadMultipleStudents(mStudentsModel.StudentsList, firstName, lastName);
                mStudentsRepo.Display(mStudentsModel.StudentsList);
            }
        }
    }
}