using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1.Models;
using System.IO;
using TP1.Controllers;

namespace TP1.Controllers
{
    public class ProjectController
    {
        private UserController _userControlador;
        private List<Project> _projectList;
        public ProjectController()
        {
            _userControlador = new UserController();
            _projectList = new List<Project>();
            string ficheiro = "ProjectDatabase.txt";
            string[] texto = File.ReadAllLines(ficheiro);
            for (int i = 0; i < texto.Length; i++)
            {
                int contador = 0;
                string[] conteudo = texto[i].Split('/');
                string[] team = new string[(conteudo.Length)-3];
                for (int j = 3; j < conteudo.Length; j++)
                {
                    team[contador] = conteudo[j];
                    contador++;
                }
                Project project = new Project(conteudo[0], int.Parse(conteudo[1]), conteudo[2],team);
                _projectList.Add(project);
            }
        }

        public void AddProjecto()
        {
            bool existe = false, encontrou = false; ;
            string nomeProjeto = string.Empty,nameOwner = string.Empty, nameMember=string.Empty;
            List<string> teamTemporario = new List<string>();
            int sprintNumber = 0;
            Console.WriteLine("Nome do projeto?");
            nomeProjeto = Console.ReadLine();
            Console.WriteLine("Numero de sprints estimadas?");
            sprintNumber = int.Parse(Console.ReadLine());
            while (!existe)
            {
                Console.WriteLine("Owner do projeto?");
                nameOwner = Console.ReadLine();         
                for (int i = 0; i < _userControlador._listUsers.Count; i++)
                {
                    if (_userControlador._listUsers[i].Name == nameOwner)
                    {
                        existe = true;
                    }
                }
            }
            Console.WriteLine("Membros da equipa do projeto? (Enter para passar à frente)");
            nameMember = Console.ReadLine();
            while (nameMember != "")
            {
                for (int i = 0; i < _userControlador._listUsers.Count; i++)
                {
                    if (_userControlador._listUsers[i].Name == nameMember)
                    {
                        teamTemporario.Add(nameMember);
                        encontrou = true;
                    }
                }
                if (encontrou) { Console.WriteLine("Utilizador adicionado."); }
                else { Console.WriteLine("Utilizador não encontrado."); }
                encontrou = false;
                Console.WriteLine("Membros da equipa do projeto? (Enter para passar à frente)");
                nameMember = Console.ReadLine();
            }
            string[] team = new string[teamTemporario.Count];
            for (int i = 0; i < team.Length; i++)
            {
                team[i] = teamTemporario[i];
            }
            Project projeto = new Project(nomeProjeto, sprintNumber, nameOwner, team);
            _projectList.Add(projeto);
        }
    }
}
