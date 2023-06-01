namespace e_Agenda.WinApp.ModuloCompromisso
{
    public class RepositorioCompromissoEmArquivo : RepositorioEmArquivoBase<Compromisso>, IRepositorioCompromisso
    {
        protected override string ObterNomeArquivo()
        {
            return "ModuloCompromisso/Compromissos.json";
        }

        public List<Compromisso> SelecionarCompromissosPassados(DateTime hoje)
        {
            return registros.Where(x => x.data.Date < hoje.Date).ToList();
        }

        public List<Compromisso> SelecionarCompromissosFuturos(DateTime dataInicio, DateTime dataFinal)
        {
            return registros
                .Where(x => x.data > dataInicio)
                .Where(x => x.data < dataFinal)
                .ToList();
        }       
    }
}
