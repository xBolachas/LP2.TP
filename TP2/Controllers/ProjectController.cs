using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TP2.Models;

namespace TP2.Controllers
{
    public class ProjectController
    {
        public List<Project> _projectList;
        private UserController _userControlador;

        public ProjectController()
        {
            _userControlador = new UserController();
            _projectList = new List<Project>();
            string diretorio = Directory.GetCurrentDirectory();
            string ficheiro = diretorio.Replace(@"\bin\Debug", @"\DataBase\ProjectDatabase.txt");
            if (!File.Exists(ficheiro)) { File.CreateText(ficheiro).Close(); }
            string[] texto = File.ReadAllLines(ficheiro);
            for (int i = 0; i < texto.Length; i++)
            {
                List<User> team = new List<User>();
                string[] conteudo = texto[i].Split('/');
                for (int j = 2; j < conteudo.Length; j++)
                {
                    User membro = new User(conteudo[j]);
                    team.Add(membro);
                }
                User owner = new User(conteudo[1]);
                Project project = new Project(conteudo[0], owner, team);
                _projectList.Add(project);
            }
        }
        /// <summary>
        /// Adiciona um novo projeto.
        /// </summary>
        /// <param name="owner">User a quem pertence o projeto.</param>
        /// <param name="projetoNome">Nome do projeto.</param>
        /// <returns>True se o projeto foi adicionado.</returns>
        public bool AdicionarProjeto(User owner, string projetoNome)
        {
            List<User> teamTemp = new List<User>();
            if (_userControlador.VerificaNome(owner.Name)&&VerificaNomeProjeto(projetoNome))
            {
                Project novoProjeto = new Project(projetoNome, owner, teamTemp);
                _projectList.Add(novoProjeto);
                Save();
                string diretorio = Directory.GetCurrentDirectory();
                string path = diretorio.Replace(@"\bin\Debug", @"\Tarefas\" + projetoNome + ".txt");
                if (!File.Exists(path)) { File.CreateText(path).Close(); }
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// Verifica se o nome do novo projeto e diferente de todos os outros.
        /// </summary>
        /// <param name="projetoNome">Nome do projeto a verificar.</param>
        /// <returns>True se nao existir um projeto com nome igual.</returns>
        public bool VerificaNomeProjeto(string projetoNome)
        {
            for (int i = 0; i < _projectList.Count; i++)
            {
                if (_projectList[i].ProjectName == projetoNome) { return false; }
            }
            return true;
        }
        /// <summary>
        /// Adiciona membros a um determinado projeto.
        /// </summary>
        /// <param name="user">User a adicionar.</param>
        /// <param name="project">Projeto a ser adicionado um novo user.</param>
        /// <returns>True se o user foi adicionado ao projeto.</returns>
        public bool AdicionarTeamMember(User user, Project project)
        {
            bool valida = true;
            for (int i = 0; i < project.Team.Count; i++)
            {
                if (project.Team[i].Name == user.Name)
                {
                    valida = false;
                }
            }
            if (valida)
            {
                project.Team.Add(user);
                Save();
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// Grava todos os projetos dos utilizadores.
        /// </summary>
        public void Save()
        {
            string diretorio = Directory.GetCurrentDirectory();
            string ficheiro = diretorio.Replace(@"\bin\Debug", @"\DataBase\ProjectDatabase.txt");
            string[] projeto = new string[_projectList.Count];
            for (int i = 0; i < _projectList.Count; i++)
            {
                projeto[i] = _projectList[i].ProjectName + "/" + _projectList[i].Owner.Name;
                for (int j = 0; j < _projectList[i].Team.Count; j++)
                {
                    projeto[i] +="/" +_projectList[i].Team[j].Name;
                }
            }
            File.WriteAllLines(ficheiro, projeto);
        }
    }
}
