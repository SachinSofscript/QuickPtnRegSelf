<%@ Page Language="VB" AutoEventWireup="false" Inherits="OTScheduling.InPatientHelp" CodeBehind="InPatientHelp.aspx.vb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxCtrl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>In Patients List</title>

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

    <%--<link runat="server" rel="stylesheet" type="text/css" id="CssCommon" href="~/Css/stylesheet.css" />
    <link runat="server" rel="stylesheet" type="text/css" id="CssButton" href="" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssAlertify" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssAlertifyBoot" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/validation.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script>--%>

</head>
<body onload="load()">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--   <asp:UpdateProgress runat="server" ID="uProgess1" DynamicLayout="true" DisplayAfter="1">
            <ProgressTemplate>
                <img id="Img1" alt="" src="~/Images/animated.gif" runat="server" style="position: absolute; left: 389px; top: 104px; width: 39px; height: 27px;" />
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
        <table id="Table1" runat="server" class="Help3MainPanel">
            <tr>
                <td>
                    <asp:Panel ID="Panel4" runat="server" CssClass="Help3SearchPanel">
                        <table>
                            <tr>
                                <td colspan="3" class="Help3HeaderAlign">
                                    <asp:Label ID="lblHeader" runat="server" Text="IN PATIENT HELP"></asp:Label>
                                    <input id="str" name="str" type="hidden" value='<%=request("frmname")%>' />
                                    <input id="cntrl" name="cntrl" type="hidden" value='<%=request("control")%>' />

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDocName" runat="server" Text="DOCTOR NAME" CssClass="label"></asp:Label>
                                    <asp:ImageButton ImageUrl="~/Images/Search.ico" ID="btnTemp1" runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDocCd" runat="server" Width="100px" ToolTip="Enter Doctor Code" MaxLength="9"
                                        onkeypress="ValidateNum(this);" CssClass="textbox" onkeyup="javascript:DoctorHelp(event);"
                                        AutoPostBack="true" TabIndex="1"></asp:TextBox>
                                    <asp:TextBox ID="lblDocNm" runat="server" ToolTip="Doctor Name" CssClass="textbox" ReadOnly="true"
                                        Width="247px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblWard" runat="server" Text="WARD NAME" CssClass="label"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlWard" runat="server" Width="300px"
                                        AutoPostBack="true" TabIndex="2">
                                    </asp:DropDownList>

                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="SEARCH" Width="100px"
                                        CssClass="buttonstandard" TabIndex="9" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPatientName" runat="server" Text="PATIENT NAME" CssClass="label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLastName" runat="server" Width="100px" ToolTip="Last Name" OnKeyDown="return (event.keyCode!=13);"
                                        CssClass="NotEditabletextbox" TabIndex="3" MaxLength="15"></asp:TextBox>&nbsp;<asp:TextBox
                                            ID="txtFirstName" runat="server" Width="120px" ToolTip="First Name" OnKeyDown="return (event.keyCode!=13);"
                                            CssClass="NotEditabletextbox" TabIndex="4" MaxLength="15"></asp:TextBox>&nbsp;<asp:TextBox
                                                ID="txtMidName" runat="server" Width="120px" ToolTip="Middle Name" OnKeyDown="return (event.keyCode!=13);"
                                                CssClass="NotEditabletextbox" TabIndex="5" MaxLength="15"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblAdmSts" runat="server" Text="STATUS"
                                        CssClass="label"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:RadioButton ID="RbAll" runat="server" GroupName="r1" Text="ALL"
                                        CssClass="label" TabIndex="6" />
                                    <asp:RadioButton ID="RbAdmit" runat="server" GroupName="r1"
                                        Text="ADMITTED" CssClass="label" TabIndex="7" />
                                    <asp:RadioButton ID="RbDschrg" runat="server" GroupName="r1"
                                        Text="DISCHARGED" CssClass="label" TabIndex="8" />
                                    &nbsp;&nbsp;&nbsp;
                 
                    <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
                                </td>

                            </tr>
                            <tr>
                                <%-- Pushpa 20180508 --%>
                                <%--<td>
                                    <asp:Label runat="server" ID="lblRecords" Text="NO OF RECORDS" CssClass="label"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblNoOfRecords" CssClass="HelpNoOfRecords"></asp:Label></td>--%>
                                <td colspan="3">
                                    <asp:Label runat="server" ID="lblRecords" Text="NO OF RECORDS" CssClass="label"></asp:Label>
                                    <asp:Label runat="server" ID="lblNoOfRecords" CssClass="HelpNoOfRecords"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:Panel runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Repeater ID="rptPager" runat="server">
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
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" CssClass="Help3GridPanel">
                        <asp:GridView ID="grdInPatientDtl" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            GridLines="horizontal" CssClass="Help3rows"
                            Visible="true">
                            <Columns>
                                <asp:TemplateField HeaderText="PATIENTS NAME" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="350px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPtnNm" Text='<%#Eval("PatientFullName")%>' Width="350px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AGE" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblAge" Text='<%#Eval("Age")%>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GENDER" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblGender" Text='<%#Eval("Gender")%>' Width="80px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BED NUMBER" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblBedNo" Text='<%#Eval("BedNo")%>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DOCTOR NAME" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="250px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDoc" Text='<%#Eval("DoctorName")%>' Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IN PAT NUMBER" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblIpNo" Text='<%#Eval("IpNo")%>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PATIENT NUMBER" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbltnNo" Text='<%#Eval("PatientNo")%>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="100px">
                                    <HeaderTemplate>
                                        <asp:Label ID="Adm" Text="Adm Date" runat="server"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblAdmDt" Text='<%#Eval("AdmDt", "{0:dd/MM/yyyy}")%>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="100px">
                                    <HeaderTemplate>
                                        <asp:Label ID="dsc" Text="Dschrg Date" runat="server"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDschgDt" Text='<%#Eval("DschgDt")%>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="STATUS" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblStatus" Text='<%#Eval("StatusDesc")%>' Width="100px"></asp:Label>
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
                <td align="left" style="width: 100%">
                    <input type="button" id="btnback" onclick="javascript: window.close();" value="BACK" class="buttonstandard" />
                </td>
            </tr>
        </table>
        <%--            -------------------------------------------------------------------%>
        <ajaxCtrl:ModalPopupExtender ID="MpDoctorHelp" runat="server" CancelControlID="btnDoctSearchClose"
            OkControlID="" TargetControlID="btnTemp1" PopupControlID="pnlDoctorHelp" Drag="true">
        </ajaxCtrl:ModalPopupExtender>
        <asp:Panel ID="pnlDoctorHelp" runat="server" Style="display: none" CssClass="Help2MainPanel">

            <table id="Table2" runat="server">
                <tr>
                    <td>
                        <asp:Panel ID="Panel6" runat="server" CssClass="Help2SearchPanel">
                            <table>
                                <tr>
                                    <td colspan="3" class="Help2HeaderAlign">
                                        <asp:Label ID="Label2" runat="server" Text="DOCTOR SEARCH" CssClass=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="Label1" Text="DOCTOR NAME" CssClass="label"></asp:Label>&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDoctorFullName" runat="server" Width="200px" ToolTip="Doctor's Name"
                                            CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblSpeciality" Text="SPECIALITY" CssClass="label"></asp:Label>&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlSpeciality" Width="250px" AutoPostBack="false"
                                            ToolTip="Doctor's Speciality">
                                        </asp:DropDownList>


                                    </td>
                                    <td>
                                        <asp:Button ID="btnDoctSearch" runat="server" Text="SEARCH" Width="100px" CssClass="buttonstandard" />

                                        <asp:Button ID="btnDoctSearchClose" runat="server" Text="CLOSE" Width="100px" CssClass="buttonstandard" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblfDocRec" Text="NO OF RECORDS:" CssClass="label"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="lblNoOfDocRec" CssClass="HelpNoOfRecords" Width="25px"></asp:Label></td>
                                    <td></td>
                                    <td align="right" colspan="2"></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" CssClass="Help2GridPanel">
                            <asp:GridView ID="GrdDoctorDetails" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                GridLines="Horizontal" CssClass="Help2rows"
                                Visible="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="DOC NO" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="60px"
                                        ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblDocCd" Text='<%#Eval("DoctorCode")%>' Width="60px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="DOCTOR NAME" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="400px"
                                        ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblDocFullNm" Text='<%#Eval("DoctorFullName")%>' Width="400px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SPECIALITY" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="250px"
                                        ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblDocSpclty" Text='<%#Eval("SpecialityCodeDesc")%>'
                                                Width="250px"></asp:Label>
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






        </asp:Panel>




        <script type="text/javascript">
            function DoctorHelp(e) {
                evt = e || window.event;
                if (evt.keyCode == 113) {
                    $find('MpDoctorHelp').show();
                    $('#grdInPatientDtl').remove();
                }
            }
        </script>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#<%=grdInPatientDtl.ClientID%> tr:has(td)").hover(function (e) {
                $(this).css("cursor", "pointer");
            });

            $("#<%=grdInPatientDtl.ClientID%> tr:has(td)").click(function (e) {
                var IpNo = $(this).find("td:eq(5)").text().toLowerCase().trim();
               
                var MyArgs = new Array(IpNo);
                ReturnValues(MyArgs, document.getElementById("str"), document.getElementById("cntrl"));
                //if (window.opener) {
                //    window.opener.returnValue = MyArgs;
                //}
                //window.returnValue = MyArgs;
                //window.close();
            }); ;
        })
        </script>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#<%=GrdDoctorDetails.ClientID%> tr:has(td)").hover(function (e) {
                $(this).css("cursor", "pointer");
            });

            $("#<%=GrdDoctorDetails.ClientID%> tr:has(td)").click(function (e) {
                var DocFirstNo = $(this).find("td:eq(0)").text().toLowerCase().trim();
                var DocName = $(this).find("td:eq(1)").text().toLowerCase().trim();

                $("#<%=GrdDoctorDetails.ClientID%> td").removeClass("selected");
                document.getElementById("<%=lblDocNm.ClientID%>").value = DocName;
                document.getElementById("<%=txtDocCd.ClientID%>").value = DocFirstNo;
                document.getElementById("<%=txtLastName.ClientID%>").focus();
                $find('MpDoctorHelp').hide();
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
                        $("#lblNoOfDocRec").text(iCounter);
                    }
                    else if (sSearchDoctorName.length != 0) { // Check data by doctor name
                        if (cellFullName.indexOf(sSearchDoctorName.toLowerCase()) >= 0) {
                            $(this).show();
                            iCounter++;
                            return true;
                        }
                        $("#lblNoOfDocRec").text(iCounter);
                    }
                    else if (sSearchSpeciality != "") {  // Check data by doctor speciality
                        if (cellSpeciality.indexOf(sSearchSpeciality.toLowerCase()) >= 0) {
                            $(this).show();
                            iCounter++;
                            return true;
                        }
                        $("#lblNoOfDocRec").text(iCounter);
                    }
                    else if ((sSearchDoctorName.length == 0) && (sSearchSpeciality == "")) { // Check data by both docor name and speciality
                        $("#lblNoOfDocRec").text(''); /*Manisha*/
                        $("#<%=GrdDoctorDetails.ClientID%> tr:has(td)").show();
                        iCounter++;
                        $("#lblNoOfDocRec").text(iCounter);
                        return true;
                    }
                });

                if (iCounter == 0) {
                    $('#<%=lblNoOfDocRec.ClientID%>').css('display', '');
                }
                e.preventDefault();
            })
        })

        function load() 
        {
            hideshow();
        }
    
        function hideshow() 
        {
            //alert();
            var gridrows = $("#grdInPatientDtl tbody tr");
            //alert();
            for (var i = 0; i < gridrows.length; i++) 
            {
                if (document.getElementById("RbAdmit").checked == true)
                {
                    gridrows[i].cells[7].style.display = "";
                    gridrows[i].cells[8].style.display = "none";
                }
                if (document.getElementById("RbDschrg").checked == true)
                {
                    gridrows[i].cells[7].style.display = "none";
                    gridrows[i].cells[8].style.display = "";
                }
                if (document.getElementById("RbAll").checked == true)
                {
                    gridrows[i].cells[7].style.display = "";
                    gridrows[i].cells[8].style.display = "";
                }
            }
            return false;
        } 

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
            hover_row("<%=grdInPatientDtl.ClientID%>");
            hover_row("<%=GrdDoctorDetails.ClientID%>");
        }
        </script>


    </form>
</body>
</html>
