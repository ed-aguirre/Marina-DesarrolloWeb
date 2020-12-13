<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaBarcos.aspx.cs" Inherits="Frontera.Catalogo.Barcos.AltaBarcos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
			<h3>Alta barco</h3>
			<hr />
		</div>
		<div class="row form-group">
			<label for= '<%=txtMatricula.ClientID %>'>Matricula</label>
				<asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control" placeholder="XXX-0000"></asp:TextBox>
				<div style="position:absolute;top:0;left:0;">
				<asp:RequiredFieldValidator ID="rfvTxtMatricula" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtMatricula"
				ErrorMessage="Matricula del barco requerida"></asp:RequiredFieldValidator>
				</div>
				<div style="position:absolute;top:0;left:0;">
				<asp:RegularExpressionValidator ID="revTxtMatricula" runat="server" CssClass="text-danger" ControlToValidate="txtMatricula"
				ValidationExpression="^[A-Z]{3}-[0-9]{4}$"
				ErrorMessage="El formato de la matricula es XXX-0000(Mayusculas)"></asp:RegularExpressionValidator>
				</div>
		</div>
		<div class="row form-group">
			<label for="<%=txtNoAmarre.ClientID %>">Número de amarre</label>
			<asp:TextBox ID="txtNoAmarre" runat="server" CssClass="form-control" placeholder="000XX"></asp:TextBox>
			<div style="position:absolute;top:0;left:0;">
				<asp:RequiredFieldValidator ID="rfvTxtNoAmarre" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtNoAmarre"
				ErrorMessage="Matricula del barco requerida"></asp:RequiredFieldValidator>
				</div>
				<div style="position:absolute;top:0;left:0;">
				<asp:RegularExpressionValidator ID="revTxtNoAmarre" runat="server" CssClass="text-danger" ControlToValidate="txtNoAmarre"
				ValidationExpression="^[0-9]{3}[A-Z]{2}$"
				ErrorMessage='El formato del numero de amarre es 000XX"(Mayusculas)'></asp:RegularExpressionValidator>
				</div>
		</div>
		<div class="row form-group">
			<label for="<%=txtNombre.ClientID %>">Nombre:</label>
			<asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholader="Nombre"></asp:TextBox>
			<div style="position:absolute;top:0;left:0;">
				<asp:RequiredFieldValidator ID="rfvTxtNombre" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtNombre"
				ErrorMessage="Nombre del barco requerido"></asp:RequiredFieldValidator>
				</div>
		</div>
		<div class="row form-group">
			<label for="<%=txtCuota.ClientID %>">Cuota:</label>
			<asp:TextBox ID="txtCuota" runat="server" CssClass="form-control" placeholader="0.0"></asp:TextBox>
			<div style="position:absolute;top:0;left:0;">
				<asp:RequiredFieldValidator ID="rfvTxtCuota" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="txtCuota"
				ErrorMessage="Matricula del barco requerida"></asp:RequiredFieldValidator>
				</div>
				<div style="position:absolute;top:0;left:0;">
				<asp:RegularExpressionValidator ID="revTxtCuota" runat="server" CssClass="text-danger" ControlToValidate="txtCuota"
				ValidationExpression="^[0-9]+(\.[0-9][0-9]?)?$"
				ErrorMessage="La cuota es un valor decimal"></asp:RegularExpressionValidator>
				</div>
		</div>
		<div class="row form-group">
			<label for="<%=ddlOwner.ClientID %>">Dueño:</label>
			<asp:DropDownList ID="ddlOwner" runat="server" CssClass="form-control" style="width:25%">
				<asp:ListItem Value="0" Text="Selecciona Dueño"></asp:ListItem>
			</asp:DropDownList>
			<asp:RequiredFieldValidator ID="rfvDdlOwner" ValidationGroup="Guardar" runat="server" CssClass="text-danger" ControlToValidate="ddlOwner"
				InitialValue="0"
				ErrorMessage="Selecciona el dueño del barco"></asp:RequiredFieldValidator>
		</div>
		<div class="row form-inline">
            <div class="colo-md-12">
                <label>Selecciona Foto:</label>
                <input type="file" class="btn btn-default btn-file" runat="server" id="SubeImagen" style="display: inline-block;" />
                <asp:Button ID="btnSubeImagen" runat="server" Text="Subir Imagen" 
					CssClass="btn btn-primary btn-xs" OnClick="btnSubeImagen_Click" />
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-3" style="text-align: center;">
                <label for="<%=SubeImagen.ClientID %>">Foto:</label>
                <asp:Image ID="imgFotoBarco" Width="200" Height="200" runat="server" />
                <label id="lblUrlFoto" runat="server"></label>
            </div>
        </div>
        <div class="row form-group">
            <asp:Button ID="btnGuardar" ValidationGroup="Guardar" runat="server" 
				Text="Guardar" CssClass="btn btn-success" 
				Visible=True OnClick="btnGuardar_Click" />
        </div>
    </div>
</asp:Content>
