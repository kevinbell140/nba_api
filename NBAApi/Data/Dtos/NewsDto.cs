using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBAApi.Data.Dtos
{
    public class NewsDto
    {
        public int NewsID { get; set; }

        [ForeignKey("PlayerNav")]
        public int PlayerID { get; set; }

        public string Source { get; set; }

        public DateTime Updated { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Url { get; set; }

        public string Author { get; set; }
    }
}

