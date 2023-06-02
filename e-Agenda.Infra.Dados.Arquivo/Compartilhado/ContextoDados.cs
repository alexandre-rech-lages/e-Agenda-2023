using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.Dominio.ModuloDespesa;
using e_Agenda.Dominio.ModuloTarefa;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace e_Agenda.Infra.Dados.Arquivo.Compartilhado
{
    public class ContextoDados //container
    {
        private const string NOME_ARQUIVO = "Compartilhado\\e-Agenda.json";

        public List<Contato> contatos;

        public List<Compromisso> compromissos;

        public List<Tarefa> tarefas;

        public List<Categoria> categorias;

        public List<Despesa> despesas;

        public ContextoDados()
        {
            contatos = new List<Contato>();
            compromissos = new List<Compromisso>();
            tarefas = new List<Tarefa>();
            categorias = new List<Categoria>();
            despesas = new List<Despesa>();
        }

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados)
                CarregarDoArquivoJson();
        }

        public void GravarEmArquivoJson()
        {
            JsonSerializerOptions config = ObterConfiguracoes();

            string registrosJson = JsonSerializer.Serialize(this, config);            

            File.WriteAllText(NOME_ARQUIVO, registrosJson);
        }

        private void CarregarDoArquivoJson()
        {
            JsonSerializerOptions config = ObterConfiguracoes();

            if (File.Exists(NOME_ARQUIVO))
            {
                string registrosJson = File.ReadAllText(NOME_ARQUIVO);

                if (registrosJson.Length > 0)
                {
                    ContextoDados ctx = JsonSerializer.Deserialize<ContextoDados>(registrosJson, config);

                    this.contatos = ctx.contatos;
                    this.compromissos = ctx.compromissos;
                    this.tarefas = ctx.tarefas;
                    this.categorias = ctx.categorias;
                    this.despesas = ctx.despesas;
                }
            }
        }

        private static JsonSerializerOptions ObterConfiguracoes()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;
            opcoes.ReferenceHandler = ReferenceHandler.Preserve;

            return opcoes;
        }
    }
}
