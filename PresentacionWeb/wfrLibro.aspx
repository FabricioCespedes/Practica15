<%@ Page Title="" Language="C#" MasterPageFile="~/wfrPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrLibro.aspx.cs" Inherits="PresentacionWeb.wfrLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="frmHead" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
    <div class="container">
        <div class="card-header text-center">
            <h1>Mantenimiento de Libros</h1>
        </div>
        <br />
        <div class="row mt-3">
            <div class="col-2">
                <asp:Label ID="Label1" runat="server" Text="Clave Libro"></asp:Label>
                <asp:TextBox ID="txtClaveLibro" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-4">
                <asp:Label ID="Label2" runat="server" Text="Titulo"></asp:Label>
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="txtIdAutor" runat="server" Text="Autor" Visible="false"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="Autor"></asp:Label>
                <div class="input-group mb-3">
                    <asp:TextBox ID="txtAutor" runat="server" CssClass="form-control" ReadOnly="true"
                        aria-describedby="btnModalAutor"
                        ></asp:TextBox>
                    <button class="btn btn-outline-primary" type="button" id="btnModalAutor"
                        data-bs-toggle="modal"  data-bs-target="#autorModal"  
                        >Buscar</button>
                </div>
            </div>
            <div class="col-3">
                <asp:Label ID="txtUdCategoria" runat="server" Text="Autor" Visible="false"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Categoria"></asp:Label>
                <div class="input-group mb-3">
                    <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" ReadOnly="true" aria-describedby="btnModalCaterogia"></asp:TextBox>
                    <button class="btn btn-outline-primary" type="button" id="btnModalCaterogia">Buscar</button>
                </div>
            </div>
            <div class="col-3">
                 <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" />
            </div>
            <div class="col-3">
                  <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-warning" />
            </div>
    </div>
        </div>

     <%--MODALES--%>
    <div class="modal" tabindex="-1" id="autorModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Buscar autor</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                   <div class="row mt-3">
                       <div class="col-auto">
                           <asp:Label ID="Label5" runat="server" Text="Autor"></asp:Label  >
                       </div>
                       <div class="col-auto">
                           <asp:TextBox ID="txtNombreAutor" runat="server" CssClass="form-control" ValidationGroup="2" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe escribir parte del nombre del autor" ControlToValidate="txtNombreAutor" Font-Italic="True" ForeColor="Red" ValidationGroup="2"></asp:RequiredFieldValidator>
                       </div>
                       <div class="col-auto">
                           <asp:Button ID="btnFiltar" runat="server" Text="Filtar" CssClass=" btn btn-primary" OnClick="bntBuscarAutor_Click"  ValidationGroup="2"                         
                               />
                       </div>
                       <asp:GridView ID="gvAutores" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                           <AlternatingRowStyle BackColor="White" />
                           <Columns>
                               <asp:TemplateField>
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkSeleccionarAutor" runat="server" CommandArgument='<%# Eval("claveAutor").ToString() %>'>Seleccionar</asp:LinkButton>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:BoundField DataField="claveAutor" HeaderText="Clave Autor" Visible="False" />
                               <asp:BoundField DataField="apPaterno" HeaderText="Apellido" />
                               <asp:BoundField DataField="nombre" HeaderText="Nombre" />
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
                   </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" tabindex="-1" id="modalCategoria">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Seleccionar categoria</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p>Modal body text goes here.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
