using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using AccesoDatos;
using System.Data;

namespace LogicaNegocio
{
    public class LNLibro
    {
        private string mensaje;
        private string cadConexion;
        ADLibro adLibro ;

        #region Constructores
        public LNLibro() {
            mensaje = string.Empty;
            cadConexion = string.Empty;
        }
        public LNLibro(string cadena) {
            mensaje = string.Empty;
            cadConexion = cadena;
            adLibro = new ADLibro(cadConexion);
        }
        #endregion

        #region Metrodos
        public bool libroRepetido(ELibro libro) {
            bool result = false;
            try
            {
                result = adLibro.libroRepetido(libro);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool claveLibroRepetida(string clave)
        {
            bool result = false;
            try
            {
                result = adLibro.claveLibroRepetida(clave);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public int insertar(ELibro libro) {
            int result;
            try
            {
                result = adLibro.insertar(libro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataSet listarTodos(string condicion = "") {
            DataSet setLibros;
            try
            {
                setLibros = adLibro.listarTodos(condicion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return setLibros;
        }

        public ELibro buscarRegistro(string condicion) {
            ELibro libro;
            try
            {
                libro = adLibro.buscarRegistro(condicion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return libro;
        }


        public int eliminar(ELibro libro) {
            int result;
            try
            {
                result = adLibro.eliminar(libro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public string eliminarProcedure(ELibro libro) {
            try
            {
                mensaje = adLibro.eliminarProcedure(libro);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        public int modificar(ELibro libro, string claveVieja = "") {
            int result;
            try
            {
                result = adLibro.modificar(libro, claveVieja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable listarTodosLibros(string condicion, bool desdeVista)
        {
            DataTable dataTable;

            try
            {
                dataTable = adLibro.listarTodosLibros(condicion, desdeVista);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dataTable;
        }
        #endregion
    }
}
