<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cobros30.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ingreso</title>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
    <!-- Bootstrap 3.3.5 -->
   
    <link href="assets/template/AdminLTE-2.3.0/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css"/>
    <!-- Theme style -->
    <link href="assets/template/AdminLTE-2.3.0/dist/css/AdminLTE.min.css" rel="stylesheet" />

    <!-- iCheck -->
    <link href="assets/template/AdminLTE-2.3.0/plugins/iCheck/flat/blue.css" rel="stylesheet" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body class="hold-transition login-page">

        <!-- jQuery 2.1.4 -->
      <div class="login-box">
      <div class="login-box-body">
      <div class="login-logo">
          <h1><span class="label label-default">CRM SMART RECOVER</span></h1>
      </div><!-- /.login-logo -->

        <p class="login-box-msg">Ingrese sus datos para iniciar la sesión</p>
        <form id="form1" runat="server">
          <div class="form-group has-feedback">
            <input id="inpUsuario" type="text" runat="server" class="form-control" placeholder="Login" required autofocus="autofocus"/>
            <span class="glyphicon glyphicon-user form-control-feedback"></span>
          </div>
          <div class="form-group has-feedback">
            <input id="inpPassword" type="password" runat="server" class="form-control" placeholder="Password" required />
            <span class="glyphicon glyphicon-lock form-control-feedback"></span>
          </div>
          <div class="row">
            <div class="col-xs-8">
            </div><!-- /.col -->
            <div class="col-xs-4">
                <asp:Button ID="btnIngresar" OnClick="btnIngresar_Click" runat="server" Text="Ingresar" CssClass="btn btn-primary btn-block btn-flat" />
            </div><!-- /.col -->
          </div>
        </form>

        <div>
<%--             <img src="assets/img/logo_mini_interweb.png" class="img-rounded" />--%>
          <img src="assets/img/logoIT.gif" class="img-rounded" />
        </div>

      </div><!-- /.login-box-body -->
         <br />
         <!-- Alertas -->
         <div id="divAlerta" runat="server" visible="false" class="alert alert-danger">
             <strong>Error!</strong> <asp:Label Text="" ID="lblError" runat="server" />
         </div>
    </div><!-- /.login-box -->



    <script type="text/javascript">
    <!--

    $(document).ready(function () {

    window.setTimeout(function() {
        $(".alert").fadeTo(1500, 0).slideUp(500, function(){
            $(this).remove(); 
        });
    }, 2000);

    });
    //-->
    </script>

    <script src="assets/template/AdminLTE-2.3.0/plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="assets/template/AdminLTE-2.3.0/bootstrap/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="assets/template/AdminLTE-2.3.0/plugins/iCheck/icheck.min.js"></script>
    <script>
      $(function () {
        $('input').iCheck({
          checkboxClass: 'icheckbox_square-blue',
          radioClass: 'iradio_square-blue',
          increaseArea: '20%' // optional
        });
      });
    </script>

</body>
</html>
