using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Practice20240304
{
    public class SportModel
    {
        public const string fSport_Id = "Sport_Id";
        public const string fSport_Gender = "Sport_Gender";
        public const string fSport_Name = "Sport_Name";
        public const string fSport_Season = "Sport_Season";

        public int Sport_Id { get; set; }
        public string Sport_Gender { get; set; }
        public string Sport_Name { get; set; }
        public string Sport_Season { get; set; }
    }
}
