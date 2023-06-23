<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashBoard.aspx.cs" Inherits="DashBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Global stylesheets Dash Board-->
    <link href="cssdashboard/css/FontFamily.css" rel="stylesheet" type="text/css"/>
    <link href="cssdashboard/Global_Assets/css/icons/icomoon/styles.min.css" rel="stylesheet" type="text/css"/>
    <link href="cssdashboard/css/bootstrap.minNew.css" rel="stylesheet" type="text/css"/>
    <link href="cssdashboard/css/bootstrap_limitless.min.css" rel="stylesheet" type="text/css"/>
    <link href="cssdashboard/css/layout.min.css" rel="stylesheet" type="text/css"/>
    <link href="cssdashboard/css/components.min.css" rel="stylesheet" type="text/css"/>
    <link href="cssdashboard/css/colors.min.css" rel="stylesheet" type="text/css"/>
    <link href="cssdashboard/Global_Assets/js/plugins/pnotify/dist/pnotify.css" rel="stylesheet" />
    <!-- /global stylesheets -->

</head>
<body>
    <form id="form1" runat="server">
        <!-- Content area -->
    <div class="content">

        <div class="row">

            <div class="col-sm-6 col-xl-4">
                <div class="card card-body">
                    <div class="media">
                        <div class="mr-3 align-self-center">
                            <i class="icon-users4 icon-3x text-primary-400"></i>
                        </div>

                        <div class="media-body text-right">
                            <h3 class="font-weight-semibold mb-0">
                                <asp:Label ID="LblTotStudents" Text="0" CssClass="font-weight-semibold mb-0" runat="server" /></h3>
                            <span class="text-uppercase font-size-sm text-muted">total Students</span>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-6 col-xl-4">
                <div class="card card-body">
                    <div class="media">
                        <div class="mr-3 align-self-center">
                            <i class="icon-user-check icon-3x text-success-400"></i>
                        </div>

                        <div class="media-body text-right">
                            <h3 class="font-weight-semibold mb-0"><asp:Label ID="LblActStudents" Text="0" CssClass="font-weight-semibold mb-0" runat="server" /></h3>
                            <span class="text-uppercase font-size-sm text-muted">Active Students</span>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-6 col-xl-4">
                <div class="card card-body">
                    <div class="media">
                          <div class="mr-3 align-self-center">
                            <i class="icon-user-lock icon-3x text-danger-400"></i>
                        </div>
                        <div class="media-body text-right">
                            <h3 class="font-weight-semibold mb-0"><asp:Label ID="LblInactStudents" Text="0" CssClass="font-weight-semibold mb-0" runat="server" /></h3>
                            <span class="text-uppercase font-size-sm text-muted">inactive Students</span>
                        </div>

                      
                    </div>
                </div>
            </div>

        </div>

           <div class="row">

                 <div class="col-sm-6 col-xl-4">
                <div class="card card-body">
                    <div class="media">
                          <div class="mr-3 align-self-center">
                            <i class="icon-user-tie icon-3x text-primary-400"></i>
                        </div>
                        <div class="media-body text-right">
                            <h3 class="font-weight-semibold mb-0"><asp:Label ID="LblTotTutors" Text="0" CssClass="font-weight-semibold mb-0" runat="server" /></h3>
                            <span class="text-uppercase font-size-sm text-muted">Total Tutors</span>
                        </div>

                      
                    </div>
                </div>
            </div>

            <div class="col-sm-6 col-xl-4">
                <div class="card card-body">
                    <div class="media">
                        <div class="mr-3 align-self-center">
                            <i class="icon-user-tie icon-3x text-success-400"></i>
                        </div>

                        <div class="media-body text-right">
                            <h3 class="font-weight-semibold mb-0">
                                <asp:Label ID="LblActTutors" Text="0" CssClass="font-weight-semibold mb-0" runat="server" /></h3>
                            <span class="text-uppercase font-size-sm text-muted">Active Tutors</span>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-6 col-xl-4">
                <div class="card card-body">
                    <div class="media">
                        <div class="mr-3 align-self-center">
                            <i class="icon-user-tie icon-3x text-danger-400"></i>
                        </div>

                        <div class="media-body text-right">
                            <h3 class="font-weight-semibold mb-0"><asp:Label ID="LblInacTutors" Text="0" CssClass="font-weight-semibold mb-0" runat="server" /></h3>
                            <span class="text-uppercase font-size-sm text-muted">inActive Tutors</span>
                        </div>
                    </div>
                </div>
            </div>          

        </div>

        <div class="row">

            <div class="col-sm-6 col-xl-4">
                <div class="card card-body">
                    <div class="media">
                        <div class="mr-3 align-self-center">
                            <i class="icon-book icon-3x text-primary-400"></i>
                        </div>

                        <div class="media-body text-right">
                            <h3 class="font-weight-semibold mb-0">
                                <asp:Label ID="Label1" Text="0" CssClass="font-weight-semibold mb-0" runat="server" /></h3>
                            <span class="text-uppercase font-size-sm text-muted">total Courses</span>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-6 col-xl-4">
                <div class="card card-body">
                    <div class="media">
                        <div class="mr-3 align-self-center">
                            <i class="icon-book icon-3x text-success-400"></i>
                        </div>

                        <div class="media-body text-right">
                            <h3 class="font-weight-semibold mb-0">
                                <asp:Label ID="Label2" Text="0" CssClass="font-weight-semibold mb-0" runat="server" /></h3>
                            <span class="text-uppercase font-size-sm text-muted">Active Courses</span>
                        </div>
                    </div>
                </div>
            </div>

           <div class="col-sm-6 col-xl-4">
                <div class="card card-body">
                    <div class="media">
                        <div class="mr-3 align-self-center">
                            <i class="icon-book icon-3x text-danger-400"></i>
                        </div>

                        <div class="media-body text-right">
                            <h3 class="font-weight-semibold mb-0">
                                <asp:Label ID="Label3" Text="0" CssClass="font-weight-semibold mb-0" runat="server" /></h3>
                            <span class="text-uppercase font-size-sm text-muted">inactive Courses</span>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>
    <!-- /content area -->
    </form>
</body>
</html>
