<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="ModEmailRead.aspx.cs" Inherits="Cobros30.ModEmailRead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        De:
                        <asp:Label ID="lblDe" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        Asunto: 
                        <asp:Label ID="lblAsunto" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        Mensaje
                        <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" ClientIDMode="Static" CssClass="form-control" ReadOnly="true" Height="200px"></asp:TextBox>
                    </div>

                </div>
                <!-- /.box-body -->

                <!-- /.box-footer -->
            </div>
            <!-- /. box -->
        </div>
        <!-- /.col -->


    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
