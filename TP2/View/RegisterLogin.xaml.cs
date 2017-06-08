using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP2.Models;
using TP2.Controllers;

namespace TP2.View
{
    /// <summary>
    /// Interaction logic for RegisterLogin.xaml
    /// </summary>
    public partial class RegisterLogin : Window
    {
        private UserController _controlador;
        public RegisterLogin()
        {
            InitializeComponent();
            _controlador = new UserController();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UserName.Text))
            {
                MessageBox.Show("Nome do cliente está vazio", "Nome vazio");
            }
            else
            {
                if (_controlador.SignUp(UserName.Text, Password.Text, Email.Text))
                {
                    MessageBox.Show("Cliente inserido com sucesso", "Cliente inserido");
                    UserName.Text = string.Empty;
                    Password.Text = string.Empty;
                    Email.Text = string.Empty;
                    _controlador.Save();
                }
                else
                {
                    MessageBox.Show("Nome ou email já em uso.");
                }
            }
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            bool verifica = false;
            User utilizador;
            for (int i = 0; i < _controlador._listUsers.Count; i++)
            {
                if (_controlador._listUsers[i].Name == UserNameLogin.Text && _controlador._listUsers[i].Password == PasswordLogin.Password)
                {
                    verifica = true;
                }
            }
            if (verifica)
            {
                MessageBox.Show("Login efetuado com sucesso.");
                utilizador = new User(UserNameLogin.Text);
                MainMenu janela = new MainMenu(utilizador);
                janela.Show();
                this.Close();
            }
            else { MessageBox.Show("Username e password nao coincidem."); }
        }
    }
}
