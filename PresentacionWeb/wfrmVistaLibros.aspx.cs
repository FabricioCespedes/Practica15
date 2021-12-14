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
            if (!IsPostBack)
            {
                limpiar();

            }

        }

        private void limpiar(string condicion = "")
        {
            txtTitulo.Text = string.Empty;
            txtTitulo.Focus();
            cargarDataGrid();
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {
            //Session["_wrn"] = e.CommandArgument.ToString();

        }

        protected void gvLibros_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvLibros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLibros.PageIndex = e.NewPageIndex;
            cargarDataGrid();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion =
                condicion = $" titulo like '%{txtTitulo.Text}%'";
            
            cargarDataGrid(condicion);
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar(" ");
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrLibro.aspx");
        }
    }
}