namespace e_Agenda.WinApp.ModuloDespesa
{
    public class RepositorioCategoriaEmArquivo : RepositorioEmArquivoBase<Categoria>, IRepositorioCategoria
    {      
        protected override string ObterNomeArquivo()
        {
            return "ModuloDespesa/Categorias.json";
        }
    }
}
