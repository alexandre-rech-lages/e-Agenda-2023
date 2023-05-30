namespace e_Agenda.WinApp.ModuloDespesa
{
    public partial class TabelaCategoriaControl : UserControl
    {
        public TabelaCategoriaControl()
        {
            InitializeComponent();

            gridCategorias.ConfigurarGridSomenteLeitura();
            gridCategorias.ConfigurarGridZebrado();

            ConfigurarColunas();
        }

        private void ConfigurarColunas()
        {
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.Name = "Id";
            id.HeaderText = "Id";

            DataGridViewTextBoxColumn titulo = new DataGridViewTextBoxColumn();
            titulo.Name = "Titulo";
            titulo.HeaderText = "Título";

            gridCategorias.Columns.Add(id);
            gridCategorias.Columns.Add(titulo);
        }

        public void AtualizarCategorias(List<Categoria> categorias) 
        {         
            gridCategorias.Rows.Clear();

            foreach (Categoria categoria in categorias)
            {
                gridCategorias.Rows.Add(categoria.id, categoria.titulo);
            }
        }

        public int ObterIdSelecionado()
        {
            if (gridCategorias.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(gridCategorias.SelectedRows[0].Cells["Id"].Value);

            return id;
        }
    }
}
