using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

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
                CarregarContatosDoArquivoJson();
        }

        public void Inserir(Contato novoContato)
        {
            contador++;
            novoContato.id = contador;
            contatos.Add(novoContato);

            GravarContatosEmArquivoJson();
        }

        public void Editar(int id, Contato contatoAtualizado)
        {
            Contato contatoSelecionado = SelecionarPorId(id);

            contatoSelecionado.AtualizarInformacoes(contatoAtualizado);

            GravarContatosEmArquivoJson();
        }

        public void Excluir(Contato contatoSelecionado)
        {
            contatos.Remove(contatoSelecionado);

            GravarContatosEmArquivoJson();
        }

        public Contato SelecionarPorId(int id)
        {
            return contatos.FirstOrDefault(x => x.id == id);
        }        

        public List<Contato> SelecionarTodos()
        {
            return contatos;
        }

        private void GravarContatosEmArquivoJson()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;

            string contatosJson = JsonSerializer.Serialize(contatos, opcoes);

            File.WriteAllText(NOME_ARQUIVO_CONTATOS, contatosJson);
        }

        private void CarregarContatosDoArquivoJson()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;

            string contatosJson = File.ReadAllText(NOME_ARQUIVO_CONTATOS);

            if (contatosJson.Length > 0)
                contatos = JsonSerializer.Deserialize<List<Contato>>(contatosJson, opcoes);

            AtualizarContador();
        }

        private void GravarContatosEmArquivoBin()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            MemoryStream contatoStream = new MemoryStream();

            serializador.Serialize(contatoStream, contatos);

            byte[] contatosEmBytes = contatoStream.ToArray();

            File.WriteAllBytes(NOME_ARQUIVO_CONTATOS, contatosEmBytes);
        }

        private void CarregarContatosDoArquivoBin()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            byte[] contatoEmBytes = File.ReadAllBytes(NOME_ARQUIVO_CONTATOS);

            MemoryStream contatoStream = new MemoryStream(contatoEmBytes);

            contatos = (List<Contato>)serializador.Deserialize(contatoStream);

            AtualizarContador();
        }

        private void AtualizarContador()
        {
            if (contatos.Count > 0) 
                contador = contatos.Max(x => x.id);
        }
    }
}
