using System.Runtime.Serialization.Formatters.Binary;

namespace e_Agenda.WinApp.ModuloTarefa
{
    public class RepositorioTarefaEmArquivo : IRepositorioTarefa
    {
        private static int contador;

        public void Inserir(Tarefa novaTarefa)
        {
            contador++;
            novaTarefa.id = contador;

            //serialização binário
            BinaryFormatter serializador = new BinaryFormatter();

            MemoryStream tarefaStream = new MemoryStream();

            serializador.Serialize(tarefaStream, novaTarefa);

            byte[] tarefaEmBytes = tarefaStream.ToArray();

            File.WriteAllBytes($"C:\\temp\\tarefas\\tarefa_{novaTarefa.id}.bin", tarefaEmBytes);

            //serialização xml
            //serialização json
            //serialização csv
        }

        public void Editar(int id, Tarefa tarefaAtualizada)
        {
            Tarefa tarefaSelecionada = 


            //serialização binário
            BinaryFormatter serializador = new BinaryFormatter();

            MemoryStream tarefaStream = new MemoryStream();

            serializador.Serialize(tarefaStream, tarefaAtualizada);

            byte[] tarefaEmBytes = tarefaStream.ToArray();

            File.WriteAllBytes($"C:\\temp\\tarefas\\tarefa_{tarefaAtualizada.id}.bin", tarefaEmBytes);
        }

        public void Excluir(Tarefa tarefaSelecionada)
        {
            File.Delete($"C:\\temp\\tarefas\\tarefa_{tarefaSelecionada.id}.bin");
        }

        public List<Tarefa> SelecionarConcluidas()
        {
            List<Tarefa> tarefasConcluidas =
                SelecionarTodos()
                .Where(x => x.percentualConcluido == 100)
                .ToList();

            return tarefasConcluidas;
        }

        public List<Tarefa> SelecionarPendentes()
        {
            List<Tarefa> tarefasPendentes =
                SelecionarTodos()
                .Where(x => x.percentualConcluido < 100)
                .ToList();

            return tarefasPendentes;
        }

        public Tarefa SelecionarPorId(int id)
        {
            Tarefa tarefa =
                SelecionarTodos()
                .FirstOrDefault(x => x.id == id);

            return tarefa;
        }

        public List<Tarefa> SelecionarTodosOrdenadosPorPrioridade()
        {
            List<Tarefa> tarefasOrdenadas =
                SelecionarTodos()
                .OrderByDescending(x => x.prioridade)
                .ToList();

            return tarefasOrdenadas;
        }

        private static List<Tarefa> SelecionarTodos()
        {
            List<Tarefa> tarefas = new List<Tarefa>();

            string[] arquivos = Directory.GetFiles("C:\\temp\\tarefas");

            foreach (string arquivoTarefa in arquivos)
            {
                BinaryFormatter serializador = new BinaryFormatter();

                byte[] tarefaEmBytes = File.ReadAllBytes(arquivoTarefa);

                MemoryStream tarefaStream = new MemoryStream(tarefaEmBytes);

                Tarefa tarefa = (Tarefa)serializador.Deserialize(tarefaStream);

                tarefas.Add(tarefa);
            }

            contador = tarefas.Max(x => x.id);

            return tarefas;
        }
    }
}
