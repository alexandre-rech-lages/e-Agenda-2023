namespace e_Agenda.WinApp.ModuloCompromisso
{
    public interface IRepositorioCompromisso
    {
        void Inserir(Compromisso compromisso);
        void Editar(int id, Compromisso compromisso);
        void Excluir(Compromisso compromissoSelecionado);
        List<Compromisso>? SelecionarCompromissosFuturos(DateTime dataInicio, DateTime dataFinal);
        List<Compromisso>? SelecionarCompromissosPassados(DateTime now);
        List<Compromisso>? SelecionarTodos();
        Compromisso SelecionarPorId(int id);
    }
}
