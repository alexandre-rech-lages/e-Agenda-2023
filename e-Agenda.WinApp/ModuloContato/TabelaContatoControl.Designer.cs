namespace e_Agenda.WinApp.ModuloContato
{
    partial class TabelaContatoControl
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
            gridContatos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridContatos).BeginInit();
            SuspendLayout();
            // 
            // gridContatos
            // 
            gridContatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridContatos.Dock = DockStyle.Fill;
            gridContatos.Location = new Point(0, 0);
            gridContatos.Name = "gridContatos";
            gridContatos.RowTemplate.Height = 25;
            gridContatos.Size = new Size(442, 413);
            gridContatos.TabIndex = 0;
            // 
            // TabelaContatoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridContatos);
            Name = "TabelaContatoControl";
            Size = new Size(442, 413);
            ((System.ComponentModel.ISupportInitialize)gridContatos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridContatos;
    }
}
