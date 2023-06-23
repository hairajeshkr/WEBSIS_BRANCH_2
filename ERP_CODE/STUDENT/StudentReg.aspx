<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentReg.aspx.cs" Inherits="StudentReg" StyleSheetTheme="SkinFile" Theme="SkinFile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<%@ Register src="../WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc4" %>
<%@ Register src="../CtrlGridSmallList.ascx" tagname="CtrlGridSmallList" tagprefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="Script/AccountLedger.js" type="text/javascript"></script>
    <div style="height:590px; width:1040px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Height="600px" Width="1030px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" style="border:1px solid #fff !important;">
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate> Student Registration
              </HeaderTemplate>
              <ContentTemplate>
                  <table class="auto-style2">
                      <tr>
                          <td class="odd" >
                              <asp:Label ID="Label124" runat="server" Text="Student Name" Width="120px"></asp:Label>
                          </td>
                          <td align="left" class="odd" colspan="2">
                              <table style="width: 100%">
                                  <tr>
                                      <td>
                                          <asp:DropDownList ID="DdlSaltn" runat="server" SkinID="Ddl100">
                                          </asp:DropDownList>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="TxtName" runat="server" placeholder="Student Name" SkinID="Txt400"></asp:TextBox>
                                      </td>
                                  </tr>
                              </table>
                          </td>
                          <td class="odd">
                              <table style="width: 60%">
                                  <tr>
                                      <td></td>
                                      <td>
                                          <asp:Label ID="Label128" runat="server" Text="Student ID" Width="100px"></asp:Label>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="TxtCode" runat="server" placeholder="Student ID" SkinID="TxtCodeDisable"></asp:TextBox>
                                      </td>
                                  </tr>
                              </table>
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label123" runat="server" Text="Admn. / Roll No" Width="120px"></asp:Label>
                          </td>
                          <td align="left" class="odd" colspan="2">
                              <table style="width: 60%">
                                  <tr>
                                      <td>
                                          <asp:TextBox ID="TxtAdmnNo" runat="server" placeholder="Admn. / Roll No" SkinID="TxtSng250"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:Label ID="Label129" runat="server" Text="Reg No." Width="100px"></asp:Label>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="TxtRegNo" runat="server" placeholder="Reg No." SkinID="TxtCode"></asp:TextBox>
                                      </td>
                                  </tr>
                              </table>
                          </td>
                          <td class="odd" rowspan="6">
                              <table style="width: 100%">
                                  <tr>
                                      <td rowspan="2">
                                           <img id="ImgItem" runat="server" alt="Image" src="~//images//admin.png" class="ItemImageStyle" style="border:solid;border-width:1px;border-color:gray;height:150px;width:200px;" />
                                     &nbsp;&nbsp;</img></td>
                                      <td></td>
                                  </tr>
                                  <tr>
                                      <td></td>
                                  </tr>
                                  <tr>
                                      <td>
                                          <ajaxToolkit:AsyncFileUpload ID="FileUploadImg" runat="server" CssClass="FileUploadControl upload-field-parent upload-field-input" FailedValidation="False" OnUploadedComplete="FileUploadImg_UploadedComplete" Width="200px" />
                                      </td>
                                      <td>
                                          <asp:HyperLink ID="HyLnkImg" runat="server" CssClass="upload-field-img"></asp:HyperLink>
                                      </td>
                                  </tr>
                              </table>
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label122" runat="server" Text="Aadhar No" Width="120px"></asp:Label>
                          </td>
                          <td align="left" class="odd" colspan="2">
                              <table style="width: 100%">
                                  <tr>
                                      <td>
                                          <asp:TextBox ID="TxtAdharNo" runat="server" placeholder="Aadhar No" SkinID="TxtSng250"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:Label ID="Label130" runat="server" Text="Student Code" Width="100px"></asp:Label>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="TxtStudentCode" runat="server" placeholder="Student Code" SkinID="TxtCode"></asp:TextBox>
                                      </td>
                                  </tr>
                              </table>
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label8" runat="server" Text="Admission Date" Width="120px"></asp:Label>
                          </td>
                          <td align="left" class="odd" colspan="2">
                              <uc3:CtrlDate ID="CtrlAdmnDate" runat="server" />
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label125" runat="server" Text="Date of Birth" Width="120px"></asp:Label>
                          </td>
                          <td align="left" class="odd" colspan="2">
                              <table class="upload-field-parent">
                                  <tr>
                                      <td>
                                          <uc3:CtrlDate ID="CtrlDob" runat="server" />
                                      </td>
                                      <td>
                                          <asp:Label ID="Label2" runat="server" Width="50px"></asp:Label>
                                      </td>
                                      <td>
                                          <asp:Label ID="Label1" runat="server" Text="Age" Width="50px"></asp:Label>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="TxtAge" runat="server" placeholder="Age" SkinID="TxtQtyCentre"></asp:TextBox>
                                      </td>
                                      <td style="width: 150px">
                                          <asp:RadioButtonList ID="RadBtnGender" runat="server" SkinID="RadBtnSex">
                                          </asp:RadioButtonList>
                                      </td>
                                  </tr>
                              </table>
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label131" runat="server" Text="Class" Width="120px"></asp:Label>
                          </td>
                          <td align="left" class="odd" colspan="2">
                              <uc2:CtrlGridList ID="CtrlGrdClass" runat="server" AccountType="ClassList" PlaceHoldr="Class" />
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label132" runat="server" Text="Division" Width="120px"></asp:Label>
                          </td>
                          <td align="left" class="odd" colspan="2">
                              <uc2:CtrlGridList ID="CtrlGrdDivision" runat="server" AccountType="DivisionList" PlaceHoldr="Division" />
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label27" runat="server" Text="Father Name" Width="120px"></asp:Label>
                          </td>
                          <td align="left" class="odd" colspan="2">
                              <table style="width: 100%;height:100%;">
                                  <tr>
                                      <td>
                                          <asp:DropDownList ID="DdlSaltnFthr" runat="server" SkinID="Ddl100">
                                          </asp:DropDownList>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="TxtFatherName" runat="server" placeholder="Father Name" SkinID="Txt400"></asp:TextBox>
                                      </td>
                                  </tr>
                              </table>
                          </td>
                          <td class="odd">
                              <asp:CheckBox ID="ChkHostel" runat="server" Font-Bold="False" SkinID="ChkSelect" Text="Hostel Accomodation" />
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label126" runat="server" Text="Mother Name" Width="120px"></asp:Label>
                          </td>
                          <td align="left" class="odd" colspan="2">
                              <table style="width: 100%">
                                  <tr>
                                      <td>
                                          <asp:DropDownList ID="DdlSaltnMthr" runat="server" SkinID="Ddl100">
                                          </asp:DropDownList>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="TxtMotherName" runat="server" placeholder="Mother Name" SkinID="Txt400"></asp:TextBox>
                                      </td>
                                  </tr>
                              </table>
                          </td>
                          <td class="odd">
                              <asp:CheckBox ID="ChkOwnAcc" runat="server" Font-Bold="False" SkinID="ChkSelect" Text="Create Own Account" />
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label42" runat="server" Text="Religion" Width="120px"></asp:Label>
                          </td>
                          <td align="left" class="odd">
                              <uc2:CtrlGridList ID="CtrlGrdReligion" runat="server" AccountType="ReligionList" GridHeight="200" PlaceHoldr="Religion" />
                          </td>
                          <td class="odd">
                              <asp:Label ID="Label134" runat="server" Text="Account Ledger" Width="120px"></asp:Label>
                          </td>
                          <td class="odd">
                              <asp:DropDownList ID="DdlAccountLedger" runat="server" SkinID="DdlList">
                              </asp:DropDownList>
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label43" runat="server" Text="Community" Width="120px"></asp:Label>
                          </td>
                          <td align="left" class="odd">
                              <uc2:CtrlGridList ID="CtrlGrdCommunity" runat="server" AccountType="CommunityList" GridHeight="200" PlaceHoldr="Community" />
                          </td>
                          <td class="odd">
                              <asp:Label ID="Label16" runat="server" Text="Country" Width="100px"></asp:Label>
                          </td>
                          <td class="odd">
                              <uc2:CtrlGridList ID="CtrlGrdCountry" runat="server" AccountType="Country" GridHeight="200" PlaceHoldr="Country" />
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label133" runat="server" Text="Category" Width="120px"></asp:Label>
                          </td>
                          <td align="left" class="odd">
                              <uc2:CtrlGridList ID="CtrlGrdCategory" runat="server" AccountType="CategoryList" GridHeight="150" PlaceHoldr="Category" />
                          </td>
                          <td class="odd">
                              <asp:Label ID="Label127" runat="server" Text="Place of Birth" Width="120px"></asp:Label>
                          </td>
                          <td class="odd">
                              <uc2:CtrlGridList ID="CtrlGrdPlace" runat="server" AccountType="PlaceofBirth" GridHeight="200" PlaceHoldr="Place of Birth" />
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label32" runat="server" Text="Blood Group" Width="120px"></asp:Label>
                          </td>
                          <td align="left" class="odd">
                              <asp:DropDownList ID="DdlBloodGrp" runat="server" SkinID="DdlBloodGroup">
                              </asp:DropDownList>
                          </td>
                          <td class="odd">
                              <asp:Label ID="Label35" runat="server" Text="Mother Language" Width="120px"></asp:Label>
                          </td>
                          <td class="odd">
                              <asp:DropDownList ID="DdlLanguage" runat="server" SkinID="DdlList">
                              </asp:DropDownList>
                          </td>
                      </tr>
                      <tr>
                          <td   class="odd">
                              <asp:Label ID="Label12" runat="server" Text="Remarks" Width="120px"></asp:Label>
                              <td class="odd">
                                  <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                              </td>
                              <td class="odd">
                                  <asp:CheckBox ID="ChkActive" runat="server" Checked="True" Font-Bold="False" SkinID="IsActive" Text="Active" />
                              </td>
                              <td class="odd">
                                  <asp:Label ID="LblScript" runat="server"></asp:Label>
                               </td>
                          </td>
                      </tr>
                      <tr>
                          <td align="center" class="FooterCommand" colspan="4" valign="middle">
                              <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="True" />
                          </td>
                      </tr>                      
                  </table>
              </ContentTemplate>
              
          </ajaxToolkit:TabPanel>
          <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
              <HeaderTemplate>Student List
              </HeaderTemplate>
              <ContentTemplate>
                  <table style="width: 100%; height: 0px;">
                      <tr >                         
                          <td style="height: 39px" class="odd">
                              <asp:Label ID="Label13" runat="server" Text="Student Name" Width="90px"></asp:Label>
                          </td>
                          <td style="height: 39px">
                              <asp:TextBox ID="TxtName_Srch" runat="server" placeholder="Student Name" SkinID="TxtSng200"></asp:TextBox>
                          </td>                          
                          <td style="height: 39px">
                              <asp:Label ID="Label137" runat="server" Text="Class" Width="50px"></asp:Label>
                          </td>
                          <td style="height: 39px">
                              <uc2:CtrlGridList ID="CtrlGrdClass_Srch" runat="server" AccountType="ClassList" PlaceHoldr="Class" />
                          </td>
                          <td style="height: 39px" class="odd">
                              <asp:Label ID="Label26" runat="server" Text="Adm. No" Width="70px"></asp:Label>
                          </td>
                          <td style="height: 39px">
                              <asp:TextBox ID="TxtAdmNo_Srch" runat="server" placeholder="Adm No. / Roll No" SkinID="TxtCode" style="left: -335px; top: 19px"></asp:TextBox>
                          </td>
                          <td style="height: 39px">
                          </td>
                      </tr>
                      <tr class="result-head">
                          <td class="odd" style="height: 39px">
                              <asp:Label ID="Label136" runat="server" Text="Adhar No." Width="100px"></asp:Label>
                          </td>
                          <td style="height: 39px">
                              <asp:TextBox ID="TxtAdhar_Srch" runat="server" placeholder="Adhar No." SkinID="TxtSng200"></asp:TextBox>
                          </td>
                          <td style="height: 39px">
                              <asp:Label ID="Label138" runat="server" Text="Division" Width="60px"></asp:Label>
                          </td>
                          <td style="height: 39px">
                              <uc2:CtrlGridList ID="CtrlGrdDiv_Srch" runat="server" AccountType="DivisionList" PlaceHoldr="Division" />
                          </td>
                           <td class="odd" style="height: 39px">
                              <asp:Label ID="Label135" runat="server" Text="Reg.No." Width="70px"></asp:Label>
                          </td>
                          <td style="height: 39px">
                              <asp:TextBox ID="TxtRegNo_Srch" runat="server" placeholder="Reg.No." SkinID="TxtCode"></asp:TextBox>
                          </td>
                          <td style="height: 39px"><asp:Button ID="BtnFind" runat="server" OnClick="ManiPulateDataEvent_Clicked" Text="Find" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" /></td>
                      </tr>
                      <tr>
                          <td colspan="8">
                              <div class="result-list" style="overflow: scroll; height: 480px; width:1005px">
                                  <asp:GridView ID="GrdVwRecords" runat="server" OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnRowDeleting="GrdVwRecords_RowDeleting"
                                      OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging" PageSize="25" SkinID="GrdVwMaster">
                                      <Columns>
                                          <asp:TemplateField HeaderText="Name">
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("DisplayName") %>' Width="300px"></asp:LinkButton>
                                                  <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("Id") %>' />
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Student Id">
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="LnkCode" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Code") %>' Width="120px"></asp:LinkButton>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Admission No">
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="LnkAdmissionNo" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("AdmissionNo") %>' Width="120px"></asp:LinkButton>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Student Code">
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="LnkStudentCode" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("StudentCode") %>' Width="120px"></asp:LinkButton>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Reg.No">
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="LnkRegNo" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("RegNo") %>' Width="150px"></asp:LinkButton>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Other Details">
                                              <ItemTemplate>
                                                  <asp:Button ID="BtnOther" runat="server" CommandName="DELETE" SkinID="BtnGrdEditGreen" Text='Other Details' Width="120px"></asp:Button>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Adm. Date">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblAdmDate" runat="server" SkinID="LblGrdMaster" Text='<%# FnGetDateString(Eval("JoinDate"))%>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Class">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblClassName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ClassName") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Division">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblDivision" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="DOB">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblDobDate" runat="server" SkinID="LblGrdMaster" Text='<%# FnGetDateString(Eval("Dob"))%>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Age">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblAge" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Age") %>' Width="50px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Sex">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblSex" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Sex") %>' Width="50px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Religion">
                                              <ItemTemplate>
                                                  <asp:Label ID="LbReligionName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ReligionName") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Community">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblCommunityName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("CommunityName") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Category">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblCategory" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("CategoryName") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="BloodGroup">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblBloodGroup" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("BloodGroup") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Nationality">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblNationalityName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("NationalityName") %>' Width="150px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="PlaceofBirth">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblPlaceofBirth" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("PlaceofBirth") %>' Width="150px"></asp:Label>
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
              <HeaderTemplate>Student Details
              </HeaderTemplate>
               <ContentTemplate>
                   <table style="width: 100%">
                       <tr class="result-head">
                           <td>
                               <asp:Label ID="Label139" runat="server" SkinID="LblBold" Text="Student Name" Width="120px"></asp:Label>
                           </td>
                           <td>
                               <asp:Label ID="LblStudentName" runat="server" SkinID="LblIdentifyLeft" Width="580px"></asp:Label>
                           </td>
                           <td>
                               <asp:Label ID="Label140" runat="server" SkinID="LblBold" Text="Student Id" Width="100px"></asp:Label>
                           </td>
                           <td>
                               <asp:Label ID="LblStudentId" runat="server" SkinID="LblIdentifyLeft" Width="200px"></asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td align="center" colspan="4" valign="middle">
                               </td>
                       </tr>
                       <tr>
                           <td align="center" colspan="4" valign="middle">
                               <table style="width: 57%">
                                   <tr>
                                       <td class="odd1">
                                           <asp:Label ID="Label141" runat="server" SkinID="LblBold" Text="Admission Details" Width="150px"></asp:Label>
                                       </td>
                                       <td class="odd2">
                                           <asp:Label ID="Label142" runat="server" SkinID="LblBold" Text="Education Details" Width="150px"></asp:Label>
                                       </td>
                                       <td class="odd3">
                                           <asp:Label ID="Label143" runat="server" SkinID="LblBold" Text="Hobbies &amp; Activities" Width="200px"></asp:Label>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td style="height: 20px">
                                           <img id="ImgStudent" runat="server" alt="Image"  class="ImageStyle" src="~/images/student_assistant.png" />
                                        &nbsp;&nbsp;</td>
                                       <td style="height: 20px">
                                           <img id="ImgEducation" runat="server" alt="Image" class="ImageStyle" src="~/images/StudentEducations.jpg" />
                                       &nbsp;&nbsp;</td>
                                       <td style="height: 20px">
                                           <img id="ImgHobby" runat="server" alt="Image" class="ImageStyle" src="~/images/StudentHobby.png" />
                                        &nbsp;&nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td class="odd2">
                                           <asp:Label ID="Label144" runat="server" SkinID="LblBold" Text="Sibling Details" Width="150px"></asp:Label>
                                       </td>
                                       <td class="odd3">
                                           <asp:Label ID="Label145" runat="server" SkinID="LblBold" Text="Address Details" Width="150px"></asp:Label>
                                       </td>
                                       <td class="odd1">
                                           <asp:Label ID="Label146" runat="server" SkinID="LblBold" Text="Fee Details" Width="150px"></asp:Label>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td>
                                           <img id="ImgSibling" runat="server" alt="Image" class="ImageStyle" src="~/images/StudentSibling.png"  />
                                       &nbsp;&nbsp;</td>
                                       <td>
                                           <img id="ImgAddress" runat="server" alt="Image" class="ImageStyle" src="~/images/HomeAddress.png" />
                                       &nbsp;&nbsp;</td>
                                       <td>
                                           <img id="ImgFee" runat="server" alt="Image" class="ImageStyle" src="~/images/StudentFee.png" />
                                       &nbsp;&nbsp;</td>
                                   </tr>
                               </table>
                           </td>
                       </tr>
                       <tr>
                           <td></td>
                           <td>
                               <asp:HiddenField ID="HdnId" runat="server" />
                           </td>
                           <td></td>
                           <td></td>
                       </tr>
                   </table>
               </ContentTemplate>
              
          </ajaxToolkit:TabPanel>
      </ajaxToolkit:TabContainer>
    </div>  
</asp:Content>

