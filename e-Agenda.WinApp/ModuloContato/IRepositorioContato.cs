namespace e_Agenda.WinApp.ModuloContato
{
    public interface IRepositorioContato
    {
        void Inserir(Contato novoContato);
        void Editar(int id, Contato contato);
        void Excluir(Contato contatoSelecionado);
        List<Contato> SelecionarTodos();
        Contato SelecionarPorId(int id);
    }
}