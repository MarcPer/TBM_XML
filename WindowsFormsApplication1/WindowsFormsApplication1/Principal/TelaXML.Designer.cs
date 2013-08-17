namespace WindowsFormsApplication1
{
    partial class TelaXML
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
            this.CaminhoXML = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtLOG = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btGerar = new System.Windows.Forms.Button();
            this.btAbrir = new System.Windows.Forms.Button();
            this.btSobre = new System.Windows.Forms.Button();
            this.btAjuda = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CaminhoXML
            // 
            this.CaminhoXML.Location = new System.Drawing.Point(48, 12);
            this.CaminhoXML.Name = "CaminhoXML";
            this.CaminhoXML.Size = new System.Drawing.Size(368, 20);
            this.CaminhoXML.TabIndex = 0;
            this.CaminhoXML.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "XML";
            // 
            // rtLOG
            // 
            this.rtLOG.Location = new System.Drawing.Point(12, 83);
            this.rtLOG.Name = "rtLOG";
            this.rtLOG.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtLOG.Size = new System.Drawing.Size(482, 134);
            this.rtLOG.TabIndex = 2;
            this.rtLOG.TabStop = false;
            this.rtLOG.Text = "";
            this.rtLOG.TextChanged += new System.EventHandler(this.rtLOG_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "LOG";
            // 
            // btGerar
            // 
            this.btGerar.Location = new System.Drawing.Point(422, 37);
            this.btGerar.Name = "btGerar";
            this.btGerar.Size = new System.Drawing.Size(72, 23);
            this.btGerar.TabIndex = 4;
            this.btGerar.Text = "Gerar";
            this.btGerar.UseVisualStyleBackColor = true;
            this.btGerar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btAbrir
            // 
            this.btAbrir.Location = new System.Drawing.Point(422, 8);
            this.btAbrir.Name = "btAbrir";
            this.btAbrir.Size = new System.Drawing.Size(72, 23);
            this.btAbrir.TabIndex = 5;
            this.btAbrir.Text = "Abrir";
            this.btAbrir.UseVisualStyleBackColor = true;
            this.btAbrir.Click += new System.EventHandler(this.button2_Click);
            // 
            // btSobre
            // 
            this.btSobre.Location = new System.Drawing.Point(419, 223);
            this.btSobre.Name = "btSobre";
            this.btSobre.Size = new System.Drawing.Size(75, 23);
            this.btSobre.TabIndex = 6;
            this.btSobre.Text = "Sobre";
            this.btSobre.UseVisualStyleBackColor = true;
            // 
            // btAjuda
            // 
            this.btAjuda.Location = new System.Drawing.Point(12, 223);
            this.btAjuda.Name = "btAjuda";
            this.btAjuda.Size = new System.Drawing.Size(75, 23);
            this.btAjuda.TabIndex = 7;
            this.btAjuda.Text = "Ajuda";
            this.btAjuda.UseVisualStyleBackColor = true;
            // 
            // TelaXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 256);
            this.Controls.Add(this.btAjuda);
            this.Controls.Add(this.btSobre);
            this.Controls.Add(this.btAbrir);
            this.Controls.Add(this.btGerar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtLOG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CaminhoXML);
            this.Name = "TelaXML";
            this.Text = "RelatFundos 0.0.1a";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CaminhoXML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtLOG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btGerar;
        private System.Windows.Forms.Button btAbrir;
        private System.Windows.Forms.Button btSobre;
        private System.Windows.Forms.Button btAjuda;
    }
}

