<%@ Page Title="" Language="C#" MasterPageFile="~/wfrPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmEliminarEditorial.aspx.cs" Inherits="PresentacionWeb.wfrmEliminarEditorial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
        <div class="container">
        <div class="card-header">
           <h5 class="card-title">Eliminación de libro</h5>
        </div>
        <div class="card">
            <div class="card-body">
                <h6 class="card-subtitle">Clave editorial:</h6>
                <h6 class="card-subtitle">Nombre:</h6>
                <p class="card-text">Esta editorial sera eliminada, favor confirmar la eliminacion</p>
            </div>
            <div class="card-footer">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-primary" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-primary " OnClick="btnRegresar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
