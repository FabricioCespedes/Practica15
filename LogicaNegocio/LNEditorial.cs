using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LogicaNegocio
{
    public class LNEditorial
    {
        private string cadConexion;
        ADEditorial accesoDatos;

        public LNEditorial(string cadConexion)
        {
            this.cadConexion = cadConexion;
            accesoDatos = new ADEditorial(cadConexion);

        }

        public EEditorial BuscarRegistro(string condicion)
        {
            EEditorial editorial;

            try
            {
                editorial = accesoDatos.BuscarRegistro(condicion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return editorial;
        }

        public int insertar(EEditorial editorial)
        {
            int result;
            try
            {
                result = accesoDatos.insertar(editorial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable ListarRegistros(string condicion = "")
        {
            DataTable result;
            try
            {
                result = accesoDatos.ListarRegistros(condicion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public int eliminar(EEditorial editorial)
        {
            int result;
            try
            {
                result = accesoDatos.eliminar(editorial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
