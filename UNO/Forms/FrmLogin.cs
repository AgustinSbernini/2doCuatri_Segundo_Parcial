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
    public partial class FrmLogin : Form
    {
        UsuariosDB usuarioDB;
        Usuarios usuario;
        bool flagLogin;
        FrmJuegoEnPartida frmJuegoEnpartida;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            usuarioDB = new();
            this.txtUsuario.Text = "Agustin";
            this.txtContraseña.Text = "agus123";
            this.txtRepetirContraseña.Visible = false;
            this.lblRepetirContraseña.Visible = false;
            flagLogin = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(flagLogin)
            {
                usuario = this.usuarioDB.LogearUsuario(this.txtUsuario.Text, this.txtContraseña.Text);
                frmJuegoEnpartida = new(usuario, 4);
                frmJuegoEnpartida.Show();
            }
            else
            {
                int validar = this.usuarioDB.CrearUsuario(this.txtUsuario.Text, this.txtContraseña.Text, txtRepetirContraseña.Text);
                if (validar != -1)
                {
                    MessageBox.Show(validar.ToString());
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            /*
            if(usuario != null)
            {
                MessageBox.Show(this.usuario.ToString());
            }
            else
            {
                MessageBox.Show("Usuario o contraseña invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(flagLogin)
            {
                this.txtRepetirContraseña.Visible = true;
                this.lblRepetirContraseña.Visible = true;
                this.btnLogin.Text = "Completar Registro";
                this.btnRegistrar.Text = "Cancelar";
                this.Text = "Registrar Usuario";
                flagLogin = false;
            }
            else
            {
                this.txtRepetirContraseña.Visible = false;
                this.lblRepetirContraseña.Visible = false;
                this.btnLogin.Text = "Login";
                this.btnRegistrar.Text = "Registrarse";
                this.Text = "Login";
                flagLogin = true;
            }
        }
        /*
        private void button1_click(object sender, eventargs e)
        {
            usuarios useraux = new usuarios("asd", "asd");
            useraux.partidasjugadas = 12;
            useraux.partidasganadas = 2;
            int num = (int) ((2 / 12.0) * 100);
            useraux.winrate = num;
            int validar = usuariodb.actualizarusuario(useraux);

            if (validar != -1)
            {
                messagebox.show(useraux.tostring());
            }
            else
            {
                messagebox.show("usuario o contraseña invalido", "error", messageboxbuttons.ok, messageboxicon.error);
            }
        }*/
    }
}
