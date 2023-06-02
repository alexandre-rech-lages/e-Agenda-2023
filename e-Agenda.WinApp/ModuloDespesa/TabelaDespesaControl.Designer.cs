namespace e_Agenda.WinApp.ModuloDespesa
{
    partial class TabelaDespesaControl
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
            gridDespesas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridDespesas).BeginInit();
            SuspendLayout();
            // 
            // gridDespesas
            // 
            gridDespesas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridDespesas.Dock = DockStyle.Fill;
            gridDespesas.Location = new Point(0, 0);
            gridDespesas.Name = "gridDespesas";
            gridDespesas.RowTemplate.Height = 25;
            gridDespesas.Size = new Size(376, 303);
            gridDespesas.TabIndex = 0;
            // 
            // TabelaDespesaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridDespesas);
            Name = "TabelaDespesaControl";
            Size = new Size(376, 303);
            ((System.ComponentModel.ISupportInitialize)gridDespesas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridDespesas;
    }
}
