using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    public class PartidasDB : DataBases, IDataBases<Partida>
    {
        public PartidasDB() : base()
        {
            this.connection = new SqlConnection(DataBases.stringConnection);
        }
        public Partida RecuperarUno(Partida partidaIngresada)
        {
            Partida partidaCreada = null;

            try
            {
                this.command = new SqlCommand();

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = $"SELECT TOP (1) * FROM dbo.PartidasDB WHERE Inicio='{partidaIngresada.Inicio}'";
                this.command.Connection = this.connection;

                this.connection.Open();

                this.reader = this.command.ExecuteReader();

                if (this.reader.Read())
                {
                    partidaCreada = new(reader.GetDateTime(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5), reader.GetInt32(6), reader.GetString(7), reader.GetBoolean(8));
                }

                reader.Close();
            }
            catch (Exception)
            {
                partidaCreada = null;
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return partidaCreada;
        }

        public int CrearNuevo(Partida partidaNueva)
        {
            int retorno = -1;

            try
            {
                this.command = new SqlCommand();

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = $"INSERT INTO dbo.PartidasDB VALUES ('{partidaNueva.Inicio.ToString("yyyy-MM-dd HH:mm:ss")}','{partidaNueva.Creador}','{partidaNueva.TipoPartida}','{partidaNueva.Final.ToString("yyyy-MM-dd HH:mm:ss")}','-',0,'-',1)";
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

            return retorno;
        }

        public int Actualizar(Partida partida)
        {
            int retorno = -1;

            if (partida is not null)
            {
                try
                {
                    this.command = new SqlCommand();
                    this.command.CommandType = CommandType.Text;
                    this.command.CommandText = $"UPDATE dbo.PartidasDB SET Final = '{partida.Final.ToString("yyyy-MM-dd HH:mm:ss")}', Historial = '{partida.Historial}', CantidadCartasJugadas = '{partida.CantidadCartasJugadas}', Duracion = '{partida.Duracion}', EnCurso = '{partida.EnCurso}' WHERE Inicio = '{partida.Inicio.ToString("yyyy-MM-dd HH:mm:ss")}'";
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

        public List<Partida> DevolverLista()
        {
            List<Partida> listaPartida = new();
            Partida partidaAux;

            try
            {
                this.command = new SqlCommand();

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = $"SELECT * FROM dbo.PartidasDB";
                this.command.Connection = this.connection;

                this.connection.Open();

                this.reader = this.command.ExecuteReader();

                while(this.reader.Read())
                {
                    partidaAux = new Partida(reader.GetDateTime(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5), reader.GetInt32(6), reader.GetString(7), reader.GetBoolean(8));
                    partidaAux.Id = reader.GetInt32(0);
                    listaPartida.Add(partidaAux);
                }

                reader.Close();
            }
            catch (Exception)
            {
                listaPartida = null;
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return listaPartida;
        }

    }
}
