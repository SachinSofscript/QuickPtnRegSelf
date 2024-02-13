<%@ Page Language="VB" AutoEventWireup="false" Inherits="OTScheduling.Pages_PatientSearch" CodeBehind="PatientSearch.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PATIENT HELP</title>

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

    <script type="text/javascript" language="javascript" charset="4">
        function handleEnter(field, event) {
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 13) {
                var i;
                for (i = 0; i < field.form.elements.length; i++)
                    if (field == field.form.elements[i])
                        break;
                i = (i + 1) % field.form.elements.length;
                field.form.elements[i].focus();
                return false;
            }
            else
                return true;
        }
    </script>
    <%--    <script language="javascript" type="text/javascript">
              $(document).ready(function () {
                  $("#<%=dgvptn.ClientID%> tr:has(td)").hover(function (e) {
                      $(this).css("cursor", "pointer");
                  });

                  $("#<%=dgvptn.ClientID%> tr:has(td)").click(function (e) {
                      if ("1" == "1") {
                          var code = $(this).find("td:eq(0)").text().trim();
                          // var decode = $(this).find("td:eq(1)").text().trim();
                          var MyArgs = new Array(code);
                          ReturnValues(MyArgs, document.getElementById("str"), document.getElementById("cntrl"));
                          //window.returnValue = MyArgs;
                          //window.close();
                      }
                  });
              })
    </script>--%>

    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(load);
            load();
        });
        function load() {
            hover_row("<%=dgvptn.ClientID%>");

            $("#<%=dgvptn.ClientID%> tr:has(td)").hover(function (e) {
                $(this).css("cursor", "pointer");
            });

            $("#<%=dgvptn.ClientID%> tr:has(td)").click(function (e) {
                if ("1" == "1") {
                    var code = $(this).find("td:eq(1)").text().trim();
                    // var decode = $(this).find("td:eq(1)").text().trim();
                    var MyArgs = new Array(code);
                    ReturnValues(MyArgs, document.getElementById("str"), document.getElementById("cntrl"));
                    //window.returnValue = MyArgs;
                    //window.close();
                }
            });
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress runat="server" ID="uProgess1" DynamicLayout="true" DisplayAfter="1">
            <ProgressTemplate>
                <img id="Img1" alt="" src="~/Images/animated.gif" runat="server" style="position: absolute; left: 498px; top: 126px; width: 39px; height: 27px;" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel2" runat="server">
                    <table id="Table1" runat="server" class="Help3MainPanel" style="width: 1270px">
                        <tr>
                            <td>
                                <asp:Panel ID="Panel1" runat="server" CssClass="Help3SearchPanel">
                                    <table border="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblHeader0" runat="server" CssClass="headerblue" Text="PATIENT SEARCH"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                             <td>&nbsp;</td>
                                            <td rowspan="3" style="vertical-align: bottom">
                                                <asp:Button ID="btnSearch" runat="server" CssClass="buttonstandard"
                                                    Height="30px" Text="SEARCH" Width="93px" />
                                                &nbsp;
                                            </td>
                                            <td>
                                                <input id="str" name="str" type="hidden" value='<%=request("frmname")%>' />
                                                <input id="cntrl" name="cntrl" type="hidden" value='<%=request("control")%>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblLastName" runat="server" CssClass="label" Text="LAST NAME"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFrstName" runat="server" CssClass="label" Text="FIRST NAME"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMidName" runat="server" CssClass="label" Text="MIDDLE NAME"></asp:Label>
                                            </td>

                                             <td>
                                                <asp:Label ID="lblFathersName" runat="server" CssClass="label" Text="FATHER'S NAME"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPhoneNum" runat="server" CssClass="label" Text="PHONE NUMBER"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAdharNo" runat="server" CssClass="label" Text="AADHAR NUMBER"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPanNo" runat="server" CssClass="label" Text="PAN NUMBER"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAddress" runat="server" CssClass="label" Text="ADDRESS"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:TextBox runat="server" ID="txtPatnLastName" Width="110px" CssClass="textbox" ToolTip="Enter Last Name"
                                                    onkeypress="ValidateAlpha(this)" onkeydown="return handleEnter(this, event)"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td valign="top">
                                                <asp:TextBox runat="server" ID="txtPatnFirstName" Width="110px" CssClass="textbox" ToolTip="Enter First Name"
                                                    onkeypress="ValidateAlpha(this)" onkeydown="return handleEnter(this, event)"></asp:TextBox>&nbsp;&nbsp;
                                            </td>
                                            <td valign="top">
                                                <asp:TextBox runat="server" ID="txtPatnMidName" Width="110px" CssClass="textbox" ToolTip="Enter Middle Name"
                                                    onkeypress="ValidateAlpha(this)" onkeydown="return handleEnter(this, event)"></asp:TextBox>&nbsp;&nbsp;
                                            </td>
                                            <td valign="top">
                                                <asp:TextBox runat="server" ID="txtPatFathersName" Width="110px" CssClass="textbox" ToolTip="Enter Father's Name"
                                                    onkeypress="ValidateAlpha(this)" onkeydown="return handleEnter(this, event)"></asp:TextBox>&nbsp;&nbsp;
                                            </td>

                                            <td valign="top">
                                                <asp:TextBox runat="server" ID="txtPhoneNum" Width="100px" CssClass="textbox" onkeypress="ValidateNum(this)"
                                                    onkeydown="return handleEnter(this, event)"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td valign="top">
                                                <asp:TextBox runat="server" ID="txtAadharNo" Width="100px" CssClass="textbox" MaxLength="12" onkeypress="ValidateNum(this)"
                                                    onkeydown="return handleEnter(this, event)"></asp:TextBox>&nbsp;&nbsp;
                                            </td>
                                            <td valign="top">
                                                <asp:TextBox runat="server" ID="txtPanNo" Width="94px" CssClass="textbox" MaxLength="10"
                                                    onkeydown="return handleEnter(this, event)"></asp:TextBox>&nbsp;&nbsp;
                                            </td>
                                            <td valign="top">
                                                <asp:TextBox runat="server" ID="txtAddress" Width="310px" CssClass="textbox"
                                                    onkeydown="return handleEnter(this, event)"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr>
                                            <%--<td colspan="6" style="height: 5px;"></td>--%>
                                            <td>
                                                <asp:Label ID="lblNumOfRecrds0" runat="server" CssClass="label"
                                                    Text="NUMBER OF RECORDS: "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNoOfRecords" runat="server" CssClass="HelpNoOfRecords">0</asp:Label>
                                            </td>
                                        </tr>

                                        <tr>

                                            <td colspan="6">
                                                <asp:Panel runat="server">
                                                    <table>
                                                        <tr>
                                                            <td align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Repeater ID="rptPager" runat="server">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkPage" runat="server" CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' Font-Bold="true" Font-Size="Small" OnClick="Page_Changed" Text='<%#Eval("Text") %>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                                &nbsp;
                                                                    <asp:Label ID="lblname" runat="server" CssClass="label" Font-Bold="true"></asp:Label>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </asp:Panel>


                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="PnlSrchResult" runat="server" ScrollBars="Both" CssClass="Help3GridPanel">
                                    <asp:GridView ID="dgvptn" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="Help3rows" Visible="False" GridLines="Horizontal">
                                        <Columns>
                                            <asp:TemplateField HeaderText="PATIENT FULL NAME" ItemStyle-Width="300px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPtntFullName" runat="server" Text='<%#Eval ("PatientFullName")%>' CssClass="labelOverFlowWrap"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PATIENT NO" ItemStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPtnNo" runat="server" Text='<%#Eval ("PatientNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPtnTtl" runat="server" Text='<%#Eval ("PatientTitleCodeDesc")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPtnFirstName" runat="server" Text='<%#Eval ("PatientFirstName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPtnMidName" runat="server" Text='<%#Eval ("PatientMiddleName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPtntLstName" runat="server" Text='<%#Eval ("PatientLastName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="MOBILE NO" ItemStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobileNum" runat="server" Text='<%#Eval("MobileNumber")%>'></asp:Label>
                                                    <%----%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="GENDER" ItemStyle-Width="40px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsex" runat="server" Text='<%#Eval ("Gender") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="AGE" ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAge" runat="server" Text='<%#Eval ("Age") %>'></asp:Label>
                                                    <%-- '<%#  Bind("BirthDate","{0:dd/MM/yyyy}") %>'--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button runat="server" ID="btnSelect" CommandName="Select" Text="SELECT" CssClass="buttonstandard" Height="25px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="ADHAR NO" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAdhar" runat="server" Text='<%#Eval ("AdharNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PAN NO" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPan" runat="server" Text='<%#Eval ("PanNO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ADDRESS" ItemStyle-Width="350px" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <HeaderStyle CssClass="Help3headerStyle" ForeColor="White" />
                                        <RowStyle CssClass="Help3rowStyle" />
                                        <AlternatingRowStyle CssClass="Help3alternatingRowStyle" />
                                        <FooterStyle CssClass="Help3footerStyle" />
                                        <PagerStyle CssClass="Help3pagerStyle" ForeColor="White" />
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <input type="button" id="btnback" onclick="javascript: window.close();" value="BACK" class="buttonstandard" ToolTip="Press ALT + B" AccessKey="B" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <script language="javascript" type="text/javascript">
            function closewindow() {
                window.close();
            }
        </script>
    </form>
</body>
</html>
