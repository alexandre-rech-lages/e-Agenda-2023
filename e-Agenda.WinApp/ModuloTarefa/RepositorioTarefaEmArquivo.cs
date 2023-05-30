using System.Runtime.Serialization.Formatters.Binary;

namespace e_Agenda.WinApp.ModuloTarefa
{

    //serialização xml
    //serialização json
    //serialização csv
    //serialização binária-bin
    public class RepositorioTarefaEmArquivo : IRepositorioTarefa
    {
        private static int contador;

        private List<Tarefa> tarefas = new List<Tarefa>();

        private const string NOME_ARQUIVO_TAREFAS = "C:\\temp\\tarefas\\dados-tarefas.bin";

        public RepositorioTarefaEmArquivo()
        {
            if (File.Exists(NOME_ARQUIVO_TAREFAS))
                CarregarTarefasDoArquivo();
        }

        public void Inserir(Tarefa novaTarefa)
        {
            contador++;
            novaTarefa.id = contador;
            tarefas.Add(novaTarefa);

            GravarTarefasEmArquivo();
        }

        public void Editar(int id, Tarefa tarefaAtualizada)
        {
            Tarefa tarefaSelecionada = SelecionarPorId(id);

            tarefaSelecionada.AtualizarInformacoes(tarefaAtualizada);

            GravarTarefasEmArquivo();
        }

        public void Excluir(Tarefa tarefaSelecionada)
        {
            tarefas.Remove(tarefaSelecionada);

            GravarTarefasEmArquivo();
        }

        public List<Tarefa> SelecionarConcluidas()
        {
            return tarefas
                    .Where(x => x.percentualConcluido == 100)
                    .ToList();
        }

        public List<Tarefa> SelecionarPendentes()
        {
            return tarefas
                    .Where(x => x.percentualConcluido < 100)
                    .ToList();
        }

        public Tarefa SelecionarPorId(int id)
        {
            Tarefa tarefa = tarefas.FirstOrDefault(x => x.id == id);

            return tarefa;
        }

        public List<Tarefa> SelecionarTodosOrdenadosPorPrioridade()
        {
            return tarefas
                    .OrderByDescending(x => x.prioridade)
                    .ToList();
        }

        public List<Tarefa> SelecionarTodos()
        {
            return tarefas;
        }

        private void CarregarTarefasDoArquivo()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            byte[] tarefaEmBytes = File.ReadAllBytes(NOME_ARQUIVO_TAREFAS);

            MemoryStream tarefaStream = new MemoryStream(tarefaEmBytes);

            tarefas = (List<Tarefa>)serializador.Deserialize(tarefaStream);

            AtualizarContador();
        }

        private void AtualizarContador()
        {
            contador = tarefas.Max(x => x.id);
        }

        private void GravarTarefasEmArquivo()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            MemoryStream tarefaStream = new MemoryStream();

            serializador.Serialize(tarefaStream, tarefas);

            byte[] tarefasEmBytes = tarefaStream.ToArray();

            File.WriteAllBytes(NOME_ARQUIVO_TAREFAS, tarefasEmBytes);
        }
    }
}
