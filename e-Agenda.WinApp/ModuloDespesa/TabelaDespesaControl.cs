namespace e_Agenda.WinApp.ModuloDespesa
{
    public partial class TabelaDespesaControl : UserControl
    {
        public TabelaDespesaControl()
        {
            InitializeComponent();

            gridDespesas.ConfigurarGridSomenteLeitura();
            gridDespesas.ConfigurarGridZebrado();

            ConfigurarColunas();
        }

        private void ConfigurarColunas()
        {
            DataGridViewTextBoxColumn[] colunas = new DataGridViewTextBoxColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "id",
                    HeaderText = "Id",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "descricao",
                    HeaderText = "Descrição",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "data",
                    HeaderText = "Data",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "valor",
                    HeaderText = "Valor",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "formaPgto",
                    HeaderText = "Forma de Pagamento",
                }
            };

            gridDespesas.Columns.AddRange(colunas);
        }

        public void AtualizarDespesas(List<Despesa> despesas)
        {
            gridDespesas.Rows.Clear();

            foreach (Despesa despesa in despesas)
            {
                gridDespesas.Rows.Add(despesa.id, despesa.descricao, despesa.data.ToShortDateString(), despesa.valor, despesa.formaPgto);
            }
        }
    }
}
