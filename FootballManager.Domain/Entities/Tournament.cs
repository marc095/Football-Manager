using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManager.Domain.Entities
{
    public class Tournament
    {
        public Tournament()
        {
            this.Teams = new List<Team>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        public virtual List<Team> Teams { get; set; }
    }
}
