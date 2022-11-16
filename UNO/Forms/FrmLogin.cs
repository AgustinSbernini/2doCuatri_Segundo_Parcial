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
        string usuarioIngresado;
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
            // Prueba si anda la conexion
            if(this.usuarioDB.ProbarConexion())
            {
                // Recolecta el usuario ingresado sin espacios
                this.usuarioIngresado = this.txtUsuario.Text.Trim();

                if (this.flagLogin)
                {
                    // Evita logear con los bots, si tiene una cuenta registrada se logea
                    if(this.usuarioIngresado != "Jugador 1" && this.usuarioIngresado != "Jugador 2" && this.usuarioIngresado != "Jugador 3" && this.usuarioIngresado != "Jugador 4")
                    {
                        this.usuario = new(this.usuarioIngresado, this.txtContraseña.Text.Trim());
                        this.usuario = this.usuarioDB.RecuperarUno(this.usuario);
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
                    // Registra un usuario en la base de datos si las contraseñas son iguales y si no esta creado antes
                    if(this.txtContraseña.Text == this.txtRepetirContraseña.Text)
                    {
                        this.usuario = new(this.txtUsuario.Text, this.txtContraseña.Text);
                        this.validar = this.usuarioDB.CrearNuevo(this.usuario);
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (this.validar != -1)
                    {
                        MessageBox.Show("El usuario se ha registrado con exito!", "Registro Completo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.btnRegistrar_Click(sender, e);
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
            // Muestra el formulario en forma de Registro
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
                // Vuelve el formulario a su forma de Login
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
