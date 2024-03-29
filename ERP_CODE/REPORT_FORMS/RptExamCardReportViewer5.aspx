<%@ Page Title="" Language="C#" Debug="true"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptExamCardReportViewer5.aspx.cs" Inherits="REPORT_FORMS_RptExamCardReportViewer5" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"/>
</asp:Content>

