namespace e_Agenda.WinApp.ModuloDespesa
{
    public partial class TelaCategoriaForm : Form
    {
        public TelaCategoriaForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }

        public Categoria ObterCategoria()
        {
            int id = Convert.ToInt32(txtId.Text);

            string titulo = txtTitulo.Text;

            return new Categoria(id, titulo);
        }

        public void ConfigurarTela(Categoria categoria)
        {
            txtId.Text = categoria.id.ToString();

            txtTitulo.Text = categoria.titulo;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Categoria categoria = ObterCategoria();

            string[] erros = categoria.Validar();

            if (erros.Count() > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
    }
}
