using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpPractice20240304;
using System.Transactions;

namespace C_Practice20240304
{
    class StudentsSportsParticipationRepo : BaseRepo
    {
        public bool ReadStudentSports(StudentModel studentmodel, List<SportModel> studentsportslist, int studentID)
        {
            try
            {
                String sql =
                    $" SELECT Students.Student_ID, Students.First_Name, Students.Middle_Name, Students.Last_Name, " +
                    $" Students.Sex, Students.Grade, Sports.Sport_Gender, Sports.Sport_Name, Sports.Sport_Season " +
                    $" FROM Students " +
                    $" INNER JOIN Sports_Participation ON Students.Student_ID = Sports_Participation.Student_ID " +
                    $" INNER JOIN Sports ON Sports_Participation.Sport_ID = Sports.Sport_ID " +
                    $" WHERE Students.Student_ID = {studentID} ";

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    SportModel studentsportmodel;

                    foreach (DataRow row in dt.Rows)
                    {
                        studentsportmodel = new SportModel()
                        {
                            Sport_Gender = (string)row[SportModel.fSport_Gender],
                            Sport_Name = (string)row[SportModel.fSport_Name],
                            Sport_Season = (string)row[SportModel.fSport_Season],
                        };

                        studentsportslist.Add(studentsportmodel);
                    }

                    DataRow row1 = dt.Rows[0];

                    studentmodel.Student_ID = (int)row1[StudentModel.fStudent_ID];
                    studentmodel.First_Name = (string)row1[StudentModel.fFirst_Name];
                    studentmodel.Middle_Name = (string)row1[StudentModel.fMiddle_Name];
                    studentmodel.Last_Name = (string)row1[StudentModel.fLast_Name];
                    studentmodel.Sex = (string)row1[StudentModel.fSex];
                    studentmodel.Grade = (string)row1[StudentModel.fGrade];

                    return true;
                }
                else
                {
                    Console.WriteLine("No student sports participation records found");

                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read students sports participation for " + e);

                return false;
            }
        }

        public bool DisplayStudentSports(StudentModel studentmodel, List<SportModel> studentsportslist)
        {
            bool success = false;

            try
            {
                Console.WriteLine(
                    $" Display school sports for ID: {studentmodel.Student_ID}, " +
                    $" Name: {studentmodel.First_Name} {studentmodel.Middle_Name} {studentmodel.Last_Name}, " +
                    $" Sex: {studentmodel.Sex}, " +
                    $" Grade: {studentmodel.Grade}");

                foreach (var row in studentsportslist)
                {
                    Console.WriteLine(
                        $"{row.Sport_Gender}, " +
                        $"{row.Sport_Name}, " +
                        $"{row.Sport_Season}"
                    );
                }

                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read students sports participation for " + e);
            }

            return success;
        }

        public bool ReadStudentLibraries(StudentModel studentmodel, List<LibraryModel> studentlibrarieslist, int studentID)
        {
            bool success = false;

            try
            {
                String sql = 
                    $" SELECT Students.Student_ID, Students.First_Name, Students.Middle_Name, " +
                    $" Students.Last_Name, Students.Sex, Students.Grade," +
                    $" Library_Books.Book_ID, Library_Books.Book_Title, Library_Books.Book_Authur " +
                    $" FROM Students " +
                    $" INNER JOIN Library_Books on Students.Student_ID = Library_Books.Student_ID_Checked_Out " +
                    $" WHERE Students.Student_ID = {studentID}";

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        LibraryModel librarymodel;

                        librarymodel = new LibraryModel()
                        {
                            Book_Id = (int)row[LibraryModel.fBook_Id],
                            Book_Title = (string)row[LibraryModel.fBook_Title],
                            Book_Author = (string)row[LibraryModel.fBook_Author]
                        };

                        studentlibrarieslist.Add(librarymodel);
                    }

                    DataRow row1 = dt.Rows[0];

                    studentmodel.Student_ID = (int)row1[StudentModel.fStudent_ID];
                    studentmodel.First_Name = (string)row1[StudentModel.fFirst_Name];
                    studentmodel.Middle_Name = (string)row1[StudentModel.fMiddle_Name];
                    studentmodel.Last_Name = (string)row1[StudentModel.fLast_Name];
                    studentmodel.Sex = (string)row1[StudentModel.fSex];
                    studentmodel.Grade = (string)row1[StudentModel.fGrade];

                    success = true;
                }
                else
                {
                    Console.WriteLine("Failed to read student's library book(s) checked out");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read students library for " + e);
            }

            return success;
        }

        public bool DisplayStudentLibraries(StudentModel studentmodel, List<LibraryModel> studentlibrarieslist)
        {
            bool success = false;

            try
            {
                Console.WriteLine(
                    $" Display library books checked out for Student ID: {studentmodel.Student_ID}, " +
                    $" {studentmodel.First_Name} {studentmodel.Middle_Name} {studentmodel.Last_Name}, " +
                    $" {studentmodel.Sex}, " +
                    $" {studentmodel.Grade} "
                    );

                foreach (var row in studentlibrarieslist)
                {
                    Console.WriteLine(
                        $" {row.Book_Id}, " +
                        $" {row.Book_Title}, " +
                        $" {row.Book_Author} "
                    );
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to retrieve library books checked out for " + e);
            }

            return success;
        }
    }
}