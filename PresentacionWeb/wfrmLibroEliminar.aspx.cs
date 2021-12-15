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
    public partial class wfrmLibroEliminar : System.Web.UI.Page
    {
        ELibro eLibro ;
        LNLibro lNLibro = new LNLibro(Config.getCadConexion);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["_claveLibro"] != null)
            {
                recuperarLibro(Session["_claveLibro"].ToString());
            }
        }

        private void recuperarLibro(string claveLibro)
        {
            string condicion = $" claveLibro = {claveLibro}";

         //   eLibro = lNLibro.listarTodos(condicion);
        }
    }
}