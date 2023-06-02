using e_Agenda.Dominio.ModuloDespesa;

namespace e_Agenda.Infra.Dados.Arquivo.ModuloDespesa
{

    public class RepositorioDespesaEmArquivo : RepositorioEmArquivoBase<Despesa>, IRepositorioDespesa
    {
        public RepositorioDespesaEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Despesa> ObterRegistros()
        {
            return contextoDados.despesas;
        }
    }
}
