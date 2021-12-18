using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AccesoDatos
{
    public class ADEditorial
    {
        public ADEditorial(string cadConec)
        {
            cadConexion = cadConec;
        }
        public ADEditorial()
        {
            cadConexion = string.Empty;
        }

        private string cadConexion;

        public EEditorial BuscarRegistro(string condicion)
        {
            EEditorial editorial = new EEditorial();
            string sentencia;
            SqlCommand comandoSQL = new SqlCommand();
            SqlConnection conexionSQL = new SqlConnection(cadConexion);
            SqlDataReader dato;
            sentencia = "Select claveEditorial, nombre From Editorial";
            if (!string.IsNullOrEmpty(condicion))
                sentencia = string.Format("{0} Where {1}", sentencia, condicion);
            comandoSQL.Connection = conexionSQL;
            comandoSQL.CommandText = sentencia;
            try
            {
                conexionSQL.Open();
                dato = comandoSQL.ExecuteReader();
                if (dato.HasRows)
                {
                    dato.Read();
                    editorial.ClaveEditorial = dato.GetString(0);
                    editorial.Nombre = !dato.IsDBNull(1) ? dato.GetString(1) : "";
                }
                conexionSQL.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error al recuperar el registro de editoriales!");
            }
            return editorial;
        }

        public int insertar(EEditorial editorial)
        {
            int result = -1;
            string sentencia = "Insert into Editorial(claveEditorial, nombre)" +
                " values(@claveEditorial,@nombre)";

            SqlConnection conexion = new SqlConnection(cadConexion);
            SqlCommand comando = new SqlCommand(sentencia, conexion);

            comando.Parameters.AddWithValue("@claveEditorial", editorial.ClaveEditorial);
            comando.Parameters.AddWithValue("@nombre", editorial.Nombre);


            try
            {
                conexion.Open();
                result = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                throw new Exception("No se ha logrado insertar una editorial");
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }

            return result;
        }

        public DataTable ListarRegistros(string condicion)
        {
            DataTable result = new DataTable();
            SqlDataAdapter adaptador;
            SqlConnection conexion = new SqlConnection(cadConexion);

            string sentencia = "Select * From Editorial";

            if (!string.IsNullOrEmpty(condicion))
                sentencia = $"{sentencia} Where {condicion}";

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion);
                adaptador.Fill(result);
            }
            catch (Exception)
            {
                throw new Exception("Se ha presentado un error extrayendo la lista de editoriales");
            }

            return result;
        }

        public int eliminar(string claveEditorial)
        {
            int result = -1;
            string sentecia = "Delete from Editorial Where claveEditorial=@claveEditorial";

            SqlConnection conexion = new SqlConnection(cadConexion);
            SqlCommand comando = new SqlCommand(sentecia, conexion);

            comando.Parameters.AddWithValue("@claveEditorial", claveEditorial);

            try
            {
                conexion.Open();
                result = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                result = -1;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }

            return result;
        }

        public int modificar(EEditorial editorial, string claveVieja = "")
        {
            int result = -1;
            string sentencia;

            SqlConnection conexion = new SqlConnection(cadConexion);
            SqlCommand comando = new SqlCommand();

            if (string.IsNullOrEmpty(claveVieja))
                sentencia = "Update Editorial set nombre=@nombre Where claveEditorial=@claveEditorial";
            else
                sentencia = $"Update Editorial set claveEditorial=@claveEditorial, nombre=@nombre Where claveEditorial='{claveVieja}'";
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            comando.Parameters.AddWithValue("@claveEditorial", editorial.ClaveEditorial);
            comando.Parameters.AddWithValue("@nombre", editorial.Nombre);

            try
            {
                conexion.Open();
                result = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error Actualizando");
            }
            finally
            {
                comando.Dispose();
                conexion.Dispose();
            }
            return result;
        }
    }
}
