using e_Agenda.Dominio.ModuloDespesa;

namespace e_Agenda.Infra.Dados.Memoria.ModuloDespesa
{
    public class RepositorioDespesaEmMemoria : RepositorioEmMemoriaBase<Despesa>, IRepositorioDespesa
    {
        public RepositorioDespesaEmMemoria(List<Despesa> despesas) : base(despesas)
        {
        }
    }
}
