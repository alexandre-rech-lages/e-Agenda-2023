using e_Agenda.Dominio.ModuloDespesa;

namespace e_Agenda.Infra.Dados.Memoria.ModuloDespesa
{
    public class RepositorioCategoriaEmMemoria : RepositorioEmMemoriaBase<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoriaEmMemoria(List<Categoria> categorias) : base(categorias) 
        {
        }        
    }
}
