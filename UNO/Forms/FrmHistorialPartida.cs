using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class FrmHistorialPartida : Form
    {
        static string historial;

        public FrmHistorialPartida()
        {
            InitializeComponent();
        }
        public FrmHistorialPartida(string historialRecibido) : this()
        {
            historial = historialRecibido;
        }

        private void FrmHistorialPartida_Load(object sender, EventArgs e)
        {
            BucleHistorial();
        }

        public static void ActualizarHistorial(string historialRecibido)
        {
            historial = historialRecibido;
        }
        
        private async void BucleHistorial()
        {
            while(true)
            { 
                var task = await Task.Run(async () =>
                {
                    controlHilo();
                    await Task.Delay(1000);
                    return 1;
                });
            }
        }

        private void controlHilo()
        {
            if (this.txtHistorial.InvokeRequired)
            {
                Action d = new Action(this.controlHilo);

                this.txtHistorial.Invoke(d);
            }
            else
            {
                this.txtHistorial.Text = historial;
            }
        }

        private void btnDescargarHistorial_Click(object sender, EventArgs e)
        {
            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\historial.txt", historial);
        }
    }
}
