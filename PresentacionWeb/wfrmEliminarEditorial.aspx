<%@ Page Title="" Language="C#" MasterPageFile="~/wfrPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmEliminarEditorial.aspx.cs" Inherits="PresentacionWeb.wfrmEliminarEditorial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
                <%--Alert--%>
        <%if (Session["_err"]!=null)
            {%>
         <div class="alert alert-danger" role="alert" >
            <% = Session["_err"]%>  
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
         </div>

        <% }%>

        <%if (Session["_wrn"]!=null)
            {%>
            <div class="alert alert-warning" role="alert">
                     <% = Session["_wrn"]%>  
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
        <% }%>
        <%--AlertEND--%>
        <div class="container">
        <div class="card-header">
           <h5 class="card-title">Eliminación de libro</h5>
        </div>
        <div class="card">
            <div class="card-body">
                <h6 class="card-subtitle">Clave editorial:  <%= ViewState["_claveEditorial"] %> </h6>
                <h6 class="card-subtitle">Nombre:  <%= ViewState["_nombre"] %></h6>
                <p class="card-text">Esta editorial sera eliminada, favor confirmar la eliminacion</p>
            </div>
            <div class="card-footer">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-primary" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-primary " OnClick="btnRegresar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
