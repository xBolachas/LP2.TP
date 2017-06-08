using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TP2.Models;

namespace TP2.Controllers
{
    public class UserController
    {
        public List<User> _listUsers;
        public UserController()
        {
            _listUsers = new List<User>();
            string diretorio = Directory.GetCurrentDirectory();
            string ficheiro = diretorio.Replace(@"\bin\Debug", @"\DataBase\UserDatabase.txt");
            if (!File.Exists(ficheiro)) { File.CreateText(ficheiro).Close(); }
            string[] texto = File.ReadAllLines(ficheiro);
            for (int i = 0; i < texto.Length; i++)
            {
                string[] conteudo = texto[i].Split('/');
                User user = new User(conteudo[0], conteudo[1], conteudo[2]);
                _listUsers.Add(user);
            }
        }
        /// <summary>
        /// Regista um novo utilizador.
        /// </summary>
        /// <param name="nome">Username</param>
        /// <param name="password">Password</param>
        /// <param name="email">Email</param>
        /// <returns>True se registou.</returns>
        public bool SignUp(string nome, string password, string email)
        {
            bool verificaNome = VerificaNome(nome);
            bool verificaEmail = VerificaEmail(email);
            if (!verificaNome && !verificaEmail)
            {
                User novoUser = new User(nome, password,email);
                _listUsers.Add(novoUser);
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// Verifica se o nome a procurar pertence a base de dados de utilizadores.
        /// </summary>
        /// <param name="nome">Nome a verificar.</param>
        /// <returns>True se o nome se encontra na lista de utilizadores.</returns>
        public bool VerificaNome(string nome)
        {
            for (int i = 0; i < _listUsers.Count; i++)
            {
                if (_listUsers[i].Name == nome) { return true; }
            }
            return false;
        }
        /// <summary>
        /// Verifica se o email a procurar pertence a base de dados de utilizadores.
        /// </summary>
        /// <param name="email">Email a verificar.</param>
        /// <returns>True se o email se encontra na lista de emails.</returns>
        public bool VerificaEmail(string email)
        {
            for (int i = 0; i < _listUsers.Count; i++)
            {
                if (_listUsers[i].Email == email) { return true; }
            }
            return false;
        }
        /// <summary>
        /// Grava a base de dados de utilizadores.
        /// </summary>
        public void Save()
        {
            string diretorio = Directory.GetCurrentDirectory();
            string ficheiro = diretorio.Replace(@"\bin\Debug", @"\DataBase\UserDatabase.txt");
            string[] utilizador = new string[_listUsers.Count];
            for (int i = 0; i < _listUsers.Count; i++)
            {
                utilizador[i] = _listUsers[i].Name + "/" + _listUsers[i].Password + "/" + _listUsers[i].Email;
            }
            File.WriteAllLines(ficheiro, utilizador);
        }
    }
}
