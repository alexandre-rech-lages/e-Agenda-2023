using System.Runtime.Serialization.Formatters.Binary;

namespace e_Agenda.WinApp.ModuloContato
{
    public class RepositorioContatoEmArquivo : IRepositorioContato
    {
        private static int contador;

        private List<Contato> contatos = new List<Contato>();

        private const string NOME_ARQUIVO_CONTATOS = "ModuloContato/Contatos.json";

        public RepositorioContatoEmArquivo()
        {
            if (File.Exists(NOME_ARQUIVO_CONTATOS))
                CarregarContatosDoArquivo();
        }

        public void Inserir(Contato novoContato)
        {
            contador++;
            novoContato.id = contador;
            contatos.Add(novoContato);

            GravarContatosEmArquivo();
        }

        public void Editar(int id, Contato contatoAtualizado)
        {
            Contato contatoSelecionado = SelecionarPorId(id);

            contatoSelecionado.AtualizarInformacoes(contatoAtualizado);

            GravarContatosEmArquivo();
        }

        public void Excluir(Contato contatoSelecionado)
        {
            contatos.Remove(contatoSelecionado);

            GravarContatosEmArquivo();
        }

        public Contato SelecionarPorId(int id)
        {
            return contatos.FirstOrDefault(x => x.id == id);
        }        

        public List<Contato> SelecionarTodos()
        {
            return contatos;
        }

        private void GravarContatosEmArquivo()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            MemoryStream contatoStream = new MemoryStream();

            serializador.Serialize(contatoStream, contatos);

            byte[] contatosEmBytes = contatoStream.ToArray();

            File.WriteAllBytes(NOME_ARQUIVO_CONTATOS, contatosEmBytes);
        }

        private void CarregarContatosDoArquivo()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            byte[] contatoEmBytes = File.ReadAllBytes(NOME_ARQUIVO_CONTATOS);

            MemoryStream contatoStream = new MemoryStream(contatoEmBytes);

            contatos = (List<Contato>)serializador.Deserialize(contatoStream);
            AtualizarContador();
        }

        private void AtualizarContador()
        {
            contador = contatos.Max(x => x.id);
        }
    }
}
