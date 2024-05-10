using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Data.Common;
using System.Diagnostics;

namespace CSharpPractice20240304
{
    class StudentRepo : BaseRepo
    {
        public bool ReadOneStudent(StudentModel studentModel, int id)
        {
            bool success = false;

            try
            {
                if (Connect())
                {
                    // Allows you to store the data retrieved from the SQL database in regular table format (right now is empty regular table) 
                    DataTable dt = new DataTable();

                    // Will allow you to later execute SQL command to retrieve SQL database data and then use it to fill DataTable with SQL results
                    // Results will be in SQL table format
                    // Think of the name (SqlDataAdapter) as a table that will adapt the SQL data in SQL data table format
                    SqlDataAdapter da = new SqlDataAdapter();

                    // Constructs the SQL query dynamically using string interpolation
                    string sql = 
                        $"SELECT * " +
                        $"FROM Students " +
                        $"WHERE Student_ID = {id}";

                   // Constructs the SQL query dynamically using string interpolation
                   // SelectCommand property is SQL command data adapter actually used to retrieve data from the SQL database
                   // sql is the sql query string used (what data you want) and con is the sql connection (the database to get data from) to the database
                   // This is what actually retrieves data from SQL database
                    da.SelectCommand = new SqlCommand(sql, connection);

                    // Fill() method fills DataTable (dt) with the results retrieved from the SQL database (da)
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        studentModel.Student_ID = Convert.ToInt32(row[StudentModel.fStudent_ID]);
                        studentModel.First_Name = row[StudentModel.fFirst_Name].ToString();
                        studentModel.Middle_Name = row[StudentModel.fMiddle_Name].ToString();
                        studentModel.Last_Name = row[StudentModel.fLast_Name].ToString();
                        studentModel.Sex = row[StudentModel.fSex].ToString();
                        studentModel.Grade = row[StudentModel.fGrade].ToString();
                        studentModel.Date_of_Birth = Convert.ToDateTime(row[StudentModel.fDate_of_Birth]);
                        studentModel.Age = Convert.ToInt32(row[StudentModel.fAge]);
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

        public StudentModel ReadOneStudent(int id)
        {
            StudentModel studentModel = new StudentModel();

            ReadOneStudent(studentModel, id);

            return studentModel;
        }

        public bool Display(StudentModel studentModel)
        {
            bool success = false; 

            try
            {
                Console.WriteLine(studentModel.Student_ID);
                Console.WriteLine(studentModel.First_Name);
                Console.WriteLine(studentModel.Middle_Name);
                Console.WriteLine(studentModel.Last_Name);
                Console.WriteLine(studentModel.Sex);
                Console.WriteLine(studentModel.Grade);
                Console.WriteLine(studentModel.Date_of_Birth);
                Console.WriteLine(studentModel.Age);
                Console.WriteLine();

                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return success;
        }

        public bool AddNew(StudentModel studentModel, int id)
        {
            bool success = false;

            try
            {
                // It is because when you call the Connect() it will return a true or false
                // If a true is returned it goes on
                if (Connect())
                {
                    string sql =
                        $"INSERT INTO [School_Sports].[dbo].[Students] " +
                        $"(Student_ID, First_Name, Middle_Name, Last_Name, Sex, Grade, Date_of_Birth) " +
                        $"VALUES ('{studentModel.Student_ID}', '{studentModel.First_Name}', '{studentModel.Middle_Name}', '{studentModel.Last_Name}', '{studentModel.Sex}', '{studentModel.Grade}', '{studentModel.Date_of_Birth}')";

                    SqlCommand cmd = new SqlCommand(sql, connection);

                    cmd.ExecuteNonQuery();

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

        public bool Update(StudentModel studentModel, int id)
        {
            bool success = false;

            try
            {
                if (Connect())
                {
                    string sql =
                        $" UPDATE [School_Sports].[dbo].[Students]" +
                        $" SET First_Name = '{studentModel.First_Name}'" +
                        $", Middle_Name = '{studentModel.Middle_Name}'" +
                        $", Last_Name = '{studentModel.Last_Name}'" +
                        $", Sex = '{studentModel.Sex}'" +
                        $", Grade = '{studentModel.Grade}'" +
                        $", Date_of_Birth = '{studentModel.Date_of_Birth}'" +
                        $" WHERE Student_ID = {studentModel.Student_ID}";

                    SqlCommand cmd = new SqlCommand(sql, connection);

                    cmd.ExecuteNonQuery();
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

        public bool Delete(int id)
        {
            bool success = false;

            try
            {
                if (Connect())
                {
                    string sql =
                        $"DELETE FROM [School_Sports].[dbo].[Students]" +
                        $"WHERE Student_ID = {id}";

                    SqlCommand cmd = new SqlCommand(sql, connection);

                    cmd.ExecuteNonQuery();

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

        // Destructor (~) to ensure connection is closed when Student object is garbage collected and destroyed
        // Automatically called when the memory occupied by objects that are no longer in use which
        // happens when the object is no longer used or referenced after the last function call
        ~StudentRepo()
        {
            // Disconnect() method is called to close the connection and release any associated resources
            Disconnect();
        }
    }
}