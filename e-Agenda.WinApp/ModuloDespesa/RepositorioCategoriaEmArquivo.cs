using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace e_Agenda.WinApp.ModuloDespesa
{
    public class RepositorioCategoriaEmArquivo : IRepositorioCategoria
    {
        private static int contador;

        private List<Categoria> categorias = new List<Categoria>();

        private const string NOME_ARQUIVO_CATEGORIAS = "ModuloDespesa/Categorias.json";

        public RepositorioCategoriaEmArquivo()
        {
            if (File.Exists(NOME_ARQUIVO_CATEGORIAS))
                CarregarCategoriasDoArquivoJson();
        }

        public void Inserir(Categoria novaCategoria)
        {
            contador++;
            novaCategoria.id = contador;
            categorias.Add(novaCategoria);

            GravarCategoriasEmArquivoJson();
        }

        public void Editar(int id, Categoria categoriaAtualizada)
        {
            Categoria categoriaSelecionada = SelecionarPorId(id);

            categoriaSelecionada.AtualizarInformacoes(categoriaAtualizada);

            GravarCategoriasEmArquivoJson();
        }

        public void Excluir(Categoria categoriaSelecionada)
        {
            categorias.Remove(categoriaSelecionada);

            GravarCategoriasEmArquivoJson();
        }
              
        public Categoria SelecionarPorId(int id)
        {
            return categorias.FirstOrDefault(x => x.id == id);
        }               

        public List<Categoria> SelecionarTodos()
        {
            return categorias;
        }

        private void GravarCategoriasEmArquivoJson()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;

            string categoriasJson = JsonSerializer.Serialize(categorias, opcoes);

            File.WriteAllText(NOME_ARQUIVO_CATEGORIAS, categoriasJson);
        }

        private void CarregarCategoriasDoArquivoJson()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;

            string categoriasJson = File.ReadAllText(NOME_ARQUIVO_CATEGORIAS);

            if (categoriasJson.Length > 0)
                categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriasJson, opcoes);

            AtualizarContador();
        }

        private void GravarCategoriasEmArquivoBin()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            MemoryStream categoriaStream = new MemoryStream();

            serializador.Serialize(categoriaStream, categorias);

            byte[] categoriasEmBytes = categoriaStream.ToArray();

            File.WriteAllBytes(NOME_ARQUIVO_CATEGORIAS, categoriasEmBytes);
        }

        private void CarregarCategoriasDoArquivoBin()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            byte[] categoriaEmBytes = File.ReadAllBytes(NOME_ARQUIVO_CATEGORIAS);

            MemoryStream categoriaStream = new MemoryStream(categoriaEmBytes);

            categorias = (List<Categoria>)serializador.Deserialize(categoriaStream);

            AtualizarContador();
        }

        private void AtualizarContador()
        {
            if (categorias.Count > 0)
                contador = categorias.Max(x => x.id);
        }
    }
}
