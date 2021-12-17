<%@ Page Title="" Language="C#" MasterPageFile="~/wfrPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmEditorial.aspx.cs" Inherits="PresentacionWeb.wfrmEditorial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
    <div class="container">
        <div class="card-header text-center">
            <h1>Mantenimiento de editoriales</h1>
        </div>
        <br />
        <%-- ALERTS--%>
        <%  if (Session["_exito"] != null)
            {%>
        <div class="alert alert-primary alert-dismissible fade show" role="alert">
            <strong><%= Session["_exito"].ToString()%> </strong>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>

        <% Session["_exito"] = null;
            } %>

        <%if (Session["_err"] != null)
            {%>
        <div class="alert alert-danger" role="alert">
            <% = Session["_err"]%>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>

        <% Session["_err"] = null;
            }%>

        <%if (Session["_wrn"] != null)
            {%>
        <div class="alert alert-warning" role="alert">
            <% = Session["_wrn"]%>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
        <%  Session["_wrn"] = null;
            }%>
        <%-- FIN ALERTS--%>
        <br />

        <div class="container">
            <div class="card-header">
                <h5 class="card-title">Ingrese los datos para crear un nuevo registro de editorial</h5>
            </div>
            <div class="card">
                <div class="card-body">
                    <asp:Label ID="Label1" runat="server" Text="Clave Editorial"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe de digitar una clave de editorial" ControlToValidate="txtClaveEditorial" ValidationGroup="1" Font-Italic="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtClaveEditorial" runat="server" CssClass="form-control" ValidationGroup="1"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                    <asp:RequiredFieldValidator ControlToValidate="txtNombre" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe de digitar un nombre de editorial" ValidationGroup="1" Font-Italic="True" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ValidationGroup="1"></asp:TextBox>
                    <br />
                    <div>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="1" Font-Italic="True" ForeColor="Red" />
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" ValidationGroup="1" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-primary" OnClick="btnRegresar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
