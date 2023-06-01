using e_Agenda.WinApp.ModuloDespesa;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

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

        private const string NOME_ARQUIVO_TAREFAS = "ModuloTarefa/Tarefas.json";

        public RepositorioTarefaEmArquivo()
        {
            if (File.Exists(NOME_ARQUIVO_TAREFAS))
                CarregarTarefasDoArquivoJson();
        }

        public void Inserir(Tarefa novaTarefa)
        {
            contador++;
            novaTarefa.id = contador;
            tarefas.Add(novaTarefa);

            GravarTarefasEmArquivoJson();
        }

        public void Editar(int id, Tarefa tarefaAtualizada)
        {
            Tarefa tarefaSelecionada = SelecionarPorId(id);

            tarefaSelecionada.AtualizarInformacoes(tarefaAtualizada);

            GravarTarefasEmArquivoJson();
        }

        public void Excluir(Tarefa tarefaSelecionada)
        {
            tarefas.Remove(tarefaSelecionada);

            GravarTarefasEmArquivoJson();
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
            return tarefas.FirstOrDefault(x => x.id == id);
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

        private void GravarTarefasEmArquivoJson()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;

            string tarefasJson = JsonSerializer.Serialize(tarefas, opcoes);

            File.WriteAllText(NOME_ARQUIVO_TAREFAS, tarefasJson);
        }

        private void CarregarTarefasDoArquivoJson()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;

            string tarefasJson = File.ReadAllText(NOME_ARQUIVO_TAREFAS);

            if (tarefasJson.Length > 0)
                tarefas = JsonSerializer.Deserialize<List<Tarefa>>(tarefasJson, opcoes);

            AtualizarContador();
        }

        private void GravarTarefasEmArquivoBin()
        {
            BinaryFormatter serializador = new BinaryFormatter();            

            MemoryStream tarefaStream = new MemoryStream();

            serializador.Serialize(tarefaStream, tarefas);

            byte[] tarefasEmBytes = tarefaStream.ToArray();

            File.WriteAllBytes(NOME_ARQUIVO_TAREFAS, tarefasEmBytes);
        }

        private void CarregarTarefasDoArquivoBin()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            byte[] tarefaEmBytes = File.ReadAllBytes(NOME_ARQUIVO_TAREFAS);

            MemoryStream tarefaStream = new MemoryStream(tarefaEmBytes);

            if (tarefaStream.Length > 10)
            {
                tarefas = (List<Tarefa>)serializador.Deserialize(tarefaStream);

                AtualizarContador();
            }
        }

        private void AtualizarContador()
        {
            if (tarefas.Count > 0)
                contador = tarefas.Max(x => x.id);
        }
    }
}