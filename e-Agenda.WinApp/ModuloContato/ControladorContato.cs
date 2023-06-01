namespace e_Agenda.WinApp.ModuloContato
{
    public class ControladorContato : ControladorBase
    {
        private IRepositorioContato repositorioContato;
        private TabelaContatoControl tabelaContato;

        public ControladorContato(IRepositorioContato repositorioContato)
        {
            this.repositorioContato = repositorioContato;
        }

        public override string ToolTipInserir { get { return "Inserir novo Contato";  } }

        public override string ToolTipEditar { get { return "Editar Contato existente"; } }

        public override string ToolTipExcluir { get { return "Excluir Contato existente"; } }

        public override void Inserir()
        {
            TelaContatoForm telaContato = new TelaContatoForm();

            DialogResult opcaoEscolhida = telaContato.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Contato contato = telaContato.ObterContato();

                repositorioContato.Inserir(contato);                
            }
            CarregarContatos();
        }

        public override void Editar()
        {
            Contato contato = ObterContatoSelecionado();

            if (contato == null)
            {
                MessageBox.Show($"Selecione um contato primeiro!", 
                    "Edição de Contatos",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaContatoForm telaContato = new TelaContatoForm();
            telaContato.ConfigurarTela(contato);

            DialogResult opcaoEscolhida = telaContato.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Contato contatoAtualizado = telaContato.ObterContato();
                repositorioContato.Editar(contatoAtualizado.id, contatoAtualizado);                
            }
            CarregarContatos();
        }

        private Contato ObterContatoSelecionado()
        {
            int id = tabelaContato.ObterIdSelecionado();

            return repositorioContato.SelecionarPorId(id);
        }

        public override void Excluir()
        {            
            Contato contato = ObterContatoSelecionado();

            if (contato == null)
            {
                MessageBox.Show($"Selecione um contato primeiro!", 
                    "Exclusão de Contatos",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o contato {contato.nome}?", "Exclusão de Contatos",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioContato.Excluir(contato);                
            }
            CarregarContatos();
        }

        private void CarregarContatos()
        {
            List<Contato> contatos = repositorioContato.SelecionarTodos();

            tabelaContato.AtualizarRegistros(contatos);            
        }

        public override UserControl ObterListagem()
        {
            if (tabelaContato == null)
                tabelaContato = new TabelaContatoControl();

            CarregarContatos();

            return tabelaContato;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Contatos";            
        }        
    }
}
