<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RentarAuto.aspx.cs" Inherits="Frontera.Tramites.RentarAuto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Rentar Auto</h3>
            <hr />
        </div>

        <div class="row form-group">
            <label for="<%=FechaSalida.ClientID %>">Fecha y Hora de Renta:</label>
            <input id="FechaSalida" runat="server" type="text" class="form-control" /><div style="position: absolute; top: 0; left: 0">
                <asp:RequiredFieldValidator ID="rfvtxtMatricula" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="FechaSalida" 
                    ErrorMessage="Fecha de salida requerida"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row form-group">
            <label for="<%=txtMonto.ClientID %>">Enganche:</label>
            <asp:TextBox ID="txtMonto" runat="server" CssClass="form-control" placeholder="$0.00"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvtxtMonto" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtMonto" 
                ErrorMessage="Monto inicial de la renta"></asp:RequiredFieldValidator>
        </div>
        
        <div class="row form-group">
            <label for="<%=ddlPersona.ClientID %>">Cliente:</label>
            <asp:DropDownList ID="ddlPersona" runat="server" CssClass="form-control" style="width:25%">
                <asp:ListItem Value="0" Text="Selecciona Cliente"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvddlPersona" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="ddlPersona" InitialValue="0" 
                ErrorMessage="Selecciona el cliente"></asp:RequiredFieldValidator>
        </div>

        <%--<div class="row form-group">
            <label for="<%=ddlAuto.ClientID %>">Auto:</label>
            <asp:DropDownList ID="ddlAuto" runat="server" CssClass="form-control" style="width:25%">
                <asp:ListItem Value="0" Text="Selecciona Auto"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvddlAuto" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="ddlAuto" InitialValue="0" 
                ErrorMessage="Selecciona el Auto"></asp:RequiredFieldValidator>
        </div>--%>

       
        <div class="row form-group">
            <label for="<%=ddlAuto.ClientID %>">Autos:</label>
            <asp:DropDownList ID="ddlAuto" runat="server" CssClass="form-control" style="width:25%">
                <asp:ListItem Value="0" Text="Selecciona un auto disponible"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvddlAuto" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="ddlAuto" InitialValue="0" 
                ErrorMessage="Selecciona el auto"></asp:RequiredFieldValidator>
        </div>
        
        <div class="row form-group">
            <asp:Button ID="btnGuardar" ValidationGroup="Guardar" runat="server" 
                Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click"/>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $.datetimepicker.setLocale('es');
            $("#<%=FechaSalida.ClientID%>").datetimepicker({
                format: 'Y/m/d H:i:s',
                minDate: '0'
            });
        });
    </script>
</asp:Content>
