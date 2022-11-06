﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Biblioteca_de_clases
{
    public class UsuariosDB
    {
        private static string stringConnection;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        static UsuariosDB()
        {
            UsuariosDB.stringConnection = @"Server=.;Database=UsuariosUNO;Trusted_Connection=True;";
        }
        public UsuariosDB()
        {
            this.connection = new SqlConnection(UsuariosDB.stringConnection);
        }
        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                this.connection.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return rta;
        }

        public Usuarios LogearUsuario(string usuario, string contraseña)
        {
            Usuarios usuarioLogeado = null;

            try
            {
                this.command = new SqlCommand();

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = $"SELECT * FROM dbo.UsuariosDB WHERE Usuario='{usuario}' AND Contraseña='{contraseña}'";
                this.command.Connection = this.connection;

                this.connection.Open();

                this.reader = this.command.ExecuteReader();

                if(this.reader.Read())
                {
                    usuarioLogeado = new(reader.GetString(1), reader.GetString(2));

                    usuarioLogeado.PartidasGanadas = reader.GetInt32(3);
                    usuarioLogeado.PartidasJugadas = reader.GetInt32(4);
                    usuarioLogeado.UltimoLogeo = reader.GetDateTime(5);
                    usuarioLogeado.Winrate = reader.GetInt32(6);
                }

                reader.Close();
            }
            catch(Exception)
            {

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

        public int CrearUsuario(string usuario, string contraseña, string repetirContraseña)
        {
            int retorno = -1;

            if(contraseña == repetirContraseña)
            {
                try
                {
                    this.command = new SqlCommand();

                    this.command.CommandType = CommandType.Text;
                    this.command.CommandText = $"SELECT * FROM dbo.UsuariosDB WHERE Usuario='{usuario}'";
                    this.command.Connection = this.connection;

                    this.connection.Open();

                    this.reader = this.command.ExecuteReader();

                    if(!this.reader.Read())
                    {
                        this.reader.Close();
                        this.command.CommandText = $"INSERT INTO dbo.UsuariosDB (Usuario,Contraseña) VALUES ('{usuario}','{contraseña}')";
                        retorno = this.command.ExecuteNonQuery();
                    }

                    this.reader.Close();
                }
                catch (Exception)
                {

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

        public int ActualizarUsuario(Usuarios usuario)
        {
            int retorno = -1;

            if(usuario is not null)
            {
                try
                {
                    this.command = new SqlCommand();
                    string ultimoLogeo = $"{usuario.UltimoLogeo.Year}-{usuario.UltimoLogeo.Month}-{usuario.UltimoLogeo.Day}";
                    this.command.CommandType = CommandType.Text;
                    this.command.CommandText = $"UPDATE dbo.UsuariosDB SET PartidasGanadas = {usuario.PartidasGanadas}, PartidasJugadas = {usuario.PartidasGanadas}, Winrate = {usuario.Winrate}, UltimoLogeo = '{ultimoLogeo}' WHERE Usuario = '{usuario.Usuario}'";
                    this.command.Connection = this.connection;

                    this.connection.Open();

                    retorno = this.command.ExecuteNonQuery();
                   
                }
                catch (Exception)
                {

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

    }
}