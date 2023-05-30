namespace e_Agenda.WinApp.ModuloDespesa
{
    public class RepositorioCategoria : RepositorioEmMemoriaBase<Categoria>
    {
        public RepositorioCategoria(List<Categoria> categorias)
        {
            this.listaRegistros = categorias;
        }
    }
}
