namespace e_Agenda.WinApp.ModuloCompromisso
{
    public partial class TabelaCompromissoControl : UserControl
    {
        public TabelaCompromissoControl()
        {
            InitializeComponent();
            ConfigurarColunas();

            gridCompromissos.ConfigurarGridZebrado();

            gridCompromissos.ConfigurarGridSomenteLeitura();
        }


        private void ConfigurarColunas()
        {
            DataGridViewColumn[] colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    Name = "id",
                    HeaderText = "Id"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "assunto",
                    HeaderText = "Assunto"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "data",
                    HeaderText = "Data"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "horarioInicio",
                    HeaderText = "Horário Início"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "contato.nome",
                    HeaderText = "Contato"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "tipoLocal",
                    HeaderText = "Local"
                }
            };

            gridCompromissos.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Compromisso> compromissos)
        {
            gridCompromissos.Rows.Clear();

            foreach (Compromisso compromisso in compromissos)
            {                
                gridCompromissos.Rows.Add(compromisso.id, compromisso.assunto, compromisso.data, compromisso.horarioInicio, compromisso.contato?.nome, compromisso.tipoLocal);
            }
        }

        public int ObterIdSelecionado()
        {
            if (gridCompromissos.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(gridCompromissos.SelectedRows[0].Cells["id"].Value);

            return id;
        }
    }
}
