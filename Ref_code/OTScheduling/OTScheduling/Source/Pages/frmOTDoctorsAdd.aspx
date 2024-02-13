<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmOTDoctorsAdd.aspx.vb" Inherits="OTScheduling.frmOTDoctorsAdd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OT DOCTORS</title>
   
    <link href="~/..\CSS\stylesheet.CSS" type="text/css" rel="stylesheet" />
    <link href="~/..\CSS\ButtonStyles.css" type="text/css" rel="stylesheet" />
    <link href="~/..\CSS\alertify.core.CSS" type="text/css" rel="stylesheet" />
    <link href="~/..\CSS\alertify.bootstrap.CSS" rel="stylesheet" type="text/css" />
    <link href="~/..\CSS\Master.CSS" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\jquery-1.10.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\alertify.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\alertify.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\validation.js"></script> 

   <%-- <link runat="server" rel="stylesheet" type="text/css" id="CssCommon" href="~/Css/stylesheet.css" />
    <link runat="server" rel="stylesheet" type="text/css" id="CssButton" href="" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssAlertify" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssAlertifyBoot" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/validation.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script> --%>

    <script type="text/javascript" language="javascript">
        function closewin() {
            if (document.getElementById("txtflag").value == "A") {
                window.close();
            }
        }
    </script>
</head>

<body onload="closewin();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress runat="server" ID="uProgess1" DynamicLayout="true" DisplayAfter="1">
            <ProgressTemplate>
                <img id="Img1" alt="" src="~/Images/animated.gif" runat="server" style="position: absolute; left: 298px; top: 126px; width: 39px; height: 27px;" />
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel runat="server" ID="UPOTDoc">
            <ContentTemplate>
                <asp:Panel ID="pnlOtDoc" runat="server" CssClass="panel" Style="margin: 0px; padding: 3px; height: 600px">
            <div class="divSearchHeader" style="padding: 4px; margin-top: 4px; text-align: center">
                <asp:Label runat="server" ID="lblDocHeading" Text=" DEFINE OT DOCTORS " CssClass="headerblue"></asp:Label>
            </div>

            <div class="divSearchHeader" style="padding: 4px; margin-top: 4px; height: 475px; text-align :center " >

                <table id="tblDoc1" runat="server" cellspacing="1" cellpadding="1" style="border-color: transparent; background-color: White; font-family: Calibri" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="" Text="OT DOCTORS" Font-Size="16px" Font-Bold="True"></asp:Label>
                           
                                <%--<asp:ImageButton ID="imgBtnOtDoc" runat="server" ImageUrl="~/Images/Search.ico" Width="16px" OnClientClick="javascript:Help(event,this,'txtOtDoc,txtOtDocName','DctNo','2','DoctorSearch.aspx','extra');return false;" />--%>

                                  <%--<asp:ImageButton ID="imageSearchDoc" runat="server" ImageUrl="~/Images/Search.ico" OnClientClick="javascript:Help(event,this,'txtdctid,txtdctname','DctNo','3','DoctorSearch.aspx','extra');return false;"
                                                Width="16px" ToolTip="Doctor Help" />--%>

                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Search.ico" Width="16px"  
                                         OnClientClick="javascript:HelpImg(event,this,'txtOtDoc,txtOtDocName','DctNo','2','frmHelpDoc.aspx','extra');return false;" />
                 
                            <asp:TextBox runat="server" ID="txtOtDoc" Text="" MaxLength="5" CssClass="textbox " TabIndex="2" Width="100px" 
                                AutoPostBack="True"   
                                onkeyup="javascript:Help(event,this,'txtOtDoc,txtOtDocName','DctNo','2','frmHelpDoc.aspx','extra');return false;"></asp:TextBox>

                            <asp:TextBox runat="server" ID="txtOtDocName" Text="" ReadOnly="true" CssClass="textbox " TabIndex="2" Width="380px"></asp:TextBox>

                            <asp:TextBox runat="server" ID="txtOtDocSpltyCd" Text="" Visible="false" MaxLength="5" CssClass="textbox " TabIndex="2" Width="100px" AutoPostBack="True"></asp:TextBox>

                            <asp:TextBox runat="server" ID="txtOtDocSpltyDesc" Text="" Visible="false" CssClass="textbox " TabIndex="2" Width="380px"></asp:TextBox>


                            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblsurgeontype" runat="server" Text="Surgeon Type"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlsurgntype" runat="server">
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                           <asp:Button ID="btnOtDocAdd" runat="server" CssClass="buttonstandard" Text="+" Width="40px" TabIndex="3" />
                        </td>


                    </tr>

                </table>

                <table>
                    <tr>
                        <td>
                            <asp:Panel runat ="server" ID="pnlfrd" class="panel" Height ="430px" Width ="1280px" >
                                 <asp:GridView runat="server" ID="grdOtDoc" AutoGenerateColumns="false" Width="100%" Height="100%" CssClass="gridrows" AlternatingRowStyle-CssClass="Alternategridrows" HeaderStyle-CssClass="gridcolumnheader" ShowHeaderWhenEmpty="true" GridLines="Horizontal" OnRowCommand="grdOtDoc_RowCommand"   >
                                    <RowStyle HorizontalAlign="Left" Height="10px" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="DOCTOR CODE" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Visible="true" ID="grdlblDocCd" Text='<% #Eval("DoctorCode")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DOCTOR NAME" Visible="True" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Visible="True" ID="grdlblDocName" Text='<% #Eval("DoctorFullName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="SPECIALTY" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Visible="true" ID="grdlblSpecDesc" Text='<% #Eval("SpecialityCodeDesc")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SPECIALTY CODE" Visible="false" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Visible="True" ID="grdlblSpecCd" Text='<% #Eval("SpecialityCode")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="SurgeonType" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Visible="true" ID="grdlbludtypeDcd" Text='<% #Eval("SurgnTypDcd")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SurgeonTypeCode" Visible="false" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Visible="True" ID="grdlbludtypeCd" Text='<% #Eval("SurgnTypCd")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                          <asp:TemplateField HeaderText="DELETE" Visible="True" HeaderStyle-HorizontalAlign="Left">
                                     <ItemTemplate>
                                         <asp:ImageButton ID="GrdImgBtnDel" runat="server" ImageUrl="~/Images/delete.gif"  CommandName="delete"
                                             ToolTip="Delete Row" />
                                     </ItemTemplate>
                                 </asp:TemplateField>


                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                           <%-- <div style="overflow-y: auto; width: 1308px; height: 440px; border: 3; border-color: black;" class="panel">
                               
                            </div>--%>
                        </td>
                    </tr>
                </table>
            </div>

            <div class="divSearchHeader" style="padding: 4px; margin-top: 4px;">
                <table id="tblDocAna" runat="server" cellspacing="1" cellpadding="1" style="border-color: transparent; background-color: White; font-family: Calibri" width="100%">
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblana" Text="ANESTHESIA TYPE :" Font-Bold="True" Font-Size="16px"> </asp:Label>
                            <asp:DropDownList runat="server" CssClass ="dropdownlist" ID="ddlOtDocAneshthsia" Width="300px"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="" Text="NURSE NAME" Font-Size="16px" Font-Bold="True"></asp:Label>
                            <asp:TextBox runat="server" ID="txtOtDocNurseName" Text="" MaxLength="50" CssClass="textbox " TabIndex="2" Width="700px"></asp:TextBox>
                        </td>

                    </tr>
                </table>
            </div>

            <div class="divSearchHeader" style="padding: 4px; margin-top: 4px; text-align: center">
                <table id="Table1" runat="server" cellspacing="1" cellpadding="1" style="border-color: transparent; background-color: White; font-family: Calibri" width="100%">
                    <tr>

                        <td style="text-align: right">&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnOtDocOk" runat="server" CssClass="buttonstandard" Text="OK" Width="100px" TabIndex="3" />
                            <asp:Button ID="btnOtDocExit" runat="server" CssClass="buttonstandard" Text="EXIT" Width="100px" TabIndex="4" Visible="False" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>

                <asp:HiddenField ID="ContentPlaceHolder1_HfAppMdCd" runat="server" />
                <asp:HiddenField ID="ContentPlaceHolder1_HfAppSubMdCd" runat="server" />

                <input id="txtflag" runat="server" enableviewstate="true" type="text" style="visibility: hidden" />
            </ContentTemplate>
        </asp:UpdatePanel> 
    </form>
    <script language="javascript" type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    load();
                }
            });
        };

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(load);
            load();
        });

        function load() {
            hover_row("<%=grdOtDoc.ClientID%>");
        }
    </script>
</body>

</html>
