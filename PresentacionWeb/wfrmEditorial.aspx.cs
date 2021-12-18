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
        EEditorial editorial =  new EEditorial();
        protected void Page_Load(object sender, EventArgs e)
        {
            string condicion;
            if (!IsPostBack)
            {
                limpiar();
                if (Session["_claveEditorial"] != null)
                {
                    condicion = $" claveEditorial = '{Session["_claveEditorial"].ToString()}'";
                    editorial = lNEditorial.BuscarRegistro(condicion);
                    if (editorial.ClaveEditorial != null)
                    {
                        txtClaveEditorial.Text = Session["_claveEditorial"].ToString();
                        txtNombre.Text = editorial.Nombre;

                        HttpCookie cookie = new HttpCookie("SessionUser");
                        if (cookie != null)
                        {
                            cookie["_claveEditorial"] = Session["_claveEditorial"].ToString();
                            cookie["_nombre"] = editorial.Nombre;                            
                            cookie.Expires = DateTime.Now.AddDays(1);
                            Response.Cookies.Add(cookie);
                        }
                    }
                }

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["_claveEditorial"] != null)
                {
                    bool clave = false; bool nom = false;
                    if (verificarAlgunCambio(ref clave, ref nom) == true)
                    {
                        editorial.ClaveEditorial = txtClaveEditorial.Text;
                        editorial.Nombre = txtNombre.Text;
                        if (editorial.ClaveEditorial != Session["_claveEditorial"].ToString())
                        {
                            if (clave == true )
                            {
                                string condicion = $" claveEditorial= '{editorial.ClaveEditorial}'";
                                if (lNEditorial.BuscarRegistro(condicion).ClaveEditorial == null)
                                {
                                    cambiar(Session["_claveEditorial"].ToString(), nom);
                                }
                                else
                                {
                                    Session["_wrn"] = " Atencion: No la clave de editorial ya existe";
                                }
                            }

                        }
                        else
                        {
                            if (nom == true)
                            {
                                string condicion = $" nombre= '{editorial.Nombre}'";
                                if (lNEditorial.BuscarRegistro(condicion).ClaveEditorial == null)
                                {
                                    cambiar("", nom);
                                }
                                else
                                {
                                    Session["_wrn"] = " Atencion: El nombre del editorial ya existe";
                                }
                            }

                        }
                    }
                }
                else
                {
                    string condicion = $" claveEditorial= '{txtClaveEditorial.Text}'";
                    editorial = lNEditorial.BuscarRegistro(condicion);
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

        private bool verificarAlgunCambio(ref bool clave, ref bool nombre)
        {
            bool resul = false;

            if (Request.Cookies["SessionUser"] != null)
            {
                if (txtClaveEditorial.Text != Request.Cookies["SessionUser"]["_claveEditorial"])
                {
                    resul = true;
                    clave = true;
                }
            }
            //if (Request.Cookies["SessionUser"]["_nombre"] != null)            {
                if (txtNombre.Text != Request.Cookies["SessionUser"]["_nombre"])
                {
                    resul = true;
                    nombre = true;
                }
            //}
            return resul;
        }

        private void cambiar(string clave, bool nombre)
        {

            if (nombre == false )
            {
                hacerModificacion(clave);
            }
            else
            {
                hacerModificacion(clave);
            }



        }

        private void hacerModificacion(string clave)
        {
            if (lNEditorial.modificar(editorial, clave) > 0)
                Session["_exito"] = " Mensaje: Ha actualizado la editorial con exito ";
            else
                Session["_wrn"] = " Atencion:No se pudo modificar";

            limpiar();
        }
    }
}