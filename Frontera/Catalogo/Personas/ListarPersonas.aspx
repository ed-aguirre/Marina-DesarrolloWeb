﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarPersonas.aspx.cs" Inherits="Frontera.Catalogo.Personas.ListarPersonas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .fotogv {
            padding: 5px;
        }
    </style>
    <div class="container">
        <div class="row" style="margin-bottom: 18px">
            <h3>Lista Clientes</h3>
            <hr />
        </div>
        <div class="row col-md-10 col-md-offset-1">
            <asp:GridView ID="gvPersonas"
                runat="server" AutoGenerateColumns="false"
                DataKeyNames="IdPersona" 
                OnRowCommand="gvPersonas_RowCommand">
                <Columns>
                    <asp:ImageField HeaderText="Foto" ReadOnly="true" DataImageUrlField="UrlFoto" ControlStyle-Width="110px" ControlStyle-CssClass="fotogv"></asp:ImageField>
                    <asp:BoundField HeaderText="Id" ItemStyle-Width="50px" DataField="IdPersona" ReadOnly="true" />
                    <asp:BoundField HeaderText="Nombre" ItemStyle-Width="150px" DataField="Nombre" />
                    <asp:BoundField HeaderText="Dirección" ItemStyle-Width="200px" DataField="Direccion" />
                    <asp:BoundField HeaderText="Teléfono" ItemStyle-Width="100px" DataField="Telefono" />
                    <asp:BoundField HeaderText="Correo" ItemStyle-Width="120px" DataField="Correo" />
                    
                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-success btn-xs" Text="Seleccionar" CommandName="Select" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
