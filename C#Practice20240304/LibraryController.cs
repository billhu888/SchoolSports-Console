using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace C_Practice20240304
{
    public class LibraryController
    {
        public void ReadLibraryAction(int bookID)
        {
            LibraryModel librarymodel = new LibraryModel();
            LibraryRepo libraryrepo = new LibraryRepo();

            if (libraryrepo.ReadLibrary(librarymodel, bookID)) 
            {
                libraryrepo.DisplayLibrary(librarymodel);
            }
            else
            {
                Console.WriteLine("Reading data failed");
            }
        }

        public void AddNewLibraryAction() 
        {
            LibraryModel librarymodel = new LibraryModel();
            LibraryRepo libraryrepo = new LibraryRepo();

            librarymodel.Book_Id = 10010;
            librarymodel.Book_Title = "Of Mice and Men";
            librarymodel.Book_Author = "John Steinbeck";

            if (libraryrepo.AddNewLibrary(librarymodel))
            {
                libraryrepo.DisplayLibrary(librarymodel);
            }
            else
            {
                Console.WriteLine("Adding data failed");
            }
        }

        public void UpdateLibraryAction(int bookID)
        {
            LibraryModel librarymodel = new LibraryModel();
            LibraryRepo libraryrepo = new LibraryRepo();

            if (libraryrepo.ReadLibrary(librarymodel, bookID))
            {
                libraryrepo.DisplayLibrary(librarymodel);
            }
            else
            {
                Console.WriteLine("Reading data failed");
            }

            librarymodel.Student_ID_Checked_Out = 1000017;

            if (libraryrepo.UpdateLibrary(librarymodel, bookID))
            {
                libraryrepo.DisplayLibrary(librarymodel);
            }
            else
            {
                Console.WriteLine("Updating data failed");
            }
        }

        public void DeleteLibraryAction(int bookID)
        {
            LibraryModel librarymodel = new LibraryModel();
            LibraryRepo libraryrepo = new LibraryRepo();

            if (libraryrepo.ReadLibrary(librarymodel, bookID))
            {
                libraryrepo.DisplayLibrary(librarymodel);
            }
            else
            {
                Console.WriteLine("Reading data failed");
            }

            if (libraryrepo.DeleteLibrary(bookID))
            {
                LibraryModel librarymodel2 = new LibraryModel();

                libraryrepo.ReadLibrary(librarymodel2, bookID);
                libraryrepo.DisplayLibrary(librarymodel2);
            }
            else
            {
                Console.WriteLine("Deleting data failed");
            }
        }

    }
}