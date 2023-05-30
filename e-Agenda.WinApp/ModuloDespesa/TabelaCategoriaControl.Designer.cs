namespace e_Agenda.WinApp.ModuloDespesa
{
    partial class TabelaCategoriaControl
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
            gridCategorias = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridCategorias).BeginInit();
            SuspendLayout();
            // 
            // gridCategorias
            // 
            gridCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCategorias.Dock = DockStyle.Fill;
            gridCategorias.Location = new Point(0, 0);
            gridCategorias.Name = "gridCategorias";
            gridCategorias.RowTemplate.Height = 25;
            gridCategorias.Size = new Size(427, 355);
            gridCategorias.TabIndex = 0;
            // 
            // TabelaCategoriaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridCategorias);
            Name = "TabelaCategoriaControl";
            Size = new Size(427, 355);
            ((System.ComponentModel.ISupportInitialize)gridCategorias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridCategorias;
    }
}
