using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca_de_clases;

namespace Forms
{
    public partial class FrmMenuPrincipal : Form
    {
        Usuarios usuario;
        FrmJuegoEnPartida frmJuegoEnPartida;
        bool soloBots;
        int cantidadCartas;
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }
        public FrmMenuPrincipal(Usuarios usuario) : this()
        {
            this.usuario = usuario;
        }


        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro desea cerrar el programa?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnUserVsBotsRapida_Click(object sender, EventArgs e)
        {
            this.soloBots = false;
            this.cantidadCartas = 1;
            this.CrearSala(soloBots, cantidadCartas);
        }

        private void btnUserVsBots_Click(object sender, EventArgs e)
        {
            this.soloBots = false;
            this.cantidadCartas = 7;
            this.CrearSala(soloBots, cantidadCartas);
        }

        private void btnBotsVsBotsRapida_Click(object sender, EventArgs e)
        {
            this.soloBots = true;
            this.cantidadCartas = 1;
            this.CrearSala(soloBots, cantidadCartas);
        }

        private void btnBotsVsBots_Click(object sender, EventArgs e)
        {
            this.soloBots = true;
            this.cantidadCartas = 7;
            this.CrearSala(soloBots, cantidadCartas);
        }

        private void CrearSala(bool bots, int cantCartas)
        {
            Task task = Task.Run(() =>
            {
                SalasAisladas(this.usuario, bots, cantCartas);
            });
        }
        private void SalasAisladas(Usuarios usuario, bool bots, int cantCartas)
        {
            this.frmJuegoEnPartida = new(usuario, bots, cantCartas);
            this.frmJuegoEnPartida.ShowDialog();
        }
    }
}
