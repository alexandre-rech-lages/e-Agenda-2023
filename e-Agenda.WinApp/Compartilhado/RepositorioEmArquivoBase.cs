using System.Text.Json;

namespace e_Agenda.WinApp.Compartilhado
{
    public abstract class RepositorioEmArquivoBase<T> where T : EntidadeBase<T>
    {
        protected List<T> registros = new List<T>();

        private int contador;

        protected abstract string ObterNomeArquivo();

        public RepositorioEmArquivoBase()
        {
            if (File.Exists(ObterNomeArquivo()))
                CarregarDoArquivoJson();
        }

        public void Inserir(T novoRegistro)
        {
            contador++;
            novoRegistro.id = contador;
            registros.Add(novoRegistro);

            GravarEmArquivoJson();
        }

        public void Editar(int id, T registroAtualizado)
        {
            T registroSelecionado = SelecionarPorId(id);

            registroSelecionado.AtualizarInformacoes(registroAtualizado);

            GravarEmArquivoJson();
        }

        public void Excluir(T registroSelecionado)
        {
            registros.Remove(registroSelecionado);

            GravarEmArquivoJson();
        }

        public T SelecionarPorId(int id)
        {
            return registros.FirstOrDefault(x => x.id == id);
        }

        public List<T> SelecionarTodos()
        {
            return registros;
        }
       
        private void GravarEmArquivoJson()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;

            string registrosJson = JsonSerializer.Serialize(registros, opcoes);

            File.WriteAllText(ObterNomeArquivo(), registrosJson);
        }

        protected void CarregarDoArquivoJson()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;

            string registrosJson = File.ReadAllText(ObterNomeArquivo());

            if (registrosJson.Length > 0)
                registros = JsonSerializer.Deserialize<List<T>>(registrosJson, opcoes);

            AtualizarContador();
        }

        private void AtualizarContador()
        {
            if (registros.Count > 0)
                contador = registros.Max(x => x.id);
        }
    }
}
