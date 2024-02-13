<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmOTServicesAdd.aspx.vb" Inherits="OTScheduling.frmOTServicesAdd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OT SERVICES</title>


    <link rel="stylesheet" type="text/css" href="<%=ConfigurationManager.AppSettings("CSS_serverpath") + "/Master.css" %>" />
    <link rel="stylesheet" type="text/css" href="<%=ConfigurationManager.AppSettings("CSS_serverpath") + "/stylesheet.css" %>" />
    <link rel="stylesheet" type="text/css" href="<%=ConfigurationManager.AppSettings("CSS_serverpath") + "/ButtonStyles.css" %>" />
    <link rel="stylesheet" type="text/css" href="<%=ConfigurationManager.AppSettings("CSS_serverpath") + "/alertify.core.css" %>" />
    <link rel="stylesheet" type="text/css" href="<%=ConfigurationManager.AppSettings("CSS_serverpath") + "/alertify.bootstrap.css" %>" />
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings("Script_serverpath") + "/jquery-1.10.2.min.js" %>"></script>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings("Script_serverpath") + "/alertify.min.js" %>"></script>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings("Script_serverpath") + "/alertify.js" %>"></script>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings("Script_serverpath") + "/validation.js" %>"></script>
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings("Script_serverpath") + "/jquery.min.js" %>"></script>
    
    
    <link rel="stylesheet" type="text/css" href="<%=ConfigurationManager.AppSettings("CSS_serverpath") + "/CSS/ui-lightness/jquery-ui -1.12.1.css" %>" />
    <script type="text/javascript" src="<%=ConfigurationManager.AppSettings("Script_serverpath") + "/jquery-ui-1.12.1.min.js" %>"></script>

  <%--  <link href="~\..\CSS\stylesheet.CSS" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\ButtonStyles.css" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\alertify.core.CSS" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\alertify.bootstrap.CSS" rel="stylesheet" type="text/css" />
    <link href="~\..\CSS\Master.CSS" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\jquery-1.10.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\alertify.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\alertify.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\validation.js"></script> --%>

    <%--<link runat="server" rel="stylesheet" type="text/css" id="CssCommon" href="~/Css/stylesheet.css" />
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
        <asp:UpdatePanel runat="server" ID="UPOTServices"  >
            <ContentTemplate>

             


                <asp:Panel ID="pnlOtDoc" runat="server" CssClass="panel" Style="margin: 0px; padding: 3px; height: 600px">
                    <div class="divSearchHeader" style="padding: 4px; margin-top: 4px; text-align: center">
                        <asp:Label runat="server" ID="lblDocHeading" Text=" DEFINE OT SERVICES " CssClass="headerblue"></asp:Label>
                    </div>

                    <div class="divSearchHeader" style="padding: 4px; margin-top: 4px; height: 485px; text-align: center">
                        <table id="tblDoc1" runat="server" cellspacing="1" cellpadding="1" style="border-color: transparent; background-color: White; font-family: Calibri" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" CssClass="" Text="OT SERVICES" Font-Size="16px" Font-Bold="false"></asp:Label>
                                    <asp:ImageButton ID="imgtodoc" runat="server" ImageUrl="~/Images/Search.ico"
                                        OnClientClick="javascript:HelpImg(event,this,'txtOtSrvCd,ContentPlaceHolder1_HfSrvCd,ContentPlaceHolder1_HfSrvDcd,ContentPlaceHolder1_HfChrgCd,ContentPlaceHolder1_HfChrgDcd,ContentPlaceHolder1_HfSrvTypCd,ContentPlaceHolder1_HfSrvTypDcd','srvcd,srvcd,srvDcd,chrgcd,chrgDcd,SrvTypCd,SrvTypDcd','2','frmOtServicesHelp.aspx','extra');return false;" 
                                        Width="16px" ToolTip="OT SERVICES Help" />
                                    <%--     <asp:HiddenField ID="ContentPlaceHolder1_HfSrvCd" runat="server" />
                                                <asp:HiddenField ID="ContentPlaceHolder1_HfSrvDcd" runat="server" />
                                                <asp:HiddenField ID="ContentPlaceHolder1_HfChrgCd" runat="server" />
                                                <asp:HiddenField ID="ContentPlaceHolder1_HfChrgDcd" runat="server" />--%>

                                    <asp:TextBox runat="server" ID="txtOtSrvCd" Text="" MaxLength="5" CssClass="textbox " TabIndex="2" 
                                        Width="70px" AutoPostBack="True"
                                        onkeyup="javascript:Help(event,this,'txtOtSrvCd,ContentPlaceHolder1_HfSrvCd,ContentPlaceHolder1_HfSrvDcd,ContentPlaceHolder1_HfChrgCd,ContentPlaceHolder1_HfChrgDcd,ContentPlaceHolder1_HfSrvTypCd,ContentPlaceHolder1_HfSrvTypDcd','srvcd,srvcd,srvDcd,chrgcd,chrgDcd,SrvTypCd,SrvTypDcd','2','frmOtServicesHelp.aspx','extra');return false;"></asp:TextBox>
                                    <%--   onkeyup="javascript:Help(event,this,'txtOtSrvCd,txtOtSrvDesc,txtOtChrgCd','srvcd,srvDcd,chrgcd','2','frmOtServicesHelp.aspx','extra');return false;"></asp:TextBox>--%>
                                    <%--  onkeyup="javascript:Help(event,this,'txtOtSrvCd,txtOtSrvDesc,txtOtChrgCd,txtOtChrgDesc','srvcd,srvDcd,chrgcd,chrgDcd','2','frmOtServicesHelp.aspx','extra');return false;"></asp:TextBox>--%>

                                    <asp:TextBox runat="server" ID="txtOtSrvDesc" Text="" ReadOnly="true" CssClass="textbox " TabIndex="2" Width="270px"></asp:TextBox>
                                    <asp:Label ID="Label1" runat="server" CssClass="" Text="CHARGE CODE" Font-Size="16px" Font-Bold="false"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtOtChrgCd"  ReadOnly ="true"  Text="" MaxLength="5" CssClass="textbox " TabIndex="2" Width="70px"></asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtOtChrgDesc" ReadOnly="true" Text="" CssClass="textbox " TabIndex="2" Width="270px"></asp:TextBox>
                                    <asp:Label ID="lblAddInfo" runat="server" CssClass="" Text="ADDITIONAL INFO" Font-Size="16px" Font-Bold="false"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlAddtnInfo" Width="200px" CssClass ="dropdownlist" ></asp:DropDownList>
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnAddSrv" runat="server" CssClass="buttonstandard" Text="+" Width="40px" TabIndex="3" />
                                    <asp:Button ID="btnDelSrv" runat="server" CssClass="buttonstandard" Visible="false" Text="-" Width="30px" TabIndex="4" />
                                </td>
                            </tr>


                        </table>

                        <table>
                            <tr>
                                <td>
                                    <asp:Panel runat="server" ID="pnlfrd" class="panel" Height="440px" Width="1290px">
                                        <asp:GridView runat="server" ID="grdSrv" AutoGenerateColumns="false" Width="100%" Height="100%" CssClass="gridrows" AlternatingRowStyle-CssClass="Alternategridrows" HeaderStyle-CssClass="gridcolumnheader" ShowHeaderWhenEmpty="true" GridLines="Horizontal">
                                            <RowStyle HorizontalAlign="Left" Height="10px" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SERVICE DESC" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Visible="true" ID="grdlblSrvDesc" Text='<% #Eval("srvdesc")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SERVICE CODE" Visible="True" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Visible="True" ID="grdlblSrvCd" Text='<% #Eval("srvcd")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="CHARGE DESC" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Visible="true" ID="grdlblChrgDesc" Text='<% #Eval("ChrgDesc")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CHARGE CODE" Visible="True" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Visible="True" ID="grdlblChrgCd" Text='<% #Eval("chrgcd")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="SERVICE TYPE" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Visible="true" ID="grdlblSurgTypDesc" Text='<% #Eval("SrvTypDesc")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Surgery Type CODE" Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Visible="false" ID="grdlblSurgTypCd" Text='<% #Eval("SrvTypCd")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ADDITIONAL INFO" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Visible="true" ID="grdlblAdditionName" Text='<% #Eval("AnesTypDesc")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ADDITIONAL code" Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Visible="false" ID="grdlblAdditioncd" Text='<% #Eval("AnesTypCd")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="RATE" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Visible="true" ID="grdlblRate" Text='<% #Eval("SrvRate")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="DELETE" Visible="True" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="GrdImgBtnDel" runat="server" ImageUrl="~/Images/delete.gif" CommandName="deleteROW"
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

                    <div class="divSearchHeader" style="padding: 4px; margin-top: 4px; ">
                        <table id="tblDocAna" runat="server" cellspacing="1" cellpadding="1" style="border-color: transparent; background-color: White; font-family: Calibri" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblDiag" runat="server" CssClass="" Text="DIAGNOSIS" Font-Size="16px" Font-Bold="True"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtSrvDiagnosis" Text="" MaxLength="60" CssClass="textbox " TabIndex="2" Width="1230px"></asp:TextBox>
                                </td>

                            </tr>
                        </table>
                    </div>

                    <div class="divSearchHeader" style="padding: 4px; margin-top: 4px; text-align: center">
                        <table id="Table1" runat="server" cellspacing="1" cellpadding="1" style="border-color: transparent; background-color: White; font-family: Calibri" width="100%">
                            <tr>
                                <td style="text-align: right">&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnOtSrvOk" runat="server" CssClass="buttonstandard" Text="OK" Width="100px" TabIndex="3" />
                                    <asp:Button ID="btnOtSrvExit" runat="server" CssClass="buttonstandard" Text="EXIT" Width="100px" TabIndex="4" Visible="False" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>

                <asp:HiddenField ID="ContentPlaceHolder1_HfAppMdCd" runat="server" />
                <asp:HiddenField ID="ContentPlaceHolder1_HfAppSubMdCd" runat="server" />
                <asp:HiddenField ID="ContentPlaceHolder1_HfSrvCd" runat="server" />
                <asp:HiddenField ID="ContentPlaceHolder1_HfSrvDcd" runat="server" />
                <asp:HiddenField ID="ContentPlaceHolder1_HfChrgCd" runat="server" />
                <asp:HiddenField ID="ContentPlaceHolder1_HfChrgDcd" runat="server" />
                <asp:HiddenField ID="ContentPlaceHolder1_HfSrvTypCd" runat="server" />
                <asp:HiddenField ID="ContentPlaceHolder1_HfSrvTypDcd" runat="server" />

                                   <input type="hidden" id="str" name="str" value="<%=request("frmname")%>" />
                <input type="hidden" id="cntrl" name="cntrl" value="<%=request("control")%>" />
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
            hover_row("<%=grdSrv.ClientID%>");
        }
    </script>
</body>

</html>

