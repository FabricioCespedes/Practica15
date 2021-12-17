using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LogicaNegocio
{
    public class LNEjemplar
    {
        private string cadConexion;
        public LNEjemplar()
        {
            cadConexion = string.Empty;
        }

        public LNEjemplar(string cadConexion)
        {
            this.cadConexion = cadConexion;
        }

        public DataTable ListarRegistros(string condicion)
        {
            DataTable result;
            ADEjemplar accesoDatos = new ADEjemplar(cadConexion);

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

        public EEjemplar BuscarRegistro(string condicion)
        {
            EEjemplar ejemplar;
            ADEjemplar accesoDatos = new ADEjemplar(cadConexion);
            try
            {
                ejemplar = accesoDatos.BuscarRegistro(condicion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ejemplar;
        }
    }
}
