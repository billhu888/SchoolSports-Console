using CSharpPractice20240304;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Practice20240304
{
    class MultipleStudentsRepo : BaseRepo
    {
        public bool ReadMultipleStudents(List<StudentModel> StudentsList, string firstName, string lastName)
        {
            bool success = false;

            try
            {
                if (Connect())
                {
                    string sql =
                       $" SELECT * " +
                       $" FROM Students ";

                    if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName)) 
                    {
                        sql = sql;
                    }
                    else if  (string.IsNullOrEmpty(firstName))
                    {
                        sql = sql + $" WHERE Last_Name = '{lastName}'";
                    }
                    else
                    {
                        sql = sql + $" WHERE First_Name = '{firstName}' AND Last_Name = '{lastName}'";
                    }

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            StudentModel StudentModel = new StudentModel
                            {
                                Student_ID = Convert.ToInt32(row[StudentModel.fStudent_ID]),
                                First_Name = row[StudentModel.fFirst_Name].ToString(),
                                Middle_Name = row[StudentModel.fMiddle_Name].ToString(),
                                Last_Name = row[StudentModel.fLast_Name].ToString(),
                                Sex = row[StudentModel.fSex].ToString(),
                                Grade = row[StudentModel.fGrade].ToString(),
                                Date_of_Birth = Convert.ToDateTime(row[StudentModel.fDate_of_Birth]),
                                Age = Convert.ToInt32(row[StudentModel.fAge])
                            };

                            StudentsList.Add(StudentModel);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }

                    success = true;
                }
                else
                {
                    Console.WriteLine("Failed to connect to database");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return success;
        }

        public bool Display(List<StudentModel> MultipleStudentsModel)
        {
            bool success = false;

            try
            {
                foreach (var row in MultipleStudentsModel)
                {
                    Console.WriteLine(
                        row.Student_ID + ", " +
                        row.First_Name + ", " +
                        row.Middle_Name + ", " +
                        row.Last_Name + ", " +
                        row.Sex + ", " +
                        row.Grade + ", " +
                        row.Date_of_Birth + ", " +
                        row.Age
                    );
                }    

                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return success;
        }

        ~MultipleStudentsRepo()
        {
            Disconnect();
        }
    }
}