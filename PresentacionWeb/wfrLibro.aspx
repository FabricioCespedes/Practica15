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

        <% Session["_err"] = null; }%>

        <%if (Session["_wrn"] != null)
            {%>
        <div class="alert alert-warning" role="alert">
            <% = Session["_wrn"]%>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
        <%  Session["_wrn"] = null; }%>
        <%-- FIN ALERTS--%>


        <br />
        <div class="row mt-3">
            <div class="col-2">
                <asp:Label ID="Label1" runat="server" Text="Clave Libro"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe de digitar una clave de libro" ControlToValidate="txtClaveLibro" ValidationGroup="3" Font-Italic="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:TextBox ID="txtClaveLibro" runat="server" CssClass="form-control" ValidationGroup="3"></asp:TextBox>

            </div>
            <div class="col-4">
                <asp:Label ID="Label2" runat="server" Text="Titulo"></asp:Label>
                <asp:RequiredFieldValidator ControlToValidate="txtTitulo" ID="RequiredFieldValidator5" runat="server" ErrorMessage="* Debe de digitar un titulo" ValidationGroup="3" Font-Italic="True" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" ValidationGroup="3"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="txtIdAutor" runat="server" Text="Autor" Visible="false"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="Autor"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Porfavor, seleccione un autor." ValidationGroup="3" Font-Italic="True" ControlToValidate="txtAutor" ForeColor="Red">*</asp:RequiredFieldValidator>
                <div class="input-group mb-3">
                    <asp:TextBox ID="txtAutor" runat="server" CssClass="form-control" ReadOnly="true"
                        aria-describedby="btnModalAutor" ValidationGroup="3"></asp:TextBox>
                    <button class="btn btn-outline-primary" type="button" id="btnModalAutor"
                        data-bs-toggle="modal" data-bs-target="#autorModal">
                        Buscar</button>
                </div>

            </div>
            <div class="col-3">
                <asp:Label ID="txtUdCategoria" runat="server" Text="Autor" Visible="false"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Categoria"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="* Seleccione una categoria" ValidationGroup="3" ControlToValidate="txtCategoria" Font-Italic="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                <div class="input-group mb-3">
                    <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" ReadOnly="true" aria-describedby="btnModalCaterogia" ValidationGroup="3"></asp:TextBox>
                    <button class="btn btn-outline-primary" type="button" data-bs-toggle="modal" data-bs-target="#modalCategoria" id="btnModalCaterogia">Buscar</button>
                </div>
            </div>
            <div class="col-3">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" ValidationGroup="3"/>
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-warning" OnClick="btnRegresar_Click" />
            </div>
            <div>   
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"  ValidationGroup="3" Font-Italic="True" ForeColor="Red" />
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
                            <asp:Label ID="Label5" runat="server" Text="Autor"></asp:Label>
                        </div>
                        <div class="col-auto">
                            <asp:TextBox ID="txtNombreAutor" runat="server" CssClass="form-control" ValidationGroup="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe escribir parte del nombre del autor" ControlToValidate="txtNombreAutor" Font-Italic="True" ForeColor="Red" ValidationGroup="2"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-auto">
                            <asp:Button ID="btnFiltar" runat="server" Text="Filtar" CssClass=" btn btn-primary" OnClick="bntBuscarAutor_Click" ValidationGroup="2" />
                        </div>
                        <asp:GridView ID="gvAutores" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" OnPageIndexChanging="gvAutores_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkSeleccionarAutor" runat="server" CommandArgument='<%# Eval("claveAutor").ToString() %>' OnCommand="lnkSeleccionarAutor_Command">Seleccionar</asp:LinkButton>
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
                    <div class="row mt-3">
                        <div class="col-auto">
                            <asp:Label ID="Label6" runat="server" Text="Categoria"></asp:Label>
                        </div>
                        <div class="col-auto">
                            <asp:TextBox ID="txtFiltroCategoria" runat="server" CssClass="form-control" ValidationGroup="1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe escribir algo" ControlToValidate="txtFiltroCategoria" Font-Italic="True" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-auto">
                            <asp:Button ID="btnFiltroCategoria" runat="server" Text="Filtar" CssClass=" btn btn-primary" OnClick="btnFiltroCategoria_Click" ValidationGroup="1" />
                        </div>
                        <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" OnPageIndexChanging="gvCategorias_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkCategoria" runat="server" CommandArgument='<%# Eval("claveCategoria").ToString() %>' OnCommand="lnkCategoria_Command">Seleccionar</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="claveCategoria" HeaderText="Clave Categoria" />
                                <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
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
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
