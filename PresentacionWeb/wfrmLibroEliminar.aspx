<%@ Page Title="" Language="C#" MasterPageFile="~/wfrPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmLibroEliminar.aspx.cs" Inherits="PresentacionWeb.wfrmLibroEliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
    <div class="container">
        <div class="card-header">
           <h5 class="card-title">Eliminación de libro</h5>
        </div>
        <div class="card">
            <div class="card-body">
                <h6 class="card-subtitle">Titulo:</h6>
                <h6 class="card-subtitle">Clave:</h6>
                <h6 class="card-subtitle">Autor:</h6>
                <h6 class="card-subtitle">Categoria:</h6>
                <p class="card-text">El libro sera eliminado, favor confirmar la eliminacion</p>
            </div>
            <div class="card-footer">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" />
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-warning " />
            </div>
        </div>
    </div>


</asp:Content>
