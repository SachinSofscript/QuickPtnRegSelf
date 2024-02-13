<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmOTEmpAdd.aspx.vb" Inherits="OTScheduling.frmOTEmpAdd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OT EMPLOYESS DETAILS</title>

    <link href="~\..\CSS\stylesheet.CSS" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\ButtonStyles.css" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\alertify.core.CSS" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\alertify.bootstrap.CSS" rel="stylesheet" type="text/css" />
    <link href="~\..\CSS\Master.CSS" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\jquery-1.10.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\alertify.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\alertify.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\validation.js"></script> 

  <%--  <link runat="server" rel="stylesheet" type="text/css" id="CssCommon" href="~/Css/stylesheet.css" />
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
        <asp:UpdatePanel runat="server" ID="UPOTEmp">
            <ContentTemplate>
                <asp:Panel ID="pnlOtDoc" runat="server" CssClass="panel" Style="margin: 0px; padding: 3px; height: 600px">
                    <div class="divSearchHeader" style="padding: 4px; margin-top: 4px; text-align: center">
                        <asp:Label runat="server" ID="lblDocHeading" Text=" DEFINE OT EMPLOYEES " CssClass="headerblue"></asp:Label>
                    </div>

                    <div class="divSearchHeader" style="padding: 4px; margin-top: 4px; height: 520px; text-align: center">
                        <table id="tblDoc1" runat="server" cellspacing="1" cellpadding="1" style="border-color: transparent; background-color: White; font-family: Calibri" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" CssClass="" Text="OT EMPLOYEE ID" Font-Size="16px" Font-Bold="false"></asp:Label>
                                  <asp:ImageButton ID="ImgBtnEmployee" runat="server" ImageUrl="~/Images/Search.ico"
                        OnClientClick="javascript:HelpImg(event,this,'txtEmpNo,ContentPlaceHolder1_HfEmpCd','txtEmpNo,txtEmpNo','1','frmOTEmpHelp.aspx','extra');" Width="16px"  />

                                   <%--  OnClientClick="javascript:Help(event,this,'txtOtSrvCd,ContentPlaceHolder1_HfSrvCd,ContentPlaceHolder1_HfSrvDcd,ContentPlaceHolder1_HfChrgCd,ContentPlaceHolder1_HfChrgDcd','srvcd,srvcd,srvDcd,chrgcd,chrgDcd','2','frmOtServicesHelp.aspx','extra');" --%>

                                    <asp:TextBox ID="txtEmpNo" runat="server" CssClass="textbox" ForeColor="Black" onkeypress="ValidateNum(this);" AutoPostBack ="true"
                                        onkeyup="javascript:Help(event,this,'txtEmpNo,ContentPlaceHolder1_HfEmpCd','txtEmpNo,txtEmpNo','1','frmOTEmpHelp.aspx','extra');" MaxLength="10" ToolTip="Enter Employee No."
                                        Width="100px" Enabled="true"></asp:TextBox>
                                    <asp:TextBox ID="txtEmpDesc" runat="server" CssClass="textbox" ForeColor="Black" Enabled="true"
                                        ReadOnly="true" Width="300px"></asp:TextBox>

                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnAddEmp" runat="server" CssClass="buttonstandard" Text="+" Width="40px" TabIndex="3" />
                                    <asp:Button ID="btnDelEmp" runat="server" CssClass="buttonstandard" Visible="false" Text="-" Width="30px" TabIndex="4" />
                                </td>
                            </tr>


                        </table>

                        <table>
                            <tr>
                                <td>
                                    <asp:Panel runat="server" ID="pnlfrd" class="panel" Height="470px" Width="1290px" ScrollBars ="Vertical" >
                                        <asp:GridView runat="server" ID="grdEmp" AutoGenerateColumns="false" Width="100%" Height="100%" CssClass="gridrows" AlternatingRowStyle-CssClass="Alternategridrows" HeaderStyle-CssClass="gridcolumnheader" ShowHeaderWhenEmpty="true" GridLines="Horizontal">
                                            <RowStyle HorizontalAlign="Left" Height="10px" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="EMPLOYEE ID" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Visible="true" ID="grdlblEmpId" Text='<% #Eval("EmpCd")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="EMPLOYEE NAME" Visible="True" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Visible="True" ID="grdlblEmpName" Text='<% #Eval("EmpName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="DELETE" Visible="True" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="GrdImgBtnDel" runat="server" ImageUrl="~/Images/delete.gif" CommandName="delete"
                                                            ToolTip="Delete Row" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                      
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>


                    <div class="divSearchHeader" style="padding: 4px; margin-top: 4px; text-align: center">
                        <table id="Table1" runat="server" cellspacing="1" cellpadding="1" style="border-color: transparent; background-color: White; font-family: Calibri" width="100%">
                            <tr>
                                <td style="text-align: right">&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnOtEmpvOk" runat="server" CssClass="buttonstandard" Text="OK" Width="100px" TabIndex="3" />
                                    <asp:Button ID="btnOtEmpExit" runat="server" CssClass="buttonstandard" Text="BACK" Width="100px" TabIndex="4" Visible="False" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>

                <asp:HiddenField ID="ContentPlaceHolder1_HfAppMdCd" runat="server" />
                <asp:HiddenField ID="ContentPlaceHolder1_HfAppSubMdCd" runat="server" />
                <asp:HiddenField ID="ContentPlaceHolder1_HfEmpCd" runat="server" />
             
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
            hover_row("<%=grdEmp.ClientID%>");
        }
    </script>
</body>

</html>
