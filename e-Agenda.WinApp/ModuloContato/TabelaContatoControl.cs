namespace e_Agenda.WinApp.ModuloContato
{
    public partial class TabelaContatoControl : UserControl
    {
        public TabelaContatoControl()
        {
            InitializeComponent();
            ConfigurarColunas();

            gridContatos.ConfigurarGridZebrado();

            gridContatos.ConfigurarGridSomenteLeitura();
        }


        private void ConfigurarColunas()
        {
            DataGridViewColumn[] colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    Name = "id",
                    HeaderText = "Id"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "nome",
                    HeaderText = "Nome"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "telefone",
                    HeaderText = "Telefone"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "email",
                    HeaderText = "E-mail"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "empresa",
                    HeaderText = "Empresa"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "cargo",
                    HeaderText = "Cargo"
                }
            };

            gridContatos.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Contato> contatos)
        {
            gridContatos.Rows.Clear();

            foreach (Contato contato in contatos)
            {
                gridContatos.Rows.Add(contato.id, contato.nome, contato.telefone, contato.email, contato.empresa, contato.cargo);
            }
        }

        public int ObterIdSelecionado()
        {
            if (gridContatos.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(gridContatos.SelectedRows[0].Cells["id"].Value);                        

            return id;
        }
    }
}