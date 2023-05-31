using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace e_Agenda.WinApp.ModuloCompromisso
{
    //serialização xml - integração entre sistemas
    //serialização json
    //serialização binária-bin
    public class RepositorioCompromissoEmArquivo : IRepositorioCompromisso
    {
        private static int contador;

        private List<Compromisso> compromissos = new List<Compromisso>();

        private const string NOME_ARQUIVO_COMPROMISSOS = "ModuloCompromisso/Compromissos.json";

        public RepositorioCompromissoEmArquivo()
        {
            if (File.Exists(NOME_ARQUIVO_COMPROMISSOS))
                CarregarCompromissosDoArquivoJson();
        }

        public void Inserir(Compromisso novoCompromisso)
        {
            contador++;
            novoCompromisso.id = contador;
            compromissos.Add(novoCompromisso);

            GravarCompromissosEmArquivoJson();
        }

        public void Editar(int id, Compromisso compromissoAtualizado)
        {
            Compromisso compromissoSelecionado = SelecionarPorId(id);

            compromissoSelecionado.AtualizarInformacoes(compromissoAtualizado);

            GravarCompromissosEmArquivoJson();
        }

        public void Excluir(Compromisso compromissoSelecionado)
        {
            compromissos.Remove(compromissoSelecionado);

            GravarCompromissosEmArquivoJson();
        }

        public Compromisso SelecionarPorId(int id)
        {
            return compromissos.FirstOrDefault(x => x.id == id);
        }

        public List<Compromisso> SelecionarTodos()
        {
            return compromissos;
        }

        public List<Compromisso> SelecionarCompromissosPassados(DateTime hoje)
        {
            return compromissos.Where(x => x.data.Date < hoje.Date).ToList();
        }

        public List<Compromisso> SelecionarCompromissosFuturos(DateTime dataInicio, DateTime dataFinal)
        {
            return compromissos
                .Where(x => x.data > dataInicio)
                .Where(x => x.data < dataFinal)
                .ToList();
        }

        #region serialização em json

        private void GravarCompromissosEmArquivoJson()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;

            string compromissosJson = JsonSerializer.Serialize(compromissos, opcoes);

            File.WriteAllText(NOME_ARQUIVO_COMPROMISSOS, compromissosJson);
        }

        private void CarregarCompromissosDoArquivoJson()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            
            string compromissosJson = File.ReadAllText(NOME_ARQUIVO_COMPROMISSOS);

            if (compromissosJson.Length > 0)
                compromissos = JsonSerializer.Deserialize<List<Compromisso>>(compromissosJson, opcoes);
        }

        #endregion

        #region serialização em xml
        private void GravarCompromissosEmArquivoXml()
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Compromisso>));

            MemoryStream compromissoStream = new MemoryStream();

            serializador.Serialize(compromissoStream, compromissos);

            byte[] compromissosEmBytes = compromissoStream.ToArray();

            //D:\Projetos Visual Studio\2023\e-Agenda\e-Agenda.WinApp\bin\Debug\net6.0-windows\ModuloCompromisso\Compromissos.bin
            File.WriteAllBytes(NOME_ARQUIVO_COMPROMISSOS, compromissosEmBytes);
        }

        private void CarregarCompromissosDoArquivoXml()
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Compromisso>));

            byte[] compromissoEmBytes = File.ReadAllBytes(NOME_ARQUIVO_COMPROMISSOS);

            MemoryStream compromissoStream = new MemoryStream(compromissoEmBytes);

            if (compromissoStream.Length > 10)
            {
                compromissos = (List<Compromisso>)serializador.Deserialize(compromissoStream);
                AtualizarContador();
            }
        }

        #endregion

        #region serialização binaria
        private void GravarCompromissosEmArquivoBinario()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            MemoryStream compromissoStream = new MemoryStream();

            serializador.Serialize(compromissoStream, compromissos);

            byte[] compromissosEmBytes = compromissoStream.ToArray();

            //D:\Projetos Visual Studio\2023\e-Agenda\e-Agenda.WinApp\bin\Debug\net6.0-windows\ModuloCompromisso\Compromissos.bin
            File.WriteAllBytes(NOME_ARQUIVO_COMPROMISSOS, compromissosEmBytes);
        }
        private void CarregarCompromissosDoArquivoBinario()
        {
            BinaryFormatter serializador = new BinaryFormatter();

            byte[] compromissoEmBytes = File.ReadAllBytes(NOME_ARQUIVO_COMPROMISSOS);

            MemoryStream compromissoStream = new MemoryStream(compromissoEmBytes);

            if (compromissoStream.Length > 10)
            {
                compromissos = (List<Compromisso>)serializador.Deserialize(compromissoStream);
                AtualizarContador();
            }
        }
        #endregion

        private void AtualizarContador()
        {
            contador = compromissos.Max(x => x.id);
        }

    }
}
