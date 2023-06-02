namespace e_Agenda.WinApp.ModuloDespesa
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
