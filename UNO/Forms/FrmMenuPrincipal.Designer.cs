
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBotsVsBotsRapida = new System.Windows.Forms.Button();
            this.btnUserVsBotsRapida = new System.Windows.Forms.Button();
            this.btnBotsVsBots = new System.Windows.Forms.Button();
            this.btnUserVsBots = new System.Windows.Forms.Button();
            this.btnDescarga = new System.Windows.Forms.Button();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.dgvPartida = new System.Windows.Forms.DataGridView();
            this.gbTablas = new System.Windows.Forms.GroupBox();
            this.rbPartidas = new System.Windows.Forms.RadioButton();
            this.rbUsuarios = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartida)).BeginInit();
            this.gbTablas.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBotsVsBotsRapida
            // 
            this.btnBotsVsBotsRapida.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBotsVsBotsRapida.BackColor = System.Drawing.Color.Black;
            this.btnBotsVsBotsRapida.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBotsVsBotsRapida.ForeColor = System.Drawing.Color.White;
            this.btnBotsVsBotsRapida.Location = new System.Drawing.Point(1067, 492);
            this.btnBotsVsBotsRapida.Name = "btnBotsVsBotsRapida";
            this.btnBotsVsBotsRapida.Size = new System.Drawing.Size(218, 109);
            this.btnBotsVsBotsRapida.TabIndex = 0;
            this.btnBotsVsBotsRapida.Text = "Crear Partida Rapida Bots vs Bots";
            this.btnBotsVsBotsRapida.UseVisualStyleBackColor = false;
            this.btnBotsVsBotsRapida.Click += new System.EventHandler(this.btnBotsVsBotsRapida_Click);
            // 
            // btnUserVsBotsRapida
            // 
            this.btnUserVsBotsRapida.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUserVsBotsRapida.BackColor = System.Drawing.Color.Black;
            this.btnUserVsBotsRapida.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUserVsBotsRapida.ForeColor = System.Drawing.Color.White;
            this.btnUserVsBotsRapida.Location = new System.Drawing.Point(1067, 206);
            this.btnUserVsBotsRapida.Name = "btnUserVsBotsRapida";
            this.btnUserVsBotsRapida.Size = new System.Drawing.Size(218, 109);
            this.btnUserVsBotsRapida.TabIndex = 1;
            this.btnUserVsBotsRapida.Text = "Crear Partida Rapida User vs Bots ";
            this.btnUserVsBotsRapida.UseVisualStyleBackColor = false;
            this.btnUserVsBotsRapida.Click += new System.EventHandler(this.btnUserVsBotsRapida_Click);
            // 
            // btnBotsVsBots
            // 
            this.btnBotsVsBots.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBotsVsBots.BackColor = System.Drawing.Color.Black;
            this.btnBotsVsBots.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBotsVsBots.ForeColor = System.Drawing.Color.White;
            this.btnBotsVsBots.Location = new System.Drawing.Point(1067, 349);
            this.btnBotsVsBots.Name = "btnBotsVsBots";
            this.btnBotsVsBots.Size = new System.Drawing.Size(218, 109);
            this.btnBotsVsBots.TabIndex = 2;
            this.btnBotsVsBots.Text = "Crear Partida Normal Bots vs Bots ";
            this.btnBotsVsBots.UseVisualStyleBackColor = false;
            this.btnBotsVsBots.Click += new System.EventHandler(this.btnBotsVsBots_Click);
            // 
            // btnUserVsBots
            // 
            this.btnUserVsBots.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUserVsBots.BackColor = System.Drawing.Color.Black;
            this.btnUserVsBots.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUserVsBots.ForeColor = System.Drawing.Color.White;
            this.btnUserVsBots.Location = new System.Drawing.Point(1067, 58);
            this.btnUserVsBots.Name = "btnUserVsBots";
            this.btnUserVsBots.Size = new System.Drawing.Size(218, 109);
            this.btnUserVsBots.TabIndex = 3;
            this.btnUserVsBots.Text = "Crear Partida Normal User vs Bots";
            this.btnUserVsBots.UseVisualStyleBackColor = false;
            this.btnUserVsBots.Click += new System.EventHandler(this.btnUserVsBots_Click);
            // 
            // btnDescarga
            // 
            this.btnDescarga.BackColor = System.Drawing.Color.Black;
            this.btnDescarga.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDescarga.ForeColor = System.Drawing.Color.White;
            this.btnDescarga.Location = new System.Drawing.Point(280, 83);
            this.btnDescarga.Name = "btnDescarga";
            this.btnDescarga.Size = new System.Drawing.Size(158, 57);
            this.btnDescarga.TabIndex = 1;
            this.btnDescarga.Text = "Descargar Historial";
            this.btnDescarga.UseVisualStyleBackColor = false;
            this.btnDescarga.Click += new System.EventHandler(this.btnDescarga_Click);
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBienvenido.Location = new System.Drawing.Point(410, 20);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(225, 32);
            this.lblBienvenido.TabIndex = 5;
            this.lblBienvenido.Text = "Bienvenido Usuario!";
            // 
            // dgvPartida
            // 
            this.dgvPartida.AllowUserToAddRows = false;
            this.dgvPartida.AllowUserToDeleteRows = false;
            this.dgvPartida.AllowUserToResizeColumns = false;
            this.dgvPartida.AllowUserToResizeRows = false;
            this.dgvPartida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPartida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartida.BackgroundColor = System.Drawing.Color.LawnGreen;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPartida.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPartida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPartida.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPartida.GridColor = System.Drawing.Color.Black;
            this.dgvPartida.Location = new System.Drawing.Point(12, 146);
            this.dgvPartida.MultiSelect = false;
            this.dgvPartida.Name = "dgvPartida";
            this.dgvPartida.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPartida.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPartida.RowHeadersVisible = false;
            this.dgvPartida.RowHeadersWidth = 51;
            this.dgvPartida.RowTemplate.Height = 29;
            this.dgvPartida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartida.Size = new System.Drawing.Size(1034, 455);
            this.dgvPartida.TabIndex = 6;
            this.dgvPartida.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartida_CellClick);
            // 
            // gbTablas
            // 
            this.gbTablas.Controls.Add(this.rbPartidas);
            this.gbTablas.Controls.Add(this.rbUsuarios);
            this.gbTablas.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbTablas.Location = new System.Drawing.Point(12, 74);
            this.gbTablas.Name = "gbTablas";
            this.gbTablas.Size = new System.Drawing.Size(243, 66);
            this.gbTablas.TabIndex = 7;
            this.gbTablas.TabStop = false;
            this.gbTablas.Text = "Seleccionar Tabla a Visualizar";
            // 
            // rbPartidas
            // 
            this.rbPartidas.AutoSize = true;
            this.rbPartidas.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbPartidas.Location = new System.Drawing.Point(138, 26);
            this.rbPartidas.Name = "rbPartidas";
            this.rbPartidas.Size = new System.Drawing.Size(96, 28);
            this.rbPartidas.TabIndex = 1;
            this.rbPartidas.TabStop = true;
            this.rbPartidas.Text = "Partidas";
            this.rbPartidas.UseVisualStyleBackColor = true;
            this.rbPartidas.CheckedChanged += new System.EventHandler(this.rbPartidas_CheckedChanged);
            // 
            // rbUsuarios
            // 
            this.rbUsuarios.AutoSize = true;
            this.rbUsuarios.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbUsuarios.Location = new System.Drawing.Point(17, 26);
            this.rbUsuarios.Name = "rbUsuarios";
            this.rbUsuarios.Size = new System.Drawing.Size(100, 28);
            this.rbUsuarios.TabIndex = 0;
            this.rbUsuarios.TabStop = true;
            this.rbUsuarios.Text = "Usuarios";
            this.rbUsuarios.UseVisualStyleBackColor = true;
            this.rbUsuarios.CheckedChanged += new System.EventHandler(this.rbPartidas_CheckedChanged);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LawnGreen;
            this.ClientSize = new System.Drawing.Size(1328, 632);
            this.Controls.Add(this.gbTablas);
            this.Controls.Add(this.dgvPartida);
            this.Controls.Add(this.btnDescarga);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.btnUserVsBots);
            this.Controls.Add(this.btnBotsVsBots);
            this.Controls.Add(this.btnUserVsBotsRapida);
            this.Controls.Add(this.btnBotsVsBotsRapida);
            this.MinimumSize = new System.Drawing.Size(1122, 679);
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenuPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartida)).EndInit();
            this.gbTablas.ResumeLayout(false);
            this.gbTablas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBotsVsBotsRapida;
        private System.Windows.Forms.Button btnUserVsBotsRapida;
        private System.Windows.Forms.Button btnBotsVsBots;
        private System.Windows.Forms.Button btnUserVsBots;
        private System.Windows.Forms.Button btnDescarga;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.DataGridView dgvPartida;
        private System.Windows.Forms.GroupBox gbTablas;
        private System.Windows.Forms.RadioButton rbPartidas;
        private System.Windows.Forms.RadioButton rbUsuarios;
    }
}