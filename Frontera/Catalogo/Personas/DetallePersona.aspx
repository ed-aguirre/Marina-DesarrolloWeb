<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePersona.aspx.cs" Inherits="Frontera.Catalogo.Personas.DetallePersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
        <div class="row">
            <h3>Detalle Cliente</h3>
            <h4>ID:
                <asp:Label ID="lblIdPersona" runat="server" Text=""></asp:Label></h4>
            <hr />
        </div>
        <div class="col-md-10 col-md-offset-1">
            <dl class="dl-horizontal">
                <dt>
                    <label for="<%=lblNombre.ClientID %>">Nombre:</label></dt>
                <dd>
                    <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label></dd>
                <dt>
                    <label for="<%=lblDireccion.ClientID %>">Dirección:</label></dt>
                <dd>
                    <asp:Label ID="lblDireccion" runat="server" Text=""></asp:Label></dd>
                <dt>
                    <label for="<%=lblTelefono.ClientID %>">Teléfono:</label></dt>
                <dd>
                    <asp:Label ID="lblTelefono" runat="server" Text=""></asp:Label></dd>
                <dt>
                    <label for="<%=lblCorreo.ClientID %>">Correo:</label></dt>
                <dd>
                    <asp:Label ID="lblCorreo" runat="server" Text=""></asp:Label></dd>
                <dt>
                    <label for="<%=imgFotoPersona %>">Foto:</label></dt>
                <dd>
                    <asp:Image ID="imgFotoPersona" Width="200" Height="200" runat="server" /></dd>
            </dl>
            <div class="row" style="margin-bottom: 18px">
                <h3>Lista Automóviles(?</h3>
                <hr />
            </div>
            <div class="row col-md-10 col-md-offset-2">
                <asp:GridView ID="gvBarcos"
                    runat="server" AutoGenerateColumns="false"
                    DataKeyNames="IdBarco">
                    <Columns>
                        <asp:ImageField HeaderText="Foto" ReadOnly="true" DataImageUrlField="UrlFoto" ControlStyle-Width="110px" ControlStyle-CssClass="fotogv"></asp:ImageField>
                        <asp:BoundField HeaderText="Id" ItemStyle-Width="50px" DataField="IdBarco" ReadOnly="true" />
                        <asp:BoundField HeaderText="Nombre" ItemStyle-Width="150px" DataField="Nombre" />
                        <asp:BoundField HeaderText="Matrícula" ItemStyle-Width="80px" DataField="Matricula" />
                        <asp:BoundField HeaderText="No Amarre" ItemStyle-Width="80px" DataField="NoAmarre" />
                        <asp:TemplateField HeaderText="Disponible" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <div style="width: 100%">
                                    <div style="width: 25%; margin: 0 auto">
                                        <asp:CheckBox ID="chkDisponible" runat="server" Enabled="false" Checked='<%#Eval("Disponibilidad") %>' />
                                    </div>
                                </div>
                            </ItemTemplate>

                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row form-group col-md-10 col-md-offset-4" style="padding-top:20px">
            <div class="col-md-4">
                <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-success" OnClick="btnEditar_Click" />
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
