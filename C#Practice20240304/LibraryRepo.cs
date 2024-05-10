using CSharpPractice20240304;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Practice20240304
{
    class LibraryRepo : BaseRepo
    {
        public bool ReadLibrary(LibraryModel librarymodel, int bookID)
        {
            bool success = false;

            try
            {
                if (Connect())
                {
                    string query =
                        $" SELECT * " +
                        $" FROM Library_Books " +
                        $" WHERE Book_ID = {bookID} ";

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0 )
                    {
                        DataRow row = dt.Rows[0];

                        librarymodel.Book_Id = (int)row[LibraryModel.fBook_Id];
                        librarymodel.Book_Title = (string)row[LibraryModel.fBook_Title];
                        librarymodel.Book_Author = (string)row[LibraryModel.fBook_Author];

                        // Check if Student_ID_Checked_Out is NULL
                        if (!row.IsNull(LibraryModel.fStudent_ID_Checked_Out))
                        {
                            // If it's not NULL, convert it to int
                            librarymodel.Student_ID_Checked_Out = (int)row[LibraryModel.fStudent_ID_Checked_Out];
                        }
                        else
                        {
                            // If it's NULL, assign null
                            librarymodel.Student_ID_Checked_Out = null; // Use nullable type int?
                        }
                    }
                    else
                    {
                        Console.WriteLine("No library book found");
                    }
                }
                else
                {
                    Console.WriteLine("Failed to connect to database");
                }

                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return success;
        }

        public bool DisplayLibrary(LibraryModel librarymodel)
        {
            bool success = false;

            try
            {
                Console.WriteLine($"Book ID: {librarymodel.Book_Id}");
                Console.WriteLine($"Book Title: {librarymodel.Book_Title}");
                Console.WriteLine($"Book Author: {librarymodel.Book_Author}");
                Console.WriteLine($"Student ID Checked Out: {librarymodel.Student_ID_Checked_Out}");
                
                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return success;
        }

        public bool AddNewLibrary(LibraryModel librarymodel)
        {
            bool success = false;

            try
            {
                if (Connect())
                {
                    string query = 
                        $" INSERT INTO Library_Books (Book_ID, Book_Title, " +
                        $" Book_Author) " +
                        $" VALUES ('{librarymodel.Book_Id}', '{librarymodel.Book_Title}', " +
                        $" '{librarymodel.Book_Author}') ";

                    SqlCommand cmd = new SqlCommand(query, connection);
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

        public bool UpdateLibrary(LibraryModel librarymodel, int bookID)
        {
            bool success = false;

            try
            {
                if (Connect())
                {
                    string query =
                        $" UPDATE Library_Books " +
                        $" SET " +
                        $" BOOK_ID = '{librarymodel.Book_Id}', " +
                        $" Book_Title = '{librarymodel.Book_Title}', " +
                        $" Book_Author = '{librarymodel.Book_Author}', " +
                        $" Student_ID_Checked_Out = '{librarymodel.Student_ID_Checked_Out}' " +
                        $" WHERE Book_ID = {bookID} ";

                    SqlCommand cmd = new SqlCommand(query, connection);
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

        public bool DeleteLibrary(int bookID)
        {
            bool success = false;

            try
            {
                if (Connect())
                {
                    string query =
                    $" DELETE FROM Library_Books " +
                    $" WHERE Book_ID = {bookID}";

                    SqlCommand cmd = new SqlCommand(query, connection);
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

        ~LibraryRepo()
        {
            // Disconnect() method is called to close the connection and release any associated resources
            Disconnect();
        }
    }
}