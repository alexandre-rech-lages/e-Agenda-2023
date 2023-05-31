namespace e_Agenda.WinApp.ModuloContato
{
    public class RepositorioContatoEmMemoria : RepositorioEmMemoriaBase<Contato>, IRepositorioContato
    {
        public RepositorioContatoEmMemoria(List<Contato> contatos)
        {
            this.listaRegistros = contatos;
        }

        
    }
}
