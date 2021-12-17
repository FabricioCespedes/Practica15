<%@ Page Title="" Language="C#" MasterPageFile="~/wfrPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmEjemplaresAsociados.aspx.cs" Inherits="PresentacionWeb.wfrmEjemplaresAsociados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
     <div class="container">
        <div class="card-header text-center">
            <h1>Ejemplares</h1>
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
         <asp:GridView runat="server" ID="gvEjemplares" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" OnPageIndexChanging="gvEjemplares_PageIndexChanging">
             <AlternatingRowStyle BackColor="White" />
             <Columns>
                 <asp:BoundField DataField="clave" HeaderText="Clave ejemplar" />
                 <asp:BoundField DataField="libro" HeaderText="Libro" />
                 <asp:BoundField DataField="condicion" HeaderText="Condicion" />
                 <asp:BoundField HeaderText="Estado" DataField="estado" />
                 <asp:BoundField DataField="edicion" HeaderText="Edicion" />
                 <asp:BoundField DataField="paginas" HeaderText="Numero de paginas" />
                 <asp:BoundField DataField="editorial" HeaderText="Editorial" />
             </Columns>
             <EditRowStyle BackColor="#2461BF" />
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
             <RowStyle BackColor="#EFF3FB" />
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#F5F7FB" />
             <SortedAscendingHeaderStyle BackColor="#6D95E1" />
             <SortedDescendingCellStyle BackColor="#E9EBEF" />
             <SortedDescendingHeaderStyle BackColor="#4870BE" />
         </asp:GridView>
         <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-primary" OnClick="btnRegresar_Click" />
    </div>
</asp:Content>
