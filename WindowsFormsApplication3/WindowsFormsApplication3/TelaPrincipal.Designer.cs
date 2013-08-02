namespace XMLBackOffice
{
    partial class TelaPrincipal
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
            this.btCliente = new System.Windows.Forms.Button();
            this.btEmissor = new System.Windows.Forms.Button();
            this.rtLOG = new System.Windows.Forms.RichTextBox();
            this.btIndexador = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btTipoAtivo = new System.Windows.Forms.Button();
            this.btEspecie = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.lbISIN = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btCliente
            // 
            this.btCliente.Location = new System.Drawing.Point(12, 35);
            this.btCliente.Name = "btCliente";
            this.btCliente.Size = new System.Drawing.Size(75, 23);
            this.btCliente.TabIndex = 0;
            this.btCliente.Text = "Cliente";
            this.btCliente.UseVisualStyleBackColor = true;
            this.btCliente.Click += new System.EventHandler(this.button1_Click);
            // 
            // btEmissor
            // 
            this.btEmissor.Location = new System.Drawing.Point(93, 35);
            this.btEmissor.Name = "btEmissor";
            this.btEmissor.Size = new System.Drawing.Size(75, 23);
            this.btEmissor.TabIndex = 1;
            this.btEmissor.Text = "Emissor";
            this.btEmissor.UseVisualStyleBackColor = true;
            this.btEmissor.Click += new System.EventHandler(this.btEmissor_Click);
            // 
            // rtLOG
            // 
            this.rtLOG.Location = new System.Drawing.Point(12, 66);
            this.rtLOG.Name = "rtLOG";
            this.rtLOG.Size = new System.Drawing.Size(704, 183);
            this.rtLOG.TabIndex = 2;
            this.rtLOG.Text = "";
            // 
            // btIndexador
            // 
            this.btIndexador.Location = new System.Drawing.Point(336, 35);
            this.btIndexador.Name = "btIndexador";
            this.btIndexador.Size = new System.Drawing.Size(75, 23);
            this.btIndexador.TabIndex = 3;
            this.btIndexador.Text = "Indexador";
            this.btIndexador.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(417, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cliente";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btTipoAtivo
            // 
            this.btTipoAtivo.Location = new System.Drawing.Point(174, 35);
            this.btTipoAtivo.Name = "btTipoAtivo";
            this.btTipoAtivo.Size = new System.Drawing.Size(75, 23);
            this.btTipoAtivo.TabIndex = 5;
            this.btTipoAtivo.Text = "Tipo Ativo";
            this.btTipoAtivo.UseVisualStyleBackColor = true;
            this.btTipoAtivo.Click += new System.EventHandler(this.btTipoAtivo_Click);
            // 
            // btEspecie
            // 
            this.btEspecie.Location = new System.Drawing.Point(255, 35);
            this.btEspecie.Name = "btEspecie";
            this.btEspecie.Size = new System.Drawing.Size(75, 23);
            this.btEspecie.TabIndex = 6;
            this.btEspecie.Text = "Espécie";
            this.btEspecie.UseVisualStyleBackColor = true;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(728, 261);
            this.shapeContainer1.TabIndex = 7;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(89, 29);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(243, 33);
            // 
            // lbISIN
            // 
            this.lbISIN.AutoSize = true;
            this.lbISIN.Location = new System.Drawing.Point(196, 19);
            this.lbISIN.Name = "lbISIN";
            this.lbISIN.Size = new System.Drawing.Size(28, 13);
            this.lbISIN.TabIndex = 8;
            this.lbISIN.Text = "ISIN";
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 261);
            this.Controls.Add(this.lbISIN);
            this.Controls.Add(this.btEspecie);
            this.Controls.Add(this.btTipoAtivo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btIndexador);
            this.Controls.Add(this.rtLOG);
            this.Controls.Add(this.btEmissor);
            this.Controls.Add(this.btCliente);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "TelaPrincipal";
            this.Text = "Alimentador de BD do XML Proj";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCliente;
        private System.Windows.Forms.Button btEmissor;
        private System.Windows.Forms.RichTextBox rtLOG;
        private System.Windows.Forms.Button btIndexador;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btTipoAtivo;
        private System.Windows.Forms.Button btEspecie;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label lbISIN;
    }
}

