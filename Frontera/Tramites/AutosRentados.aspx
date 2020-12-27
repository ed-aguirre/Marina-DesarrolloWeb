<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AutosRentados.aspx.cs" Inherits="Frontera.Tramites.AutosRentados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>
				<asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
            </h3>
            <hr />
        </div>

        <div class="row col-md-10 col-md-offset-1">
            <asp:GridView ID="gvTramites"
                runat="server" AutoGenerateColumns="false"
                DataKeyNames="IdTramite"
                OnRowCommand="gvTramites_RowCommand">
                <Columns>
                    <asp:ImageField HeaderText="Foto Auto" ReadOnly="true" DataImageUrlField="UrlFotoAuto" ControlStyle-Width="110px" ControlStyle-CssClass="fotogv"></asp:ImageField>
                    <asp:ImageField HeaderText="Foto Cliente" ReadOnly="true" DataImageUrlField="UrlFotoPersona" ControlStyle-Width="110px" ControlStyle-CssClass="fotogv"></asp:ImageField>
                    <asp:BoundField HeaderText="Id" ItemStyle-Width="50px" DataField="IdTramite" ReadOnly="true" />
                    <asp:BoundField HeaderText="Fecha" ItemStyle-Width="150px" DataField="FechaHoraOperacion" />
                    <asp:BoundField HeaderText="Monto" ItemStyle-Width="200px" DataField="Monto" />
                    <asp:BoundField HeaderText="Cliente" ItemStyle-Width="200px" DataField="NombreCliente" />
                    <asp:BoundField HeaderText="Matricula" ItemStyle-Width="200px" DataField="Matricula" />
                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-danger btn-xs" Text="Realizar devolución" CommandName="Select" />
                    </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
