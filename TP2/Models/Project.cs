using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Models
{
    public class Project
    {
        public Project(string projectName, User owner, List<User> team)
        {
            ProjectName = projectName;
            Owner = owner;
            Team = team;
        }

        public Project(string projectName)
        {
            ProjectName = projectName;
        }

        public string ProjectName { get; set; }
        public User Owner { get; set; }
        public List<User> Team { get; set; }
    }
}
