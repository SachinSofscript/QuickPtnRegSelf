<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmHelpDoc.aspx.vb" Inherits="OTScheduling.frmHelpDoc" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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

 <%--   <link runat="server" rel="stylesheet" type="text/css" id="CssCommon" href="~/Css/stylesheet.css" />
    <link runat="server" rel="stylesheet" type="text/css" id="CssButton" href="" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssAlertify" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssAlertifyBoot" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/validation.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script> --%>

    <script type="text/javascript">
       
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

        $(document).ready(function () {
            $("#<%=GrdDoctorDetails.ClientID%> tr:has(td)").hover(function (e) {
                $(this).css("cursor", "pointer");
            });

            $("#<%=GrdDoctorDetails.ClientID%> tr:has(td)").click(function (e) {
                var DocFirstNo = $(this).find("td:eq(0)").text().toLowerCase().trim();
                var DocLastNm = $(this).find("td:eq(1)").text().toLowerCase().trim();
              
                $("#<%=GrdDoctorDetails.ClientID%> td").removeClass("selected");
                var MyArgs = new Array(DocFirstNo, DocLastNm);
                //window.opener.enablepanel();
                ReturnValues(MyArgs, document.getElementById("str"), document.getElementById("cntrl"), 'NP');
            });
        })
    
    </script>
   
  <script type="text/javascript">

      $(document).ready(function () {

          //$('#<%=lblNoOfRecords.ClientID%>').css('display', 'none');  /*Manisha commented this to show no. of records*/

            $('#<%=btnDoctSearch.ClientID%>').click(function (e) {

                /*  $('#<%=lblNoOfRecords.ClientID%>').css('display', 'none'); // Hide No records to display label.*/
                $("#<%=GrdDoctorDetails.ClientID%> tr:has(td)").hide(); // Hide all the rows.

                var iCounter = 0;
                var sSearchDoctorName = $('#<%=txtDoctorFullName.ClientID%>').val(); //Get the search box value
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
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

        <input type="hidden" id="str" name="str" value="<%=request("frmname")%>" />
        <input type="hidden" id="cntrl" name="cntrl" value="<%=request("control")%>" />
        <table id="Table1" runat="server" class="Help2MainPanel">
            <tr>
                <td>
                    <asp:Panel ID="Panel6" runat="server" CssClass="Help2SearchPanel">
                        <table>
                            <tr>
                                <td class="Help2HeaderAlign">
                                    <asp:Label runat="server" ID="lblFrstName0"
                                        Text="SEARCH PARAMETERS"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblDocNm" Text="DOCTOR NAME" CssClass="label"></asp:Label>&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDoctorFullName" runat="server" Width="300px" ToolTip="Doctor's Name"
                                        CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblSpeciality" Text="SPECIALITY" CssClass="label"></asp:Label>&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlSpeciality" Width="280px" AutoPostBack="false"
                                        ToolTip="Doctor's Speciality">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnDoctSearch" runat="server" Text="SEARCH" Width="100px" CssClass="buttonstandard"
                                        Height="25px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblRecords" Text="NO OF RECORDS" CssClass="label"></asp:Label>
                                </td>
                                <td colspan="4">
                                    <asp:Label runat="server" ID="lblNoOfRecords" CssClass="HelpNoOfRecords" Width="100px"></asp:Label>
                                </td>

                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" CssClass="Help2GridPanel">
                        <asp:GridView ID="GrdDoctorDetails" runat="server" AllowSorting="True" AutoGenerateColumns="False" GridLines="horizontal" CssClass="Help2rows">
                            <Columns>
                                <asp:TemplateField HeaderText="DOC NO" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="60px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDocCd" Text='<%#Eval("DoctorCode")%>' Width="35px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="DOCTOR NAME" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="270px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDocFullNm" Text='<%#Eval("DoctorFullName")%>' Width="265px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SPECIALITY" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="250px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDocSpclty" Text='<%#Eval("SpecialityCodeDesc")%>'
                                            Width="245px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDocFrstNm" Text='<%#Eval("DoctorFirstName")%>' Style="visibility: hidden;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDocMidNm" Text='<%#Eval("DoctorMiddleName")%>' Style="visibility: hidden;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDocLstNm" Text='<%#Eval("DoctorLastName")%>' Style="visibility: hidden;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--  <asp:TemplateField HeaderText="Select" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnSelect" Text="SELECT" CommandName="Select" CssClass="buttonstandard"
                                        Height="25px" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
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

         <asp:HiddenField ID="HfAppMdCd" runat="server" />
    <asp:HiddenField ID="HfAppSubMdCd" runat="server" />
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
            hover_row("<%=GrdDoctorDetails.ClientID%>");
        }
    </script>
</body>
</html>
