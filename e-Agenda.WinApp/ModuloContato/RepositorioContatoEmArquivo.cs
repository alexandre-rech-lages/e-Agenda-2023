namespace e_Agenda.WinApp.ModuloContato
{
    public class RepositorioContatoEmArquivo : RepositorioEmArquivoBase<Contato>, IRepositorioContato
    {
        public RepositorioContatoEmArquivo(ContextoDados contexto) : base(contexto)
        {
            
        }


        protected override List<Contato> ObterRegistros()
        {
            return contextoDados.contatos;
        }
    }
}
