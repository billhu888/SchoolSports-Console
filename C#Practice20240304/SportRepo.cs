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
    class SportRepo : BaseRepo
    {
        public bool ReadSport(SportModel sportmodel, int id)
        {
            bool success = false;

            try
            {
                if (Connect())
                {
                    String query =
                        $" SELECT *" +
                        $" FROM SPORTS" +
                        $" WHERE SPORT_ID = {id}";

                    DataTable dt = new DataTable();
                    // SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataAdapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        sportmodel.Sport_Id = (int)row[SportModel.fSport_Id];
                        sportmodel.Sport_Gender = (string)row[SportModel.fSport_Gender];
                        sportmodel.Sport_Name = (string)row[SportModel.fSport_Name];
                        sportmodel.Sport_Season = (string)row[SportModel.fSport_Season];
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

        public bool DisplaySport(SportModel sportmodel)
        {
            bool success = false;

            try
            {
                Console.WriteLine($"Sport ID: {sportmodel.Sport_Id}");
                Console.WriteLine($"Sport Gender: {sportmodel.Sport_Gender}");
                Console.WriteLine($"Sport Name: {sportmodel.Sport_Name}");
                Console.WriteLine($"Sport Season: {sportmodel.Sport_Season}");

                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to display sport for " + e);
            }

            return success;
        }

        public bool AddNewSport(SportModel sportmodel)
        {
            bool success = false;

            try
            {
                if (Connect())
                {
                    String query =
                        $" INSERT INTO SPORTS (Sport_ID, Sport_Gender, Sport_Name, Sport_Season)" +
                        $" VALUES ('{sportmodel.Sport_Id}', '{sportmodel.Sport_Gender}', " +
                        $" '{sportmodel.Sport_Name}', '{sportmodel.Sport_Season}')";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();

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

        public bool DeleteSport(int id)
        {
            bool success = false;

            try
            {
                if (Connect())
                {
                    String query =
                        $" DELETE FROM SPORTS" +
                        $" WHERE Sport_ID = {id}";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();

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

        public bool UpdateSport(SportModel sportmodel, int id)
        {
            bool success = false;

            try
            {
                if(Connect())
                {
                    String query =
                        $" UPDATE SPORTS" +
                        $" SET Sport_Gender = '{sportmodel.Sport_Gender}', " +
                        $" Sport_Name = '{sportmodel.Sport_Name}', " +
                        $" Sport_Season = '{sportmodel.Sport_Season}' " +
                        $" WHERE Sport_ID = {id}";

                    SqlCommand command = new SqlCommand(query, connection);             
                    command.ExecuteNonQuery();

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

        ~SportRepo()
        {
            Disconnect();
        }
    }
}