using CSharpPractice20240304;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C_Practice20240304
{
    class MultipleLibraryRepo : BaseRepo
    { 
        public bool ReadMultipleLibrary(List<LibraryModel> librarylist, string bookID)
        {
            bool success = false;

            try
            {
                if (Connect())
                {
                    String sql =
                        $" SELECT * " +
                        $" FROM Library_Books ";

                    if (string.IsNullOrEmpty(bookID))
                    {
                        sql = sql;
                    }
                    else
                    {
                        int book_ID = Convert.ToInt32(bookID);
                        sql = sql + $" WHERE Book_ID = {book_ID}";
                    }

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, connection);
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
                                Book_Author = (string)row[LibraryModel.fBook_Author],
                            };

                            if (row.IsNull(LibraryModel.fStudent_ID_Checked_Out))
                            {
                                librarymodel.Student_ID_Checked_Out = null;
                            }
                            else
                            {
                                librarymodel.Student_ID_Checked_Out = (int)row[LibraryModel.fStudent_ID_Checked_Out];
                            }

                            librarylist.Add(librarymodel);
                        }

                        success = true;
                    }
                    else
                    {
                        Console.WriteLine("No records found");
                    }
                }
                else 
                {
                    Console.WriteLine("Failed to connect to database");
                }  
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e);
            }

            return success;
        }

        public bool DisplayMultipleLibrary(List<LibraryModel> librarylist)
        {
            bool success = false;

            try
            {
                foreach (var row in librarylist)
                {
                    Console.WriteLine(
                        $"{row.Book_Id}, " +
                        $"{row.Book_Title}, " +
                        $"{row.Book_Author}, " +
                        $"{row.Student_ID_Checked_Out}"
                    );
                }

                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to display sport for " + e);
            }

            return success;
        }

        ~MultipleLibraryRepo()
        {
            Disconnect();
        }
    }
}