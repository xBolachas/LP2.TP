using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1.Models;
using System.IO;

namespace TP1.Controllers
{
    public class UserController
    {
        public List<User> _listUsers;
        public UserController()
        {
            _listUsers = new List<User>();
            string ficheiro = "UserDatabase.txt";
            string[] texto = File.ReadAllLines(ficheiro);
            for (int i = 0; i < texto.Length; i++) 
            {
                string[] conteudo = texto[i].Split('/');
                User user = new User(conteudo[0], conteudo[1], conteudo[2]);
                _listUsers.Add(user);
            }
        }

        public void Save()
        {
            string ficheiro = "UserDatabase.txt";
            string[] utilizador = new string[_listUsers.Count];
            for (int i = 0; i < _listUsers.Count; i++)
            {
                utilizador[i] = _listUsers[i].Name+"/"+ _listUsers[i].Password+"/"+ _listUsers[i].Email;
            }
            File.WriteAllLines(ficheiro, utilizador);
        }
        
        public void Registration()
        {
            string nome, password, email;
            Console.WriteLine("Nome");
            nome = Console.ReadLine();
            Console.WriteLine("PW:");
            password = Console.ReadLine();
            Console.WriteLine("Email");
            email = Console.ReadLine();
            User user = new User(nome, password, email);
            _listUsers.Add(user);
            Save();
        }


    }
}
