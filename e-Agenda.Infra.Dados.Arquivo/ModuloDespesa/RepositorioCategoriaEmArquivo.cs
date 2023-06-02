using e_Agenda.Dominio.ModuloDespesa;

namespace e_Agenda.Infra.Dados.Arquivo.ModuloDespesa
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
