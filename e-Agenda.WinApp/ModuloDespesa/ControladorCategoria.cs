namespace e_Agenda.WinApp.ModuloDespesa
{
    public class ControladorCategoria : ControladorBase
    {
        private RepositorioCategoria repositorioCategoria;
        private TabelaCategoriaControl tabelaCategorias;

        public ControladorCategoria(RepositorioCategoria repositorioCategoria)
        {
            this.repositorioCategoria = repositorioCategoria;
        }

        public override string ToolTipInserir => "Inserir nova Categoria";

        public override string ToolTipEditar => "Editar Categoria existente";

        public override string ToolTipExcluir => "Excluir Categoria existente";

        public override void Inserir()
        {
            TelaCategoriaForm telaCategoria = new TelaCategoriaForm();
            DialogResult opcaoEscolhida = telaCategoria.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Categoria novaCategoria = telaCategoria.ObterCategoria();

                repositorioCategoria.Inserir(novaCategoria);
            }

            CarregarCategorias();
        }

        public override void Editar()
        {
            Categoria categoria = ObterCategoriaSelecionada();

            if (categoria == null)
            {
                MessageBox.Show(
                    "Selecione uma categoria primeiro",
                    "Edição de Categoria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaCategoriaForm telaCategoria = new TelaCategoriaForm();

            telaCategoria.ConfigurarTela(categoria);

            DialogResult opcaoEscolhida = telaCategoria.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Categoria categoriaAtualizada = telaCategoria.ObterCategoria();

                repositorioCategoria.Editar(categoriaAtualizada.id, categoriaAtualizada);                
            }

            CarregarCategorias();
        }
       
        public override void Excluir()
        {
            Categoria categoria = ObterCategoriaSelecionada();

            if (categoria == null) 
            {
                MessageBox.Show(
                    "Selecione uma categoria primeiro", 
                    "Exclusão de Categoria",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show(
                $"Deseja excluir a categoria {categoria.titulo}?",
               "Exclusão de Categoria", 
               MessageBoxButtons.OKCancel, 
               MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioCategoria.Excluir(categoria);                
            }

            CarregarCategorias();
        }

        public override UserControl ObterListagem()
        {
            tabelaCategorias = new TabelaCategoriaControl();

            CarregarCategorias();

            return tabelaCategorias;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Categorias";
        }

        private void CarregarCategorias()
        {
            List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

            tabelaCategorias.AtualizarCategorias(categorias);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {categorias.Count} categoria(s)");
        }

        private Categoria ObterCategoriaSelecionada()
        {
            int id = tabelaCategorias.ObterIdSelecionado();

            return repositorioCategoria.SelecionarPorId(id);
        }

    }
}
