<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Frontera._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>MiLLanta</h1>
        <p class="lead">
            Bienvenido al Cotizador de MiLlanta.<br />
            ¡Selecciona una opción en el apartado de Catálogos para comenzar!

        </p>
        
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Dar de alta clientes</h2>
            <p>
                Registra clientes en el sistema para despues mostrarlos en una lista, actualizarlos o eliminarlos. 
                Es necesario registrar un cliente para realizar una renta de automóvil.
            </p>
            <p>
                <a class="btn btn-default" href="/Catalogo/Personas/AltaPersona.aspx">Registrar Cliente &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Dar de alta un automóvil</h2>
            <p>
                Ingresa los datos de un automóvil en el sistema, es necesario contar con una foto del vehiculo para completar el registro.
            </p>
            <p>
                <a class="btn btn-default" href="/Catalogo/Autos/AltaAuto.aspx">Registrar Automóvil &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Rentar automóvil</h2>
            <p>
                Realiza la renta de un automóvil. Es necesario haber registrado en el sistema al menos a un cliente y 
                un automóvil para realizar una renta, asi como de tener automóviles disponibles.
            </p>
            <p>
                <a class="btn btn-default" href="/Tramites/RentarAuto.aspx">Rentar Automóvil &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
