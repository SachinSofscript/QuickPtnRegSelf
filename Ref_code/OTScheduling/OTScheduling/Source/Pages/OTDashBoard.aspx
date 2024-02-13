<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage.master" CodeBehind="OTDashBoard.aspx.vb" Inherits="OTScheduling.OTDashBoard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxCntrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--  <script type="text/javascript" src="../Scripts/colResizable-1.6.min"></script>

    <script type="text/javascript" src="../Scripts/colResizable-1.6"></script>--%>

    <script type="text/javascript">

        function SetReturnValue1() {

            __doPostBack();
        }


        <%--  function   ResizeCol() {
            debugger;
            $("<%= grdOtList.ClientID%>").colResizable({
                liveDrag: true,
                //gripInnerHtml : '<div class=gip>'

                dragginClass:"dragging",
            });

        }--%>
    </script>

    <script type="text/javascript" language="javascript">


        function setsession1() {
            sessionStorage.setItem('forcelogout', 1);
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



        function savecnfirmation() {
            confirmAction('Are you sure want to save Record?', performAction); return false;
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







   <%-- function funAddValues(Code, Desc, txt1, txt2) {
        var newElem1 = document.getElementById("<%=txtpatid.ClientID%>");
        newElem1.value = Code;
        var newElem1 = document.getElementById("<%=txtpatname.ClientID%>");
            newElem1.value = Desc;
         
            enablepanel1()
             return false;
         }--%>


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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
            <div class="panel">
                <asp:Panel runat="server" ID="pnl" Height="140px">
                    <table cellspacing="1" cellpadding="1" style="border: 0px solid gray; padding: 1px; padding-right: 1px; margin-top: 2px;">





                        <tr>

                            <td align="left">


                                <asp:Panel runat="server" Width="197px" Wrap="true" GroupingText="Dates" Class="headerblue" Font-Size="Small" ID="pnlDt">

                                    <table cellspacing="1" cellpadding="1" border="0">


                                        <tr>


                                            <td class="label" runat="server" id="td1" align="left">
                                                <span class="label" style="font-weight: 500">From : </span>

                                                <span>
                                                    <asp:CheckBox ID="ChkDt" runat="server" AutoPostBack="true" OnCheckedChanged="ChkDt_CheckedChanged" /></span>
                                                <asp:TextBox ID="txtFrmDate" CssClass="textbox" Width="65px" runat="server" AutoPostBack="true" OnTextChanged="txtFrmDate_TextChanged"></asp:TextBox>
                                                <AjaxCntrl:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar" Format="dd/MM/yyyy" PopupButtonID="txtFrmDate"
                                                    TargetControlID="txtFrmDate">
                                                </AjaxCntrl:CalendarExtender>



                                            </td>











                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label" style="font-weight: 500">To:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                <asp:TextBox ID="txtToDate" CssClass="textbox" Width="65px" runat="server" AutoPostBack="true" OnTextChanged="txtToDate_TextChanged"></asp:TextBox>
                                                <AjaxCntrl:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar" Format="dd/MM/yyyy" PopupButtonID="txtToDate"
                                                    TargetControlID="txtToDate">
                                                </AjaxCntrl:CalendarExtender>
                                            </td>

                                        </tr>


                                        <tr>
                                            <td style="height: 14px;"></td>


                                        </tr>
                                    </table>



                                </asp:Panel>



                            </td>

                            <td>

                                <asp:Panel runat="server" Width="142px" Wrap="true" GroupingText="Criteria" Class="headerblue" Font-Size="Small">


                                    <table cellspacing="1" cellpadding="1" border="0">


                                        <tr>


                                            <td class="label" runat="server" id="td2" align="left">

                                                <span class="label" style="font-weight: 500">
                                                    <asp:RadioButton ID="RBSurgary" runat="server" AutoPostBack="true" CssClass="label" GroupName="PtnTyp" Checked="true"
                                                        Text="Surgary" />
                                                </span>




                                            </td>











                                        </tr>

                                        <tr>
                                            <td>
                                                <span class="label" style="font-weight: 500">
                                                    <asp:RadioButton ID="RBBooking" runat="server" AutoPostBack="true" CssClass="label" GroupName="PtnTyp"
                                                        Text="Booking" />
                                                    <span class="label" style="font-weight: 500"></td>



                                        </tr>

                                        <tr>
                                            <td style="height: 14px;"></td>


                                        </tr>

                                    </table>
                                </asp:Panel>

                            </td>


                            <td>

                                <asp:Panel runat="server" Width="142px" Wrap="true" GroupingText="Status" Class="headerblue" Font-Size="Small">


                                    <table cellspacing="1" cellpadding="1" border="0">


                                        <tr>


                                            <td class="label" runat="server" id="td3" align="left">
                                                <span class="label" style="font-weight: 500">
                                                    <asp:RadioButton ID="rdbActive" runat="server" AutoPostBack="true"  Checked="true" CssClass="label" GroupName="Search"
                                                        Text="Active" />
                                                </span>



                                            </td>

                                        </tr>

                                        <tr>
                                            <td>
                                                <span class="label" style="font-weight: 500">
                                                    <asp:RadioButton ID="rdbCancelled" runat="server" AutoPostBack="true" CssClass="label" GroupName="Search"
                                                        Text="Cancelled" />
                                                </span></td>


                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label" style="font-weight: 500">
                                                    <asp:RadioButton ID="rdbAll" runat="server" AutoPostBack="true" CssClass="label" GroupName="Search"
                                                        Text="All" />

                                                </span>
                                            </td>


                                        </tr>

                                    </table>
                                </asp:Panel>

                            </td>



                            <td>

                                <asp:Panel runat="server" Width="453px" Wrap="true" GroupingText="SEARCH" Class="headerblue" Font-Size="Small">


                                    <table cellspacing="1" cellpadding="1" border="0" width="430px;">


                                        <tr>
                                            <td><span class="label" style="font-weight: 500">
                                                <asp:Label runat="server" ID="lblIpOpName" Text="OT" CssClass="label"></asp:Label>
                                            </span></td>

                                            <td class="label" runat="server" id="td4" align="left">
                                                <span class="label" style="font-weight: 500">

                                                    <asp:ImageButton ID="ImgBtnOT" runat="server" ToolTip="OT HELP" ImageUrl="~/Images/Search.ico"
                                                        OnClientClick="javascript:HelpImg(event,this,'txtOT','OT','1','OTHelp.aspx','extra');return false;"
                                                        Width="16px" />

                                                    <asp:TextBox ID="txtOT" runat="server" CssClass="textbox" ForeColor="Black" onkeypress="ValidateNum(this);"
                                                        AutoPostBack="true" OnTextChanged="txtOT_TextChanged"
                                                        onkeyup="javascript:Help(event,this,'txtOT','OT','1','OTHelp.aspx','extra');return false;"
                                                        Width="100px" BackColor="White" TabIndex="1"></asp:TextBox>
                                                    <asp:TextBox ID="txtOTDesc" runat="server" CssClass="textbox" ForeColor="Black" BackColor="White" Width="225px" MaxLength="50" TabIndex="2"></asp:TextBox>
                                                </span>
                                            </td>

















                                        </tr>

                                        <tr>



                                            <td><span class="label" style="font-weight: 500">
                                                <asp:Label runat="server" ID="Label1" Text="Cr Company:" CssClass="label"></asp:Label>
                                            </span></td>
                                            <td>

                                                <asp:ImageButton ID="ImgBtnCreditCo" runat="server" ToolTip="Company help" ImageUrl="~/Images/Search.ico"
                                                    OnClientClick="javascript:HelpImg(event,this,'txtCreditCoCd','CreditCo','1','CreditCompHelp.aspx','extra');"
                                                    Width="16px" />


                                                <asp:TextBox ID="txtCreditCoCd" runat="server" CssClass="textbox" ForeColor="Black"
                                                    AutoPostBack="true" MaxLength="9" onkeypress="ValidateNum(this);" onkeyup="javascript:Help(event,this,'txtCreditCoCd','CreditCo','1','CreditCompHelp.aspx','extra');"
                                                    Width="100px" BackColor="White" placeholder="Enter Company" ToolTip="Enter Company Code" TabIndex="1"></asp:TextBox>

                                                <asp:TextBox ID="txtCreditCoDcd" runat="server" CssClass="textbox" ForeColor="Black"
                                                    BackColor="White" Width="225px" MaxLength="50" placeholder="Enter Company Description" ToolTip="Enter Company Description" TabIndex="2"></asp:TextBox>

                                            </td>


                                        </tr>


                                        <tr>



                                            <td><span class="label" style="font-weight: 500">
                                                <asp:Label runat="server" ID="Label4" Text="Patient Type:" CssClass="label"></asp:Label>
                                            </span>



                                            </td>


                                            <td>&nbsp; &nbsp; &nbsp;

                       <asp:DropDownList ID="ddlPtnTypByUser" runat="server" CssClass="dropdownlist" Width="333px" AutoPostBack="true" ToolTip="Patient Type"></asp:DropDownList>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="height: 14px;"></td>


                                        </tr>

                                    </table>
                                </asp:Panel>

                            </td>






                            <td>&nbsp;&nbsp;&nbsp;</td>

                            <td align="right">

                                <asp:Button ID="btnSearch" runat="server" CssClass="buttonstandard" Text="SHOW" Height="38px" Width="106px" OnClick="btnSearch_Click" />
                            </td>
                        </tr>




                    </table>



                </asp:Panel>
            </div>

            <div>

                <asp:Panel runat="server" ID="pnlPrevAdjData" Height="352px" ScrollBars="Auto">


                    <asp:GridView ID="grdOTList" AlternatingRowStyle-CssClass="Alternategridrows" runat="server" OnRowDataBound="grdOTList_RowDataBound"
                        AllowSorting="false" AutoGenerateColumns="false" HeaderStyle-CssClass="gridcolumnheader"
                        GridLines="Both" CssClass="gridrows" Visible="true" Width="2509px" EmptyDataText="No Record Found"
                        Height="100%" ShowHeaderWhenEmpty="true">
                        <Columns>



                            <asp:TemplateField HeaderText="Sr No." HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblSrNo" Width="30px" Text='<%#Container.DataItemIndex + 1 %>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Surgery Date" Visible="true" HeaderStyle-Width="60px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding" ItemStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblSurgeryDt" Text='<%#Eval("APTM_DATE")%>' Width="60px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Bkg. Date" Visible="true" HeaderStyle-Width="55px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblBkngDtTm" Text='<%#Eval("CRTDTTM", "{0:dd/MM/yyyy}")%>' Width="55px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>




                            <asp:TemplateField HeaderText="Bkg. Time" Visible="true" HeaderStyle-Width="45px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblBkTm" Text='<%# DateTime.Parse(Eval("CRTDTTM").ToString()).ToString("hh:mm tt")%>' Width="45px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>





                            <asp:TemplateField HeaderText="Theatre" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="60px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblOT" Text='<%# Eval("fct_name")%>'
                                        CssClass="AlignLeft" Width="60px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>




                            <asp:TemplateField HeaderText="From Tm" Visible="true" HeaderStyle-Width="45px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding" ItemStyle-Width="45px">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblfrmtm" Width="45px" Text='<%#Eval("Frmtm").ToString() %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>






                            <asp:TemplateField HeaderText="To Tm" Visible="true" HeaderStyle-Width="35px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding" ItemStyle-Width="35px">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lbltotm" Width="35px" Text='<%#Eval("ToTm").ToString() %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>





                            <asp:TemplateField HeaderText="Booking Doctor" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="85px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblDrName" Width="85px" Text='<%# Eval("DOCNAME")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Surgon & Assistant Surgon Name" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="85px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding" ItemStyle-Width="85px">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblSurgeon" Width="85px" Text='<%# Eval("SurgeonName")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Surgery" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="110px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding" ItemStyle-Width="110px">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblSurgey" Width="110px" Text='<%# Eval("SurgeyName")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            
                                                        
                             <asp:TemplateField HeaderText="Remark" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="110px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblRemark" Width="110px" Text='<%# Eval("APPTRMRK")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%-- 
                                                         <asp:TemplateField HeaderText="MR No" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblPtnNo" Width="100px" Text='<%# Eval("PtnNo")%>' 
                                                                CssClass="AlignLeft"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>


                            <asp:TemplateField HeaderText="Patient No" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="50px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPtnNO" Width="50px" Text='<%# Eval("PTNNO")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Ip No" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="50px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblIpNo" Width="50px" Text='<%# Eval("IPNO")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>




                            <asp:TemplateField HeaderText="Patient Name" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="140px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPtnName" Width="140px" Text='<%# Eval("PTNLNGNM")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>




                            <asp:TemplateField HeaderText="Bkg. Type" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="60px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblBookingType" Width="60px" Text='<%# Eval("BOOKING_TYPE_DCD")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Type of Anaesthesia" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="120px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblAnaesthesia" Width="120px" Text='<%# Eval("AnesthesiaTyp")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Anaesthetist" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblAnaesthetist" Width="100px" Text='<%# Eval("ANAESTHESIST")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>






                            <asp:TemplateField HeaderText="Appt No" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="50px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblApptNo" Width="50px" Text='<%# Eval("APPTNO")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>




                            <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="60px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblStatus" Width="60px" Text='<%# Eval("APPTMSTSDCD")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Patient Category" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="90px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPtnCategory" Width="90px" Text='<%# Eval("PtnType")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>




                            <asp:TemplateField HeaderText="Credit Company" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="150px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblCrComp" Width="150px" Text='<%# Eval("ArDcd")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>






                            <asp:TemplateField HeaderText="Bed No." HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="50px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblBedNo" Width="50px" Text='<%# Eval("Bedno")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Patient Class" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPtnClass" Width="80px" Text='<%# Eval("PatientClassCodeDesc")%>'
                                        CssClass="AlignLeft"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>















































































                        </Columns>
                    </asp:GridView>


                </asp:Panel>

            </div>


            <div class="bottompanel">
                <table>
                    <tr>

                        <td>
                            <asp:Button runat="server" ID="btnClear" Text="CLEAR" CssClass="buttonstandard" />
                        </td>

                        <td>
                            <asp:Button ID="btnBack" runat="server" CssClass="buttonstandard" Text="BACK" OnClick="btnBack_Click" />

                            <asp:Button runat="server" ID="btnexport" Text="export" CssClass="buttonstandard" Visible="false" />
                        </td>


                        <td>
                            <asp:Button ID="BtnSessionState" runat="server" Style="visibility: hidden" />
                        </td>
                        <td>

                            <asp:HiddenField runat="server" ID="hdnPtnNo" />
                            <asp:HiddenField runat="server" ID="hfGlDtlsPath" />
                        </td>
                        <td>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <asp:HiddenField ID="hdnNewFileName" runat="server" />
                            <asp:HiddenField ID="hdnActFileName" runat="server" />


                            <asp:HiddenField ID="HfDocNo" runat="server" />
                            <asp:HiddenField ID="HfVchDt" runat="server" />
                            <asp:HiddenField ID="HfDocTyp" runat="server" />
                            <asp:HiddenField ID="HfDocTag" runat="server" />
                            <asp:HiddenField ID="hfAccntNo" runat="server" />

                        </td>
                    </tr>
                </table>
            </div>

        </ContentTemplate>


    </asp:UpdatePanel>


    <asp:HiddenField ID="HfAppMdCd" runat="server" />
    <asp:HiddenField ID="HfAppSubMdCd" runat="server" />
    <asp:HiddenField ID="hfaccess" runat="server" />
    <asp:HiddenField ID="hfsave" runat="server" />
    <asp:HiddenField ID="hfdelete" runat="server" />
    <asp:HiddenField ID="hfprint" runat="server" />
    <asp:HiddenField ID="hfauth" runat="server" />

</asp:Content>
