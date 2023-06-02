namespace e_Agenda.WinApp.ModuloDespesa
{
    partial class TelaDespesaForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtDescricao = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            txtData = new DateTimePicker();
            txtValor = new TextBox();
            cmbFormaPgto = new ComboBox();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 154);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 27;
            label6.Text = "Forma de Pgto:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(82, 124);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 25;
            label4.Text = "Valor:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 94);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 24;
            label3.Text = "Data: ";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(123, 62);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(350, 23);
            txtDescricao.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 65);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 18;
            label2.Text = "Descrição:";
            // 
            // txtId
            // 
            txtId.Location = new Point(123, 32);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(83, 23);
            txtId.TabIndex = 17;
            txtId.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(98, 36);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 16;
            label1.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(398, 290);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 41);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(317, 290);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 41);
            btnGravar.TabIndex = 14;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // txtData
            // 
            txtData.Format = DateTimePickerFormat.Short;
            txtData.Location = new Point(124, 93);
            txtData.Name = "txtData";
            txtData.Size = new Size(131, 23);
            txtData.TabIndex = 28;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(123, 122);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(132, 23);
            txtValor.TabIndex = 29;
            // 
            // cmbFormaPgto
            // 
            cmbFormaPgto.FormattingEnabled = true;
            cmbFormaPgto.Location = new Point(124, 151);
            cmbFormaPgto.Name = "cmbFormaPgto";
            cmbFormaPgto.Size = new Size(132, 23);
            cmbFormaPgto.TabIndex = 30;
            // 
            // TelaDespesaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 343);
            Controls.Add(cmbFormaPgto);
            Controls.Add(txtValor);
            Controls.Add(txtData);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtDescricao);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaDespesaForm";
            Text = "Cadastro de Despesas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label4;
        private Label label3;
        private TextBox txtDescricao;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private Button btnCancelar;
        private Button btnGravar;
        private DateTimePicker txtData;
        private TextBox txtValor;
        private ComboBox cmbFormaPgto;
    }
}