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
        FrmMenuPrincipal frmMenuPrincipal;
        int validar;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.usuarioDB = new();
            this.txtUsuario.Text = "Agustin";
            this.txtContraseña.Text = "agus123";
            this.txtRepetirContraseña.Visible = false;
            this.lblRepetirContraseña.Visible = false;
            this.flagLogin = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(this.usuarioDB.ProbarConexion())
            {
                if(this.flagLogin)
                {
                    if(this.txtUsuario.Text != "Jugador 1" && this.txtUsuario.Text != "Jugador 2" && this.txtUsuario.Text != "Jugador 3" && this.txtUsuario.Text != "Jugador 4")
                    {
                        this.usuario = this.usuarioDB.RecuperarUno(this.txtUsuario.Text, this.txtContraseña.Text);
                    }
                    if (usuario != null)
                    {
                        this.frmMenuPrincipal = new(usuario);
                        this.Hide();
                        if(this.frmMenuPrincipal.ShowDialog() == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }   
                }
                else
                {
                    if(this.txtContraseña.Text == txtRepetirContraseña.Text)
                    {
                        this.validar = this.usuarioDB.CrearNuevo(this.txtUsuario.Text, this.txtContraseña.Text);
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (this.validar != -1)
                    {
                        MessageBox.Show("El usuario se ha registrado con exito!", "Registro Completo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("El usuario ya esta registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error al intentar conectarse a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                this.flagLogin = false;
            }
            else
            {
                this.txtRepetirContraseña.Visible = false;
                this.lblRepetirContraseña.Visible = false;
                this.btnLogin.Text = "Login";
                this.btnRegistrar.Text = "Registrarse";
                this.Text = "Login";
                this.flagLogin = true;
            }
        }
    }
}
