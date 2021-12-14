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
            cargarDataGrid();
        }

        private void cargarDataGrid(string condicion ="")
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
            cargarDataGrid($" nombre like '%{txtNombreAutor.Text}%'");
            string javaScript = "abrirModal();";
            ScriptManager.RegisterStartupScript(this,this.GetType(),"script",javaScript,true);
        }
    }
}