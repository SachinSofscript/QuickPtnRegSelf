<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage.master" CodeBehind="Page_Default.aspx.vb" Inherits="OTScheduling.Page_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <link href="../CSS/ModelPopup.css" rel="stylesheet" />


    <style type="text/css">
        .ostable{

            width: 96%;
            background-color: white;
            border: 1px solid #867f7f;

        }
        .ostable td{

            width: 96%;
            background-color: white;
            border: 1px solid #867f7f;

        }

        
    </style>

    <script type="text/javascript">

        function SetReturnValue1() {

            __doPostBack();
        }



      
    </script>

    <script type="text/javascript" language="javascript">
        function CheckOtherIsCheckedByGVID(spanChk) {

            var IsChecked = spanChk.checked;
            if (IsChecked) { }
            var grid = window["<%= grdindirectbooking.ClientID%>"];
            var totalrowcount = grid.rows.length;
            totalrowcount = totalrowcount - 1;
            var CurrentRdbID = spanChk.id;
            var Chk = spanChk;
            Parent = document.getElementById("<%=grdindirectbooking.ClientID%>");
            var items = Parent.getElementsByTagName('input');
            for (i = 0; i < items.length; i++) {
                if (items[i].id != CurrentRdbID && items[i].type == "radio") {
                    if (items[i].checked) {
                        items[i].checked = false;
                    }
                }
            }
        }

        function setsession1() {
            sessionStorage.setItem('forcelogout', 1);
            return true;
        }

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




        function ValidateNum(sender) {
            if (((event.keyCode < 48) || (event.keyCode > 57))) {
                event.returnValue = false;
                sender.focus();
            }
            if (event.keyCode == 13)
                event.returnValue = true;
        }




        function setshiftnow() {
            document.getElementById("ContentPlaceHolder1_Button1").click();
            return true;
        }



        function savecnfirmation() {
            confirmAction('Are you sure cancel the OT request?', performAction); return false;
        }


        function performAction() {
            document.getElementById("ContentPlaceHolder1_Button5").click();
        }

        function confirmAction(message, action) {
            alertify.confirm(message, function (e) {
                if (e) {
                    if (action) {
                        action();
                    }
                }
            });
        }
        function finalvalidations() {

            return savecnfirmation();
        }


        $("#instimage").load(function () {
            var ifrm = $("#instimage").contents();
            ifrm.find().click(function () {
                alert('a')

            });

        });


    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--  <asp:UpdateProgress runat="server" ID="uProgess1" DynamicLayout="true" DisplayAfter="1">
        <ProgressTemplate>
            <img id="Img1" alt="" src="~/Images/animated.gif" runat="server" style="position: absolute; left: 498px; top: 126px; width: 39px; height: 27px;" />
        </ProgressTemplate>
    </asp:UpdateProgress>--%>

    <asp:UpdatePanel runat="server" ID="UpPopupCovertOpToIp" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <asp:Panel ID="divOverlayPopupCovertOpToIp" ClientIDMode="Static" runat="server" CssClass="popup-overlay"></asp:Panel>
            <div id="divPopupCovertOpToIp" runat="server" style="position: fixed; z-index: 991; left: 0; height: 100%; width: 100%;" visible="false">
                <center>
                    <div style="height: auto; display: inline-table; padding-bottom: 10px; width: 618px; padding: 0px 10px;">
                        <div style="margin: 30px auto; height: auto; font-size: 14px">
                            <div>
                                <div class="alert-header">
                                    <div class="divHeader">
                                        <span runat="server" style="color: white; font-size: 16px; margin-left: -10px;">CONVERT THE OT BOOKING FROM OP TO IP</span>
                                    </div>
                                </div>
                                <div class="alert-body">
                                    <asp:Panel ID="Panel2" runat="server" CssClass="panel" Height="305px"  ScrollBars="Vertical">
                                        <asp:GridView ID="grdOtList" runat="server" AlternatingRowStyle-CssClass="Alternategridrows"
                                            HeaderStyle-CssClass="gridcolumnheader" AutoGenerateColumns="False" CssClass="gridrows"
                                            Width="100%" ShowHeaderWhenEmpty="true" HeaderStyle-Wrap="false" RowStyle-Wrap="false">
                                            <AlternatingRowStyle CssClass="Alternategridrows" />
                                            <Columns>
                                                <asp:BoundField DataField="ExpectedDate" HeaderText="DATE" ItemStyle-CssClass="label" DataFormatString="{0:d}" HeaderStyle-Width="80px" />
                                                <asp:TemplateField HeaderText="APPT NO" HeaderStyle-Width="90px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApptNo" runat="server" Text='<%#  Eval("TrnNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PTN NO" HeaderStyle-Width="90px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblptnno" runat="server" Text='<%#  Eval("PtnNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="IP NO" HeaderStyle-Width="90px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIpNo" runat="server" Text='<%#  Eval("IpNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="PtnFrstNm" HeaderText="PATIENT FIRST NAME" Visible="false" ItemStyle-CssClass="label" />
                                                <asp:BoundField DataField="PtnFullNm" HeaderText="PATIENT NAME" ItemStyle-CssClass="label" HeaderStyle-Width="300px" />
                                                
                                                <asp:BoundField DataField="DocCd" HeaderText="DOCTOR cODE" Visible="false" ItemStyle-CssClass="label" HeaderStyle-Width="300px" />
                                                <asp:BoundField DataField="DocFullNm" HeaderText="DOCTOR NAME" Visible="true" ItemStyle-CssClass="label" HeaderStyle-Width="300px" />
                                        
                                                        
                                                 <asp:TemplateField HeaderText="" HeaderStyle-Width="90px">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnUpdate" runat="server" Text="CONVERT IN IP" CssClass="btnpopupcss" Width="110px"
                                                            OnClick="btnUpdate_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                        </asp:GridView>
                                    </asp:Panel>
                                </div>
                                <div class="alert-footer">
                                    <div>
                                        <table>
                                            <tr>
                                                <td align="left" style="width: 670px;"></td>
                                                <td align="right">
                                                    <span class="pull-right">
                                                        <asp:Button ID="btnClosePopupCovertOpToIp" runat="server" Text="CLOSE" CssClass="btnpopupcss"
                                                            ToolTip="Press ALT + 1 For Close popup" AccessKey="1" OnClick="btnClosePopupCovertOpToIp_Click" />
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- Added By Nutan 11 Jan 2022 --%>
   <asp:UpdatePanel runat="server" ID="upPopupIPOPPtntypwisetrn" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <ContentTemplate> 
                <div id="divPopupIPOPPtntypwisetrn" runat="server" style="position: fixed;margin-top:180px; z-index: 991; left: 0; height: 100%; width: 100%;" visible="false">
                    <center>
                    <div style="height: auto;display: inline-table; padding-bottom: 10px; width: 292px; padding: 10px 10px; border:1px">
                        <div style="margin:30px auto; height: auto; font-size:14px">
                            <div>
                                <div class="alert-header">
                                   <div class="divHeader">
                                    <span runat="server" style="color: white;" >PATIENT OUTSTANDING DETAILS  </span> 
                                       <div style="float:right">
                                           <asp:ImageButton ID="ImageButton1" runat="server" style="height: 24px;width: 24px;" ImageUrl="~/Images/Close48px.png" OnClick="btnClosePopup_Click" />
                                       </div>
                                   </div>
                                </div>
                                <div class="alert-body">
                                    <table  class="label ostable" style="padding-left:15px;width:100%">
                                                <tr>
                                                    <td class=" label ostable td">
                                                        <asp:Label ID="Label9" runat="server" CssClass="headerblack">Un-Settled Amount :</asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblunstldamnt" Style="text-align: right" runat="server" CssClass="headerblack"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label11" runat="server" CssClass="headerblack">Un-Billed Amount :</asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblunbldamnt" runat="server" Style="text-align: right" CssClass="headerblack"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" CssClass="headerblack">Deposit Balance :</asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lbldepbal" runat="server" Style="text-align: right" CssClass="headerblack"></asp:Label></td>
                                                </tr>
                                                <tr style="background-color: lightgoldenrodyellow">
                                                    <td>
                                                        <asp:Label ID="lbldueamntnm" BackColor="LightGoldenrodYellow" runat="server" CssClass="headerblack">Due Amount :</asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lbldueamnt" BackColor="LightGoldenrodYellow" Style="text-align: right" runat="server" CssClass="headerblack"></asp:Label></td>
                                                   
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:CheckBox ID="ckhoffcperm" runat="server" Text="OFFICE PERMISSION?" CssClass="headerblack" OnCheckedChanged="ckhoffcperm_CheckedChanged" AutoPostBack="true"/>
                                                    </td>
                                                </tr>
                                            </table>
                                 </div>
                                <div class="alert-footer">
                                    <span class="pull-right">  
                                        <asp:Button ID="btnClosePopup" runat="server" Text="CLOSE" CssClass="buttonstandard" OnClick="btnClosePopup_Click"/>
                                    </span> 
                                </div>
                             </div>
                        </div>
                     </div>
                     </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%-- Added By Nutan 11 Jan 2022 --%>

    <asp:UpdatePanel ID="pnlMain" runat="server">
        <ContentTemplate>
            <div class="divSearchHeader">
                <table>
                    <asp:ImageButton ID="ImageButton3" Width="1px" runat="server" ImageUrl="~/Images/Search.ico" Style="visibility: hidden" />
                    <tr>
                        <td>
                            <asp:Label ID="lblPatient" runat="server" CssClass="label" Text="SORT BY"></asp:Label>
                        </td>
                        <td></td>
                        <td>
                            <asp:RadioButtonList ID="rdbOrderBy" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                                <asp:ListItem Text="REQUEST NO" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="PATIENT NO" Value="1"></asp:ListItem>
                                <asp:ListItem Text="PATIENT NAME" Value="2"></asp:ListItem>
                                <asp:ListItem Text="DOCTOR NAME" Value="3"></asp:ListItem>
                            </asp:RadioButtonList>

                        </td>
                        <td>&nbsp;                            &nbsp;
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td style="width: 20px">
                            <asp:Label ID="lblot" runat="server" Text="OT" CssClass="label"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Search.ico" Width="16px" OnClientClick="javascript:HelpImg(event,this,'txtot','OT','1','OTSearch.aspx','extra');return false;" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtot" runat="server" Width="100px" AutoPostBack="true" MaxLength="4"
                                onkeypress="ValidateNum(this);" CssClass="textbox"
                                onkeyup="javascript:Help(event,this,'txtot','OT','1','OTSearch.aspx','extra');return false;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtotname" runat="server" ToolTip="OT Name" MaxLength="4" ReadOnly="true" Width="300px" CssClass="textbox"></asp:TextBox>
                        </td>
                        <td class="style1">
                            <asp:Label ID="Label1" runat="server" Text="DATE" CssClass="label"></asp:Label>
                            &nbsp;&nbsp;
                             <asp:Label ID="lblRevDate" runat="server" Font-Bold="true" ForeColor="Blue" Font-Size="14px" Text="DATE" CssClass="label"></asp:Label>
                            &nbsp;&nbsp;  &nbsp;&nbsp;  &nbsp;&nbsp;
                            
                            <asp:Label ID="lbldt" runat="server" Text="TO DATE" CssClass="label"></asp:Label>
                            &nbsp;&nbsp;

                            
                            
                                            <asp:TextBox ID="txtdate" runat="server" Width="100px" CssClass="textbox" AutoPostBack="true"
                                                Height="16px" ForeColor="Black" BackColor="White"></asp:TextBox>
                            <asp:CalendarExtender ID="toCal1" runat="server" CssClass="MyCalendar" Format="dd/MM/yyyy"
                                PopupButtonID="txtdate" TargetControlID="txtdate">
                            </asp:CalendarExtender>
                        </td>
                        <td style="visibility: hidden">
                            <asp:Button ID="Button1" Text="TEST" CssClass="divskyblue" runat="server" Width="1px" />
                        </td>

                        <td>

                              <asp:Button  ID="BtnOtList" runat="server"  CssClass="inner-btn" Text="OT List" Visible="true" Width="89px" OnClick="BtnOtList_Click"/>

                        </td>
                    </tr>
                </table>
                <asp:Panel ID="Panel1" runat="server" CssClass="panel" Height="490px" ScrollBars="Vertical">
                    <asp:GridView ID="grdindirectbooking" runat="server" AlternatingRowStyle-CssClass="Alternategridrows" HeaderStyle-CssClass="gridcolumnheader" AutoGenerateColumns="False" CssClass="gridrows" Width="100%" ShowHeaderWhenEmpty="true" OnRowDataBound="grdindirectbooking_RowDataBound"  >
                        <AlternatingRowStyle CssClass="Alternategridrows" />
                        <Columns>
                            <asp:TemplateField HeaderText="SEL" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10px">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbSel" runat="server" onclick="javascript:CheckOtherIsCheckedByGVID(this);"
                                        EnableViewState="true" Visible="true"
                                        AutoPostBack="true" OnCheckedChanged="rbSel_CheckedChanged"></asp:RadioButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="TrnNo" HeaderText="REQ NO" ItemStyle-CssClass="label" HeaderStyle-Width="50px" />
                            <asp:TemplateField HeaderText="IP NO" HeaderStyle-Width="90px">
                                <ItemTemplate>
                                    <asp:Label ID="lblptnno" runat="server" Text='<%#  Eval("PtnNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PtnFrstNm" HeaderText="PATIENT FIRST NAME" Visible="false" ItemStyle-CssClass="label" />
                            <asp:BoundField DataField="PtnFullNm" HeaderText="PATIENT NAME" ItemStyle-CssClass="label" HeaderStyle-Width="300px" />
                            <%--Nutan 11.01.2022--%>
                                                <asp:TemplateField HeaderText="O.S." HeaderStyle-Width="30px">
                                                <ItemTemplate>
                                                        <asp:LinkButton ID="lnkOSDetail" runat="server" Text="OS" CssClass="btn btn-xs btn-flat button pull-right" 
                                                            ToolTip="OUTSTANDING DETAILS" OnClick="lnkOSDetail_Click"
                                                            CommandName="SelectOSDetails" 
                                                            CommandArgument='<%# Eval("PtnNo") & "," & Eval("TrnNo")%>' 
                                                            ></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                               <%--Nutan 11.01.2022--%>
                            <asp:BoundField DataField="DocCd" HeaderText="DOCTOR cODE" Visible="false" ItemStyle-CssClass="label" HeaderStyle-Width="300px" />
                            <asp:BoundField DataField="DocFullNm" HeaderText="DOCTOR NAME" Visible="true" ItemStyle-CssClass="label" HeaderStyle-Width="300px" />


                            <asp:TemplateField HeaderStyle-Width="20px" HeaderText="O.P.">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgOPStatus" runat="server" ImageUrl='<%# IIf(Convert.ToBoolean(Eval("IsOfficePrmsnGiven")) = True, "~/images/check.png", "~/images/Uncheck.png") %>' 
                                        ToolTip ='<%# IIf(Convert.ToBoolean(Eval("IsOfficePrmsnGiven")) = True, "Office permission is given", "Office permission is pending") %>' 
                                        
                                         />

                                </ItemTemplate>

                            </asp:TemplateField>


                             <%--Nutan 11.01.2022--%>
                            <asp:TemplateField HeaderText="O.P." HeaderStyle-Width="30px">
                                <ItemTemplate>
                                    <asp:checkbox ID="chkOP" runat="server"  CssClass="btn btn-xs btn-flat button pull-right" ToolTip="OFFICE PERMISSION GIVEN" Checked  ='<%# Convert.ToBoolean(Eval("IsOfficePrmsnGiven"))%>' OnCheckedChanged="chkOP_CheckedChanged" AutoPostBack="true"></asp:checkbox>
                                    <asp:TextBox ID="txtoffPermRmrk" runat="server" Text='<%# Eval("OfficePrmsnRmrk")%>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--Nutan 11.01.2022--%>
                            <asp:BoundField DataField="Gender" HeaderText="GENDER" ItemStyle-CssClass="label" HeaderStyle-Width="60px" />
                            <asp:BoundField DataField="Age" HeaderText="AGE" ItemStyle-CssClass="label" HeaderStyle-Width="70px" />
                            <asp:BoundField DataField="MobNo" HeaderText="MOBILE" ItemStyle-CssClass="label" HeaderStyle-Width="80px" />
                            <asp:BoundField DataField="ExpectedDate" HeaderText="EXPECTED DATE" ItemStyle-CssClass="label" DataFormatString="{0:d}" HeaderStyle-Width="80px" />
                            <asp:BoundField DataField="TrnNo" HeaderText="TrnCd" Visible="false" ItemStyle-CssClass="label" HeaderStyle-Width="300px" />
                            <asp:BoundField DataField="PtnActualPtnNo" HeaderText="PtnActuaLPtnNo" Visible="false" ItemStyle-CssClass="label" HeaderStyle-Width="300px" />



                        </Columns>

                    </asp:GridView>
                </asp:Panel>
            </div>
            <div id="div1" runat="server" style="width: 100%; height: 1px; visibility: hidden">
                <table border="1" style="width: 100%; height: 1px; visibility: hidden">
                    <tr>
                        <td align="left" style="visibility: hidden" />
                        <asp:RadioButton ID="rdoip" runat="server" Checked="True" Text="IP" Style="visibility: hidden" />
                        <asp:RadioButton ID="rdoop" runat="server" Text="OP" Style="visibility: hidden" />
                        <input id="txtflag" runat="server" enableviewstate="true" type="text" style="visibility: hidden" />
                        </td>
                    </tr>
                    <caption>
                        <input id="txtreqno" runat="server" enableviewstate="true" type="text" style="visibility: hidden" />
                        <input id="txtimgsession" runat="server" enableviewstate="true" type="text" style="visibility: hidden" />
                        <input id="txtactionflag" runat="server" enableviewstate="true" type="text" style="visibility: hidden" />
                        <asp:Button ID="Button5" runat="server" Width="1px" Height="1px" Style="visibility: hidden" />
                        <asp:Button ID="Button6" runat="server" Width="1px" Height="1px" Style="visibility: hidden" />
                    </caption>
                </table>
            </div>
            <asp:HiddenField ID="HfAppMdCd" runat="server" />
            <asp:HiddenField ID="HfAppSubMdCd" runat="server" />
            <asp:HiddenField ID="hfaccess" runat="server" />
            <asp:HiddenField ID="hfsave" runat="server" />
            <asp:HiddenField ID="hfdelete" runat="server" />
            <asp:HiddenField ID="hfprint" runat="server" />
            <asp:HiddenField ID="hfauth" runat="server" />
            <div class="bottompanel">
                <asp:Button ID="btndirectbking" runat="server" Text="DIRECT OT BOOKING" CssClass="buttonstandard" />
                <asp:Button ID="btnindirectbking" runat="server" Text="OT BOOKING AGAINST REQUEST" CssClass="buttonstandard" />
                <asp:Button ID="btnnewotrequest" runat="server" Text="NEW OT REQUEST" CssClass="buttonstandard" />
                <asp:Button ID="btneditrequest" runat="server" Text="EDIT OT REQUEST" CssClass="buttonstandard" />
                <asp:Button ID="btncancelrequest" runat="server" Text="CANCEL OT REQUEST" CssClass="buttonstandard" />
                <asp:Button ID="btnConvertToIp" runat="server" Text="CONVERT OP TO IP" CssClass="buttonorange" />  
                  <asp:Button ID="btnOTDashBoardSche" runat="server" Text="OT SCHEDULE DASHBOARD" CssClass="buttonstandard" />                  
                <asp:Button ID="btnPrint" runat="server" Text="PRINT" CssClass="buttonstandard" />
                <asp:Button ID="btnCancel" runat="server" CssClass="buttonstandard" Text="CANCEL" />
                <asp:Button ID="btnExit" runat="server" CssClass="buttonstandard" Text="EXIT" TabIndex="26"
                    OnClientClick="return setsession()" />
                <asp:Button ID="btnFinalPrint" Style="visibility: hidden" runat="server" Height="1px" Width="1px" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
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
            hover_row("<%=grdindirectbooking.ClientID%>");
            hover_row("<%=grdOtList.ClientID%>");
        }
    </script>
</asp:Content>
