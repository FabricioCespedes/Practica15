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
    public partial class wfrmLibroEliminar : System.Web.UI.Page
    {
        ELibro eLibro ;
        LNLibro lNLibro = new LNLibro(Config.getCadConexion);
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["_claveLibro"] != null)
                {
                    recuperarLibro(Session["_claveLibro"].ToString());
                }
                else
                {
                    Session["_wrn"] = "NO ha seleccionado un libro eliminar";
                    btnEliminar.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $" Error: {ex.Message}";
            }
        }

        private void recuperarLibro(string claveLibro)
        {
            string condicion = $" clave = '{claveLibro}'";
            DataTable dataTable;
            dataTable = lNLibro.listarTodosLibros(condicion, true);
            if (dataTable != null)
            {
                ViewState["_titulo"] = dataTable.Rows[0][1];
                ViewState["_autor"] = dataTable.Rows[0][2];
                ViewState["_categoria"] = dataTable.Rows[0][3];
            }
            else
            {
                Session["_wrn"] = "El libro seleccionado no existe en la base de datos";
                btnEliminar.Enabled = true;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("wfrmVistaLibros.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int result = -1;

            if (Session["_claveLibro"] != null)
            {
                try
                {
                    result = lNLibro.eliminar(Session["_claveLibro"].ToString());
                    if (result > 0)
                    {
                        Session.RemoveAll();
                        Session["_exito"] = $" Exito: ha eliminado un libro con exito";
                        Response.Redirect("wfrmVistaLibros.aspx",false);
                    }
                    else
                    {
                        Session["_wrn"] = "El libro seleccionado no existe en la base de datos";
                    }


                }
                catch (Exception ex)
                {

                    Session["_err"] = $" Error: {ex.Message}";
                }
            }
        }
    }
}