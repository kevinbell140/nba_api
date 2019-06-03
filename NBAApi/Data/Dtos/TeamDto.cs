using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAApi.Data.Dtos
{
    public class TeamDto
    {
        public int TeamID { get; set; }
        public string Key { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string LeagueID { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string TertiaryColor { get; set; }
        public string WikipediaLogoUrl { get; set; }
    }
}
