namespace e_Agenda.WinApp.ModuloDespesa
{
    public class Categoria : EntidadeBase<Categoria>
    {
        public string titulo;

        public List<Despesa> despesas;


        public Categoria(string titulo)
        {
            this.titulo = titulo;
            this.despesas = new List<Despesa>();    
        }

        public Categoria(int id, string titulo)
        {
            this.id = id;
            this.titulo = titulo;
            this.despesas = new List<Despesa>();
        }

        public override void AtualizarInformacoes(Categoria registroAtualizado)
        {
            this.titulo = registroAtualizado.titulo;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(titulo))
            {
                erros.Add("O campo 'título' é obrigatório");
            }

            return erros.ToArray();
        }
    }
}
