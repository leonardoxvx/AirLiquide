<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="InDeuda.aspx.cs" Inherits="Cobros30.InDeuda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<section class="content-header">
          <h3>
            Editar Deuda
          </h3>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#"><i class="fa fa-dashboard"></i> Administracion</a></li>
            <li class="active">Editar Deuda</li>
          </ol>
        </section>

    <section class="content">

        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>

        <div class="panel-primary">
            <div class="panel-heading">
                <strong>Editar Deuda</strong>
            </div>

            <table class="table small">
                <tr>
                    <td>
                        <strong>Nº Documento</strong>
                        <asp:HiddenField ID="hfIdDeuda" runat="server" />
                        <asp:TextBox ID="txtNroDocumento" runat="server" Enabled="false" Width="100px" CssClass="form-control input-sm"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <strong>Estado</strong>
                        <asp:DropDownList ID="ddlEstadoDeuda" runat="server" Width="200px" CssClass="form-control input-sm" OnDataBound="ddlEstadoDeuda_DataBound"></asp:DropDownList>
                    </td>
                    <td>
                        <strong>Observacion</strong>
                        <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                    </td>
                    
                </tr>
            </table>
            <div class="panel-footer">
                <asp:LinkButton ID="lbtnNuevaDeuda" OnClick="lbtnNuevaDeuda_Click" runat="server" Visible="true" CssClass="btn btn-sm btn-google" ToolTip="Guardar deuda">Guardar <span class="glyphicon glyphicon-floppy-disk" ></span></asp:LinkButton>
            </div>
        </div>

    </section>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
