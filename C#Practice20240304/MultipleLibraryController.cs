using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Practice20240304
{
    public class MultipleLibraryController
    {
        public void ReadMultipleLibrary()
        {
            MultipleLibraryModel multiplelibrarymodel = new MultipleLibraryModel();
            MultipleLibraryRepo multiplelibraryrepo = new MultipleLibraryRepo();

            multiplelibrarymodel.ListLibrary = new List<LibraryModel>();

            Console.WriteLine("Enter Library Book ID (optional, press Enter to skip): ");
            string sID = Console.ReadLine();

            multiplelibraryrepo.ReadMultipleLibrary(multiplelibrarymodel.ListLibrary, sID);

            multiplelibraryrepo.DisplayMultipleLibrary(multiplelibrarymodel.ListLibrary);
        }
    }
}
