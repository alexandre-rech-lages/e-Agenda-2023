using e_Agenda.Dominio.ModuloContato;

namespace e_Agenda.Infra.Dados.Arquivo.ModuloContato
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
