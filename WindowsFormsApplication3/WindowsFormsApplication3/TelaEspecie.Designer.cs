namespace XMLBackOffice
{
    partial class TelaEspecie
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
            this.lbCodigoEspecie = new System.Windows.Forms.Label();
            this.lbUltimo = new System.Windows.Forms.Label();
            this.lbDe = new System.Windows.Forms.Label();
            this.lbDescricao = new System.Windows.Forms.Label();
            this.ConsultaCodigo = new System.Windows.Forms.TextBox();
            this.btLimpa = new System.Windows.Forms.Button();
            this.ConsultaDescricao = new System.Windows.Forms.TextBox();
            this.lbPrimeiro = new System.Windows.Forms.Label();
            this.btEsquerda = new System.Windows.Forms.Button();
            this.btDireita = new System.Windows.Forms.Button();
            this.lbConsulta = new System.Windows.Forms.Label();
            this.btConsulta = new System.Windows.Forms.Button();
            this.lbCadastra = new System.Windows.Forms.Label();
            this.btAbrir = new System.Windows.Forms.Button();
            this.btCadastra = new System.Windows.Forms.Button();
            this.lbArquivo = new System.Windows.Forms.Label();
            this.EnderecoCadastro = new System.Windows.Forms.TextBox();
            this.lbLOG = new System.Windows.Forms.Label();
            this.LOGEspecie = new System.Windows.Forms.RichTextBox();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.btHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbCodigoEspecie
            // 
            this.lbCodigoEspecie.AutoSize = true;
            this.lbCodigoEspecie.Location = new System.Drawing.Point(28, 118);
            this.lbCodigoEspecie.Name = "lbCodigoEspecie";
            this.lbCodigoEspecie.Size = new System.Drawing.Size(40, 13);
            this.lbCodigoEspecie.TabIndex = 51;
            this.lbCodigoEspecie.Text = "Código";
            this.lbCodigoEspecie.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbUltimo
            // 
            this.lbUltimo.AutoSize = true;
            this.lbUltimo.Location = new System.Drawing.Point(421, 195);
            this.lbUltimo.Name = "lbUltimo";
            this.lbUltimo.Size = new System.Drawing.Size(13, 13);
            this.lbUltimo.TabIndex = 63;
            this.lbUltimo.Text = "0";
            this.lbUltimo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDe
            // 
            this.lbDe.AutoSize = true;
            this.lbDe.Location = new System.Drawing.Point(402, 195);
            this.lbDe.Name = "lbDe";
            this.lbDe.Size = new System.Drawing.Size(19, 13);
            this.lbDe.TabIndex = 62;
            this.lbDe.Text = "de";
            this.lbDe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbDescricao
            // 
            this.lbDescricao.AutoSize = true;
            this.lbDescricao.Location = new System.Drawing.Point(13, 141);
            this.lbDescricao.Name = "lbDescricao";
            this.lbDescricao.Size = new System.Drawing.Size(55, 13);
            this.lbDescricao.TabIndex = 50;
            this.lbDescricao.Text = "Descrição";
            this.lbDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConsultaCodigo
            // 
            this.ConsultaCodigo.Location = new System.Drawing.Point(74, 115);
            this.ConsultaCodigo.Name = "ConsultaCodigo";
            this.ConsultaCodigo.Size = new System.Drawing.Size(115, 20);
            this.ConsultaCodigo.TabIndex = 48;
            // 
            // btLimpa
            // 
            this.btLimpa.Location = new System.Drawing.Point(381, 112);
            this.btLimpa.Name = "btLimpa";
            this.btLimpa.Size = new System.Drawing.Size(75, 23);
            this.btLimpa.TabIndex = 57;
            this.btLimpa.Text = "Limpa";
            this.btLimpa.UseVisualStyleBackColor = true;
            this.btLimpa.Click += new System.EventHandler(this.btLimpa_Click);
            // 
            // ConsultaDescricao
            // 
            this.ConsultaDescricao.Location = new System.Drawing.Point(74, 141);
            this.ConsultaDescricao.Name = "ConsultaDescricao";
            this.ConsultaDescricao.Size = new System.Drawing.Size(460, 20);
            this.ConsultaDescricao.TabIndex = 59;
            // 
            // lbPrimeiro
            // 
            this.lbPrimeiro.AutoSize = true;
            this.lbPrimeiro.Location = new System.Drawing.Point(362, 195);
            this.lbPrimeiro.Name = "lbPrimeiro";
            this.lbPrimeiro.Size = new System.Drawing.Size(13, 13);
            this.lbPrimeiro.TabIndex = 58;
            this.lbPrimeiro.Text = "0";
            this.lbPrimeiro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btEsquerda
            // 
            this.btEsquerda.Location = new System.Drawing.Point(459, 190);
            this.btEsquerda.Name = "btEsquerda";
            this.btEsquerda.Size = new System.Drawing.Size(36, 23);
            this.btEsquerda.TabIndex = 60;
            this.btEsquerda.Text = "<";
            this.btEsquerda.UseVisualStyleBackColor = true;
            this.btEsquerda.Click += new System.EventHandler(this.btEsquerda_Click);
            // 
            // btDireita
            // 
            this.btDireita.Location = new System.Drawing.Point(498, 190);
            this.btDireita.Name = "btDireita";
            this.btDireita.Size = new System.Drawing.Size(36, 23);
            this.btDireita.TabIndex = 61;
            this.btDireita.Text = ">";
            this.btDireita.UseVisualStyleBackColor = true;
            this.btDireita.Click += new System.EventHandler(this.btDireita_Click);
            // 
            // lbConsulta
            // 
            this.lbConsulta.AutoSize = true;
            this.lbConsulta.Location = new System.Drawing.Point(30, 96);
            this.lbConsulta.Name = "lbConsulta";
            this.lbConsulta.Size = new System.Drawing.Size(48, 13);
            this.lbConsulta.TabIndex = 56;
            this.lbConsulta.Text = "Consulta";
            // 
            // btConsulta
            // 
            this.btConsulta.Location = new System.Drawing.Point(462, 112);
            this.btConsulta.Name = "btConsulta";
            this.btConsulta.Size = new System.Drawing.Size(75, 23);
            this.btConsulta.TabIndex = 55;
            this.btConsulta.Text = "Consulta";
            this.btConsulta.UseVisualStyleBackColor = true;
            this.btConsulta.Click += new System.EventHandler(this.btConsulta_Click);
            // 
            // lbCadastra
            // 
            this.lbCadastra.AutoSize = true;
            this.lbCadastra.Location = new System.Drawing.Point(30, 11);
            this.lbCadastra.Name = "lbCadastra";
            this.lbCadastra.Size = new System.Drawing.Size(49, 13);
            this.lbCadastra.TabIndex = 44;
            this.lbCadastra.Text = "Cadastra";
            // 
            // btAbrir
            // 
            this.btAbrir.Location = new System.Drawing.Point(463, 24);
            this.btAbrir.Name = "btAbrir";
            this.btAbrir.Size = new System.Drawing.Size(75, 23);
            this.btAbrir.TabIndex = 47;
            this.btAbrir.Text = "Abrir";
            this.btAbrir.UseVisualStyleBackColor = true;
            this.btAbrir.Click += new System.EventHandler(this.btAbrir_Click);
            // 
            // btCadastra
            // 
            this.btCadastra.Location = new System.Drawing.Point(462, 52);
            this.btCadastra.Name = "btCadastra";
            this.btCadastra.Size = new System.Drawing.Size(75, 23);
            this.btCadastra.TabIndex = 45;
            this.btCadastra.Text = "Cadastrar";
            this.btCadastra.UseVisualStyleBackColor = true;
            this.btCadastra.Click += new System.EventHandler(this.btCadastra_Click);
            // 
            // lbArquivo
            // 
            this.lbArquivo.AutoSize = true;
            this.lbArquivo.Location = new System.Drawing.Point(25, 29);
            this.lbArquivo.Name = "lbArquivo";
            this.lbArquivo.Size = new System.Drawing.Size(43, 13);
            this.lbArquivo.TabIndex = 46;
            this.lbArquivo.Text = "Arquivo";
            // 
            // EnderecoCadastro
            // 
            this.EnderecoCadastro.Location = new System.Drawing.Point(74, 26);
            this.EnderecoCadastro.Name = "EnderecoCadastro";
            this.EnderecoCadastro.Size = new System.Drawing.Size(383, 20);
            this.EnderecoCadastro.TabIndex = 43;
            // 
            // lbLOG
            // 
            this.lbLOG.AutoSize = true;
            this.lbLOG.Location = new System.Drawing.Point(15, 248);
            this.lbLOG.Name = "lbLOG";
            this.lbLOG.Size = new System.Drawing.Size(29, 13);
            this.lbLOG.TabIndex = 42;
            this.lbLOG.Text = "LOG";
            this.lbLOG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LOGEspecie
            // 
            this.LOGEspecie.Location = new System.Drawing.Point(12, 264);
            this.LOGEspecie.Name = "LOGEspecie";
            this.LOGEspecie.ReadOnly = true;
            this.LOGEspecie.Size = new System.Drawing.Size(538, 131);
            this.LOGEspecie.TabIndex = 41;
            this.LOGEspecie.Text = "";
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(10, 18);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(540, 64);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(560, 407);
            this.shapeContainer1.TabIndex = 64;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.Location = new System.Drawing.Point(10, 103);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(540, 132);
            // 
            // btHelp
            // 
            this.btHelp.Location = new System.Drawing.Point(18, 52);
            this.btHelp.Name = "btHelp";
            this.btHelp.Size = new System.Drawing.Size(17, 23);
            this.btHelp.TabIndex = 70;
            this.btHelp.Text = "?";
            this.btHelp.UseVisualStyleBackColor = true;
            this.btHelp.Click += new System.EventHandler(this.btHelp_Click);
            // 
            // TelaEspecie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 407);
            this.Controls.Add(this.btHelp);
            this.Controls.Add(this.lbCodigoEspecie);
            this.Controls.Add(this.lbUltimo);
            this.Controls.Add(this.lbDe);
            this.Controls.Add(this.lbDescricao);
            this.Controls.Add(this.ConsultaCodigo);
            this.Controls.Add(this.btLimpa);
            this.Controls.Add(this.ConsultaDescricao);
            this.Controls.Add(this.lbPrimeiro);
            this.Controls.Add(this.btEsquerda);
            this.Controls.Add(this.btDireita);
            this.Controls.Add(this.lbConsulta);
            this.Controls.Add(this.btConsulta);
            this.Controls.Add(this.lbCadastra);
            this.Controls.Add(this.btAbrir);
            this.Controls.Add(this.btCadastra);
            this.Controls.Add(this.lbArquivo);
            this.Controls.Add(this.EnderecoCadastro);
            this.Controls.Add(this.lbLOG);
            this.Controls.Add(this.LOGEspecie);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "TelaEspecie";
            this.Text = "TelaEspecie";
            this.Load += new System.EventHandler(this.TelaEspecie_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCodigoEspecie;
        private System.Windows.Forms.Label lbUltimo;
        private System.Windows.Forms.Label lbDe;
        private System.Windows.Forms.Label lbDescricao;
        private System.Windows.Forms.TextBox ConsultaCodigo;
        private System.Windows.Forms.Button btLimpa;
        private System.Windows.Forms.TextBox ConsultaDescricao;
        private System.Windows.Forms.Label lbPrimeiro;
        private System.Windows.Forms.Button btEsquerda;
        private System.Windows.Forms.Button btDireita;
        private System.Windows.Forms.Label lbConsulta;
        private System.Windows.Forms.Button btConsulta;
        private System.Windows.Forms.Label lbCadastra;
        private System.Windows.Forms.Button btAbrir;
        private System.Windows.Forms.Button btCadastra;
        private System.Windows.Forms.Label lbArquivo;
        private System.Windows.Forms.TextBox EnderecoCadastro;
        private System.Windows.Forms.Label lbLOG;
        public System.Windows.Forms.RichTextBox LOGEspecie;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private System.Windows.Forms.Button btHelp;
    }
}