<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CreditCompHelp.aspx.vb" Inherits="OTScheduling.CreditCompHelp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CHARGE MASTER HELP</title>

        <link href="~\..\CSS\stylesheet.CSS" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\ButtonStyles.CSS" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\alertify.core.CSS" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\alertify.bootstrap.CSS" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\jquery-1.10.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\alertify.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\alertify.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\validation.js"></script>

    <%--<link runat="server" rel="stylesheet" type="text/css" id="CssCommon" href="~/Css/stylesheet.css" />
    <link runat="server" rel="stylesheet" type="text/css" id="CssButton" href="" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssAlertify" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssAlertifyBoot" />
    <script type="text/javascript" id="js2" src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/validation.js"></script>--%>

    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            $("#<%=gddetails.ClientID%> tr:has(td)").hover(function (e) {
                $(this).css("cursor", "pointer");
            });

           <%-- $("#<%=btnSelect.ClientID%>").click(function (e)
            {
               var grd = $("#<%=gddetails.ClientID %>");
                for (var i=0; i < grd.rows.length ; i++) {
                    var chk = grd.rows[i].cells[2];
                    if (chk.checked) {
                        var code = $(this).find("td:eq(0)").text().trim();
                        var decode = $(this).find("td:eq(1)").text().trim();
                        var MyArgs = new Array(code, decode);
                        var dlist=[];
                        dlist.push({ Decode: decode, Code: code });
                        ReturnValues(dlist, document.getElementById("str"), document.getElementById("cntrl"));
                    }
                }
            });--%>


            $("#<%=gddetails.ClientID%> tr:has(td)").click(function (e) {
                if ("1" == "1") {
                    var code = $(this).find("td:eq(0)").text().trim();
                    var decode = $(this).find("td:eq(1)").text().trim();
                    var MyArgs = new Array(code, decode);
                    ReturnValues(MyArgs, document.getElementById("str"), document.getElementById("cntrl"));
                    //window.returnValue = MyArgs;
                    //window.close();
                }

            });
        })


    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=btnSearch.ClientID%>').click(function (e) {
                $("#<%=gddetails.ClientID%> tr:has(td)").hide(); // Hide all the rows.
                var iCounter = 0;
                $("#lblNoOfRecords").text(iCounter);
                var sSearchtxtCriteria = $('#<%=txtCriteria.ClientID%>').val(); //Get the search box value
                var sSearchCondition = $('#ddlConditions').find('option').filter(':selected').val();


                //Iterate through all the td.
                $("#<%=gddetails.ClientID%> tr:has(td)").each(function () {

                    if (sSearchCondition == "1" && sSearchtxtCriteria != "") {
                        var celltxtCriteria = $(this).find("td:eq(1)").text().toLowerCase().trim();
                    }
                    else if (sSearchCondition == "2" && sSearchtxtCriteria != "") {
                        var celltxtCriteria = $(this).find("td:eq(0)").text().toLowerCase().trim();
                    }
                    else {

                        var celltxtCriteria = ""

                        //     document.getElementById("<%=txtCriteria.ClientID%>").value = ""
                        $("#lblNoOfRecords").text("");

                    }


                    if ((sSearchtxtCriteria.length != 0)) {

                        if (celltxtCriteria.indexOf(sSearchtxtCriteria.toLowerCase()) >= 0) {
                            // alert(1);
                            $(this).show();
                            iCounter++;
                            $("#lblNoOfRecords").text(iCounter);
                            return true;
                        }


                    }
                    else if ((celltxtCriteria == "")) {
                        // alert(2);
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
    <script type="text/javascript">
        function Check_Click(ObjRef) {
            var row = ObjRef.parentNode.parentNode;
            if (ObjRef.checked) {
                <%-- var arrayobjIcd = new Array();
                var values = document.getElementById("<%=txtsearch.ClientID%>").value
                arrayobjIcd.push(values)--%>
                document.getElementById("ContentPlaceHolder1_btnSelIcdGroup").click();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <input type="hidden" id="str" name="str" value="<%=request("frmname")%>" />
        <input type="hidden" id="cntrl" name="cntrl" value="<%=request("control")%>" />
        <asp:Panel ID="Panel2" runat="server">
            <table id="Table1" runat="server" class="Help1MainPanel">
                <tr>
                    <td>
                        <asp:Panel ID="Panel3" runat="server" CssClass="Help1SearchPanel">
                            <table>
                                <tr>
                                    <td colspan="3" class="Help1HeaderAlign">
                                        <asp:Label ID="lblHeader" runat="server" Text="" CssClass=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlConditions" Width="200px" AutoPostBack="false"
                                            ToolTip="Select Searching Criteria">
                                            <asp:ListItem Value="1">Description</asp:ListItem>
                                            <asp:ListItem Value="2">Code</asp:ListItem>

                                        </asp:DropDownList>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCriteria" runat="server" Width="185px" ToolTip=""
                                            CssClass="textbox" MaxLength="25"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" Text="SEARCH" Width="100px" CssClass="buttonstandard"
                                            Height="25px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRecords" runat="server" CssClass="label" Text="NO OF RECORDS:" Visible="true"></asp:Label>

                                        <asp:Label ID="lblNoOfRecords" runat="server" CssClass="HelpNoOfRecords"></asp:Label>
                                    </td>
                                    <td style="text-align: right">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlAreaCd" runat="server" Visible="false" CssClass="Help1GridPanel" ScrollBars="Auto">

                            <asp:GridView ID="gddetails" runat="server" AutoGenerateColumns="False" CssClass="Help1rows"
                                AlternatingRowStyle-CssClass="Alternategridrows" HeaderStyle-CssClass="gridcolumnheader"
                                GridLines="Horizontal">

                                <Columns>
                                    <asp:TemplateField HeaderText="CODE" Visible="True" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Visible="True" ID="lblcd" Text='<% #Eval("Code")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DESCRIPTION" Visible="True" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbldcd" Text='<% #Eval("Decode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="" HeaderStyle-Width="40px">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chksel" runat="server" onclick="Check_Click(this)" Checked='<%# Eval("CheckBoxChecked") %>' AutoPostBack="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
                <tr>
                    <td><asp:Button ID="btnSelect" runat="server" Text="Ok" /></td>
                    <td align="right">
                        <input type="button" id="btnback" onclick="javascript: window.close();" value="BACK" class="buttonstandard" />
                    </td>
                </tr>
            </table>
            </table>
        </asp:Panel>




    </form>
</body>
</html>
