namespace XMLBackOffice
{
    partial class TelaLogin
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
            this.lbUsuario = new System.Windows.Forms.Label();
            this.ConsultaUsuario = new System.Windows.Forms.TextBox();
            this.btConsulta = new System.Windows.Forms.Button();
            this.lbSenha = new System.Windows.Forms.Label();
            this.ConsultaSenha = new System.Windows.Forms.TextBox();
            this.LOGLogin = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(12, 9);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(43, 13);
            this.lbUsuario.TabIndex = 87;
            this.lbUsuario.Text = "Usuário";
            this.lbUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConsultaUsuario
            // 
            this.ConsultaUsuario.Location = new System.Drawing.Point(61, 6);
            this.ConsultaUsuario.Name = "ConsultaUsuario";
            this.ConsultaUsuario.Size = new System.Drawing.Size(202, 20);
            this.ConsultaUsuario.TabIndex = 1;
            // 
            // btConsulta
            // 
            this.btConsulta.Location = new System.Drawing.Point(269, 30);
            this.btConsulta.Name = "btConsulta";
            this.btConsulta.Size = new System.Drawing.Size(75, 23);
            this.btConsulta.TabIndex = 3;
            this.btConsulta.Text = "Consulta";
            this.btConsulta.UseVisualStyleBackColor = true;
            this.btConsulta.Click += new System.EventHandler(this.btConsulta_Click);
            // 
            // lbSenha
            // 
            this.lbSenha.AutoSize = true;
            this.lbSenha.Location = new System.Drawing.Point(17, 35);
            this.lbSenha.Name = "lbSenha";
            this.lbSenha.Size = new System.Drawing.Size(38, 13);
            this.lbSenha.TabIndex = 90;
            this.lbSenha.Text = "Senha";
            this.lbSenha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConsultaSenha
            // 
            this.ConsultaSenha.Location = new System.Drawing.Point(61, 32);
            this.ConsultaSenha.Name = "ConsultaSenha";
            this.ConsultaSenha.PasswordChar = '*';
            this.ConsultaSenha.Size = new System.Drawing.Size(202, 20);
            this.ConsultaSenha.TabIndex = 2;
            this.ConsultaSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeys);
            // 
            // LOGLogin
            // 
            this.LOGLogin.Location = new System.Drawing.Point(12, 69);
            this.LOGLogin.Name = "LOGLogin";
            this.LOGLogin.ReadOnly = true;
            this.LOGLogin.Size = new System.Drawing.Size(327, 192);
            this.LOGLogin.TabIndex = 4;
            this.LOGLogin.Text = "";
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 273);
            this.Controls.Add(this.LOGLogin);
            this.Controls.Add(this.lbSenha);
            this.Controls.Add(this.ConsultaSenha);
            this.Controls.Add(this.btConsulta);
            this.Controls.Add(this.lbUsuario);
            this.Controls.Add(this.ConsultaUsuario);
            this.Name = "TelaLogin";
            this.Text = "TelaLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.TextBox ConsultaUsuario;
        private System.Windows.Forms.Button btConsulta;
        private System.Windows.Forms.Label lbSenha;
        protected System.Windows.Forms.TextBox ConsultaSenha;
        public System.Windows.Forms.RichTextBox LOGLogin;

    }
}