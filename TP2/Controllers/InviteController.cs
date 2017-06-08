using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TP2.Models;
using System.Globalization;

namespace TP2.Controllers
{
    public class InviteController
    {
        public List<Invite> _inviteList;
        private UserController _userController;

        public InviteController()
        {
            _userController = new UserController();
            _inviteList = new List<Invite>();
            string diretorio = Directory.GetCurrentDirectory();
            string ficheiro = diretorio.Replace(@"\bin\Debug", @"\DataBase\Invites.txt");
            if (!File.Exists(ficheiro)) { File.CreateText(ficheiro).Close(); }
            string[] texto = File.ReadAllLines(ficheiro);
            for (int i = 0; i < texto.Length; i++)
            {
                string[] conteudo = texto[i].Split('/');
                User inviter = new User(conteudo[0]);
                User invited = new User(conteudo[1]);
                Project projeto = new Project(conteudo[2]);
                Invite invite = new Invite(inviter , invited, projeto);
                _inviteList.Add(invite);
            }
        }
        /// <summary>
        /// Adiciona um novo invite na base de dados.
        /// </summary>
        /// <param name="invitingUser">User que esta a convidar.</param>
        /// <param name="projeto">Projeto para o qual foi convidado.</param>
        /// <param name="invited">User a ser convidado.</param>
        /// <returns>True se adicionou um novo convite.</returns>
        public bool AdicionarInvite(User invitingUser, Project projeto, string invited)
        {
            User invitedUser = null;
            bool verifica = false;
            for (int i = 0; i < _userController._listUsers.Count; i++)
            {
                if (_userController._listUsers[i].Name == invited) { verifica = true; invitedUser = _userController._listUsers[i]; }
            }
            if (verifica)
            {
                Invite invite = new Invite(invitingUser,invitedUser,projeto);
                _inviteList.Add(invite);
                Save();
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// Remove invites da base de dados.
        /// </summary>
        /// <param name="convite">Convite a ser removido.</param>
        public void RemoverInvite(Invite convite)
        {
            string diretorio = Directory.GetCurrentDirectory();
            string ficheiro = diretorio.Replace(@"\bin\Debug", @"\DataBase\Invites.txt");
            _inviteList.Remove(convite);
            string[] invites = new string[_inviteList.Count];
            for (int i = 0; i < _inviteList.Count; i++)
            {
                invites[i] = _inviteList[i].Inviting.Name + "/" + _inviteList[i].Invited.Name + "/" + _inviteList[i].Projeto.ProjectName;
            }
            File.WriteAllLines(ficheiro, invites);
        }
        /// <summary>
        /// Grava todos os invites dos utilizadores.
        /// </summary>
        public void Save()
        {
            string diretorio = Directory.GetCurrentDirectory();
            string ficheiro = diretorio.Replace(@"\bin\Debug", @"\DataBase\Invites.txt");
            string[] invites = new string[_inviteList.Count];
            for (int i = 0; i < _inviteList.Count; i++)
            {
                invites[i] = _inviteList[i].Inviting.Name + "/" + _inviteList[i].Invited.Name + "/" + _inviteList[i].Projeto.ProjectName;
            }
            File.WriteAllLines(ficheiro, invites);
        }
    }
}
