using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Practice20240304
{
    public class MultipleSportsController
    {
        public void ReadMultipleSportsAction()
        {
            MultipleSportsModel multiplesportsmodel = new MultipleSportsModel();
            MultipleSportsRepo multiplesportsrepo = new MultipleSportsRepo();

            // List<SportModel> ListSports 
            multiplesportsmodel.ListSports = new List<SportModel>();

            Console.WriteLine("Enter Sport ID (optional, press Enter to skip): ");
            string sID = Console.ReadLine(); 

            multiplesportsrepo.ReadMultipleSports(multiplesportsmodel.ListSports, sID);

            multiplesportsrepo.DisplayMultipleSports(multiplesportsmodel.ListSports);
        }
    }
}