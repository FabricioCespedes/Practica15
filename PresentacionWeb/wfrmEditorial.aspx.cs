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
    public partial class wfrmEditorial : System.Web.UI.Page
    {

        LNEditorial lNEditorial = new LNEditorial(Config.getCadConexion);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = $" claveEditorial= '{txtClaveEditorial.Text}'";
                EEditorial editorial = lNEditorial.BuscarRegistro(condicion);
                if (editorial.Nombre == null)
                {
                    condicion = $" nombre= '{txtNombre.Text}'";
                    editorial = lNEditorial.BuscarRegistro(condicion);
                    if (editorial.Nombre == null)
                    {
                        editorial.ClaveEditorial = txtClaveEditorial.Text;
                        editorial.Nombre = txtNombre.Text;

                        if (lNEditorial.insertar(editorial) > 0)
                        {
                            Session["_exito"] = " Mensaje: Ha guardado el editorial con exito ";
                            limpiar();
                        }
                        else
                        {
                            txtNombre.Focus();
                            Session["_wrn"] = " Atencion: No ha guardado el editorial con exito ";
                        }
                    }
                    else
                    {
                        Session["_wrn"] = " Atencion: El nombre de editorial ya esta en uso";
                        txtClaveEditorial.Focus();
                    }

                }
                else
                {
                    Session["_wrn"] = " Atencion: La clave de la editorial ya esta en uso";
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session.Remove("_error");
            Session.Remove("_wrn");
            Session.Remove("_exito");
            Response.Redirect("wfrmVistaEditoriales.aspx");
        }

        private void limpiar()
        {
            txtClaveEditorial.Text = "";
            txtNombre.Text = "";

        }

    }
}