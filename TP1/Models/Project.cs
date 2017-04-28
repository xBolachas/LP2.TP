using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Models
{
    public class Project
    {
        public Project(string projname, int sprints, string owner, string[] team)
        {
            ProjName = projname;
            Sprints = sprints;
            Owner = owner;
            Team = team;
        }

        public string ProjName { get; set; }
        public string Owner { get; set; }
        public string[] Team { get; set; }
        public int Sprints { get; set; }
    }
}
