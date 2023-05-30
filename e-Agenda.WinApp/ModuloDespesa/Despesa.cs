namespace e_Agenda.WinApp.ModuloDespesa
{
    public class Despesa : EntidadeBase<Despesa>
    {
        public string descricao;
        public DateTime data;
        public decimal valor;
        public FormaPgtoDespesaEnum formaPgto;

        public List<Categoria> categorias;

        public Despesa(string descricao, DateTime data, decimal valor, FormaPgtoDespesaEnum formaPgto)
        {
            this.descricao = descricao;
            this.data = data;
            this.valor = valor;
            this.formaPgto = formaPgto;
            this.categorias = new List<Categoria>();
        }

        public override void AtualizarInformacoes(Despesa registroAtualizado)
        {
            this.descricao = registroAtualizado.descricao;
            this.data = registroAtualizado.data;
            this.valor = registroAtualizado.valor;
            this.formaPgto = registroAtualizado.formaPgto;
            this.categorias = registroAtualizado.categorias;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(descricao)) 
            {
                erros.Add("O campo 'descrição' é obrigatório");
            }

            if (data == DateTime.MinValue)
            {
                erros.Add("O campo 'data' é obrigatório");
            }

            if (valor <= 0)
            {
                erros.Add("O campo 'valor' precisa ser maior que 0");
            }

            if (formaPgto == FormaPgtoDespesaEnum.Nenhum)
            {
                erros.Add("O campo 'forma de pagamento' é obrigatório");
            }

            return erros.ToArray();
        }
    }
}
