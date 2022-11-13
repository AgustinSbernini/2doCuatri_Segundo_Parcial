
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
            this.lstManoCartas = new System.Windows.Forms.ListBox();
            this.lblCartaMesa = new System.Windows.Forms.Label();
            this.lblJugador2TotalCartas = new System.Windows.Forms.Label();
            this.lblJugador3TotalCartas = new System.Windows.Forms.Label();
            this.lblJugador4TotalCartas = new System.Windows.Forms.Label();
            this.pbCartaMesa = new System.Windows.Forms.PictureBox();
            this.lblJugador1TotalCartas = new System.Windows.Forms.Label();
            this.lblContador = new System.Windows.Forms.Label();
            this.btnAgarrarCarta = new System.Windows.Forms.Button();
            this.lblJugador3 = new System.Windows.Forms.Label();
            this.lblJugador2 = new System.Windows.Forms.Label();
            this.lblJugador4 = new System.Windows.Forms.Label();
            this.btnTirarCarta = new System.Windows.Forms.Button();
            this.pbCartaMano = new System.Windows.Forms.PictureBox();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.pbJugador4 = new System.Windows.Forms.PictureBox();
            this.pbJugador2 = new System.Windows.Forms.PictureBox();
            this.pbJugador1 = new System.Windows.Forms.PictureBox();
            this.pbJugador3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCartaMesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCartaMano)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJugador4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJugador2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJugador1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJugador3)).BeginInit();
            this.SuspendLayout();
            // 
            // lstManoCartas
            // 
            this.lstManoCartas.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lstManoCartas.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstManoCartas.FormattingEnabled = true;
            this.lstManoCartas.ItemHeight = 24;
            this.lstManoCartas.Location = new System.Drawing.Point(469, 521);
            this.lstManoCartas.Name = "lstManoCartas";
            this.lstManoCartas.Size = new System.Drawing.Size(289, 172);
            this.lstManoCartas.TabIndex = 0;
            this.lstManoCartas.SelectedIndexChanged += new System.EventHandler(this.lstManoCartas_SelectedIndexChanged);
            // 
            // lblCartaMesa
            // 
            this.lblCartaMesa.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.lblJugador2TotalCartas.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this.lblJugador3TotalCartas.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.lblJugador4TotalCartas.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblJugador4TotalCartas.BackColor = System.Drawing.Color.Black;
            this.lblJugador4TotalCartas.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJugador4TotalCartas.ForeColor = System.Drawing.Color.Yellow;
            this.lblJugador4TotalCartas.Image = global::Forms.Properties.Resources.DorsoJugadores;
            this.lblJugador4TotalCartas.Location = new System.Drawing.Point(1026, 202);
            this.lblJugador4TotalCartas.Name = "lblJugador4TotalCartas";
            this.lblJugador4TotalCartas.Size = new System.Drawing.Size(124, 181);
            this.lblJugador4TotalCartas.TabIndex = 4;
            this.lblJugador4TotalCartas.Text = "7";
            this.lblJugador4TotalCartas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbCartaMesa
            // 
            this.pbCartaMesa.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.lblJugador1TotalCartas.Location = new System.Drawing.Point(775, 676);
            this.lblJugador1TotalCartas.Name = "lblJugador1TotalCartas";
            this.lblJugador1TotalCartas.Size = new System.Drawing.Size(0, 20);
            this.lblJugador1TotalCartas.TabIndex = 6;
            this.lblJugador1TotalCartas.Visible = false;
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.BackColor = System.Drawing.Color.Black;
            this.lblContador.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblContador.ForeColor = System.Drawing.Color.White;
            this.lblContador.Location = new System.Drawing.Point(90, 64);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(75, 31);
            this.lblContador.TabIndex = 7;
            this.lblContador.Text = "label1";
            // 
            // btnAgarrarCarta
            // 
            this.btnAgarrarCarta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgarrarCarta.Image = global::Forms.Properties.Resources.Dorso;
            this.btnAgarrarCarta.Location = new System.Drawing.Point(469, 269);
            this.btnAgarrarCarta.Name = "btnAgarrarCarta";
            this.btnAgarrarCarta.Size = new System.Drawing.Size(124, 186);
            this.btnAgarrarCarta.TabIndex = 8;
            this.btnAgarrarCarta.UseVisualStyleBackColor = true;
            this.btnAgarrarCarta.Click += new System.EventHandler(this.btnAgarrarCarta_Click);
            // 
            // lblJugador3
            // 
            this.lblJugador3.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.lblJugador2.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this.lblJugador4.Anchor = System.Windows.Forms.AnchorStyles.Right;
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
            // btnTirarCarta
            // 
            this.btnTirarCarta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnTirarCarta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnTirarCarta.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTirarCarta.Location = new System.Drawing.Point(809, 572);
            this.btnTirarCarta.Name = "btnTirarCarta";
            this.btnTirarCarta.Size = new System.Drawing.Size(113, 84);
            this.btnTirarCarta.TabIndex = 14;
            this.btnTirarCarta.Text = "Tirar Carta";
            this.btnTirarCarta.UseVisualStyleBackColor = false;
            this.btnTirarCarta.Click += new System.EventHandler(this.btnTirarCarta_Click);
            // 
            // pbCartaMano
            // 
            this.pbCartaMano.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbCartaMano.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCartaMano.Location = new System.Drawing.Point(324, 507);
            this.pbCartaMano.Name = "pbCartaMano";
            this.pbCartaMano.Size = new System.Drawing.Size(124, 186);
            this.pbCartaMano.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCartaMano.TabIndex = 15;
            this.pbCartaMano.TabStop = false;
            // 
            // btnHistorial
            // 
            this.btnHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnHistorial.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHistorial.Location = new System.Drawing.Point(90, 572);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(131, 84);
            this.btnHistorial.TabIndex = 16;
            this.btnHistorial.Text = "Historial de la Partida";
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // pbJugador4
            // 
            this.pbJugador4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbJugador4.BackColor = System.Drawing.Color.Transparent;
            this.pbJugador4.Image = global::Forms.Properties.Resources.GloboTextoInvertido;
            this.pbJugador4.Location = new System.Drawing.Point(868, 142);
            this.pbJugador4.Name = "pbJugador4";
            this.pbJugador4.Size = new System.Drawing.Size(152, 124);
            this.pbJugador4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbJugador4.TabIndex = 17;
            this.pbJugador4.TabStop = false;
            this.pbJugador4.Visible = false;
            // 
            // pbJugador2
            // 
            this.pbJugador2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pbJugador2.BackColor = System.Drawing.Color.Transparent;
            this.pbJugador2.Image = global::Forms.Properties.Resources.GloboTexto;
            this.pbJugador2.Location = new System.Drawing.Point(183, 142);
            this.pbJugador2.Name = "pbJugador2";
            this.pbJugador2.Size = new System.Drawing.Size(152, 124);
            this.pbJugador2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbJugador2.TabIndex = 18;
            this.pbJugador2.TabStop = false;
            this.pbJugador2.Visible = false;
            // 
            // pbJugador1
            // 
            this.pbJugador1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbJugador1.BackColor = System.Drawing.Color.Transparent;
            this.pbJugador1.Image = global::Forms.Properties.Resources.GloboTexto;
            this.pbJugador1.Location = new System.Drawing.Point(775, 424);
            this.pbJugador1.Name = "pbJugador1";
            this.pbJugador1.Size = new System.Drawing.Size(152, 124);
            this.pbJugador1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbJugador1.TabIndex = 19;
            this.pbJugador1.TabStop = false;
            this.pbJugador1.Visible = false;
            // 
            // pbJugador3
            // 
            this.pbJugador3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbJugador3.BackColor = System.Drawing.Color.Transparent;
            this.pbJugador3.Image = global::Forms.Properties.Resources.GloboTexto;
            this.pbJugador3.Location = new System.Drawing.Point(664, 12);
            this.pbJugador3.Name = "pbJugador3";
            this.pbJugador3.Size = new System.Drawing.Size(152, 124);
            this.pbJugador3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbJugador3.TabIndex = 20;
            this.pbJugador3.TabStop = false;
            this.pbJugador3.Visible = false;
            // 
            // FrmJuegoEnPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Forms.Properties.Resources.Mesa;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1191, 705);
            this.Controls.Add(this.pbJugador3);
            this.Controls.Add(this.pbJugador1);
            this.Controls.Add(this.pbJugador2);
            this.Controls.Add(this.pbJugador4);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.pbCartaMano);
            this.Controls.Add(this.btnTirarCarta);
            this.Controls.Add(this.lblJugador4);
            this.Controls.Add(this.lblJugador2);
            this.Controls.Add(this.lblJugador3);
            this.Controls.Add(this.btnAgarrarCarta);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.lblJugador1TotalCartas);
            this.Controls.Add(this.pbCartaMesa);
            this.Controls.Add(this.lblJugador4TotalCartas);
            this.Controls.Add(this.lblJugador3TotalCartas);
            this.Controls.Add(this.lblJugador2TotalCartas);
            this.Controls.Add(this.lblCartaMesa);
            this.Controls.Add(this.lstManoCartas);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1209, 752);
            this.Name = "FrmJuegoEnPartida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmJuegoEnPartida";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJuegoEnPartida_FormClosing);
            this.Load += new System.EventHandler(this.FrmJuegoEnPartida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCartaMesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCartaMano)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJugador4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJugador2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJugador1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJugador3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstManoCartas;
        private System.Windows.Forms.Label lblCartaMesa;
        private System.Windows.Forms.Label lblJugador2TotalCartas;
        private System.Windows.Forms.Label lblJugador3TotalCartas;
        private System.Windows.Forms.Label lblJugador4TotalCartas;
        private System.Windows.Forms.PictureBox pbCartaMesa;
        private System.Windows.Forms.Label lblJugador1TotalCartas;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Button btnAgarrarCarta;
        private System.Windows.Forms.Label lblJugador3;
        private System.Windows.Forms.Label lblJugador2;
        private System.Windows.Forms.Label lblJugador4;
        private System.Windows.Forms.Button btnTirarCarta;
        private System.Windows.Forms.PictureBox pbCartaMano;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.PictureBox pbJugador4;
        private System.Windows.Forms.PictureBox pbJugador2;
        private System.Windows.Forms.PictureBox pbJugador1;
        private System.Windows.Forms.PictureBox pbJugador3;
    }
}