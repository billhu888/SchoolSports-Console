using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Practice20240304
{
    public class SportController
    {
        public void ReadSportAction(int id)
        {
            SportModel sportmodel = new SportModel();
            SportRepo sportrepo = new SportRepo();

            if (sportrepo.ReadSport(sportmodel, id))
            {
                sportrepo.DisplaySport(sportmodel);
            }
            else
            {
                Console.WriteLine("Reading data failed");
            }
        }

        public void AddNewSportAction()
        {
            SportModel sportmodel = new SportModel();
            SportRepo sportrepo = new SportRepo();

            sportmodel.Sport_Id = 112;
            sportmodel.Sport_Gender = "Girls";
            sportmodel.Sport_Name = "Cheer";
            sportmodel.Sport_Season = "Year";

            if (sportrepo.AddNewSport(sportmodel))
            {
                sportrepo.ReadSport(sportmodel, sportmodel.Sport_Id);
                sportrepo.DisplaySport(sportmodel);
            }
            else
            {
                Console.WriteLine("Adding data failed");
            }
        }

        public void DeleteSportAction(int id)
        {
            SportModel sportmodel = new SportModel();
            SportRepo sportrepo = new SportRepo();

            if (sportrepo.ReadSport(sportmodel, id))
            {
                sportrepo.DisplaySport(sportmodel);
            }
            else
            {
                Console.WriteLine("Reading data failed");
            }

            if (sportrepo.DeleteSport(id))
            {
                SportModel sportmodel2 = new SportModel();

                sportrepo.ReadSport(sportmodel2, id);
                sportrepo.DisplaySport(sportmodel2);
            }
            else
            {
                Console.WriteLine("Deleting data failed");
            }
        }

        public void UpdateSportAction(int id)
        {
            SportModel sportmodel = new SportModel();
            SportRepo sportrepo = new SportRepo();

            if (sportrepo.ReadSport(sportmodel, id))
            {
                sportrepo.DisplaySport(sportmodel);
            }
            else
            {
                Console.WriteLine("Reading data failed");
            }

            sportmodel.Sport_Season = "Year";

            if (sportrepo.UpdateSport(sportmodel, id))
            {
                sportrepo.ReadSport(sportmodel, id);
                sportrepo.DisplaySport(sportmodel);
            }
            else
            {
                Console.WriteLine("Updating data failed");
            }
        }
    }
}