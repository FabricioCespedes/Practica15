<%@ Page Title="" Language="C#" MasterPageFile="~/wfrPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmVistaLibros.aspx.cs" Inherits="PresentacionWeb.wfrmVistaLibros"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
    <div class="container">
        <div class="card-header text-center">
            <h1>Gestionar Libros</h1>
        </div>
        <br />

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
        <div class="row mt-3">
            <div class="col-auto">
                <asp:Label ID="Label1" runat="server" Text="Titulo del libro"></asp:Label> 

            </div>
            <div class="col-auto form-control">
                <asp:TextBox ID="txtTitulo" runat="server" ToolTip="Escriba aqui el texto que desea buscar" ValidationGroup="1"></asp:TextBox>  
                <asp:Button ID="btnBuscar" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-outline-secondary" OnClick="btnLimpiar_Click" /> 

                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-outline-info" OnClick="btnNuevo_Click" />
            </div>
        </div>

           <asp:RequiredFieldValidator ID="rfvTxttitulo" runat="server" ErrorMessage="Por favor digite algun texto para buscar" ControlToValidate="txtTitulo" Font-Italic="True" ForeColor="#FF5050" ValidationGroup="1"></asp:RequiredFieldValidator>

        <br />
        <asp:GridView ID="gvLibros" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="2px" CellPadding="10" ForeColor="#3333FF" GridLines="Vertical" Width="100%" AllowPaging="True" EmptyDataText="No ahí datos que mostrar, inserte uno nuevo." OnPageIndexChanging="gvLibros_PageIndexChanging" PageSize="15">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("Clave").ToString() %>' OnCommand="lnkModificar_Command">Modificar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("Clave").ToString() %>'>Eliminar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Clave" HeaderText="Clave" />
                <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                <asp:BoundField DataField="Nombre" HeaderText="Autor" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" BorderStyle="Solid" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </div>
</asp:Content>
