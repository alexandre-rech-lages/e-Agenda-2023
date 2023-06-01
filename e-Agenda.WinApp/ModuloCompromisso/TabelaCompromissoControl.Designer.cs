namespace e_Agenda.WinApp.ModuloCompromisso
{
    partial class TabelaCompromissoControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridCompromissos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridCompromissos).BeginInit();
            SuspendLayout();
            // 
            // gridCompromissos
            // 
            gridCompromissos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCompromissos.Dock = DockStyle.Fill;
            gridCompromissos.Location = new Point(0, 0);
            gridCompromissos.Name = "gridCompromissos";
            gridCompromissos.RowTemplate.Height = 25;
            gridCompromissos.Size = new Size(353, 233);
            gridCompromissos.TabIndex = 0;
            // 
            // TabelaCompromissoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridCompromissos);
            Name = "TabelaCompromissoControl";
            Size = new Size(353, 233);
            ((System.ComponentModel.ISupportInitialize)gridCompromissos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridCompromissos;
    }
}
