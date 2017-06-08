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
    /// Interaction logic for ProjectInfo.xaml
    /// </summary>
    public partial class ProjectInfo : Window
    {
        private TarefaController _tarefaController;
        private List<Tarefa> _taskDone;
        private List<Tarefa> _taskNotDone;
        private User _userLogged;
        private Project _projeto;
        public ProjectInfo(Project projeto, ProjectController projetoControlador,User userLogado)
        {
            InitializeComponent();
            _userLogged = userLogado;
            _tarefaController = new TarefaController(projeto,projetoControlador);
            _taskDone = new List<Tarefa>();
            _taskNotDone = new List<Tarefa>();
            _projeto = projeto;
            for (int i = 0; i < _tarefaController._taskList.Count; i++)
            {
                if (_tarefaController._taskList[i].Complete == 0)
                {
                    _taskNotDone.Add(_tarefaController._taskList[i]);
                }
                else { _taskDone.Add(_tarefaController._taskList[i]); }
            }
            Backlog.ItemsSource = _taskNotDone;
        }

        private void ConcluirTarefas(object sender, RoutedEventArgs e)
        {
            bool worked = false;
            List<Tarefa> tarefasCompletadas = new List<Tarefa>();
            for (int i = 0; i < Backlog.Items.Count; i++)
            {
                CheckBox verify = Backlog.Columns[2].GetCellContent(Backlog.Items[i]) as CheckBox;
                if (verify.IsChecked == true && (_taskNotDone[i].User.Name == _userLogged.Name|| _projeto.Owner.Name == _userLogged.Name ))
                {
                    _taskNotDone[i].Complete = 1;
                    MessageBox.Show("Tarefa concluida!");
                    worked = true;
                }
            }
            if (!worked) { MessageBox.Show("Esta tarefa não lhe pertence."); }
            _tarefaController.Save();
            this.Close();
        }


    }
}
