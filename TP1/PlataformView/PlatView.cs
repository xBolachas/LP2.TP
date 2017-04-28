using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1.Controllers;
using TP1.Models;

namespace TP1.PlataformView
{
    public class PlatView
    {
        private UserController _userControlador;
        private ProjectController _projectControlador;

        public PlatView()
        {
            _userControlador = new UserController();
            _projectControlador = new ProjectController();
        }

        public void Menu()
        {
            _userControlador.Registration();
            _projectControlador.AddProjecto();
        }
    }
}
