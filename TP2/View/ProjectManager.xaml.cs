using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ProjectManager.xaml
    /// </summary>
    public partial class ProjectManager : Window
    {
        Window creatingForm;
        private ProjectController _projetoControlador;
        private TarefaController _tarefaControlador;
        private InviteController _inviteControlador;
        public Project nomeProjeto;
        private User _userLogged;
        private Project _projetoEscolhido;
        ///
        Func<ProjectController, bool> _projetoControladorAction;

        public Window setCreatingForm
        {
            get { return creatingForm; }
            set { creatingForm = value; }
        }

        public ProjectManager(Project projetoNome, ProjectController projetoController,User userLogado, Func<ProjectController, bool> projetoControladorAction)
        {
            InitializeComponent();
            _inviteControlador = new InviteController();
            _projetoControlador = projetoController;
            nomeProjeto = projetoNome;
            _tarefaControlador = new TarefaController(nomeProjeto, _projetoControlador);
            _userLogged = userLogado;
            _projetoControladorAction = projetoControladorAction;
            for (int i = 0; i < _projetoControlador._projectList.Count; i++)
            {
                if (_projetoControlador._projectList[i].ProjectName == projetoNome.ProjectName)
                {
                    _projetoEscolhido = _projetoControlador._projectList[i];
                    _projetoEscolhido.Team.Add(_projetoEscolhido.Owner);
                }
            }
            UsersProjeto.ItemsSource = _projetoEscolhido.Team;
        }
        private void RenameProject(object sender, RoutedEventArgs e)
        {
            bool valida = false;
            Project projeto = null;
            for (int i = 0; i < _projetoControlador._projectList.Count; i++)
            {
                if (_projetoControlador._projectList[i].ProjectName == nomeProjeto.ProjectName)
                {
                    valida = true;
                    projeto = _projetoControlador._projectList[i];
                    projeto.Team.Remove(projeto.Team[0]);
                }
            }
            if (valida)
            {
                for (int i = 0; i < _inviteControlador._inviteList.Count; i++)
                {
                    if (_inviteControlador._inviteList[i].Projeto.ProjectName == projeto.ProjectName)
                    {
                        _inviteControlador._inviteList[i].Projeto.ProjectName = ChangeProjectName.Text;
                        _inviteControlador.Save();
                    }
                }
                _tarefaControlador.MudaNome(projeto.ProjectName,ChangeProjectName.Text);
                projeto.ProjectName = ChangeProjectName.Text;
                MessageBox.Show("Nome alterado com sucesso para: "+ChangeProjectName.Text);
                _projetoControlador.Save();
            }
            else { MessageBox.Show("Erro."); }
        }

        private void AdicionarTarefa(object sender, RoutedEventArgs e)
        {
            string userEscolhido = UsersProjeto.Text;
            if (_tarefaControlador.AdicionarTarefa(userEscolhido, TarefaContent.Text))
            {
                MessageBox.Show("Tarefa adicionada");
                _tarefaControlador.Save();
            }
            else
            {
                MessageBox.Show("Erro");
            }
        }

        private void AdicionarUsers(object sender, RoutedEventArgs e)
        {
            bool verifica = false;
            if (!string.IsNullOrWhiteSpace(UserToAdd.Text))
            {
                User invited = new User(UserToAdd.Text);
                for (int i = 0; i < _inviteControlador._inviteList.Count; i++)
                {
                    if (_inviteControlador._inviteList[i].Invited.Name==invited.Name && _inviteControlador._inviteList[i].Projeto.ProjectName == nomeProjeto.ProjectName)
                    {
                        verifica = true;
                    }
                }
                if (!verifica)
                {
                    if (_inviteControlador.AdicionarInvite(_userLogged, nomeProjeto, UserToAdd.Text))
                    {
                        MessageBox.Show("Invite enviado.");
                        _inviteControlador.Save();
                    }
                    else { MessageBox.Show("Nao foi possivel encontrar o utilizador."); }
                }
                else { MessageBox.Show("Utilizador ja foi convidado."); }
            }
            else { MessageBox.Show("Nao foi possivel encontrar o utilizador."); }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            _projetoControladorAction.Invoke(_projetoControlador);

            creatingForm.Show();
        }

        private void ApagarProjeto(object sender, RoutedEventArgs e)
        {
            _projetoControlador._projectList.Remove(_projetoEscolhido);
            _tarefaControlador.ApagaFicheiroTarefas(_projetoEscolhido.ProjectName);
            _projetoControlador.Save();
            for (int i = 0; i < _inviteControlador._inviteList.Count; i++)
            {
                if (_inviteControlador._inviteList[i].Projeto.ProjectName == _projetoEscolhido.ProjectName)
                {
                    _inviteControlador._inviteList.Remove(_inviteControlador._inviteList[i]);
                    _inviteControlador.Save();
                }
            }
            this.Close();
        }
    }
}
