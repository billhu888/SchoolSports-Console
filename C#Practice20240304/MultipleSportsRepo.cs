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
    class MultipleSportsRepo : BaseRepo
    {
        public bool ReadMultipleSports(List<SportModel> sportsList, string sID)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();

                String sql =
                    $" SELECT * " +
                    $" FROM SPORTS ";

                if (string.IsNullOrEmpty(sID))
                {
                    sql = sql;
                }
                else
                {
                    int sportID = Convert.ToInt32(sID);
                    sql = sql + $" WHERE Sport_Id = {sportID}";
                }

                da.SelectCommand = new SqlCommand(sql, connection);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    SportModel sportmodel;

                    foreach (DataRow row in dt.Rows)
                    {
                        sportmodel = new SportModel()
                        {
                            Sport_Id = (int)row[SportModel.fSport_Id],
                            Sport_Gender = (string)row[SportModel.fSport_Gender],
                            Sport_Name = (string)row[SportModel.fSport_Name],
                            Sport_Season = (string)row[SportModel.fSport_Season]
                        };

                        sportsList.Add(sportmodel);
                    }

                    return true;
                }
                else
                {
                    Console.WriteLine("No records found");

                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read sport for " + e);

                return false;
            }
        }

        public bool DisplayMultipleSports(List<SportModel> sportsList)
        {
            bool success = false;

            try
            {
                foreach (var row in sportsList)
                {
                    Console.WriteLine(
                        $"{row.Sport_Id}, " +
                        $"{row.Sport_Gender}, " +
                        $"{row.Sport_Name}, " +
                        $"{row.Sport_Season}"
                        );
                }

                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read sport for " + e);
            }

            return success;
        }

        ~MultipleSportsRepo()
        {
            Disconnect();
        }
    }
}