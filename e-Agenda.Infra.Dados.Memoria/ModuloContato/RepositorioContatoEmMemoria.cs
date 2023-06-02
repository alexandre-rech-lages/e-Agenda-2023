using e_Agenda.Dominio.ModuloContato;

namespace e_Agenda.Infra.Dados.Memoria.ModuloContato
{
    public class RepositorioContatoEmMemoria : RepositorioEmMemoriaBase<Contato>, IRepositorioContato
    {
        public RepositorioContatoEmMemoria(List<Contato> contatos) : base(contatos)
        {            
        }        
    }
}
