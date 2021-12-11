using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class wfrmVistaLibros : System.Web.UI.Page
    {
        LNLibro lNLibro = new LNLibro(Config.getCadConexion);
        private void cargarDataGrid(string condicion = "")
        {
            DataTable dataTable;
            try
            {
                dataTable = lNLibro.listarTodosLibros(condicion, true);
                if (dataTable != null)
                {
                    gvLibros.DataSource = dataTable;
                    gvLibros.DataBind();
                }
                else
                {
                    Session["_wrn"] = "No se encontraron libro";
                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $"Error: {ex.Message}";
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtTitulo.Text = string.Empty;
            txtTitulo.Focus();
            cargarDataGrid();
            Session["_err"] = "Hola";
        }


    }
}