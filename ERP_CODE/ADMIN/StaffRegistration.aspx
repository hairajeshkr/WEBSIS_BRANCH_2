<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StaffRegistration.aspx.cs" Inherits="STUDENT_StaffRegistration" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="../CtrlDate.ascx" TagName="CtrlDate" TagPrefix="uc3" %>
<%@ Register Src="../WebUserControl.ascx" TagName="WebUserControl" TagPrefix="uc4" %>
<%@ Register Src="../CtrlGridSmallList.ascx" TagName="CtrlGridSmallList" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/AccountLedger.js" type="text/javascript"></script>
    <div style="height: 850px; width: 1070px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="850px" Width="1050px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>Staff Registration</HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style2" style="height: 796px">
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label124" runat="server" Text="Staff Name" Width="120px"></asp:Label></td>
                            <td align="left" class="odd" colspan="4">
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DdlSaltn" runat="server" SkinID="Ddl100"></asp:DropDownList></td>
                                        <td>
                                            <asp:TextBox ID="TxtName" runat="server" placeholder="Staff Name" SkinID="Txt400"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                            <td class="odd" colspan="2">
                                <table style="width: 56%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label128" runat="server" Text="Staff ID" Width="70px"></asp:Label>
                                            <asp:TextBox ID="TxtCode" runat="server" Enabled="False" placeholder="Staff ID" SkinID="TxtCodeDisable"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label123" runat="server" Text="App. Order No." Width="120px"></asp:Label></td>
                            <td align="left" class="odd" colspan="4">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TxtApporderNo" runat="server" placeholder="App. Order No." SkinID="TxtSng250"></asp:TextBox></td>
                                        <td class="odd">
                                            <asp:Label ID="Label129" runat="server" Text="Reg No." Width="100px"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="TxtRegNo" runat="server" placeholder="Reg No." SkinID="Txt140"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                            <td class="odd" rowspan="6" colspan="2">
                                <table style="width: 83%">
                                    <tr>
                                        <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table class="upload-field-parent">
                                            <tr>
                                                <td>
                                                    <img id="ImgItem" runat="server" alt="Image" class="ItemImageStyle" src="~//images//admin.png" style="border: solid; border-width: 1px; border-color: gray; height: 150px; width: 200px;" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <img id="ImgCapture" runat="server" alt="Image" class="ItemImageStyle" src="~/images/ImageCapture.png" style="border: solid; border-width: 1px; border-color: gray; height: 50px; width: 50px; cursor: pointer;"></img> </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    </img>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</img>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</img>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</img></img></img>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</img></td>
                                                <caption>
                                                    <img/>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </caption>
                                            </tr>
                                        </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="upload-field-input" style="width: 78px">
                                            <ajaxToolkit:AsyncFileUpload ID="FileUploadImg" runat="server" CssClass="FileUploadControl upload-field-parent upload-field-input" FailedValidation="False" Width="200px" />
                                        </td>
                                        <td>
                                            <asp:HyperLink ID="HyLnkImg" runat="server" CssClass="upload-field-img"></asp:HyperLink></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label122" runat="server" Text="Probationary Period" Width="133px" Height="28px"></asp:Label></td>
                            <td align="left" class="odd" colspan="4">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TxtProbationaryPeriod" runat="server" placeholder="Probationary Period" SkinID="TxtSng250"></asp:TextBox></td>
                                        <td>
                                            <asp:CheckBox ID="chkGuest" runat="server" Font-Bold="False" SkinID="ChkSelect" Text="Guest" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkVacStaff" runat="server" Font-Bold="False" SkinID="ChkSelect" Text="Vacation Staff" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label8" runat="server" Text="Date of Joining" Width="120px"></asp:Label></td>
                            <td align="left" class="odd" colspan="4">
                                <table class="upload-field-parent">
                                    <tr>
                                        <td>
                                            <uc3:CtrlDate ID="CtrlDOJ" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label125" runat="server" Text="Date of Birth" Width="90px"></asp:Label>
                                        </td>
                                        <td>
                                            <uc3:CtrlDate ID="CtrlDob" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label152" runat="server" Text="Age" Width="25px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtAge" runat="server" Enabled="False" placeholder="Age" SkinID="TxtQtyCentreDisable"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label131" runat="server" Text="Appointment Nature" Width="133px" Height="36px"></asp:Label>
                            </td>
                            <td align="left" class="odd" colspan="4">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DdlAppointmentNature" runat="server" SkinID="DdlNatureOfAppointment">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="height: 39px; width: 150px">
                                            <asp:RadioButtonList ID="RadBtnGender" runat="server" SkinID="RadBtnSex" Height="22px" Width="193px">
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="height: 39px">
                                <asp:Label ID="Label132" runat="server" Text="Permanent Address" Width="136px"></asp:Label>
                            </td>
                            <td align="left" class="odd" colspan="4" style="height: 39px">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TxtPermanentAddress" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td style="height: 39px; width: 150px">
                                            <asp:RadioButtonList ID="RadBtnMaritalStatus" runat="server" SkinID="RadBtnLst" Width="189px">
                                                <asp:ListItem Value="1">Married</asp:ListItem>
                                                <asp:ListItem Value="2">Unmarried</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label154" runat="server" Text="Temporary Address" Width="130px"></asp:Label>
                            </td>
                            <td align="left" class="odd" colspan="4">
                                <table>
                                    <tr>
                                        <td>
                                           <asp:TextBox ID="TxtTemproraryAddress" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td class="odd">
                                            <asp:Label ID="Label155" runat="server" Text="Blood Group" Width="100px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DdlBloodGrp" runat="server" SkinID="DdlBloodGroup">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label27" runat="server" Text="Bank A/c No." Width="140px"></asp:Label></td>
                            <td align="left" class="odd" colspan="4">
                                <table style="width: 100%; height: 100%;">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TxtBankAccNo" runat="server" placeholder="Bank A/c No." SkinID="Txt140"></asp:TextBox></td>
                                        <td class="odd">
                                            <asp:Label ID="Label6" runat="server" Text="Bank Name" Width="140px"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="TxtBankName" runat="server" placeholder="Bank Name" SkinID="Txt140"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                            <td class="odd" colspan="2">
                                <table class="upload-field-parent" style="width: 49%">
                                    <tr>
                                        <td class="odd" style="width: 119px">
                                            <asp:Label ID="Label1" runat="server" Text="Subject" Width="100px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DdlSubject" runat="server" SkinID="DdlRelationShip">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label7" runat="server" Text="Branch Name" Width="140px"></asp:Label></td>
                            <td align="left" class="odd" colspan="4">
                                <table style="width: 100%; height: 100%;">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TxtBranchName" runat="server" placeholder="Branch Name" SkinID="Txt140"></asp:TextBox></td>
                                        <td class="odd">
                                            <asp:Label ID="Label9" runat="server" Text="IFSC Code" Width="140px"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="TxtIFSC" runat="server" placeholder="IFSC Code" SkinID="Txt140"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                            <td class="odd" colspan="2">
                                <table class="upload-field-parent" style="width: 14%">
                                    <tr>
                                        <td class="odd" style="width: 119px">
                                            <asp:Label ID="Label2" runat="server" Text="Training" Width="100px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DdlTraining" runat="server" SkinID="DdlTraining">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label153" runat="server" Text="Father/Spouse Name" Width="140px"></asp:Label></td>
                            <td align="left" class="odd" colspan="4">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="height: 39px">
                                            <asp:DropDownList ID="DdlFatherSpouseSalu" runat="server" SkinID="Ddl100">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="height: 39px">
                                            <asp:TextBox ID="TxtFatherSpouseName" runat="server" placeholder="Father/Spouse Name" SkinID="Txt400"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="odd" colspan="2">
                                <table class="upload-field-parent" style="width: 84%">
                                    <tr>
                                        <td class="odd" style="width: 119px">
                                            <asp:Label ID="Label156" runat="server" Text="Experiance" Width="120px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DdlExperiance" runat="server" SkinID="DdlExperiance">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label42" runat="server" Text="Department" Width="120px"></asp:Label>
                            </td>
                            <td align="left" class="odd" colspan="3">
                                <uc2:CtrlGridList ID="CtrlGrdDepartment" runat="server" AccountType="ReligionList" GridHeight="180" PlaceHoldr="Religion" />
                            </td>
                            <td class="odd">
                                <asp:Label ID="Label134" runat="server" Text="Official Status" Width="120px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:DropDownList ID="DdlOfficialStatus" runat="server" SkinID="DdlOfficialStatus">
                                </asp:DropDownList>
                            </td>
                            <td class="odd">
                                <asp:Label ID="Label3" runat="server" Text="State" Width="100px"></asp:Label>
                                <asp:DropDownList ID="DdlState" runat="server" SkinID="DdlBloodGroup">
                                </asp:DropDownList>
                            </td>
                            <tr>
                                <td class="odd">
                                    <asp:Label ID="Label43" runat="server" Text="Qualification" Width="80px"></asp:Label>
                                </td>
                                <td align="left" class="odd" colspan="3">
                                    <uc2:CtrlGridList ID="CtrlQualification" runat="server" AccountType="CommunityList" GridHeight="150" PlaceHoldr="Qualification" />
                                </td>
                                <td class="odd">
                                    <asp:Label ID="Label4" runat="server" Text="Account Head" Width="105px"></asp:Label>
                                </td>
                                <td class="odd">
                                    <asp:DropDownList ID="DdlAccountHead" runat="server" SkinID="DdlBloodGroup">
                                    </asp:DropDownList>
                                </td>
                                <td class="odd">
                                    <asp:Label ID="Label5" runat="server" Text="Account Group" Width="100px"></asp:Label>
                                    <asp:DropDownList ID="DdlAccountGroup" runat="server" Height="32px" SkinID="DdlBloodGroup">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="odd">
                                    <asp:Label ID="Label133" runat="server" Text="Designation" Width="120px"></asp:Label>
                                </td>
                                <td align="left" class="odd" colspan="3">
                                    <uc2:CtrlGridList ID="CtrlDesignation" runat="server" AccountType="CategoryList" GridHeight="120" PlaceHoldr="Designation" />
                                </td>
                                <td class="odd">
                                    <asp:Label ID="Label127" runat="server" Text="Reason For Leaving" Width="136px"></asp:Label>
                                </td>
                                <td align="left" class="odd" colspan="2">
                                    <asp:TextBox ID="TxtReasonLeaving" runat="server" placeholder="Reason For Leaving" SkinID="TxtSng200" Width="276px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="odd">
                                    <asp:Label ID="Label149" runat="server" Text="PF No" Width="130px"></asp:Label>

                                    <td colspan="3">
                                        <asp:TextBox ID="TxtPFNo" runat="server" placeholder="PF No" SkinID="Txt140"></asp:TextBox></td>


                                    <td class="odd">
                                        <asp:Label ID="Label12" runat="server" Text="Remarks" Width="120px"></asp:Label>
                                    </td>
                                    <td class="odd" colspan="2" rowspan="3" style="margin-left: 40px">
                                        <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </td>
                            </tr>
                            <tr>
                                <td class="odd">
                                    <asp:Label ID="Label150" runat="server" Text="PAN No" Width="130px"></asp:Label>
                                    <td class="upload-field-input" style="width: 270px">
                                        <asp:TextBox ID="TxtPANNo" runat="server" placeholder="PAN No" SkinID="Txt140"></asp:TextBox></td>
                                    <td class="upload-field-input" style="width: 270px">
                                        <asp:Label ID="Label10" runat="server" Text="Aadhar No" Width="107px"></asp:Label></td>
                                    <td>&nbsp;</td>
                                    <td class="odd">
                                        <asp:TextBox ID="TxtAadharNo" runat="server" placeholder="Aadhar No" SkinID="Txt140"></asp:TextBox>
                                    </td>
                                </td>
                            </tr>
                            <tr>
                                <td class="odd">
                                    <asp:Label ID="Label151" runat="server" Text="Mob No." Width="130px"></asp:Label>
                                    <td class="odd" colspan="3">
                                        <table class="upload-field-parent">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="TxtMobNo" runat="server" placeholder="Phone No" SkinID="Txt140"></asp:TextBox>
                                                </td>
                                                <td><asp:Label ID="Label11" runat="server" Text="Phone No" Width="107px"></asp:Label></td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="odd"><asp:TextBox ID="TxtPhoneNo" runat="server" placeholder="Phone No" SkinID="Txt140"></asp:TextBox></td>
                                </td>
                            </tr>
                            <tr>
                                <td class="odd">
                                    <td class="odd" colspan="3">
                                        <asp:CheckBox ID="ChkActive" runat="server" Checked="True" Font-Bold="False" SkinID="IsActive" Text="Active" />
                                    </td>
                                    <td class="odd"></td>
                                    <td class="odd" colspan="2">
                                        <asp:Label ID="LblScript" runat="server"></asp:Label>
                                    </td>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="FooterCommand" colspan="7" valign="middle">
                                    <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="True" />
                                </td>
                            </tr>
                        </tr>
                    </table>
                </ContentTemplate>




            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>Staff List</HeaderTemplate>



                <ContentTemplate>
                    <table style="width: 100%; height: 0px;">
                        <tr>
                            <td style="height: 39px" class="odd">
                                <asp:Label ID="Label13" runat="server" Text="Staff Name" Width="90px"></asp:Label></td>
                            <td style="height: 39px">
                                <asp:TextBox ID="TxtName_Srch" runat="server" placeholder="Staff Name" SkinID="TxtSng200"></asp:TextBox></td>
                            
                            <td style="height: 39px" class="odd">
                                <asp:Label ID="Label26" runat="server" Text="Adm. No" Width="70px"></asp:Label></td>
                            <td style="height: 39px">
                                <asp:TextBox ID="TxtAdmNo_Srch" runat="server" placeholder="Adm No. / Roll No" SkinID="TxtCode" Style="left: -335px; top: 19px"></asp:TextBox></td>
                            <td style="height: 39px"></td>
                        </tr>
                        <tr class="result-head">
                            <td class="odd" style="height: 39px">
                                <asp:Label ID="Label136" runat="server" Text="Adhar No." Width="100px"></asp:Label></td>
                            <td style="height: 39px">
                                <asp:TextBox ID="TxtAdhar_Srch" runat="server" placeholder="Adhar No." SkinID="TxtSng200"></asp:TextBox></td>
                           
                            <td class="odd" style="height: 39px">
                                <asp:Label ID="Label135" runat="server" Text="Reg.No." Width="70px"></asp:Label></td>
                            <td style="height: 39px">
                                <asp:TextBox ID="TxtRegNo_Srch" runat="server" placeholder="Reg.No." SkinID="TxtCode"></asp:TextBox></td>
                            <td style="height: 39px">
                                <asp:Button ID="BtnFind" runat="server" Text="Find" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" OnClick="ManiPulateDataEvent_Clicked" /></td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <div class="result-list" style="overflow: scroll; height: 500px; width: 1005px">
                                    <asp:GridView ID="GrdVwRecords" runat="server" PageSize="25" SkinID="GrdVwMaster" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("DisplayName") %>' Width="300px"></asp:LinkButton><asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("Id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Staff Id">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkCode" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Code") %>' Width="120px"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reg.No">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkRegNo" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("RegNo") %>' Width="120px"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Staff Code">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkStudentCode" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Code") %>' Width="120px"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DOB">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkDOB" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Dob") %>' Width="150px"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Permanent Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblPAddress" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("PAddress") %>' Width="50px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Temporaroy Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblTAddress" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("CAddress") %>' Width="50px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sex">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSex" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Sex") %>' Width="50px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mob No">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblMobNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("MobNo") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Bank Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblBankName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("BankName") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="A/c No">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblAccno" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("BankAccNo") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="BloodGroup">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblBloodGroup" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("BloodGroup") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                <ItemStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:CheckBoxField DataField="Active" HeaderText="Active" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </ContentTemplate>




            </ajaxToolkit:TabPanel>
            
            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>Staff Details</HeaderTemplate>

            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>

