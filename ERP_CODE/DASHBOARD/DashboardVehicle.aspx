<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashboardVehicle.aspx.cs" Inherits="DashboardVehicle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <!-- Bootstrap -->
    <link href="../STYLE/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="../STYLE/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- NProgress -->
    <link href="../STYLE/nprogress/nprogress.css" rel="stylesheet" />
    <!-- bootstrap-daterangepicker -->
    <link href="../STYLE/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet" />
    <!-- Custom Theme Style -->
    <link href="../STYLEBUILD/css/custom.min.css" rel="stylesheet" />
        <!-- Custom dash board Theme Style -->
    <link href="../StyleSheet/StyleControlsNew.css" rel="stylesheet" />
    <!-- jQuery -->
    <script src="../STYLE/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../STYLE/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <!-- FastClick -->
    <script src="../STYLE/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../STYLE/nprogress/nprogress.js"></script>
    <!-- Chart.js -->
    <script src="../STYLE/Chart.js/dist/Chart.min.js"></script>
    <!-- jQuery Sparklines -->
    <script src="../STYLE/jquery-sparkline/dist/jquery.sparkline.min.js"></script>
    <!-- Flot -->
    <script src="../STYLE/Flot/jquery.flot.js"></script>
    <script src="../STYLE/Flot/jquery.flot.pie.js"></script>
    <script src="../STYLE/Flot/jquery.flot.time.js"></script>
    <script src="../STYLE/Flot/jquery.flot.stack.js"></script>
    <script src="../STYLE/Flot/jquery.flot.resize.js"></script>
    <!-- Flot plugins -->
    <script src="../STYLE/flot.orderbars/js/jquery.flot.orderBars.js"></script>
    <script src="../STYLE/flot-spline/js/jquery.flot.spline.min.js"></script>
    <script src="../STYLE/flot.curvedlines/curvedLines.js"></script>
    <!-- DateJS -->
    <script src="../STYLE/DateJS/build/date.js"></script>
    <!-- bootstrap-daterangepicker -->
    <script src="../STYLE/moment/min/moment.min.js"></script>
    <script src="../STYLE/bootstrap-daterangepicker/daterangepicker.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="../STYLEBUILD/js/custom.min.js"></script>
</head>
<body style="background-color: whitesmoke;">
<form id="form1" runat="server">
<!-- page content -->
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> <asp:Timer ID="Timer1" runat="server" Enabled="false" Interval="18000" OnTick="Timer1_Tick"></asp:Timer>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate> 
<div class="right_col" role="main">
<div class="">
    <div class="row" style="display: inline-block;width:100%;">
        <div class="top_tiles">
            <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 ">
                <div class="tile-stats tile-bck-orange">
                    <div class="icon tile-font-white"><i class="fa fa-automobile"></i></div>
                    <div class="count tile-font-white"><span runat="server" id="SpnCnt1">179</span></div>
                    <h3 class="tile-font-white">Vehicle's</h3>
                    <p class="tile-font-white">Running vehicle count.</p>
                </div>
            </div>
            <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 ">
                <div class="tile-stats tile-bck-vilote">
                    <div class="icon tile-font-white"><i class="fa fa-male" style="text-align:right;"></i></div>
                    <div class="count tile-font-white"><span runat="server" id="SpnCnt2">179</span></div>
                    <h3 class="tile-font-white">Driver's</h3>
                    <p class="tile-font-white">Duty driver's count.</p>
                </div>
            </div>
            <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 ">
                <div class="tile-stats tile-bck-red">
                    <div class="icon tile-font-white"><i class="fa fa-wrench"></i></div>
                    <div class="count tile-font-white"><span runat="server" id="SpnCnt3">179</span></div>
                    <h3 class="tile-font-white">Maintanance</h3>
                    <p class="tile-font-white">Workshope vehicle's count..</p>
                </div>
            </div>
            <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 ">
                <div class="tile-stats tile-bck-blue">
                    <div class="icon tile-font-white"><i class="fa fa-inbox"></i></div>
                    <div class="count tile-font-white"><span runat="server" id="SpnCnt4">179</span></div>
                    <h3 class="tile-font-white">Trip Order</h3>
                    <p class="tile-font-white">Pending trip order count.</p>
                </div>
            </div>
              <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 ">
                <div class="tile-stats tile-bck-green">
                    <div class="icon tile-font-white"><i class="fa fa-cab"></i></div>
                    <div class="count tile-font-white"><span runat="server" id="SpnCnt5">179</span></div>
                    <h3 class="tile-font-white">Trip allocation</h3>
                    <p class="tile-font-white">Today trip allocation list.</p>
                </div>
            </div>
            <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 ">
                <div class="tile-stats tile-bck-Lblue">
                    <div class="icon tile-font-white"><i class="fa fa-bus"></i></div>
                    <div class="count tile-font-white"><span runat="server" id="SpnCnt6">179</span></div>
                    <h3 class="tile-font-white">Running Trip</h3>
                    <p class="tile-font-white">Running trip list count.</p>
                </div>
            </div>
            <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 ">
                <div class="tile-stats tile-bck-dark">
                    <div class="icon tile-font-white"><i class="fa fa-random"></i></div>
                    <div class="count tile-font-white"><span runat="server" id="SpnCnt7">179</span></div>
                    <h3 class="tile-font-white">Long Trip</h3>
                    <p class="tile-font-white">Pending long trip list count.</p>
                </div>
            </div>
             <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 ">
                <div class="tile-stats tile-bck-Dvilote">
                    <div class="icon tile-font-white"><i class="fa fa-folder"></i></div>
                    <div class="count tile-font-white"><span runat="server" id="SpnCnt8">179</span></div>
                    <h3 class="tile-font-white">My Trip</h3>
                    <p class="tile-font-white">My trip allocation list count.</p>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Rc Exipre Vehicle List <small>Sessions</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                             <!--<div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                <a class="dropdown-item" href="#">Settings 1</a>
                                <a class="dropdown-item" href="#">Settings 2</a>
                            </div>-->
                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:Repeater runat="server" ID="RptrRcExpireLst">
                        <ItemTemplate>
                            <article class="media event" style="padding-bottom: 2px;">
                                <a class="pull-left date">
                                    <p class="month"><%#Eval("MonthVal")%></p>
                                    <p class="day"><%#Eval("DateVal")%></p>
                                </a>
                                <div class="media-body">
                                    <a class="title" href="#"><%#Eval("ItemDesc")%></a>
                                    <p><%#Eval("Remarks")%></p>
                                </div>
                            </article>
                     </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Registration Exipre Vehicle List <small>Sessions</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                              <!--<div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                <a class="dropdown-item" href="#">Settings 1</a>
                                <a class="dropdown-item" href="#">Settings 2</a>
                            </div>-->
                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:Repeater runat="server" ID="RptrRegExpireLst">
                        <ItemTemplate>
                            <article class="media event" style="padding-bottom: 2px;">
                                <a class="pull-left date">
                                    <p class="month"><%#Eval("MonthVal")%></p>
                                    <p class="day"><%#Eval("DateVal")%></p>
                                </a>
                                <div class="media-body">
                                    <a class="title" href="#"><%#Eval("ItemDesc")%></a>
                                    <p><%#Eval("Remarks")%></p>
                                </div>
                            </article>
                     </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Insurance Exipre Vehicle List <small>Sessions</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                            <!--<div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                <a class="dropdown-item" href="#">Settings 1</a>
                                <a class="dropdown-item" href="#">Settings 2</a>
                            </div>-->
                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                 <asp:Repeater runat="server" ID="RptrIsuxpireLst">
                        <ItemTemplate>
                            <article class="media event" style="padding-bottom: 2px;">
                                <a class="pull-left date">
                                    <p class="month"><%#Eval("MonthVal")%></p>
                                    <p class="day"><%#Eval("DateVal")%></p>
                                </a>
                                <div class="media-body">
                                    <a class="title" href="#"><%#Eval("ItemDesc")%></a>
                                    <p><%#Eval("Remarks")%></p>
                                </div>
                            </article>
                     </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
<!-- /page content -->
    </form>
</body>
</html>
