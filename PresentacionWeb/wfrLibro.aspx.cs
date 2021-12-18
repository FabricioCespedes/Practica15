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
    public partial class wfrLibro : System.Web.UI.Page
    {
        LNAutor lNAutor = new LNAutor(Config.getCadConexion);
        LNCategoria lNCategoria = new LNCategoria(Config.getCadConexion);
        LNLibro lNLibro = new LNLibro(Config.getCadConexion);
        ELibro libro = new ELibro();

        protected void Page_Load(object sender, EventArgs e)
        {
            string condicion;
            if (!IsPostBack)
            {
                limpiar();
                if (Session["_claveLibro"] != null)
                {
                    condicion = $" claveLibro = '{Session["_claveLibro"].ToString()}'";
                    libro = lNLibro.buscarRegistro(condicion);
                    if (libro != null)
                    {
                        txtClaveLibro.Text = Session["_claveLibro"].ToString();
                        txtIdAutor.Text = libro.ClaveAutor;
                        txtTitulo.Text = libro.Titulo;
                        txtUdCategoria.Text = libro.Clavecategoria.ClaveCategoria;
                        recuperarAutor(libro.ClaveAutor);
                        recuperarCategoria(libro.Clavecategoria.ClaveCategoria);
                        HttpCookie cookie = new HttpCookie("SessionUser");
                        if (cookie != null)
                        {
                            cookie["_claveLibro"] = Session["_claveLibro"].ToString();
                            cookie["_idAutor"] = libro.ClaveAutor;
                            cookie["_idCategoria"] = libro.Clavecategoria.ClaveCategoria;
                            cookie["_titulo"] = libro.Titulo;
                            cookie.Expires = DateTime.Now.AddHours(1);
                            Response.Cookies.Add(cookie);
                        }
                    }
                }

            }

        }

        private void cargarGridCategorias(string condicion = "")
        {
            try
            {
                DataTable dataTable;

                dataTable = lNCategoria.ListarRegistros(condicion);
                if (dataTable != null)
                {
                    gvCategorias.DataSource = dataTable;
                    gvCategorias.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $"Error: {ex.Message}";
            }
        }

        private void cargarGridAutores(string condicion ="")
        {
            try
            {
                DataTable dataTable;

                dataTable = lNAutor.ListarRegistros(condicion);
                if (dataTable != null)
                {
                    gvAutores.DataSource = dataTable;
                    gvAutores.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session["_err"]= $"Error: {ex.Message}";
            }        
        }

        protected void bntBuscarAutor_Click(object sender, EventArgs e)
        {
            llamarJavaScriptAutores();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (Session["_claveLibro"] != null)
                {
                     bool bCl =false ;  bool bT = false; bool bAu = false; bool bCat = false;

                     
                    if (verificarAlgunCambio(ref bCl, ref bT, ref bAu, ref bCat) == true)
                    {
                        libro.ClaveLibro = txtClaveLibro.Text;
                        libro.Titulo = txtTitulo.Text;
                        libro.ClaveAutor = txtIdAutor.Text;
                        libro.Clavecategoria.ClaveCategoria = txtUdCategoria.Text;

                        if (libro.ClaveLibro != Session["_claveLibro"].ToString())
                        {
                            if (lNLibro.claveLibroRepetida(libro.ClaveLibro) == false)
                            {
                                cambiosTituloAutor(Session["_claveLibro"].ToString());
                            }
                            else
                            {
                                Session["_wrn"] = " Atencion: La clave del libro ya esta en uso";
                            }
                        }
                        else
                        {
                            cambiosTituloAutor("");
                        }
                    }
                }
                else
                {
                    if (lNLibro.claveLibroRepetida(txtClaveLibro.Text) == false)
                    {
                        ECategoria eCategoria = new ECategoria(txtUdCategoria.Text, txtCategoria.Text);
                        libro = new ELibro(txtClaveLibro.Text, txtTitulo.Text, txtIdAutor.Text, eCategoria, false);
                        if (lNLibro.libroRepetido(libro) == false)
                        {
                            if (lNLibro.insertar(libro) > 0)
                            {
                                Session["_exito"] = " Mensaje: Ha guardado el libro con exito ";
                                limpiar();
                            }
                        }
                        else
                        {
                            Session["_wrn"] = " Atencion: Ese titulo ya existe ";
                        }
                    }
                    else
                    {
                        Session["_wrn"] = " Atencion: La clave del libro ya esta en uso";
                    }
                }                    
            }
            catch (Exception ex)
            {

                Session["_err"] = $" Error : '{ex.Message}' ";
            }
        }

        private void cambiosTituloAutor(string clave)
        {
            if (Request.Cookies["SessionUser"]["_idAutor"] != txtIdAutor.Text || Request.Cookies["SessionUser"]["_titulo"] != txtTitulo.Text)
            {
                if (lNLibro.libroRepetido(libro) == false)
                {
                    hacerModificacion(clave);
                }
                else
                {
                    Session["_wrn"] = " Atencion: No se puede actualizar porque el título y autor ya existen";
                }
            }
            else
            {
                hacerModificacion(clave);
            }
        }

        private void hacerModificacion(string clave)
        {
            if (lNLibro.modificar(libro, clave) > 0)
                Session["_exito"] = " Mensaje: Ha actualizado el libro con exito ";
            else
                Session["_wrn"] = " Atencion:No se pudo modificar";

            limpiar();
        }


        private void limpiar()
        {
            txtAutor.Text = "";
            txtCategoria.Text = "";
            txtClaveLibro.Text = "";
            txtFiltroCategoria.Text = "";
            txtIdAutor.Text = "";
            txtNombreAutor.Text = "";
            txtTitulo.Text = "";
            txtUdCategoria.Text = "";
            cargarGridAutores();
            cargarGridCategorias();
        }

        protected void btnFiltroCategoria_Click(object sender, EventArgs e)
        {
            llamarJavaScriptCategorias();
        }

        protected void gvAutores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAutores.PageIndex = e.NewPageIndex;
            //cargarGridAutores();
            llamarJavaScriptAutores();
        }

        protected void gvCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCategorias.PageIndex = e.NewPageIndex;
            //cargarGridCategorias();
            llamarJavaScriptCategorias();
        }

        private void llamarJavaScriptCategorias()
        {
            cargarGridCategorias($" descripcion like '%{txtFiltroCategoria.Text}%'");
            string javaScript = "abrirModal2();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        private void llamarJavaScriptAutores()
        {
            cargarGridAutores($" nombre like '%{txtNombreAutor.Text}%'");
            string javaScript = "abrirModal();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }

        protected void lnkSeleccionarAutor_Command(object sender, CommandEventArgs e)
        {
            recuperarAutor(e.CommandArgument.ToString());
        }

        private void recuperarAutor(string v)
        {
            string condicion = $" claveAutor = '{v}'";

            EAutor eAutor;

            try
            {
                eAutor = lNAutor.BuscarRegistro(condicion);
                if (lNAutor != null)
                {
                    txtIdAutor.Text = eAutor.ClaveAutor;
                    txtAutor.Text = eAutor.ApPaterno + " " + eAutor.Nombre;
                }
            }
            catch (Exception ex)
            {

                Session["_err"] = $" Error:{ex.Message}";
            }
        }

        protected void lnkCategoria_Command(object sender, CommandEventArgs e)
        {
            recuperarCategoria(e.CommandArgument.ToString());
        }

        private void recuperarCategoria(string v)
        {
            string condicion = $" claveCategoria = '{v}'";
            ECategoria eCategoria;
            try
            {
                eCategoria = lNCategoria.BuscarRegistro(condicion);
                if (eCategoria != null)
                {
                    txtUdCategoria.Text = eCategoria.ClaveCategoria;
                    txtCategoria.Text =  eCategoria.Descripcion;
                }
            }
            catch (Exception ex)
            {
                Session["_err"] = $" Error:{ex.Message}";
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session.Remove("_error");
            Session.Remove("_wrn");
            Session.Remove("_exito");
            Response.Redirect("wfrmVistaLibros.aspx");
        }

        
        private bool verificarAlgunCambio(ref bool bCl, ref bool bT, ref bool bAu, ref bool bCat)
        {
            bool resul = false;
            
            if (Request.Cookies["SessionUser"] != null)
            {
                if (txtClaveLibro.Text != Request.Cookies["SessionUser"]["_claveLibro"])
                {
                    resul = true;
                }
            }
            if (Request.Cookies["SessionUser"] != null)
            {
                if (txtIdAutor.Text != Request.Cookies["SessionUser"]["_idAutor"])
                {
                    resul = true;
                }
            }
            if (Request.Cookies["SessionUser"] != null)
            {
                if (txtUdCategoria.Text != Request.Cookies["SessionUser"]["_idCategoria"])
                {
                    resul = true;
                }
            }
            if (Request.Cookies["SessionUser"] != null)
            {
                if (txtTitulo.Text != Request.Cookies["SessionUser"]["_titulo"])
                {
                    resul = true;
                }
            }

            return resul;
        }

    }
}