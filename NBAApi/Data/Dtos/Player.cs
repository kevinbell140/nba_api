using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBAApi.Data.Dtos
{
    public class Player
    {
        public int PlayerID { get; set; }

        public int TeamID { get; set; }

        public string Status { get; set; }

        public int Jersey { get; set; } = 0;

        [DisplayName("Pos")]
        public string Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public int? Height { get; set; }
        public int? Weight { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public string UsaTodayHeadshotUrl { get; set; }

        public string PhotoUrl { get; set; }
    }
}
