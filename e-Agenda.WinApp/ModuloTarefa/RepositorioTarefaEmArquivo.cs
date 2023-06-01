namespace e_Agenda.WinApp.ModuloTarefa
{
    public class RepositorioTarefaEmArquivo : RepositorioEmArquivoBase<Tarefa>, IRepositorioTarefa
    {
        protected override string ObterNomeArquivo()
        {
            return "ModuloTarefa/Tarefas.json";
        }

        public List<Tarefa> SelecionarConcluidas()
        {
            return registros
                    .Where(x => x.percentualConcluido == 100)
                    .ToList();
        }

        public List<Tarefa> SelecionarPendentes()
        {
            return registros
                    .Where(x => x.percentualConcluido < 100)
                    .ToList();
        }

        public List<Tarefa> SelecionarTodosOrdenadosPorPrioridade()
        {
            return registros
                    .OrderByDescending(x => x.prioridade)
                    .ToList();
        }
    }
}