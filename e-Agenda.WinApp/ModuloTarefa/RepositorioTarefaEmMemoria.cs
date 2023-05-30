namespace e_Agenda.WinApp.ModuloTarefa
{

    public class RepositorioTarefaEmMemoria : RepositorioEmMemoriaBase<Tarefa>, IRepositorioTarefa
    {

        public RepositorioTarefaEmMemoria(List<Tarefa> tarefas)
        { 
            listaRegistros = tarefas;
        }

        public List<Tarefa>? SelecionarConcluidas()
        {
            return listaRegistros
                .Where(x => x.percentualConcluido == 100)
                .OrderByDescending(x => x.prioridade)
                .ToList();
        }

        public List<Tarefa>? SelecionarPendentes()
        {
            return listaRegistros
                .Where(x => x.percentualConcluido < 100)
                .OrderByDescending(x => x.prioridade)
                .ToList();
        }

        public List<Tarefa> SelecionarTodosOrdenadosPorPrioridade()
        {
            return listaRegistros
                .OrderByDescending(x => x.prioridade)
                .ToList();
        }
    }
}
