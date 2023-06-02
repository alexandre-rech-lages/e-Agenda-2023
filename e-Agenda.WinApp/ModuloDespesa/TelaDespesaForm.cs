using e_Agenda.Dominio.ModuloDespesa;

namespace e_Agenda.WinApp.ModuloDespesa
{
    public partial class TelaDespesaForm : Form
    {
        public TelaDespesaForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            CarregarFormasDePagamento();
        }

        private void CarregarFormasDePagamento()
        {
            FormaPgtoDespesaEnum[] formasPgto = Enum.GetValues<FormaPgtoDespesaEnum>();

            foreach (FormaPgtoDespesaEnum formaPgto in formasPgto)
            {
                cmbFormaPgto.Items.Add(formaPgto);
            }
        }

        public Despesa ObterDespesa()
        {
            //pegar as informações dos componentes e agrupar em objeto do tipo despesa

            string descricao = txtDescricao.Text;

            DateTime data = txtData.Value;

            decimal valor = Convert.ToDecimal(txtValor.Text);

            FormaPgtoDespesaEnum formaPgtoDespesa = (FormaPgtoDespesaEnum)cmbFormaPgto.SelectedItem;

            return new Despesa(descricao, data, valor, formaPgtoDespesa);
        }
    }
}
