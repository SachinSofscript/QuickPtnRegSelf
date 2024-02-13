<%@ Page Language="VB" AutoEventWireup="false" Inherits="OTScheduling.Pages_frmOtServicesHelp" CodeBehind="frmOtServicesHelp.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OT SERVICES HELP</title>

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
     

<%--    <link href="~\..\CSS\stylesheet.CSS" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\ButtonStyles.css" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\alertify.core.CSS" type="text/css" rel="stylesheet" />
    <link href="~\..\CSS\alertify.bootstrap.CSS" rel="stylesheet" type="text/css" />
    <link href="~\..\CSS\Master.CSS" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\jquery-1.10.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\alertify.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\alertify.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\validation.js"></script> --%>

     <%-- <link runat="server" rel="stylesheet" type="text/css" id="CssCommon" href="~/Css/stylesheet.css" />
    <link runat="server" rel="stylesheet" type="text/css" id="CssButton" href="" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssAlertify" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssAlertifyBoot" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/validation.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script> --%>

</head>
<body onload="load()">
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
                <input type="hidden" id="str" name="str" value="<%=request("frmname")%>" />
                <input type="hidden" id="cntrl" name="cntrl" value="<%=request("control")%>" />
                <asp:Panel ID="Panel2" runat="server">
                    <table id="Table1" runat="server" class="Help2MainPanel">
                        <tr>
                            <td>
                                <asp:Panel ID="Panel3" runat="server" CssClass="Help2SearchPanel">
                                    <table>
                                        <tr>
                                            <td colspan="5" class="Help2HeaderAlign">
                                                <asp:Label ID="lblHeading" runat="server" Text="OT SERVICES SEARCH"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtCriteria" runat="server" Width="230px" ToolTip="" placeholder="Enter Atleast 3 letters" CssClass="textbox"></asp:TextBox>
                                            <%--</td>--%>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlConditions" Width="250px" AutoPostBack="false"
                                                    ToolTip="Select Searching Criteria">
                                                    <asp:ListItem Value="1">OT Service Desc</asp:ListItem>
                                               <%--     <asp:ListItem Value="2">OT Service Code</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
<%--                                                <asp:Button runat="server" ID="btnSrvSrch" Text="SEARCH" AutoPostBack="true" CssClass="buttonstandard" OnClick ="btnSrvSrch_Click1" />--%>

                                                     <asp:Button runat="server" ID="btnSrvSch" Text="SEARCH" AutoPostBack="true" CssClass="buttonstandard" OnClick ="btnSrvSch_Click" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblRecords0" runat="server" CssClass="label" Text="NO OF RECORDS"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNoOfRecords" runat="server" CssClass="label"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td align="right">&nbsp;</td>
                                            <td align="left">&nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>


                        <tr>
                            <td>
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both"
                                    CssClass="Help2GridPanel">
                                    <asp:GridView ID="GrdDoctorDetails" runat="server" AllowSorting="True"
                                        AutoGenerateColumns="False"
                                        GridLines="Horizontal" CssClass="Help2rows">

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


                                              <asp:TemplateField HeaderText="SERVICE TYPE CODE" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Visible="true" ID="grdlblSurgTypCd" Text='<% #Eval("SrvTypCd")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          


                                            <asp:TemplateField HeaderText="ADDITIONAL INFO" Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Visible="false" ID="grdlblAdditionName" Text='<% #Eval("AnesTypDesc")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ADDITIONAL code" Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Visible="false" ID="grdlblAdditioncd" Text='<% #Eval("AnesTypCd")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="RATE" Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Visible="false" ID="grdlblRate" Text='<% #Eval("SrvRate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>

                                        <HeaderStyle CssClass="Help2headerStyle" ForeColor="White" />
                                        <RowStyle CssClass="Help2rowStyle" />
                                        <AlternatingRowStyle CssClass="Help2alternatingRowStyle" />
                                        <FooterStyle CssClass="Help2footerStyle" />
                                        <PagerStyle CssClass="Help2pagerStyle" ForeColor="White" />
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>

                    <%--                    <asp:HiddenField ID="HfAppMdCd" runat="server" />
                <asp:HiddenField ID="HfAppSubMdCd" runat="server" />--%>
                    <asp:HiddenField ID="ContentPlaceHolder1_HfAppMdCd" runat="server" />
                    <asp:HiddenField ID="ContentPlaceHolder1_HfAppSubMdCd" runat="server" />
                </asp:Panel>



            </ContentTemplate>
        </asp:UpdatePanel>


       

        <script type="text/javascript">
            function jsFunctions() {
                hover_row("<%=GrdDoctorDetails.ClientID%>");

                $(document).ready(function () {
                    $("#<%=GrdDoctorDetails.ClientID%> tr:has(td)").hover(function (e) {
                        $(this).css("cursor", "pointer");
                    });

                    $("#<%=GrdDoctorDetails.ClientID%> tr:has(td)").click(function (e) {

                        var srvDcd = $(this).find("td:eq(0)").text().toLowerCase().trim();
                        var srvcd = $(this).find("td:eq(1)").text().toLowerCase().trim();
                        var chrgDcd = $(this).find("td:eq(2)").text().toLowerCase().trim();
                        var chrgcd = $(this).find("td:eq(3)").text().toLowerCase().trim();

                        var SrvTypDcd = $(this).find("td:eq(4)").text().toLowerCase().trim();
                        var SrvTypcd = $(this).find("td:eq(5)").text().toLowerCase().trim();
                        //alert(srvcd);
                        // $("#<%=GrdDoctorDetails.ClientID%> td").removeClass("selected");

                        //var MyArgs = new Array(srvcd, SrvDesc, chrgcd, chrgDesc);   srvcd,srvDcd,chrgcd,chrgDcd
                        //var MyArgs = new Array(srvcd, chrgcd);
                        //  var MyArgs = new Array(srvcd, srvDcd);
                        //alert(srvcd);
                        //alert(chrgDcd);
                        var MyArgs = new Array(srvcd, srvcd, srvDcd, chrgcd, chrgDcd, SrvTypcd, SrvTypDcd);
                        ReturnValues(MyArgs, document.getElementById("str"), document.getElementById("cntrl"), '');
                    });
                })
            }

            function load() {
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(jsFunctions);
            }
        </script>



      <%--<script type="text/javascript">
            $(document).ready(function () {

                //$('#<%=lblNoOfRecords.ClientID%>').css('display', 'none');  /*Manisha commented this to show no. of records*/
   $('#<%=btnSrvSch().ClientID%>').click(function (e) {


                $("#<%=GrdDoctorDetails.ClientID%> tr:has(td)").hide(); // Hide all the rows.

                var iCounter = 0;
                var sSearchDoctorName = $('#<%=txtCriteria.ClientID%>').val(); //Get the search box value
                var sSearchSpeciality = $('#ddlSpeciality').find('option').filter(':selected').text();
                if (sSearchSpeciality == "All") {
                    sSearchSpeciality = "";
                }

                //Iterate through all the td.
                $("#<%=GrdDoctorDetails.ClientID%> tr:has(td)").each(function () {
                    var cellFullName = $(this).find("td:eq(1)").text().toLowerCase().trim();
                    var cellSpeciality = $(this).find("td:eq(2)").text().toLowerCase().trim();
                    if ((sSearchDoctorName.length != 0) && (sSearchSpeciality != "")) { // Check data by both docor name and speciality
                        if ((cellFullName.indexOf(sSearchDoctorName.toLowerCase()) >= 0) && (cellSpeciality.indexOf(sSearchSpeciality.toLowerCase()) >= 0)) { //Check if data matches
                            $(this).show();
                            iCounter++;
                            return true;
                        }
                        $("#lblNoOfRecords").text(iCounter);
                    }
                    else if (sSearchDoctorName.length != 0) { // Check data by doctor name
                        if (cellFullName.indexOf(sSearchDoctorName.toLowerCase()) >= 0) {
                            $(this).show();
                            iCounter++;
                            return true;
                        }
                        $("#lblNoOfRecords").text(iCounter);
                    }
                    else if (sSearchSpeciality != "") {  // Check data by doctor speciality
                        if (cellSpeciality.indexOf(sSearchSpeciality.toLowerCase()) >= 0) {
                            $(this).show();
                            iCounter++;
                            return true;
                        }
                        $("#lblNoOfRecords").text(iCounter);
                    }
                    else if ((sSearchDoctorName.length == 0) && (sSearchSpeciality == "")) { // Check data by both docor name and speciality
                        $("#lblNoOfRecords").text(''); /*Manisha*/
                        $("#<%=GrdDoctorDetails.ClientID%> tr:has(td)").show();
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
        </script>--%>
    </form>
</body>
</html>
