namespace e_Agenda.WinApp.ModuloContato
{
    public class RepositorioContatoEmArquivo : RepositorioEmArquivoBase<Contato>, IRepositorioContato
    {        
        protected override string ObterNomeArquivo()
        {
            return "ModuloContato/Contatos.json";
        }
    }
}
