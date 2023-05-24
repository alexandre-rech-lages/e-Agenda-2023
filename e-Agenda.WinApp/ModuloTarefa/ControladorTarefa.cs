using e_Agenda.WinApp.Compartilhado;

namespace e_Agenda.WinApp.ModuloTarefa
{
    public class ControladorTarefa : ControladorBase
    {
        private RepositorioTarefa repositorioTarefa;
        private ListagemTarefaControl listagemTarefas;

        public ControladorTarefa(RepositorioTarefa repositorioTarefa)
        {
            this.repositorioTarefa = repositorioTarefa;
        }

        public override string ToolTipInserir { get { return "Inserir nova Tarefa"; } }

        public override string ToolTipEditar { get { return "Editar Tarefa existente"; } }

        public override string ToolTipExcluir { get { return "Excluir Tarefa existente"; } }

        public override void Editar()
        {
            Tarefa tarefaSelecionada = listagemTarefas.ObterTarefaSelecionada();

            TelaTarefaForm telaTarefa = new TelaTarefaForm(edicaoDeTarefa: true);

            telaTarefa.ConfigurarTela(tarefaSelecionada);

            DialogResult opcaoEscolhida = telaTarefa.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Tarefa tarefa = telaTarefa.ObterTarefa();

                repositorioTarefa.Editar(tarefa.id, tarefa);

                CarregarTarefas();
            }
        }

        public override void Excluir()
        { 
        
        }

        public override void Inserir()
        {
            TelaTarefaForm telaTarefa = new TelaTarefaForm(edicaoDeTarefa: false);

            DialogResult opcaoEscolhida = telaTarefa.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Tarefa novaTarefa = telaTarefa.ObterTarefa();

                repositorioTarefa.Inserir(novaTarefa);

                CarregarTarefas();
            }
        }

        private void CarregarTarefas()
        {
            List<Tarefa> tarefas = repositorioTarefa.SelecionarTodos();

            listagemTarefas.AtualizarRegistros(tarefas);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {tarefas.Count} tarefa(s)");
        }

        public override UserControl ObterListagem()
        {            
            if (listagemTarefas ==  null)
                listagemTarefas = new ListagemTarefaControl();

            CarregarTarefas();

            return listagemTarefas;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Tarefas";
        }
    }
}
