<%@ Page Title="" Language="C#" MasterPageFile="~/wfrPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmVistaEditoriales.aspx.cs" Inherits="PresentacionWeb.wfrmVistaEditoriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">

    <div class="container">
        <div class="card-header text-center">
            <h1>Gestionar Editoriales</h1>
        </div>
        <br />
        <%--Alert--%>        <%if (Session["_err"]!=null)
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
        <% }%>        <%--AlertEND--%>
        <div class="row mt-3">
            <div class="col-auto">
                <asp:Label ID="Label1" runat="server" Text="Titulo del editorial"></asp:Label> 
                <asp:RequiredFieldValidator ID="rfvTxttitulo" runat="server" ErrorMessage="Por favor digite algun texto para buscar" ControlToValidate="txtTitulo" Font-Italic="True" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            </div>
            <div class="col-auto form-control">
                <asp:TextBox ID="txtTitulo" runat="server" ToolTip="Escriba aqui el texto que desea buscar" ValidationGroup="1"></asp:TextBox>
                <asp:Button ID="btnBuscar" CssClass="btn btn-outline-primary" runat="server" Text="Buscar" ValidationGroup="1" OnClick="btnBuscar_Click" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Cssclass="btn btn-outline-primary" OnClick="btnLimpiar_Click"  /> 
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-outline-primary" OnClick="btnNuevo_Click"  />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="1" Font-Italic="True" ForeColor="Red" />
            </div>
        </div>
        <br />
        <asp:GridView ID="gvEditorial" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="gvEditorial_PageIndexChanging" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("claveEditorial").ToString() %>'>Modificar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("claveEditorial").ToString() %>' OnCommand="LinkButton2_Command">Eliminar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("claveEditorial").ToString() %>' OnCommand="LinkButton3_Command">Ejemplares</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="claveEditorial" HeaderText="Clave Editorial" ReadOnly="True" />
                <asp:BoundField DataField="nombre" HeaderText="Editorial" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

        </asp:GridView>
    </div>

</asp:Content>
