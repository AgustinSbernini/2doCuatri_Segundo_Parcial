
namespace Forms
{
    partial class FrmHistorialPartida
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
            this.txtHistorial = new System.Windows.Forms.RichTextBox();
            this.btnDescargarHistorial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtHistorial
            // 
            this.txtHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHistorial.Location = new System.Drawing.Point(12, 12);
            this.txtHistorial.Name = "txtHistorial";
            this.txtHistorial.Size = new System.Drawing.Size(314, 408);
            this.txtHistorial.TabIndex = 0;
            this.txtHistorial.Text = "";
            // 
            // btnDescargarHistorial
            // 
            this.btnDescargarHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDescargarHistorial.Location = new System.Drawing.Point(332, 339);
            this.btnDescargarHistorial.Name = "btnDescargarHistorial";
            this.btnDescargarHistorial.Size = new System.Drawing.Size(85, 81);
            this.btnDescargarHistorial.TabIndex = 1;
            this.btnDescargarHistorial.Text = "Descargar Historial";
            this.btnDescargarHistorial.UseVisualStyleBackColor = true;
            this.btnDescargarHistorial.Click += new System.EventHandler(this.btnDescargarHistorial_Click);
            // 
            // FrmHistorialPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 432);
            this.Controls.Add(this.btnDescargarHistorial);
            this.Controls.Add(this.txtHistorial);
            this.Name = "FrmHistorialPartida";
            this.Text = "Historial de la Partida";
            this.Load += new System.EventHandler(this.FrmHistorialPartida_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtHistorial;
        private System.Windows.Forms.Button btnDescargarHistorial;
    }
}