using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AccesoDatos
{
    public class ADEjemplar
    {
        public ADEjemplar(string cadConec)
        {
            cadConexion = cadConec;
        }
        public ADEjemplar()
        {
            cadConexion = string.Empty;
        }

        private string cadConexion;

        public DataTable ListarRegistros(string condicion)
        {
            DataTable result = new DataTable();
            SqlDataAdapter adaptador;
            SqlConnection conexion = new SqlConnection(cadConexion);

            string sentencia = "Select e.claveEjemplar as clave, l.titulo as libro, c.descripcion as condicion, est.descripcion as estado, e.edicion as edicion, edi.nombre as editorial , e.numeroPaginas as paginas From Ejemplar e join libro l on e.claveLibro = l.claveLibro join CONDICION c on e.claveCondicion = c.claveCondicion join ESTADO est on e.claveEstado = est.claveEstado join EDITORIAL edi on e.claveEditorial = edi.claveEditorial ";

            if (!string.IsNullOrEmpty(condicion))
                sentencia = $"{sentencia} Where {condicion}";

            try
            {
                adaptador = new SqlDataAdapter(sentencia, conexion);
                adaptador.Fill(result);
            }
            catch (Exception)
            {
                throw new Exception("Se ha presentado un error extrayendo la lista de ejemplares");
            }

            return result;
        }

        public EEjemplar BuscarRegistro(string condicion)
        {
            EEjemplar ejemplar = new EEjemplar();
            string sentencia;
            SqlCommand comandoSQL = new SqlCommand();
            SqlConnection conexionSQL = new SqlConnection(cadConexion);
            SqlDataReader dato;
            sentencia = "select claveEjemplar from EJEMPLAR";
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
                    ejemplar.ClaveEjemplar = dato.GetString(0);
                }
                conexionSQL.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error al recuperar el registro!");
            }
            return ejemplar;
        }
    }
}
