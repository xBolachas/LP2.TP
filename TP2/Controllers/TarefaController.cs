using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TP2.Models;

namespace TP2.Controllers
{
    public class TarefaController
    {
        public List<Tarefa> _taskList;
        private ProjectController _projectController;
        private UserController _userController;
        private string projetoNome;
        public TarefaController(Project projeto,ProjectController projetoController)
        {
            _taskList = new List<Tarefa>();
            _projectController = projetoController;
            _userController = new UserController();
            string diretorio = Directory.GetCurrentDirectory();
            string ficheiro = diretorio.Replace(@"\bin\Debug", @"\Tarefas\" + projeto.ProjectName + ".txt");
            projetoNome = projeto.ProjectName;
            string[] texto = File.ReadAllLines(ficheiro);
            for (int i = 0; i < texto.Length; i++)
            {
                string[] conteudo = texto[i].Split('/');
                User developer = new User(conteudo[1]);
                Tarefa tarefa = new Tarefa(conteudo[0], developer, int.Parse(conteudo[2]));
                _taskList.Add(tarefa);
            }
        }

        /// <summary>
        /// Apaga o ficheiro das tarefas do projeto apagado.
        /// </summary>
        /// <param name="projetoNome">Nome do projeto apagado.</param>
        public void ApagaFicheiroTarefas(string projetoNome)
        {
            string diretorio = Directory.GetCurrentDirectory();
            string ficheiro = diretorio.Replace(@"\bin\Debug", @"\Tarefas\" + projetoNome + ".txt");
            File.Delete(ficheiro);
        }
        /// <summary>
        /// Adiciona tarefas a um determinado membro da equipa do projeto.
        /// </summary>
        /// <param name="dev">Nome do developer.</param>
        /// <param name="conteudo">Conteudo da tarefa.</param>
        /// <returns>True se a tarefa foi adicionada.</returns>
        public bool AdicionarTarefa(string dev, string conteudo)
        {
            User developer = new User(dev);
            if (_userController.VerificaNome(dev))
            {
                Tarefa novaTarefa = new Tarefa(conteudo,developer,0);
                _taskList.Add(novaTarefa);
                Save();
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// Muda o nome do ficheiro do projeto.
        /// </summary>
        /// <param name="nomeProjeto">Nome do projeto antigo.</param>
        /// <param name="novoNome">Nome do projeto novo.</param>
        public void MudaNome(string nomeProjeto,string novoNome)
        {
            string diretorio = Directory.GetCurrentDirectory();
            string ficheiro = diretorio.Replace(@"\bin\Debug", @"\Tarefas\" + projetoNome + ".txt");
            File.Move(ficheiro, @"C:\Users\Utilizador\Documents\Visual Studio 2015\Projects\LP2\TP2\Tarefas\" + novoNome + ".txt");
        }
        /// <summary>
        /// Grava a base de dados das tarefas de todos os projetos.
        /// </summary>
        public void Save()
        {
            string diretorio = Directory.GetCurrentDirectory();
            string ficheiro = diretorio.Replace(@"\bin\Debug", @"\Tarefas\" + projetoNome + ".txt");
            string[] tarefa = new string[_taskList.Count];
            for (int i = 0; i < _taskList.Count; i++)
            {
                tarefa[i] = _taskList[i].WhatToDo + "/" + _taskList[i].User.Name+"/"+_taskList[i].Complete;
            }
            File.WriteAllLines(ficheiro, tarefa);
        }
    }
}
