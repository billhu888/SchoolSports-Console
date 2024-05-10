using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice20240304
{
    public class StudentController
    {
        public void ReadOneStudentAction(int id)
        {
            // sModel is empty and id is used to fill in sModel's fields
            StudentModel sModel = new StudentModel();
            StudentRepo sRepo = new StudentRepo();

            if (sRepo.ReadOneStudent(sModel, id))
            {
                sRepo.Display(sModel);
            }
            else
            {
                Console.WriteLine("Reading data failed");
            }
        }

        public void AddNewStudentAction()
        {
            StudentModel sModel = new StudentModel();
            StudentRepo sRepo = new StudentRepo();

            // Create a new StudentModel and you fill in each value
            sModel.Student_ID = 1000029;
            sModel.First_Name = "Sarah";
            sModel.Middle_Name = "Eunbi";
            sModel.Last_Name = "Lee";
            sModel.Sex = "Female";
            sModel.Grade = "10";
            DateTime DateOfBirth = DateTime.Parse("2007-10-03");
            sModel.Date_of_Birth = DateOfBirth;

            if (sRepo.AddNew(sModel, sModel.Student_ID))
            {
                // This is to make sure it has been added
                ReadOneStudentAction(sModel.Student_ID);
            }
            else
            {
                Console.WriteLine("Adding data failed");
            }
        }

        public void UpdateAction(int id)
        {
            // Get and fill in the model of the existing student to update
            // Once model is filled in, update the necessary field(s)
            StudentModel sModel = new StudentModel();
            StudentRepo sRepo = new StudentRepo();

            // Shows what the student to be updateed currently looks like
            sRepo.ReadOneStudent(sModel, id);
            sRepo.Display(sModel);

            sModel.Grade = "11";
            DateTime DateOfBirth = DateTime.Parse("2006-11-18");
            sModel.Date_of_Birth = DateOfBirth;

            if (sRepo.Update(sModel, id))
            {
                ReadOneStudentAction(id);
            }
            else
            {
                Console.WriteLine("Updating data failed");
            }
        }

        public void DeleteAction(int id)
        {
            StudentModel sModel = new StudentModel();
            StudentRepo sRepo = new StudentRepo();

            if (sRepo.ReadOneStudent(sModel, id))
            {
                sRepo.Display(sModel);

                if (sRepo.Delete(id))
                {
                    ReadOneStudentAction(id);
                }
                else
                {
                    Console.WriteLine("Deleting data failed");
                }
            }
            else
            {
                Console.WriteLine("Reading data failed");
            }
        }
    }
}