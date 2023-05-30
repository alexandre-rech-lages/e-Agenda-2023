namespace e_Agenda.WinApp.ModuloContato
{
    public partial class TelaContatoForm : Form
    {
        public TelaContatoForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public Contato ObterContato()
        {
            int id = Convert.ToInt32(txtId.Text);

            string nome = txtNome.Text;

            string telefone = txtTelefone.Text;

            string email = txtEmail.Text;

            string cargo = txtCargo.Text;

            string empresa = txtEmpresa.Text;

            Contato contato = new Contato(nome, telefone, email, cargo, empresa);

            if (id > 0) 
                contato.id = id;

            return contato;                            
        }

        public void ConfigurarTela(Contato contato)
        {
            txtId.Text = contato.id.ToString();

            txtNome.Text = contato.nome;

            txtTelefone.Text = contato.telefone;
            
            txtEmail.Text = contato.email;

            txtCargo.Text = contato.cargo;

            txtEmpresa.Text = contato.empresa;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Contato contato = ObterContato();

            string[] erros = contato.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }           
        }
    }
}
