<%@ Page Language="VB" AutoEventWireup="false" Inherits="OTScheduling.Pages_OTHelp" Codebehind="OTHelp.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OT SEARCH</title>
   
    <link href="~\..\CSS\stylesheet.CSS" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\ButtonStyles.css" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\alertify.core.CSS" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\alertify.bootstrap.CSS" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\jquery-1.10.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\alertify.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\alertify.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\validation.js"></script>
    <link href="~\..\CSS\Master.CSS" rel="stylesheet" type="text/css" />

    <%--<link href="" rel="stylesheet" type="text/css" id="cssMaster" />
    <link runat="server" rel="stylesheet" type="text/css" id="CssCommon" href="" />
    <link runat="server" rel="stylesheet" type="text/css" id="CssButton" href="" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssAlertify" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssAlertifyBoot" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/validation.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script>--%>

    <script type="text/javascript">

        $(document).ready(function () {
            $("#<%=GrdOTDetails.ClientID%> tr:has(td)").hover(function (e) {
                $(this).css("cursor", "pointer");
            });
            $("#<%=GrdOTDetails.ClientID%> tr:has(td)").click(function (e) {
                var OTNO = $(this).find("td:eq(0)").text().toLowerCase().trim();
                $("#<%=GrdOTDetails.ClientID%> td").removeClass("selected");
                    var MyArgs = new Array(OTNO);
                    ReturnValues(MyArgs, document.getElementById("str"), document.getElementById("cntrl"), '');
                    //window.returnValue = MyArgs;
                    //window.close();
                });
        })

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


     <script type="text/javascript">
         $(document).ready(function () {
             $('#<%=btnSearch.ClientID%>').click(function (e) {
                $("#<%=GrdOTDetails.ClientID%> tr:has(td)").hide(); // Hide all the rows.
                var iCounter = 0;
                $("#lblNoOfRecords").text(iCounter);
                var sSearchtxtCriteria = $('#<%=txtCriteria.ClientID%>').val(); //Get the search box value
                var sSearchCondition = $('#ddlConditions').find('option').filter(':selected').val();
                $("#<%=GrdOTDetails.ClientID%> tr:has(td)").each(function () {
                   if (sSearchCondition == "1" && sSearchtxtCriteria != "") {
                       var celltxtCriteria = $(this).find("td:eq(1)").text().toLowerCase().trim();
                   }
                   else if (sSearchCondition == "2" && sSearchtxtCriteria != "") {
                       var celltxtCriteria = $(this).find("td:eq(0)").text().toLowerCase().trim();
                   }
                   else {
                       var celltxtCriteria = ""
                       $("#lblNoOfRecords").text("");
                   }
                   if ((sSearchtxtCriteria.length != 0)) {
                       if (celltxtCriteria.indexOf(sSearchtxtCriteria.toLowerCase()) >= 0) {
                           $(this).show();
                           iCounter++;
                           $("#lblNoOfRecords").text(iCounter);
                           return true;
                       }
                   }
                   else if ((celltxtCriteria == "")) {
                       $(this).show();
                       iCounter++;
                       $("#lblNoOfRecords").text(iCounter);
                       return true;
                   }
               });
               if (iCounter == 0) {
                   $('#<%=lblNoOfRecords.ClientID%>').css('display', '');
                }
                e.preventDefault();
            })
        })
    </script>



</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

        <input type="hidden" id="str" name="str" value="<%=request("frmname")%>" />
        <input type="hidden" id="cntrl" name="cntrl" value="<%=request("control")%>" />
        <table id="Table1" runat="server" class="Help1MainPanel">
            <tr>
                <td>
                    <asp:Panel ID="Panel6" runat="server" CssClass="Help1SearchPanel">
                        <table>
                            <tr>
                                <td class="Help1HeaderAlign">
                                    <asp:Label runat="server" ID="lblFrstName0"
                                        Text="OT HELP"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCriteria" runat="server" Width="230px" ToolTip="" CssClass="textbox"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlConditions" Width="250px" AutoPostBack="false"
                                        ToolTip="Select Searching Criteria">
                                        <asp:ListItem Value="1">OT Name</asp:ListItem>
                                        <asp:ListItem Value="2">OT NO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="SEARCH" Width="100px" CssClass="buttonstandard"
                                        Height="25px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblRecords" Text="NO OF RECORDS" CssClass="label" Visible="true"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Label runat="server" ID="lblNoOfRecords" CssClass="HelpNoOfRecords" Width="25px" Visible="true"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" CssClass="Help1GridPanel">
                        <asp:GridView ID="GrdOTDetails" runat="server" AllowSorting="True" AutoGenerateColumns="False" GridLines="horizontal" CssClass="Help1rows">
                            <Columns>
                                <asp:TemplateField HeaderText="FCT CODE" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblFctCd" Text='<%#Eval("Code")%>' Width="60px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FCT NAME" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblFctNm" Text='<%#Eval("Decode")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="Help1headerStyle" ForeColor="White" />
                            <RowStyle CssClass="Help1rowStyle" />
                            <AlternatingRowStyle CssClass="Help1alternatingRowStyle" />
                            <FooterStyle CssClass="Help1footerStyle" />
                            <PagerStyle CssClass="Help1pagerStyle" ForeColor="White" />
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
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
            hover_row("<%=GrdOTDetails.ClientID%>");
        }
    </script>
</body>
</html>
