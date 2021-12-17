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
    public partial class wfrmEjemplaresAsociados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrmVistaEditoriales.aspx");
        }

        protected void gvEjemplares_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEjemplares.PageIndex = e.NewPageIndex;
            cargarDataGrid();
        }

        private void cargarDataGrid()
        {
            try
            {
                LNEjemplar lNEjemplar = new LNEjemplar(Config.getCadConexion);
                DataTable dataTable;
                string condicion = $"  e.claveEditorial = '{Session["_claveEditorial"]}'";
                dataTable = lNEjemplar.ListarRegistros(condicion);
                if (dataTable != null)
                {
                    gvEjemplares.DataSource = dataTable;
                    gvEjemplares.DataBind();
                }
                else
                {
                    Session["_wrn"] = "No se encontraron editoriales";
                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $"Error: {ex.Message}";
            }
        }
    }
}