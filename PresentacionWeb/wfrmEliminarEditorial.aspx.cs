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
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    string condicion = $" claveEditorial = '{Session["_claveEditorial"]}'";
            //    LNEditorial lNEditorial = new LNEditorial(Config.getCadConexion);
            //    EEditorial editorial = new EEditorial();
            //    editorial = lNEditorial.BuscarRegistro(condicion);
            //    if (editorial.ClaveEditorial != null)
            //    {
            //        txt
            //    }
            //    else
            //    {
            //        Session["_wrn"] = "Advertencia: la editorial seleccionada no existe o ya fue eliminada.";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Session["_err"] = $"Error: {ex.Message}";
            //}
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfrmVistaEditoriales.aspx");

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {



        }

        private void recuperarEditorial(string v)
        {
            //try
            //{
            //    string condicion = $" claveEditorial = '{v}'";
            //    LNEditorial lNEditorial = new LNEditorial(Config.getCadConexion);
            //    EEditorial editorial = new EEditorial();
            //    editorial = lNEditorial.BuscarRegistro(condicion);
            //    if (editorial.ClaveEditorial != null)
            //    {

            //    }
            //    else
            //    {
            //        Session["_wrn"] = "Advertencia: la editorial seleccionada no existe o ya fue eliminada.";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Session["_err"] = $"Error: {ex.Message}";
            //}
        }
    }

}