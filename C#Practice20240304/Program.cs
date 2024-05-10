using C_Practice20240304;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice20240304
{
    class Program
    {
        static void Main(string[] args)
        {
            //StudentModel sModel1 = new StudentModel();
            //StudentRepo s1 = new StudentRepo();
            //s1.ReadOneStudent(sModel1, 1000022);
            //s1.ReadOneStudent(1000022);
            //s1.Display(sModel1);

            //StudentController sA1 = new StudentController();
            //sA1.ReadOneStudentAction(1000022);

            //StudentController sA2 = new StudentController();
            //sA2.AddNewStudentAction();

            //StudentController sA3 = new StudentController();
            //sA3.UpdateAction(1000028);

            //StudentController sA4 = new StudentController();
            //sA4.DeleteAction(1000029);

            //StudentRepo s2 = new StudentRepo();
            //StudentModel sModel2 = s2.ReadOneStudent(1000022);
            //s2.Display(sModel2);

            //Student s2 = new Student();
            //s2.ReadOneStudent(1000025);
            //s2.Display();
            //s2.First_Name = "Beverly";
            //s2.Update2();
            //s2.Display();

            //Student s3 = new Student();
            //s3.ReadOneStudent(2);
            //s3.Display();
            //s3.Delete();
            //s3.Display();

            //Student s4 = new Student();
            //s4.Student_ID = 1000027;
            //s4.First_Name = "Sarah";
            //s4.Middle_Name = "Eunbi";
            //s4.Last_Name = "Lee";
            //s4.Sex = "Female";
            //s4.Grade = "10";
            //DateTime DateOfBirth = DateTime.Parse("2007-10-03");
            //s4.Date_of_Birth = DateOfBirth;
            //s4.AddNew2();
            //s4.ReadOneStudent(1000027);
            //s4.Display();
            //Console.WriteLine("Add done");
            //s4.Delete();
            //Console.WriteLine("Delete done");
            //s4.ReadOneStudent(1000027);
            //// This still prints because the variable values are still there
            //s4.Display();

            //MultipleStudentsController mStudentsController = new MultipleStudentsController();
            //mStudentsController.ReadMultipleStudentsAction();



            SportController sController1 = new SportController();
            sController1.ReadSportAction(102);

            //SportController sController2 = new SportController();
            //sController2.AddNewSportAction();

            //SportController sController3 = new SportController();
            //sController3.DeleteSportAction(112);

            //SportController sController4 = new SportController();
            //sController4.UpdateSportAction(112);

            //MultipleSportsController msController1 = new MultipleSportsController();
            //msController1.ReadMultipleSportsAction();



            //StudentsSportsParticipationController ssController = new StudentsSportsParticipationController();
            //ssController.ReadStudentsSportsParticipationAction();



            //LibraryController lConroller1 = new LibraryController();
            //lConroller1.ReadLibraryAction(10009);

            //LibraryController lConroller2 = new LibraryController();
            //lConroller2.AddNewLibraryAction();

            //LibraryController lConroller3 = new LibraryController();
            //lConroller3.UpdateLibraryAction(10010);

            //LibraryController lConroller4 = new LibraryController();
            //lConroller4.DeleteLibraryAction(10010);

            //MultipleLibraryController mlController = new MultipleLibraryController();
            //mlController.ReadMultipleLibrary();
        }
    }
}