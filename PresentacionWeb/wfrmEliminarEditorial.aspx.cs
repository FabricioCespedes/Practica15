using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class wfrmEliminarEditorial : System.Web.UI.Page
    {
        LNEditorial lNEditorial = new LNEditorial(Config.getCadConexion);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["_claveEditorial"] != null)
                {
                    recuperarEditorial(Session["_claveEditorial"].ToString());
                }
                else
                {
                    Session["_wrn"] = "No ha seleccionado una editorial a eliminar";
                    btnEliminar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error: {ex.Message}";
            }
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("wfrmVistaEditoriales.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int result = -1;
            if (Session["_claveEditorial"] != null)
            {
                try
                {
                    result = lNEditorial.eliminar(Session["_claveEditorial"].ToString());
                    if (result > 0)
                    {
                        Session.RemoveAll();
                        Session["_exito"] = $" Exito: ha eliminado una editorial con exito";
                        Response.Redirect("wfrmVistaEditoriales.aspx", false);
                    }
                    else
                    {
                        Session["_wrn"] = "El editorial seleccionado no existe en la base de datos";
                    }


                }
                catch (Exception ex)
                {

                    Session["_err"] = $" Error: {ex.Message}";
                }
            }

        }

        private void recuperarEditorial(string claveEditorial)
        {
            string condicion = $" claveEditorial = '{claveEditorial}'";
            EEditorial eEditorial;
            eEditorial = lNEditorial.BuscarRegistro(condicion);
            if (eEditorial.ClaveEditorial != null)
            {
                ViewState["_claveEditorial"] = eEditorial.ClaveEditorial;
                ViewState["_nombre"] = eEditorial.Nombre;
            }
            else
            {
                Session["_wrn"] = "La editorial seleccionada no existe en la base de datos";
                btnEliminar.Enabled = true;
            }
        }
    }

}