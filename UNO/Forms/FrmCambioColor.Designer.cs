
namespace Forms
{
    partial class FrmCambioColor
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
            this.btnRojo = new System.Windows.Forms.Button();
            this.btnVerde = new System.Windows.Forms.Button();
            this.btnAmarillo = new System.Windows.Forms.Button();
            this.btnAzul = new System.Windows.Forms.Button();
            this.lblCambioColor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRojo
            // 
            this.btnRojo.BackColor = System.Drawing.Color.Red;
            this.btnRojo.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRojo.Location = new System.Drawing.Point(84, 80);
            this.btnRojo.Name = "btnRojo";
            this.btnRojo.Size = new System.Drawing.Size(133, 90);
            this.btnRojo.TabIndex = 0;
            this.btnRojo.Text = "Rojo";
            this.btnRojo.UseVisualStyleBackColor = false;
            this.btnRojo.Click += new System.EventHandler(this.BtnElegido);
            // 
            // btnVerde
            // 
            this.btnVerde.BackColor = System.Drawing.Color.Lime;
            this.btnVerde.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVerde.Location = new System.Drawing.Point(257, 198);
            this.btnVerde.Name = "btnVerde";
            this.btnVerde.Size = new System.Drawing.Size(133, 90);
            this.btnVerde.TabIndex = 1;
            this.btnVerde.Text = "Verde";
            this.btnVerde.UseVisualStyleBackColor = false;
            this.btnVerde.Click += new System.EventHandler(this.BtnElegido);
            // 
            // btnAmarillo
            // 
            this.btnAmarillo.BackColor = System.Drawing.Color.Yellow;
            this.btnAmarillo.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAmarillo.Location = new System.Drawing.Point(84, 198);
            this.btnAmarillo.Name = "btnAmarillo";
            this.btnAmarillo.Size = new System.Drawing.Size(133, 90);
            this.btnAmarillo.TabIndex = 2;
            this.btnAmarillo.Text = "Amarillo";
            this.btnAmarillo.UseVisualStyleBackColor = false;
            this.btnAmarillo.Click += new System.EventHandler(this.BtnElegido);
            // 
            // btnAzul
            // 
            this.btnAzul.BackColor = System.Drawing.Color.Blue;
            this.btnAzul.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAzul.Location = new System.Drawing.Point(257, 80);
            this.btnAzul.Name = "btnAzul";
            this.btnAzul.Size = new System.Drawing.Size(133, 90);
            this.btnAzul.TabIndex = 3;
            this.btnAzul.Text = "Azul";
            this.btnAzul.UseVisualStyleBackColor = false;
            this.btnAzul.Click += new System.EventHandler(this.BtnElegido);
            // 
            // lblCambioColor
            // 
            this.lblCambioColor.AutoSize = true;
            this.lblCambioColor.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCambioColor.ForeColor = System.Drawing.Color.White;
            this.lblCambioColor.Location = new System.Drawing.Point(66, 20);
            this.lblCambioColor.Name = "lblCambioColor";
            this.lblCambioColor.Size = new System.Drawing.Size(371, 39);
            this.lblCambioColor.TabIndex = 4;
            this.lblCambioColor.Text = "A que color desea cambiar?";
            // 
            // FrmCambioColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(500, 353);
            this.Controls.Add(this.lblCambioColor);
            this.Controls.Add(this.btnAzul);
            this.Controls.Add(this.btnAmarillo);
            this.Controls.Add(this.btnVerde);
            this.Controls.Add(this.btnRojo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCambioColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elegir Color";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRojo;
        private System.Windows.Forms.Button btnVerde;
        private System.Windows.Forms.Button btnAmarillo;
        private System.Windows.Forms.Button btnAzul;
        private System.Windows.Forms.Label lblCambioColor;
    }
}