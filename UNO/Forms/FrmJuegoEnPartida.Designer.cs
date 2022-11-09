
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
            this.lblJugador2TotalCartas = new System.Windows.Forms.Label();
            this.lblJugador3TotalCartas = new System.Windows.Forms.Label();
            this.lblJugador4TotalCartas = new System.Windows.Forms.Label();
            this.pbCartaMesa = new System.Windows.Forms.PictureBox();
            this.lblJugador1TotalCartas = new System.Windows.Forms.Label();
            this.lblContador = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblJugador3 = new System.Windows.Forms.Label();
            this.lblJugador2 = new System.Windows.Forms.Label();
            this.lblJugador4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCartaMesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ManoCartas
            // 
            this.ManoCartas.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ManoCartas.FormattingEnabled = true;
            this.ManoCartas.ItemHeight = 24;
            this.ManoCartas.Location = new System.Drawing.Point(504, 521);
            this.ManoCartas.Name = "ManoCartas";
            this.ManoCartas.Size = new System.Drawing.Size(254, 172);
            this.ManoCartas.TabIndex = 0;
            this.ManoCartas.Click += new System.EventHandler(this.ManoCartas_Click);
            // 
            // lblCartaMesa
            // 
            this.lblCartaMesa.BackColor = System.Drawing.Color.Transparent;
            this.lblCartaMesa.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCartaMesa.ForeColor = System.Drawing.Color.Black;
            this.lblCartaMesa.Location = new System.Drawing.Point(493, 235);
            this.lblCartaMesa.Name = "lblCartaMesa";
            this.lblCartaMesa.Size = new System.Drawing.Size(224, 31);
            this.lblCartaMesa.TabIndex = 1;
            this.lblCartaMesa.Text = "Color Elegido: Amarillo";
            // 
            // lblJugador2TotalCartas
            // 
            this.lblJugador2TotalCartas.BackColor = System.Drawing.Color.Black;
            this.lblJugador2TotalCartas.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJugador2TotalCartas.ForeColor = System.Drawing.Color.Yellow;
            this.lblJugador2TotalCartas.Image = global::Forms.Properties.Resources.DorsoJugadores;
            this.lblJugador2TotalCartas.Location = new System.Drawing.Point(45, 198);
            this.lblJugador2TotalCartas.Name = "lblJugador2TotalCartas";
            this.lblJugador2TotalCartas.Size = new System.Drawing.Size(120, 189);
            this.lblJugador2TotalCartas.TabIndex = 2;
            this.lblJugador2TotalCartas.Text = "7";
            this.lblJugador2TotalCartas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJugador3TotalCartas
            // 
            this.lblJugador3TotalCartas.BackColor = System.Drawing.Color.Black;
            this.lblJugador3TotalCartas.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJugador3TotalCartas.ForeColor = System.Drawing.Color.Yellow;
            this.lblJugador3TotalCartas.Image = global::Forms.Properties.Resources.DorsoJugadores;
            this.lblJugador3TotalCartas.Location = new System.Drawing.Point(536, 9);
            this.lblJugador3TotalCartas.Name = "lblJugador3TotalCartas";
            this.lblJugador3TotalCartas.Size = new System.Drawing.Size(122, 180);
            this.lblJugador3TotalCartas.TabIndex = 3;
            this.lblJugador3TotalCartas.Text = "7";
            this.lblJugador3TotalCartas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJugador4TotalCartas
            // 
            this.lblJugador4TotalCartas.BackColor = System.Drawing.Color.Black;
            this.lblJugador4TotalCartas.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJugador4TotalCartas.ForeColor = System.Drawing.Color.Yellow;
            this.lblJugador4TotalCartas.Image = global::Forms.Properties.Resources.DorsoJugadores;
            this.lblJugador4TotalCartas.Location = new System.Drawing.Point(1031, 202);
            this.lblJugador4TotalCartas.Name = "lblJugador4TotalCartas";
            this.lblJugador4TotalCartas.Size = new System.Drawing.Size(124, 181);
            this.lblJugador4TotalCartas.TabIndex = 4;
            this.lblJugador4TotalCartas.Text = "7";
            this.lblJugador4TotalCartas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbCartaMesa
            // 
            this.pbCartaMesa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbCartaMesa.Location = new System.Drawing.Point(634, 269);
            this.pbCartaMesa.Name = "pbCartaMesa";
            this.pbCartaMesa.Size = new System.Drawing.Size(124, 186);
            this.pbCartaMesa.TabIndex = 5;
            this.pbCartaMesa.TabStop = false;
            this.pbCartaMesa.BackgroundImageChanged += new System.EventHandler(this.pbCartaMesa_BackgroundImageChanged);
            // 
            // lblJugador1TotalCartas
            // 
            this.lblJugador1TotalCartas.AutoSize = true;
            this.lblJugador1TotalCartas.BackColor = System.Drawing.Color.Black;
            this.lblJugador1TotalCartas.ForeColor = System.Drawing.Color.White;
            this.lblJugador1TotalCartas.Location = new System.Drawing.Point(1064, 611);
            this.lblJugador1TotalCartas.Name = "lblJugador1TotalCartas";
            this.lblJugador1TotalCartas.Size = new System.Drawing.Size(74, 20);
            this.lblJugador1TotalCartas.TabIndex = 6;
            this.lblJugador1TotalCartas.Text = "Jugador 1";
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.BackColor = System.Drawing.Color.Black;
            this.lblContador.ForeColor = System.Drawing.Color.White;
            this.lblContador.Location = new System.Drawing.Point(64, 37);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(50, 20);
            this.lblContador.TabIndex = 7;
            this.lblContador.Text = "label1";
            // 
            // button1
            // 
            this.button1.Image = global::Forms.Properties.Resources.Dorso;
            this.button1.Location = new System.Drawing.Point(469, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 186);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblJugador3
            // 
            this.lblJugador3.AutoSize = true;
            this.lblJugador3.BackColor = System.Drawing.Color.Black;
            this.lblJugador3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJugador3.ForeColor = System.Drawing.Color.White;
            this.lblJugador3.Location = new System.Drawing.Point(411, 67);
            this.lblJugador3.Name = "lblJugador3";
            this.lblJugador3.Size = new System.Drawing.Size(107, 28);
            this.lblJugador3.TabIndex = 11;
            this.lblJugador3.Text = "Jugador 3";
            // 
            // lblJugador2
            // 
            this.lblJugador2.AutoSize = true;
            this.lblJugador2.BackColor = System.Drawing.Color.Black;
            this.lblJugador2.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJugador2.ForeColor = System.Drawing.Color.White;
            this.lblJugador2.Location = new System.Drawing.Point(55, 169);
            this.lblJugador2.Name = "lblJugador2";
            this.lblJugador2.Size = new System.Drawing.Size(95, 24);
            this.lblJugador2.TabIndex = 12;
            this.lblJugador2.Text = "Jugador 2";
            // 
            // lblJugador4
            // 
            this.lblJugador4.AutoSize = true;
            this.lblJugador4.BackColor = System.Drawing.Color.Black;
            this.lblJugador4.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJugador4.ForeColor = System.Drawing.Color.White;
            this.lblJugador4.Location = new System.Drawing.Point(1043, 169);
            this.lblJugador4.Name = "lblJugador4";
            this.lblJugador4.Size = new System.Drawing.Size(95, 24);
            this.lblJugador4.TabIndex = 13;
            this.lblJugador4.Text = "Jugador 4";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LimeGreen;
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(811, 572);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 75);
            this.button2.TabIndex = 14;
            this.button2.Text = "Tirar Carta";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Forms.Properties.Resources._0AzulNinguno;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::Forms.Properties.Resources.Tachado1;
            this.pictureBox1.Location = new System.Drawing.Point(324, 507);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // FrmJuegoEnPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Forms.Properties.Resources.Mesa;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1191, 705);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblJugador4);
            this.Controls.Add(this.lblJugador2);
            this.Controls.Add(this.lblJugador3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.lblJugador1TotalCartas);
            this.Controls.Add(this.pbCartaMesa);
            this.Controls.Add(this.lblJugador4TotalCartas);
            this.Controls.Add(this.lblJugador3TotalCartas);
            this.Controls.Add(this.lblJugador2TotalCartas);
            this.Controls.Add(this.lblCartaMesa);
            this.Controls.Add(this.ManoCartas);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1209, 752);
            this.Name = "FrmJuegoEnPartida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmJuegoEnPartida";
            this.Load += new System.EventHandler(this.FrmJuegoEnPartida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCartaMesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ManoCartas;
        private System.Windows.Forms.Label lblCartaMesa;
        private System.Windows.Forms.Label lblJugador2TotalCartas;
        private System.Windows.Forms.Label lblJugador3TotalCartas;
        private System.Windows.Forms.Label lblJugador4TotalCartas;
        private System.Windows.Forms.PictureBox pbCartaMesa;
        private System.Windows.Forms.Label lblJugador1TotalCartas;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblJugador3;
        private System.Windows.Forms.Label lblJugador2;
        private System.Windows.Forms.Label lblJugador4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}