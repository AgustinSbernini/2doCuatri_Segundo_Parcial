
namespace Forms
{
    partial class FrmJuegoEnPartida
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
            this.ManoCartas = new System.Windows.Forms.ListBox();
            this.lblCartaMesa = new System.Windows.Forms.Label();
            this.lblJugador2 = new System.Windows.Forms.Label();
            this.lblJugador3 = new System.Windows.Forms.Label();
            this.lblJugador4 = new System.Windows.Forms.Label();
            this.pbCartaMesa = new System.Windows.Forms.PictureBox();
            this.lblJugador1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCartaMesa)).BeginInit();
            this.SuspendLayout();
            // 
            // ManoCartas
            // 
            this.ManoCartas.FormattingEnabled = true;
            this.ManoCartas.ItemHeight = 20;
            this.ManoCartas.Location = new System.Drawing.Point(409, 361);
            this.ManoCartas.Name = "ManoCartas";
            this.ManoCartas.Size = new System.Drawing.Size(254, 184);
            this.ManoCartas.TabIndex = 0;
            this.ManoCartas.Click += new System.EventHandler(this.ManoCartas_Click);
            // 
            // lblCartaMesa
            // 
            this.lblCartaMesa.Location = new System.Drawing.Point(455, 81);
            this.lblCartaMesa.Name = "lblCartaMesa";
            this.lblCartaMesa.Size = new System.Drawing.Size(177, 29);
            this.lblCartaMesa.TabIndex = 1;
            this.lblCartaMesa.Text = "lblCartaMesa";
            // 
            // lblJugador2
            // 
            this.lblJugador2.AutoSize = true;
            this.lblJugador2.Location = new System.Drawing.Point(64, 195);
            this.lblJugador2.Name = "lblJugador2";
            this.lblJugador2.Size = new System.Drawing.Size(74, 20);
            this.lblJugador2.TabIndex = 2;
            this.lblJugador2.Text = "Jugador 2";
            // 
            // lblJugador3
            // 
            this.lblJugador3.AutoSize = true;
            this.lblJugador3.Location = new System.Drawing.Point(475, 37);
            this.lblJugador3.Name = "lblJugador3";
            this.lblJugador3.Size = new System.Drawing.Size(74, 20);
            this.lblJugador3.TabIndex = 3;
            this.lblJugador3.Text = "Jugador 3";
            // 
            // lblJugador4
            // 
            this.lblJugador4.AutoSize = true;
            this.lblJugador4.Location = new System.Drawing.Point(917, 195);
            this.lblJugador4.Name = "lblJugador4";
            this.lblJugador4.Size = new System.Drawing.Size(74, 20);
            this.lblJugador4.TabIndex = 4;
            this.lblJugador4.Text = "Jugador 4";
            // 
            // pbCartaMesa
            // 
            this.pbCartaMesa.Location = new System.Drawing.Point(455, 113);
            this.pbCartaMesa.Name = "pbCartaMesa";
            this.pbCartaMesa.Size = new System.Drawing.Size(141, 217);
            this.pbCartaMesa.TabIndex = 5;
            this.pbCartaMesa.TabStop = false;
            this.pbCartaMesa.BackgroundImageChanged += new System.EventHandler(this.pbCartaMesa_BackgroundImageChanged);
            // 
            // lblJugador1
            // 
            this.lblJugador1.AutoSize = true;
            this.lblJugador1.Location = new System.Drawing.Point(780, 397);
            this.lblJugador1.Name = "lblJugador1";
            this.lblJugador1.Size = new System.Drawing.Size(74, 20);
            this.lblJugador1.TabIndex = 6;
            this.lblJugador1.Text = "Jugador 1";
            // 
            // FrmJuegoEnPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 571);
            this.Controls.Add(this.lblJugador1);
            this.Controls.Add(this.pbCartaMesa);
            this.Controls.Add(this.lblJugador4);
            this.Controls.Add(this.lblJugador3);
            this.Controls.Add(this.lblJugador2);
            this.Controls.Add(this.lblCartaMesa);
            this.Controls.Add(this.ManoCartas);
            this.Name = "FrmJuegoEnPartida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmJuegoEnPartida";
            this.Load += new System.EventHandler(this.FrmJuegoEnPartida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCartaMesa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ManoCartas;
        private System.Windows.Forms.Label lblCartaMesa;
        private System.Windows.Forms.Label lblJugador2;
        private System.Windows.Forms.Label lblJugador3;
        private System.Windows.Forms.Label lblJugador4;
        private System.Windows.Forms.PictureBox pbCartaMesa;
        private System.Windows.Forms.Label lblJugador1;
    }
}