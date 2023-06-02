using e_Agenda.Dominio.ModuloContato;

namespace e_Agenda.Dominio.ModuloCompromisso
{
    [Serializable]
    public class Compromisso : EntidadeBase<Compromisso>
    {
        public string assunto;

        public DateTime data;

        public TimeSpan horarioInicio;

        public TimeSpan horarioFinal;

        public Contato contato;

        public string localPresencial;

        public string localOnline;

        public TipoLocalEnum tipoLocal;

        public Compromisso() //parameterless
        {

        }

        public Compromisso(int id, string assunto, DateTime data, TimeSpan horarioInicio, TimeSpan horarioFinal,
            Contato contato, string local, TipoLocalEnum tipoLocal)
        {
            this.id = id;
            this.assunto = assunto;
            this.data = data;
            this.horarioInicio = horarioInicio;
            this.horarioFinal = horarioFinal;
            this.contato = contato;
            this.tipoLocal = tipoLocal;

            if (tipoLocal == TipoLocalEnum.Online)
                localOnline = local;
            else
                localPresencial = local;
        }

        public Compromisso(string assunto, DateTime data, TimeSpan horarioInicio, TimeSpan horarioFinal,
            Contato contato, string local, TipoLocalEnum tipoLocal)
        {
            this.id = id;
            this.assunto = assunto;
            this.data = data;
            this.horarioInicio = horarioInicio;
            this.horarioFinal = horarioFinal;
            this.contato = contato;
            this.tipoLocal = tipoLocal;

            if (tipoLocal == TipoLocalEnum.Online)
                localOnline = local;
            else
                localPresencial = local;
        }

        public override string ToString()
        {
            return "Id: " + id + ", " + assunto + ", Data: " + data;
        }

        public override void AtualizarInformacoes(Compromisso registroAtualizado)
        {
            assunto = registroAtualizado.assunto;
            data = registroAtualizado.data;
            horarioInicio = registroAtualizado.horarioInicio;
            horarioFinal = registroAtualizado.horarioFinal;
            contato = registroAtualizado.contato;
            tipoLocal = registroAtualizado.tipoLocal;

            if (registroAtualizado.tipoLocal == TipoLocalEnum.Online)
                localOnline = registroAtualizado.localOnline;
            else
                localPresencial = registroAtualizado.localPresencial;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(assunto))
                erros.Add("O campo 'assunto' é obrigatório");

            return erros.ToArray();
        }

        public override bool Equals(object? obj)
        {
            return obj is Compromisso compromisso &&
                   id == compromisso.id &&
                   assunto == compromisso.assunto &&
                   data == compromisso.data &&
                   horarioInicio.Equals(compromisso.horarioInicio) &&
                   horarioFinal.Equals(compromisso.horarioFinal) &&
                   EqualityComparer<Contato>.Default.Equals(contato, compromisso.contato) &&
                   localPresencial == compromisso.localPresencial &&
                   localOnline == compromisso.localOnline &&
                   tipoLocal == compromisso.tipoLocal;
        }
    }
}
