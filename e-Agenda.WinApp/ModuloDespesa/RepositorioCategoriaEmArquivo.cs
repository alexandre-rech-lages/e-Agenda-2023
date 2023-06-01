namespace e_Agenda.WinApp.ModuloDespesa
{
    public class RepositorioCategoriaEmArquivo : RepositorioEmArquivoBase<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoriaEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }
      
        protected override List<Categoria> ObterRegistros()
        {
            return contextoDados.categorias;
        }
    }
}
