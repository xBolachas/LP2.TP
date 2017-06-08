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
using System.Windows.Shapes;
using TP2.Controllers;
using TP2.Models;

namespace TP2.View
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        //private event EventHandler _newEvent;
        private ProjectController _projetoControlador;
        private UserController _userControlador;
        private User _userLogged;
        private List<Project> _allUserProjectList;
        private List<Project> _userOwnedProjectList;
        private List<Project> _userNormalProjectList;
        public List<Label> listaNomes;
        public List<Button> listaTarefaButton;
        public List<Button> listaButton;
        private int numProjetos=0;

        /*protected virtual void OnNewEvent(object sender, EventArgs e)
        {
            EventHandler handler = _newEvent;
        }*/

        public MainMenu(User utilizadorLogado)
        {
            InitializeComponent();


            _userOwnedProjectList = new List<Project>();
            _userNormalProjectList = new List<Project>();
            _allUserProjectList = new List<Project>();
            _projetoControlador = new ProjectController();
            _userControlador = new UserController();
            _userLogged = utilizadorLogado;
            UserLogado.Content = _userLogged.Name;
            for (int i = 0; i < _projetoControlador._projectList.Count; i++)
            {
                if (_projetoControlador._projectList[i].Owner.Name == _userLogged.Name) { _userOwnedProjectList.Add(_projetoControlador._projectList[i]); _allUserProjectList.Add(_projetoControlador._projectList[i]); numProjetos++; }
            }
            for (int p = 0; p < _projetoControlador._projectList.Count; p++)
            {
                for (int h = 0; h < _projetoControlador._projectList[p].Team.Count; h++)
                {
                    if (_projetoControlador._projectList[p].Team[h].Name == _userLogged.Name) { _userNormalProjectList.Add(_projetoControlador._projectList[p]); _allUserProjectList.Add(_projetoControlador._projectList[p]); numProjetos++; }
                }
            }

            listaNomes = new List<Label>();
            listaNomes.Add(Projeto1);
            listaNomes.Add(Projeto2);
            listaNomes.Add(Projeto3);
            listaNomes.Add(Projeto4);
            listaNomes.Add(Projeto5);
            listaNomes.Add(Projeto6);
            listaButton = new List<Button>();
            listaButton.Add(Projeto1Definicoes);
            listaButton.Add(Projeto2Definicoes);
            listaButton.Add(Projeto3Definicoes);
            listaButton.Add(Projeto4Definicoes);
            listaButton.Add(Projeto5Definicoes);
            listaButton.Add(Projeto6Definicoes);
            listaTarefaButton = new List<Button>();
            listaTarefaButton.Add(Projeto1Aceder);
            listaTarefaButton.Add(Projeto2Aceder);
            listaTarefaButton.Add(Projeto3Aceder);
            listaTarefaButton.Add(Projeto4Aceder);
            listaTarefaButton.Add(Projeto5Aceder);
            listaTarefaButton.Add(Projeto6Aceder);
            Load();
        }



        private void CriarProjeto(object sender, RoutedEventArgs e)
        {
            if (numProjetos < 6)
            {
                if (!string.IsNullOrWhiteSpace(ProjetoCriarName.Text))
                    {
                        if (_projetoControlador.AdicionarProjeto(_userLogged, ProjetoCriarName.Text))
                            {
                                listaButton[numProjetos].Visibility = Visibility.Visible;
                                listaNomes[numProjetos].Content = ProjetoCriarName.Text;
                                listaTarefaButton[numProjetos].Visibility = Visibility.Visible;
                                listaNomes[numProjetos].Visibility = Visibility.Visible;
                                numProjetos++;
                                Loader();
                                Load();
                        MessageBox.Show("Projeto criado com sucesso.");
                            }
                    else { MessageBox.Show("Nome do projeto já em uso."); }
                    }
            }
            else { MessageBox.Show("Numero máximo de projetos alcançado."); }
            
        }

        private void Loader()
        {
            numProjetos = 0;
            _userOwnedProjectList = new List<Project>();
            _userNormalProjectList = new List<Project>();
            _allUserProjectList = new List<Project>();
            _projetoControlador = new ProjectController();
            _userControlador = new UserController();
            UserLogado.Content = _userLogged.Name;
            for (int i = 0; i < _projetoControlador._projectList.Count; i++)
            {
                if (_projetoControlador._projectList[i].Owner.Name == _userLogged.Name) { _userOwnedProjectList.Add(_projetoControlador._projectList[i]); _allUserProjectList.Add(_projetoControlador._projectList[i]); numProjetos++; }
            }
            for (int p = 0; p < _projetoControlador._projectList.Count; p++)
            {
                for (int h = 0; h < _projetoControlador._projectList[p].Team.Count; h++)
                {
                    if (_projetoControlador._projectList[p].Team[h].Name == _userLogged.Name) { _userNormalProjectList.Add(_projetoControlador._projectList[p]); _allUserProjectList.Add(_projetoControlador._projectList[p]); numProjetos++; }
                }
            }
        }
        private void Load()
        {
            int contador = 0;
            for (int u = 0; u < 6; u++)
            {
                listaNomes[u].Content = "";
                listaButton[u].Visibility = Visibility.Hidden;
                listaTarefaButton[u].Visibility = Visibility.Hidden;
                listaNomes[u].Visibility = Visibility.Hidden;
            }
            for (int i = 0; i < _userOwnedProjectList.Count; i++)
            {
                listaNomes[i].Content = _userOwnedProjectList[i].ProjectName;
                listaButton[i].Visibility = Visibility.Visible;
                listaTarefaButton[i].Visibility = Visibility.Visible;
                listaNomes[i].Visibility = Visibility.Visible;
                contador++;
            }
            for (int j = 0; j < _userNormalProjectList.Count; j++)
            {
                listaNomes[contador].Content = _userNormalProjectList[j].ProjectName;
                listaTarefaButton[contador].Visibility = Visibility.Visible;
                listaNomes[contador].Visibility = Visibility.Visible;
                contador++;
            }
        }

        private bool LoadBack(ProjectController p) {
            Loader();
            Load();
            return true;
        }

        private void AcederProjectManager(object sender, RoutedEventArgs e)
        {
            Button botao = sender as Button;

            ProjectManager projetoDefinicoes = null;

            Func<ProjectController, bool> f = LoadBack;

            for (int i = 0; i < listaButton.Count; i++)
            {
                if (listaButton[i] == botao)
                {
                    projetoDefinicoes = new ProjectManager(_allUserProjectList[i], _projetoControlador, _userLogged, f);
                    projetoDefinicoes.setCreatingForm = this;
                }
            }
            projetoDefinicoes.Show();
            this.Hide();
        }

        private void AcederProjectInfo(object sender, RoutedEventArgs e)
        {
            ProjectInfo projetoTarefas = null;
            Button botao = sender as Button;
            for (int k = 0; k < listaTarefaButton.Count; k++)
            {
                if (listaTarefaButton[k] == botao)
                {
                    projetoTarefas = new ProjectInfo(_allUserProjectList[k], _projetoControlador,_userLogged);
                }
            }
            projetoTarefas.Show();
        }

        private void AcederUserInvites(object sender, RoutedEventArgs e)
        {
            Func<ProjectController, bool> f = LoadBack;
            UserInvites janela = new UserInvites(_userLogged, _projetoControlador,f);
            janela.setCreatingForm = this;
            janela.Show();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            RegisterLogin novaJanela = new RegisterLogin();
            novaJanela.Show();
            this.Close();
        }
    }
}
