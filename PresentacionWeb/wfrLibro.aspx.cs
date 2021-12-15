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
        ELibro eLibro = new ELibro();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGridAutores();
            cargarGridCategorias();
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
                if (lNLibro.claveLibroRepetida(txtClaveLibro.Text) == false)
                {
                    ECategoria eCategoria = new ECategoria(txtUdCategoria.Text, txtCategoria.Text);
                    eLibro = new ELibro(txtClaveLibro.Text, txtTitulo.Text, txtIdAutor.Text, eCategoria, false);
                    if (lNLibro.libroRepetido(eLibro) ==  false)
                    {
                        if (lNLibro.insertar(eLibro) > 0)
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
            catch (Exception ex)
            {

                Session["_err"] = $" Error : '{ex.Message}' ";
            }
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
    }
}