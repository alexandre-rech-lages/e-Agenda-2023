namespace e_Agenda.WinApp.ModuloDespesa
{
    public class RepositorioCategoriaEmMemoria : RepositorioEmMemoriaBase<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoriaEmMemoria(List<Categoria> categorias)
        {
            this.listaRegistros = categorias;
        }
    }
}
