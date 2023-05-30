using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloTarefa
{
    public class RepositorioTarefaEmBancoDados : IRepositorioTarefa
    {
        public void Editar(int id, Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Tarefa tarefaSelecionada)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Tarefa novaTarefa)
        {
            throw new NotImplementedException();
        }

        public List<Tarefa> SelecionarConcluidas()
        {
            throw new NotImplementedException();
        }

        public List<Tarefa> SelecionarPendentes()
        {
            throw new NotImplementedException();
        }

        public Tarefa SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tarefa> SelecionarTodosOrdenadosPorPrioridade()
        {
            throw new NotImplementedException();
        }
    }
}
