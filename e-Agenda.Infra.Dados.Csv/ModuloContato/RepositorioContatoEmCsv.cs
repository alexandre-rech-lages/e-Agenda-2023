using Csv;
using e_Agenda.Dominio.ModuloContato;

namespace e_Agenda.Infra.Dados.Csv.ModuloContato
{
    public class RepositorioContatoEmCsv : IRepositorioContato
    {
        private int contador = 0;

        List<Contato> contatos = new List<Contato>();

        public void Inserir(Contato novoContato)
        {
            novoContato.id = ++contador;

            contatos.Add(novoContato);

            GravarEmArquivoCsv();
        }

        private void GravarEmArquivoCsv()
        {
            var columnNames = new[] { "Id", "Nome", "Telefone", "Email", "Cargo", "Empresa" };

            List<string[]> rows = new List<string[]>();

            foreach(Contato c in contatos)
            {
                rows.Add(new string[] { c.id.ToString(), c.nome, c.telefone, c.email, c.cargo, c.empresa });
            }

            var csv = CsvWriter.WriteToText(columnNames, rows, ';');
            File.WriteAllText("C:\\temp\\contatos.csv", csv);
           
        }

        public void Editar(int id, Contato contato)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Contato contatoSelecionado)
        {
            throw new NotImplementedException();
        }        

        public Contato SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contato> SelecionarTodos()
        {
            return contatos;
        }
    }
}
