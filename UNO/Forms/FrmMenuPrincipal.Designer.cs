
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
            this.btnBotsVsBots = new System.Windows.Forms.Button();
            this.btnUserVsBots = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBotsVsBots
            // 
            this.btnBotsVsBots.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBotsVsBots.Location = new System.Drawing.Point(950, 112);
            this.btnBotsVsBots.Name = "btnBotsVsBots";
            this.btnBotsVsBots.Size = new System.Drawing.Size(149, 93);
            this.btnBotsVsBots.TabIndex = 0;
            this.btnBotsVsBots.Text = "Crear Partida Bots vs Bots";
            this.btnBotsVsBots.UseVisualStyleBackColor = true;
            // 
            // btnUserVsBots
            // 
            this.btnUserVsBots.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUserVsBots.Location = new System.Drawing.Point(950, 255);
            this.btnUserVsBots.Name = "btnUserVsBots";
            this.btnUserVsBots.Size = new System.Drawing.Size(149, 93);
            this.btnUserVsBots.TabIndex = 1;
            this.btnUserVsBots.Text = "Crear Partida User vs Bots";
            this.btnUserVsBots.UseVisualStyleBackColor = true;
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 632);
            this.Controls.Add(this.btnUserVsBots);
            this.Controls.Add(this.btnBotsVsBots);
            this.Name = "FrmMenuPrincipal";
            this.Text = "FrmMenuPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBotsVsBots;
        private System.Windows.Forms.Button btnUserVsBots;
    }
}