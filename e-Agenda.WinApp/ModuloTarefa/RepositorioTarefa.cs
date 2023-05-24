using e_Agenda.WinApp.Compartilhado;


namespace e_Agenda.WinApp.ModuloTarefa
{
    public class RepositorioTarefa : RepositorioBase<Tarefa>
    {

        public RepositorioTarefa(List<Tarefa> tarefas)
        { 
            listaRegistros = tarefas;
        }
    }
}
