using System.Runtime.Serialization.Formatters.Binary;

namespace e_Agenda.WinApp.ModuloDespesa
{
    public class RepositorioCategoriaEmArquivo : IRepositorioCategoria
    {
        private static int contador;

        private List<Categoria> categorias = new List<Categoria>();

        private const string NOME_ARQUIVO_CATEGORIAS = "ModuloCategoria/Categorias.json";

        public RepositorioCategoriaEmArquivo()
        {
            if (File.Exists(NOME_ARQUIVO_CATEGORIAS))
                CarregarCategoriasDoArquivo();
        }

        public void Inserir(Categoria novaCategoria)
        {
            contador++;
            novaCategoria.id = contador;
            categorias.Add(novaCategoria);

            GravarCategoriasEmArquivo();
        }

        public void Editar(int id, Categoria categoriaAtualizada)
        {
            Categoria categoriaSelecionada = SelecionarPorId(id);

            categoriaSelecionada.AtualizarInformacoes(categoriaAtualizada);

            GravarCategoriasEmArquivo();
        }

        public void Excluir(Categoria categoriaSelecionada)
        {
            categorias.Remove(categoriaSelecionada);

            GravarCategoriasEmArquivo();
        }
              
        public Categoria SelecionarPorId(int id)
        {
            return categorias.FirstOrDefault(x => x.id == id);
        }               

        public List<Categoria> SelecionarTodos()
        {
            return categorias;
        }

        private void GravarCategoriasEmArquivo()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            MemoryStream categoriaStream = new MemoryStream();

            serializador.Serialize(categoriaStream, categorias);

            byte[] categoriasEmBytes = categoriaStream.ToArray();

            File.WriteAllBytes(NOME_ARQUIVO_CATEGORIAS, categoriasEmBytes);
        }

        private void CarregarCategoriasDoArquivo()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            byte[] categoriaEmBytes = File.ReadAllBytes(NOME_ARQUIVO_CATEGORIAS);

            MemoryStream categoriaStream = new MemoryStream(categoriaEmBytes);

            categorias = (List<Categoria>)serializador.Deserialize(categoriaStream);

            AtualizarContador();
        }

        private void AtualizarContador()
        {
            contador = categorias.Max(x => x.id);
        }
    }
}
