namespace e_Agenda.WinApp.ModuloDespesa
{
    public class RepositorioCategoria : RepositorioBase<Categoria>
    {
        public RepositorioCategoria(List<Categoria> categorias)
        {
            this.listaRegistros = categorias;
        }
    }
}
