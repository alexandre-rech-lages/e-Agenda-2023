namespace e_Agenda.WinApp.ModuloDespesa
{
    public class ControladorDespesa : ControladorBase
    {
        private TabelaDespesaControl tabelaDespesa;
        private IRepositorioDespesa repositorioDespesa;

        public ControladorDespesa(IRepositorioDespesa repositorioDespesa)
        {
            this.repositorioDespesa = repositorioDespesa;
        }

        public override string ToolTipInserir => "Inserir Nova Despesa";

        public override string ToolTipEditar => "Editar Despesa Existente";

        public override string ToolTipExcluir => "Excluir Despesa Existente";

        public override void Inserir()
        {
            TelaDespesaForm telaDespesa = new TelaDespesaForm();

            DialogResult opcaoEscolhida = telaDespesa.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Despesa novaDespesa = telaDespesa.ObterDespesa();
                repositorioDespesa.Inserir(novaDespesa);
            }
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }        

        public override UserControl ObterListagem()
        {
            tabelaDespesa = new TabelaDespesaControl();

            List<Despesa> despesas = repositorioDespesa.SelecionarTodos();

            tabelaDespesa.AtualizarDespesas(despesas);

            return tabelaDespesa;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Despesas";
        }
    }
}
