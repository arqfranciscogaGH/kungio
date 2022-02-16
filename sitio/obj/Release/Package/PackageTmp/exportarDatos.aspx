<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="exportarDatos.aspx.cs" Inherits="Sitio.exportarDatos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Exportar  información KunGio</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="Servicios Credito infonavit linea IV en Kungio">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="msapplication-tap-highlight" content="no" />
    <meta name="robots" content="index,follow,all" />
    <meta name="keywords" content="Servicios Credito infonavit linea IV Pension Afore  Prcalificate" />
    <meta name="author" content="Francisco Garcia | STI" />
    <!--
    Google Fonts
    ============================================= -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700" rel="stylesheet" type="text/css">

    <!--
    CSS
    ============================================= -->
<%--    <!-- Fontawesome -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css">--%>
    <link href="Comun/plugins/fontawesome-free-5.0.1/css/fontawesome-all.css" rel="stylesheet" type="text/css">
    <!-- Bootstrap -->
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <!-- Fancybox -->
    <link rel="stylesheet" href="css/jquery.fancybox.css">
    <!-- owl carousel -->
    <link rel="stylesheet" href="css/owl.carousel.css">
    <!-- Animate -->
    <link rel="stylesheet" href="css/animate.css">
    <!-- Main Stylesheet -->
    <link rel="stylesheet" href="css/main.css">
    <!-- Main Responsive -->
    <link rel="stylesheet" href="css/responsive.css">

    <link href="App_Themes/Base/maqueta.css" rel="stylesheet" />
    <!-- Modernizer Script for old Browsers -->
    <style>
/*        .cuerpo {
            background-color: black;
        }
        bodys {
             background-color: black;
        }*/
    </style>
</head>
</head>

<body class="cuerpo">
    <form id="form1" runat="server">
         <section id="ExportarInformacion">
             <h1>Exportar  información</h1>
             <br />
             <br />
             <asp:GridView ID="gridService" runat="server">  </asp:GridView>  
             <br />
             <br />
             <asp:Button id="btnExportar" runat="server" Text="   Dashboard   "  CssClass="botonOtro"  onclick="btnExportar_Click"  />	

             <br />
             <br />
         </section >
         <footer id="footer" class="text-center">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="footer-logo wow fadeInDown">
                            <img src="img/logo2.png" alt="logo">
                        </div>
                        <div class="footer-social wow fadeInUp">
                            <h3>Nuestras redes sociales</h3>
                            <ul class="text-center list-inline">
                                <li><a href="https://www.facebook.com/KunGio.mx"><i class="fab fa-facebook-f fa-lg "></i></a></li>
                                <li><a href="https://www.facebook.com/KunGio.mx"><i class="fab fa-twitter fa-lg"></i></a></li>
                                <li><a href="https://www.facebook.com/KunGio.mx"><i class="fab fa-youtube fa-lg"></i></a></li>
                                <li><a href="https://www.facebook.com/KunGio.mx"><i class="fab fa-instagram fa-lg"></i></a></li>

                            </ul>
                        </div>
                        <div class="copyright">
                            <p>Derechos Reservados KUNGIO ,  <a href="http://KunGio.mx"></a> Diseñado por Francisco Garcia <a target="_blank" href="http://KunGio.mx"></a></p>
                        </div>
                    </div>
                </div>
            </div>
         </footer>
    </form>
</body>
</html>
