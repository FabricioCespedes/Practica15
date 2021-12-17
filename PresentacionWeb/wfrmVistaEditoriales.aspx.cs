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
    public partial class wfrmVistaEditoriales : System.Web.UI.Page
    {
        LNEditorial lNEditorial = new LNEditorial(Config.getCadConexion);

        private void cargarDataGrid(string condicion = "")
        {
            DataTable dataTable;
            try
            {
                dataTable = lNEditorial.ListarRegistros(condicion);
                if (dataTable != null)
                {
                    gvEditorial.DataSource = dataTable;
                    gvEditorial.DataBind();
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

        protected void gvEditorial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEditorial.PageIndex = e.NewPageIndex;
            cargarDataGrid();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion = condicion = $" nombre like '%{txtTitulo.Text}%'";
            cargarDataGrid(condicion);
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar(" ");
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrmEditorial.aspx");
        }

        protected void LinkButton3_Command(object sender, CommandEventArgs e)
        {
            Session["_claveEditorial"] = e.CommandArgument.ToString();
            Response.Redirect("wfrmEjemplaresAsociados.aspx");
        }

        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            try
            {
                EEjemplar ejemplar; 
                string condicion = $" claveEditorial = '{e.CommandArgument.ToString()}'";
                LNEjemplar lNEjemplar = new LNEjemplar(Config.getCadConexion);
                ejemplar = lNEjemplar.BuscarRegistro(condicion);
                if (ejemplar.ClaveEjemplar == null)
                {
                    Session["_claveEditorial"] = e.CommandArgument.ToString();
                    Response.Redirect("wfrmEliminarEditorial.aspx");
                }
                else
                {
                    Session["_wrn"] = "Advertensia, no se puede eliminar esta editorial ya que existen libros ligados a la editorial seleccionada";
                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $"Error: {ex.Message}";
            }
        }
    }
}