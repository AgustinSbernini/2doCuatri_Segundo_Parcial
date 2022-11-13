
namespace Forms
{
    partial class FrmMenuPrincipal
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
            this.btnBotsVsBotsRapida = new System.Windows.Forms.Button();
            this.btnUserVsBotsRapida = new System.Windows.Forms.Button();
            this.btnBotsVsBots = new System.Windows.Forms.Button();
            this.btnUserVsBots = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBotsVsBotsRapida
            // 
            this.btnBotsVsBotsRapida.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBotsVsBotsRapida.Location = new System.Drawing.Point(881, 463);
            this.btnBotsVsBotsRapida.Name = "btnBotsVsBotsRapida";
            this.btnBotsVsBotsRapida.Size = new System.Drawing.Size(218, 109);
            this.btnBotsVsBotsRapida.TabIndex = 0;
            this.btnBotsVsBotsRapida.Text = "Crear Partida Rapida Bots vs Bots";
            this.btnBotsVsBotsRapida.UseVisualStyleBackColor = true;
            this.btnBotsVsBotsRapida.Click += new System.EventHandler(this.btnBotsVsBotsRapida_Click);
            // 
            // btnUserVsBotsRapida
            // 
            this.btnUserVsBotsRapida.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUserVsBotsRapida.Location = new System.Drawing.Point(881, 196);
            this.btnUserVsBotsRapida.Name = "btnUserVsBotsRapida";
            this.btnUserVsBotsRapida.Size = new System.Drawing.Size(218, 109);
            this.btnUserVsBotsRapida.TabIndex = 1;
            this.btnUserVsBotsRapida.Text = "Crear Partida Rapida User vs Bots ";
            this.btnUserVsBotsRapida.UseVisualStyleBackColor = true;
            this.btnUserVsBotsRapida.Click += new System.EventHandler(this.btnUserVsBotsRapida_Click);
            // 
            // btnBotsVsBots
            // 
            this.btnBotsVsBots.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBotsVsBots.Location = new System.Drawing.Point(881, 328);
            this.btnBotsVsBots.Name = "btnBotsVsBots";
            this.btnBotsVsBots.Size = new System.Drawing.Size(218, 109);
            this.btnBotsVsBots.TabIndex = 2;
            this.btnBotsVsBots.Text = "Crear Partida Normal Bots vs Bots ";
            this.btnBotsVsBots.UseVisualStyleBackColor = true;
            this.btnBotsVsBots.Click += new System.EventHandler(this.btnBotsVsBots_Click);
            // 
            // btnUserVsBots
            // 
            this.btnUserVsBots.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUserVsBots.Location = new System.Drawing.Point(881, 58);
            this.btnUserVsBots.Name = "btnUserVsBots";
            this.btnUserVsBots.Size = new System.Drawing.Size(218, 109);
            this.btnUserVsBots.TabIndex = 3;
            this.btnUserVsBots.Text = "Crear Partida Normal User vs Bots";
            this.btnUserVsBots.UseVisualStyleBackColor = true;
            this.btnUserVsBots.Click += new System.EventHandler(this.btnUserVsBots_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 632);
            this.Controls.Add(this.btnUserVsBots);
            this.Controls.Add(this.btnBotsVsBots);
            this.Controls.Add(this.btnUserVsBotsRapida);
            this.Controls.Add(this.btnBotsVsBotsRapida);
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMenuPrincipal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenuPrincipal_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBotsVsBotsRapida;
        private System.Windows.Forms.Button btnUserVsBotsRapida;
        private System.Windows.Forms.Button btnBotsVsBots;
        private System.Windows.Forms.Button btnUserVsBots;
    }
}