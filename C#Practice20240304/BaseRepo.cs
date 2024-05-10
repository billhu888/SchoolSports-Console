using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice20240304
{
    abstract class BaseRepo
    {
        protected bool isConnected = false;
        protected SqlConnection connection;

        public BaseRepo()
        {
            // Initialize the connection once 
            connection = new SqlConnection(@"Persist Security Info=False; Integrated Security=true; Initial Catalog=School_Sports; Server=DESKTOP-BM0O4AL");
            //Connect();
        }

        protected bool Connect()
        {
            try
            {
                if (!isConnected)
                {
                    connection.Open();
                    isConnected = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                isConnected = false;
            }

            return isConnected;
        }

        protected bool Disconnect()
        {
            try
            {
                if (isConnected)
                {
                    connection.Close();
                    isConnected = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return isConnected;
        }
    }
}