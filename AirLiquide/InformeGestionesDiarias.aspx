<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="InformeGestionesDiarias.aspx.cs" Inherits="Cobros30.InformeGestionesDiarias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        
     <!-- Content Header (Page header) -->
        <section class="content-header">
          <h3>
            Informe Gestiones Diarias
          </h3>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <%--<li><a href="#"><i class="fa fa-dashboard"></i> Cartera</a></li>--%>
            <li class="active">Informe Gestiones Diarias</li>
          </ol>

        </section>
        <!--  -->

        <section class="content">

            <div id="divAlerta" runat="server" visible="false" class="alert alert-danger">
                <strong>Atención!: </strong>
                <asp:Label Text="" ID="lblInfo" runat="server" />
            </div>

            
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <strong>
                        <asp:Label ID="lblCantidadOSuma1" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblMes1" runat="server" Text=""></asp:Label>
                    </strong>
                </div>
                <div class="table-responsive">
                    <asp:GridView ID="grvInformeRecupero1" EmptyDataText="Selección realizada no obtuvo registros" AutoGenerateColumns="true" runat="server" HeaderStyle-CssClass="info" OnRowDataBound="paginacion1_RowDataBound" PagerStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed table small">
                        <Columns>
                            <%--<asp:TemplateField HeaderText="Ejecutivo">
                        <ItemTemplate>
                            <asp:Label ID="lblEjecutivo" runat="server" Text='<%# Bind("LOGIN") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="RSA">
                        <ItemTemplate>
                            <asp:Label ID="lblRsa" runat="server" Text='<%# Bind("RSA", "{0:n0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Chilena">
                        <ItemTemplate>
                            <asp:Label ID="lblChilena" runat="server" Text='<%# Bind("CHILENA", "{0:n0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Liberty">
                        <ItemTemplate>
                            <asp:Label ID="lblLiberty" runat="server" Text='<%# Bind("LIBERTY", "{0:n0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Hertz">
                        <ItemTemplate>
                            <asp:Label ID="lblHertz" runat="server" Text='<%# Bind("HERTZ", "{0:n0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Consorcio">
                        <ItemTemplate>
                            <asp:Label ID="lblConsorcio" runat="server" Text='<%# Bind("CONSORCIO", "{0:n0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Bci">
                        <ItemTemplate>
                            <asp:Label ID="lblBci" runat="server" Text='<%# Bind("BCI", "{0:n0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                            --%>

                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotal" runat="server" Text=''></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Promedio">
                                <ItemTemplate>
                                    <asp:Label ID="lblPromedio" runat="server" Text=''></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            
            
            
    <div class="panel panel-primary">
    <div class="panel-heading">
        <strong>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblMes2" runat="server" Text=""></asp:Label>
        </strong>
    </div>
        <div class="table-responsive">
            <asp:GridView ID="grvInformeRecupero2" EmptyDataText="Selección realizada no obtuvo registros" AutoGenerateColumns="true" runat="server" OnRowDataBound="paginacion2_RowDataBound" HeaderStyle-CssClass="info" PagerStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed table small">
                <Columns>
                    <%--<asp:TemplateField HeaderText="Ejecutivo">
                        <ItemTemplate>
                            <asp:Label ID="lblEjecutivo" runat="server" Text='<%# Bind("LOGIN") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="RSA">
                        <ItemTemplate>
                            <asp:Label ID="lblRsa" runat="server" Text='<%# Bind("RSA", "{0:n0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Chilena">
                        <ItemTemplate>
                            <asp:Label ID="lblChilena" runat="server" Text='<%# Bind("CHILENA", "{0:n0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Liberty">
                        <ItemTemplate>
                            <asp:Label ID="lblLiberty" runat="server" Text='<%# Bind("LIBERTY", "{0:n0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Hertz">
                        <ItemTemplate>
                            <asp:Label ID="lblHertz" runat="server" Text='<%# Bind("HERTZ", "{0:n0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Consorcio">
                        <ItemTemplate>
                            <asp:Label ID="lblConsorcio" runat="server" Text='<%# Bind("CONSORCIO", "{0:n0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Bci">
                        <ItemTemplate>
                            <asp:Label ID="lblBci" runat="server" Text='<%# Bind("BCI", "{0:n0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" runat="server" Text=''></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Promedio" >
                        <ItemTemplate>
                            <asp:Label ID="lblPromedio" runat="server" Text=''></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
    </div>






        
    <div class="panel panel-primary">
    <div class="panel-heading">
        <strong>
            <asp:Label ID="lblMes3" runat="server" Text=""></asp:Label>
        </strong>
    </div>
        <div class="table-responsive">
            <asp:GridView ID="grvInformeRecupero3" EmptyDataText="Selección realizada no obtuvo registros" AutoGenerateColumns="true" runat="server" OnRowDataBound="paginacion3_RowDataBound" HeaderStyle-CssClass="info" PagerStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed table small">
                <Columns>
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" runat="server" Text=''></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Promedio" >
                        <ItemTemplate>
                            <asp:Label ID="lblPromedio" runat="server" Text=''></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
    </div>


    
    <div class="panel panel-primary">
    <div class="panel-heading">
        <strong>
            <asp:Label ID="lblMes4" runat="server" Text=""></asp:Label>
        </strong>
    </div>
        <div class="table-responsive">
            <asp:GridView ID="grvInformeRecupero4" EmptyDataText="Selección realizada no obtuvo registros" AutoGenerateColumns="true" runat="server" OnRowDataBound="paginacion4_RowDataBound" HeaderStyle-CssClass="info" PagerStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed table small">
                <Columns>
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" runat="server" Text=''></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Promedio" >
                        <ItemTemplate>
                            <asp:Label ID="lblPromedio" runat="server" Text=''></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
    </div>


        
    <div class="panel panel-primary">
    <div class="panel-heading">
        <strong>
            <asp:Label ID="lblMes5" runat="server" Text=""></asp:Label>
        </strong>
    </div>
        <div class="table-responsive">
            <asp:GridView ID="grvInformeRecupero5" EmptyDataText="Selección realizada no obtuvo registros" AutoGenerateColumns="true" runat="server" OnRowDataBound="paginacion5_RowDataBound" HeaderStyle-CssClass="info" PagerStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed table small">
                <Columns>
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" runat="server" Text=''></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Promedio" >
                        <ItemTemplate>
                            <asp:Label ID="lblPromedio" runat="server" Text=''></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
    </div>

        
        
    <div class="panel panel-primary">
    <div class="panel-heading">
        <strong>
            <asp:Label ID="lblMes6" runat="server" Text=""></asp:Label>
        </strong>
    </div>
        <div class="table-responsive">
            <asp:GridView ID="grvInformeRecupero6" EmptyDataText="Selección realizada no obtuvo registros" AutoGenerateColumns="true" runat="server" OnRowDataBound="paginacion6_RowDataBound" HeaderStyle-CssClass="info" PagerStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed table small">
                <Columns>
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" runat="server" Text=''></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Promedio" >
                        <ItemTemplate>
                            <asp:Label ID="lblPromedio" runat="server" Text=''></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
    </div>





        </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
