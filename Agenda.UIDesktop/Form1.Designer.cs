
namespace Agenda.UIDesktop
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblContatoNovo = new System.Windows.Forms.Label();
            this.txtContatoNovo = new System.Windows.Forms.TextBox();
            this.lblContatoSalvo = new System.Windows.Forms.Label();
            this.txtContatoSalvo = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblContatoNovo
            // 
            this.lblContatoNovo.AutoSize = true;
            this.lblContatoNovo.Location = new System.Drawing.Point(13, 13);
            this.lblContatoNovo.Name = "lblContatoNovo";
            this.lblContatoNovo.Size = new System.Drawing.Size(73, 13);
            this.lblContatoNovo.TabIndex = 0;
            this.lblContatoNovo.Text = "Contato Novo";
            // 
            // txtContatoNovo
            // 
            this.txtContatoNovo.Location = new System.Drawing.Point(16, 30);
            this.txtContatoNovo.Name = "txtContatoNovo";
            this.txtContatoNovo.Size = new System.Drawing.Size(276, 20);
            this.txtContatoNovo.TabIndex = 1;
            // 
            // lblContatoSalvo
            // 
            this.lblContatoSalvo.AutoSize = true;
            this.lblContatoSalvo.Location = new System.Drawing.Point(16, 57);
            this.lblContatoSalvo.Name = "lblContatoSalvo";
            this.lblContatoSalvo.Size = new System.Drawing.Size(74, 13);
            this.lblContatoSalvo.TabIndex = 2;
            this.lblContatoSalvo.Text = "Contato Salvo";
            // 
            // txtContatoSalvo
            // 
            this.txtContatoSalvo.Location = new System.Drawing.Point(19, 74);
            this.txtContatoSalvo.Name = "txtContatoSalvo";
            this.txtContatoSalvo.Size = new System.Drawing.Size(273, 20);
            this.txtContatoSalvo.TabIndex = 3;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(217, 100);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtContatoSalvo);
            this.Controls.Add(this.lblContatoSalvo);
            this.Controls.Add(this.txtContatoNovo);
            this.Controls.Add(this.lblContatoNovo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblContatoNovo;
        private System.Windows.Forms.TextBox txtContatoNovo;
        private System.Windows.Forms.Label lblContatoSalvo;
        private System.Windows.Forms.TextBox txtContatoSalvo;
        private System.Windows.Forms.Button btnSalvar;
    }
}

