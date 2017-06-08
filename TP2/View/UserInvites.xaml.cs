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
using System.ComponentModel;

namespace TP2.View
{
    /// <summary>
    /// Interaction logic for UserInvites.xaml
    /// </summary>
    public partial class UserInvites : Window
    {
        Window creatingForm;
        private InviteController _inviteController;
        private ProjectController _projetoControlador;
        private List<Invite> _userLoggedInvites;
        private User _userLogged;

        Func<ProjectController, bool> _projetoControladorAction;
        public UserInvites(User userLogado,ProjectController projectController, Func<ProjectController, bool> projetoControladorAction)
        {
            InitializeComponent();
            _inviteController = new InviteController();
            _projetoControlador = projectController;
            _userLoggedInvites = new List<Invite>();
            _userLogged = userLogado;
            _projetoControladorAction = projetoControladorAction;
            for (int i = 0; i < _inviteController._inviteList.Count; i++)
            {
                if (_inviteController._inviteList[i].Invited.Name == _userLogged.Name)
                {
                    _userLoggedInvites.Add(_inviteController._inviteList[i]);
                }
            }
            InviteGrid.ItemsSource = _userLoggedInvites;
        }
        public Window setCreatingForm
        {
            get { return creatingForm; }
            set { creatingForm = value; }
        }

        private void AcceptInvite(object sender, RoutedEventArgs e)
        {
            List<Invite> acceptedInvites = new List<Invite>();
            List<Project> acceptedProjects = new List<Project>();
            for (int i = 0; i < InviteGrid.Items.Count; i++)
            {
                CheckBox verify = InviteGrid.Columns[1].GetCellContent(InviteGrid.Items[i]) as CheckBox;
                if(verify.IsChecked == true)
                {
                    acceptedInvites.Add(_userLoggedInvites[i]);
                }
            }
            for (int r = 0; r < _projetoControlador._projectList.Count; r++)
            {
                for (int t = 0; t < acceptedInvites.Count; t++)
                {
                    if (_projetoControlador._projectList[r].ProjectName == acceptedInvites[t].Projeto.ProjectName)
                    {
                        acceptedProjects.Add(_projetoControlador._projectList[r]);
                    }
                }
            }
            for (int j = 0; j < acceptedInvites.Count; j++)
            {
                _projetoControlador.AdicionarTeamMember(_userLogged,acceptedProjects[j]);
                _projetoControlador.Save();
                _inviteController.RemoverInvite(acceptedInvites[j]);
                MessageBox.Show("Convite aceite.");
            }
        }

        private void DeclineInvite(object sender, RoutedEventArgs e)
        {
            List<Invite> deniedInvites = new List<Invite>();
            for (int i = 0; i < InviteGrid.Items.Count; i++)
            {
                CheckBox verify = InviteGrid.Columns[1].GetCellContent(InviteGrid.Items[i]) as CheckBox;
                if (verify.IsChecked == true)
                {
                    deniedInvites.Add(_userLoggedInvites[i]);
                }
            }
            for (int j = 0; j < deniedInvites.Count; j++)
            {
                _inviteController.RemoverInvite(deniedInvites[j]);
                MessageBox.Show("Convite rejeitado.");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _projetoControladorAction.Invoke(_projetoControlador);
            creatingForm.Show();
        }

    }
}
