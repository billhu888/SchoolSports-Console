using CSharpPractice20240304;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Practice20240304
{
    public class StudentsSportsParticipationController
    {
        public void ReadStudentsSportsParticipationAction()
        {
            StudentsSportsParticipationModel studentssportsparticipationmodel = new StudentsSportsParticipationModel();
            StudentsSportsParticipationRepo studentssportsparticipationrepo = new StudentsSportsParticipationRepo();

            studentssportsparticipationmodel.studentmodel = new StudentModel();
            studentssportsparticipationmodel.listsportmodel = new List<SportModel>();
            studentssportsparticipationmodel.listlibrarymodel = new List<LibraryModel>();

            Console.WriteLine("Enter Student ID (Required): ");
            string sID = Console.ReadLine();
            int studentID = Convert.ToInt32(sID);

            studentssportsparticipationrepo.ReadStudentSports(studentssportsparticipationmodel.studentmodel, studentssportsparticipationmodel.listsportmodel, studentID);
            studentssportsparticipationrepo.DisplayStudentSports(studentssportsparticipationmodel.studentmodel, studentssportsparticipationmodel.listsportmodel);

            studentssportsparticipationrepo.ReadStudentLibraries(studentssportsparticipationmodel.studentmodel, studentssportsparticipationmodel.listlibrarymodel, studentID);
            studentssportsparticipationrepo.DisplayStudentLibraries(studentssportsparticipationmodel.studentmodel, studentssportsparticipationmodel.listlibrarymodel);
        }
    }
}