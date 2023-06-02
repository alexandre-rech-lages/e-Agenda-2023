namespace e_Agenda.WinApp.ModuloDespesa
{
    public class RepositorioCategoriaEmMemoria : RepositorioEmMemoriaBase<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoriaEmMemoria(List<Categoria> categorias) : base(categorias) 
        {
        }        
    }
}
