<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="CambioContrasena.aspx.cs" Inherits="Cobros30.CambioContrasena" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <!-- Content Header (Page header) -->
        <section class="content-header">
          
            <asp:Panel ID="pnlCambiodeClave" runat="server">
                <div class="well well-sm">
                <h4>Cambio contraseña</h4>
                </div>
            </asp:Panel>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#"><i class="fa fa-dashboard"></i> Administracion</a></li>
            <li class="active">Cambio Contraseña</li>
          </ol>
        </section>
        <!--  -->

     <section class="content">

        <!-- Alertas -->
        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>

        <div class="form-horizontal">
           <div class="form-group">
            <label class="col-sm-2 control-label">Nombre</label>
            <div class="col-sm-10">
              <asp:Label ID="lblNombre" runat="server" Text="Label" CssClass="btn btn-link btn-sm"></asp:Label>
            </div>
          </div>
          <div class="form-group">
            <label class="col-sm-2 control-label">Usuario</label>
            <div class="col-sm-10">
              <asp:Label ID="lblUsuario" runat="server" Text="Label" CssClass="btn btn-link btn-sm"></asp:Label>
            </div>
          </div>
          <div class="form-group">
            <label for="inputPassword" class="col-sm-2 control-label">Contraseña actual</label>
            <div class="col-sm-10">
              <asp:TextBox ID="txtContrasenaActual" Width="20%" runat="server" CssClass="form-control input-sm" TextMode="Password"></asp:TextBox>
            </div>
          </div>
          <div class="form-group">
            <label for="inputPassword" class="col-sm-2 control-label">Contraseña</label>
            <div class="col-sm-10">
              <asp:TextBox ID="txtContrasenaNueva" Width="20%" runat="server" CssClass="form-control input-sm" TextMode="Password"></asp:TextBox>
            </div>
          </div>
          <div class="form-group">
            <label for="inputPassword" class="col-sm-2 control-label">Confirmar Contraseña</label>
            <div class="col-sm-10">
              <asp:TextBox ID="txtContrasena" Width="20%" runat="server" CssClass="form-control input-sm" TextMode="Password"></asp:TextBox>
            </div>
          </div>
        </div>
         
        <asp:LinkButton ID="lbtnGrabar" CssClass="btn btn-danger" runat="server" 
            onclick="lbtnGrabar_Click"><i aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></i> Grabar</asp:LinkButton>

     </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
