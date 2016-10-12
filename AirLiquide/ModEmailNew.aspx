<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="ModEmailNew.aspx.cs" Inherits="Cobros30.ModEmailNew" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/template/AdminLTE-2.3.0/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h4>
            Nuevo Mensaje
          </h4>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#"><i class="fa fa-dashboard"></i> Administracion</a></li>
            <li class="active">Nuevo Mensaje</li>
          </ol>
        </section>
        <!--  -->

    

    <section class="content">
        
    <!-- Alertas -->
        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <asp:LinkButton ID="lbtnVolver" OnClick="lbtnVolver_Click" runat="server" CssClass="btn btn-default"><span class="glyphicon glyphicon-arrow-left"></span> Ver Mensajes</asp:LinkButton>
                    <h3 class="box-title">Nuevo Mensaje</h3>
                    
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="form-group">
                        <%--<input runat="server" id="txtPara" style="width:30%" class="form-control" placeholder="Para:">--%>
                        
                        
                        <table class="table">
                            <tr>
                                <td width="30%">
                                    Para
                                    <asp:DropDownList ID="ddlEjecutivo" Width="100%" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlEjecutivo_SelectedIndexChanged" AutoPostBack="true" OnDataBound="ddlEjecutivo_DataBound">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Email
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Width="250px"></asp:TextBox>
                                    
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="form-group">
                        Asunto
                        <input runat="server" id="txtAsunto" class="form-control" placeholder="Asunto:">
                    </div>
                    <div class="form-group">
                        Mensaje
                        <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" ClientIDMode="Static" CssClass="form-control" Height="200px"></asp:TextBox>
                    </div>

                </div>
                <!-- /.box-body -->
                <div class="box-footer">
                    <div class="pull-right">
                        <asp:LinkButton ID="lbtnEnviar" OnClick="lbtnEnviar_Click" runat="server" CssClass="btn btn-primary"><span class="fa fa-envelope-o"></span> Enviar</asp:LinkButton>
                    </div>
                </div>
                <!-- /.box-footer -->
            </div>
            <!-- /. box -->
        </div>
        <!-- /.col -->


    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">

    <!-- Bootstrap WYSIHTML5 -->
    <script src="assets/template/AdminLTE-2.3.0/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>

    <!-- Page Script -->
<%--    <script>
      $(function () {
        //Add text editor
          $("#txtMensaje").wysihtml5(
              {
                  toolbar: {
                      "font-styles": true, // Font styling, e.g. h1, h2, etc.
                      "emphasis": true, // Italics, bold, etc.
                      "lists": true, // (Un)ordered lists, e.g. Bullets, Numbers.
                      "html": true, // Button which allows you to edit the generated HTML.
                      "link": false, // Button to insert a link.
                      "image": false, // Button to insert an image.
                      "color": false, // Button to change color of font
                      "blockquote": true // Blockquote
                      //"size": <buttonsize>  options are xs, sm, lg
                      },
              }
              );
      });
    </script>--%>

</asp:Content>
