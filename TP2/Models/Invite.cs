using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Models
{
    public class Invite
    {
        public Invite(User inviting, User invited, Project projeto)
        {
            Inviting = inviting;
            Invited = invited;
            Projeto = projeto;
        }
        public User Inviting { get; set; }
        public User Invited { get; set; }
        public Project Projeto { get; set; }
    }
}
