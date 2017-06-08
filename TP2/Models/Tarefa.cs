using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Models
{
    public class Tarefa
    {
        public Tarefa(string whatToDo, User user,int complete)
        {
            WhatToDo = whatToDo;
            User = user;
            Complete = complete;
        }

        public string WhatToDo { get; set; }
        public User User { get; set; }
        public int Complete { get; set; }
    }
}
