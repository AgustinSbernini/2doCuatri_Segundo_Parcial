using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Biblioteca_de_clases
{
    public class UsuariosDB : DataBases, IDataBases<Usuarios>
    {
        public UsuariosDB() : base()
        {
            this.connection = new SqlConnection(DataBases.stringConnection);
        }
        public bool ProbarConexion()
        {
            bool retorno = true;

            try
            {
                this.connection.Open();
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return retorno;
        }

        public Usuarios RecuperarUno(Usuarios usuarioIngresado)
        {
            Usuarios usuarioLogeado = null;

            try
            {
                this.command = new SqlCommand();

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = $"SELECT * FROM dbo.UsuariosDB WHERE Usuario='{usuarioIngresado.Usuario}' AND Contraseña='{usuarioIngresado.Contraseña}'";
                this.command.Connection = this.connection;

                this.connection.Open();

                this.reader = this.command.ExecuteReader();

                if (this.reader.Read())
                {
                    usuarioLogeado = new(reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetDateTime(6));
                    usuarioLogeado.Id = reader.GetInt32(0);
                }

                reader.Close();
            }
            catch (Exception)
            {
                usuarioLogeado = null;
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return usuarioLogeado;
        }

        public int CrearNuevo(Usuarios usuarioNuevo)
        {
            int retorno = -1;

            try
            {
                this.command = new SqlCommand();

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = $"SELECT * FROM dbo.UsuariosDB WHERE Usuario='{usuarioNuevo.Usuario}'";
                this.command.Connection = this.connection;

                this.connection.Open();

                this.reader = this.command.ExecuteReader();

                if (!this.reader.Read())
                {
                    this.reader.Close();
                    this.command.CommandText = $"INSERT INTO dbo.UsuariosDB VALUES ('{usuarioNuevo.Usuario}','{usuarioNuevo.Contraseña}',{usuarioNuevo.PartidasGanadas},{usuarioNuevo.PartidasJugadas},{usuarioNuevo.Winrate},'{usuarioNuevo.UltimoLogeo.ToString("yyyy-MM-dd HH:mm:ss")}')";
                    retorno = this.command.ExecuteNonQuery();
                }
                else
                {
                    this.reader.Close();
                }
            }
            catch (Exception e)
            {
                retorno = -1;
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }


            return retorno;
        }

        public int Actualizar(Usuarios usuario)
        {
            int retorno = -1;

            if (usuario is not null)
            {
                try
                {
                    this.command = new SqlCommand();
                    this.command.CommandType = CommandType.Text;
                    this.command.CommandText = $"UPDATE dbo.UsuariosDB SET PartidasGanadas = {usuario.PartidasGanadas}, PartidasJugadas = {usuario.PartidasJugadas}, Winrate = {usuario.Winrate}, UltimoLogeo = '{usuario.UltimoLogeo.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE Usuario = '{usuario.Usuario}'";
                    this.command.Connection = this.connection;

                    this.connection.Open();

                    retorno = this.command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    retorno = -1;
                }
                finally
                {
                    if (this.connection.State == ConnectionState.Open)
                    {
                        this.connection.Close();
                    }
                }
            }

            return retorno;
        }

        public List<Usuarios> DevolverLista()
        {
            List<Usuarios> listaUsuario = new();

            try
            {
                this.command = new SqlCommand();

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = $"SELECT * FROM dbo.UsuariosDB ORDER BY -Winrate";
                this.command.Connection = this.connection;

                this.connection.Open();

                this.reader = this.command.ExecuteReader();

                while (this.reader.Read())
                {
                    Usuarios usuarioAux = new(reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetDateTime(6));
                    usuarioAux.Id = reader.GetInt32(0);

                    listaUsuario.Add(usuarioAux);
                }

                reader.Close();
            }
            catch (Exception)
            {
                listaUsuario = null;
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return listaUsuario;
        }
    }
}
