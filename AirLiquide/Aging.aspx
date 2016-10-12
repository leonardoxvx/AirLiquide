<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Aging.aspx.cs" Inherits="Cobros30.Aging" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- Content Header (Page header) -->
        <section class="content-header">
          <h3>
            Reporte AGING
          </h3>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <%--<li><a href="#"><i class="fa fa-dashboard"></i> Cartera</a></li>--%>
            <li class="active">AGING</li>
          </ol>
        </section>
        <!--  -->
    <section class="content">

         <!-- Alertas -->
        <div id="divAlerta" runat="server" visible="false" class="alert alert-danger alerta">
            <strong>Atención!: </strong>
            <asp:Label Text="" ID="lblInfo" runat="server" />
            <asp:HyperLink ID="hlDescargar" runat="server"></asp:HyperLink>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <asp:Panel ID="pnlCarteraAsignada" runat="server" DefaultButton="lbtnBuscar">
                    <div class="panel panel-primary">
                        <div class="panel-heading"><strong>AGING</strong></div>

                        <table class="table">
                            <tr>
                                <td>
                                    <strong>Cod.Cliente</strong>
                                    <asp:TextBox ID="txtCodCliente" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </td>
                                <td>
                                    <strong>Usuario Asignado</strong>
                                    <asp:DropDownList ID="ddlUsuarioAsignado" runat="server" CssClass="form-control input-sm" OnDataBound="ddlUsuarioAsignado_DataBound">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <strong>Sucursal</strong>
                                    <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="form-control input-sm" OnDataBound="ddlSucursal_DataBound">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <strong>Sector</strong>
                                    <asp:DropDownList ID="ddlSector" runat="server" CssClass="form-control input-sm" OnDataBound="ddlSector_DataBound">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <br />
                                    <asp:LinkButton ID="lbtnBuscar" CssClass="btn btn-primary btn-sm" Visible="false" runat="server" OnClick="lbtnBuscar_Click"><i aria-hidden="true" class="glyphicon glyphicon-search"></i> Buscar</asp:LinkButton>
                                    <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-sm"  Text="Buscar" OnClick="lbtnBuscar_Click" />
                                </td>
                                <td><br />
                                    <asp:LinkButton ID="btnExcel" Text="text" OnClick="btnExcel_Click" CssClass="btn btn-success btn-sm btn-block" runat="server"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                                </td>
                            </tr>
                        </table>

                        
                        <asp:GridView ID="grvResultado" runat="server" CssClass="table table-bordered table-hover table-condensed small" 
                            HeaderStyle-CssClass="info" AutoGenerateColumns="false" OnRowDataBound="grvResultado_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Cliente">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRutDeudor" runat="server" Text='<%# Bind("CLIENTE") %>' Visible="true"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Cod.Cliente">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCodigo" runat="server" Visible="false" Text='<%# Bind("CODIGO") %>' ></asp:Label>
                                        <asp:LinkButton ID="lbtnCodigo" Text='<%# Bind("CODIGO") %>' runat="server" OnClick="lbtnCodigo_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="No Exigible">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNoExigible" runat="server" Text='<%# Bind("NO_EXIGIBLE","{0:n0}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="1-30 Dias">
                                    <ItemTemplate>
                                        <asp:Label ID="lblT130" runat="server" Text='<%# Bind("T_1_30","{0:n0}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="31-60 Dias">
                                    <ItemTemplate>
                                        <asp:Label ID="T_31_60" runat="server" Text='<%# Bind("T_31_60","{0:n0}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="61-90 Dias">
                                    <ItemTemplate>
                                        <asp:Label ID="T_61_90" runat="server" Text='<%# Bind("T_61_90","{0:n0}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="91-120 Dias">
                                    <ItemTemplate>
                                        <asp:Label ID="T_91_120" runat="server" Text='<%# Bind("T_91_120","{0:n0}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="121-180 Dias">
                                    <ItemTemplate>
                                        <asp:Label ID="T_121_180" runat="server" Text='<%# Bind("T_121_180","{0:n0}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mas 180 Dias">
                                    <ItemTemplate>
                                        <asp:Label ID="T_180" runat="server" Text='<%# Bind("T_180","{0:n0}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("TOTAL","{0:n0}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>

                            </Columns>

                        </asp:GridView>


                    </div>
                </asp:Panel>

            </ContentTemplate>
        </asp:UpdatePanel>

    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
