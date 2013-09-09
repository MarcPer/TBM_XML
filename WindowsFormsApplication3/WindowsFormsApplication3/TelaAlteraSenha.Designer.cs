namespace XMLBackOffice
{
    partial class TelaAlteraSenha
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
            this.lbSenha = new System.Windows.Forms.Label();
            this.ConsultaRepitaSenha = new System.Windows.Forms.TextBox();
            this.btCadastrar = new System.Windows.Forms.Button();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.ConsultaNovaSenha = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbSenha
            // 
            this.lbSenha.AutoSize = true;
            this.lbSenha.Location = new System.Drawing.Point(9, 35);
            this.lbSenha.Name = "lbSenha";
            this.lbSenha.Size = new System.Drawing.Size(104, 13);
            this.lbSenha.TabIndex = 95;
            this.lbSenha.Text = "Repita Nova Senha:";
            this.lbSenha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConsultaRepitaSenha
            // 
            this.ConsultaRepitaSenha.Location = new System.Drawing.Point(119, 32);
            this.ConsultaRepitaSenha.Name = "ConsultaRepitaSenha";
            this.ConsultaRepitaSenha.PasswordChar = '*';
            this.ConsultaRepitaSenha.Size = new System.Drawing.Size(202, 20);
            this.ConsultaRepitaSenha.TabIndex = 92;
            // 
            // btCadastrar
            // 
            this.btCadastrar.Location = new System.Drawing.Point(246, 58);
            this.btCadastrar.Name = "btCadastrar";
            this.btCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btCadastrar.TabIndex = 93;
            this.btCadastrar.Text = "Cadastrar";
            this.btCadastrar.UseVisualStyleBackColor = true;
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(43, 9);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(70, 13);
            this.lbUsuario.TabIndex = 94;
            this.lbUsuario.Text = "Nova Senha:";
            this.lbUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConsultaNovaSenha
            // 
            this.ConsultaNovaSenha.Location = new System.Drawing.Point(119, 6);
            this.ConsultaNovaSenha.Name = "ConsultaNovaSenha";
            this.ConsultaNovaSenha.Size = new System.Drawing.Size(202, 20);
            this.ConsultaNovaSenha.TabIndex = 91;
            // 
            // TelaAlteraSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 88);
            this.Controls.Add(this.lbSenha);
            this.Controls.Add(this.ConsultaRepitaSenha);
            this.Controls.Add(this.btCadastrar);
            this.Controls.Add(this.lbUsuario);
            this.Controls.Add(this.ConsultaNovaSenha);
            this.Name = "TelaAlteraSenha";
            this.Text = "Cadastramento de Senha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSenha;
        protected System.Windows.Forms.TextBox ConsultaRepitaSenha;
        private System.Windows.Forms.Button btCadastrar;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.TextBox ConsultaNovaSenha;
    }
}