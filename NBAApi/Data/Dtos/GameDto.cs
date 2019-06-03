using NBAApi.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NBAApi.Data.Dtos
{
    public class GameDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GameID { get; set; }

        public int Season { get; set; }

        public int? SeasonType { get; set; }

        public string Status { get; set; }

        public DateTime DateTime { get; set; }


        [ForeignKey("HomeTeamNav")]
        public int? HomeTeamID { get; set; }

        [ForeignKey("AwayTeamNav")]
        public int? AwayTeamID { get; set; }


        public int? HomeTeamScore { get; set; }

        public int? AwayTeamScore { get; set; }

        public DateTime? Updated { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PointSpread { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? OverUnder { get; set; }

        public int? AwayTeamMoneyLine { get; set; }

        public int? HomeTeamMoneyLine { get; set; }
    }
}
