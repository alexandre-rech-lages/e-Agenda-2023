using e_Agenda.Dominio.ModuloCompromisso;

namespace e_Agenda.Infra.Dados.Memoria.ModuloCompromisso
{
    public class RepositorioCompromissoEmMemoria : RepositorioEmMemoriaBase<Compromisso>, IRepositorioCompromisso
    {
        public RepositorioCompromissoEmMemoria(List<Compromisso> compromissos) : base(compromissos) 
        { 
        }        

        public List<Compromisso> SelecionarCompromissosPassados(DateTime hoje)
        {
            return listaRegistros.Where(x => x.data.Date < hoje.Date).ToList();
        }

        //Selecionar Compromissos Futuros ( dataInicio, dataFinal)
        public List<Compromisso> SelecionarCompromissosFuturos(DateTime dataInicio, DateTime dataFinal)
        {
            return listaRegistros
                .Where(x => x.data > dataInicio)
                .Where(x => x.data < dataFinal)
                .ToList();
        }


    }
}
