<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage.master" CodeBehind="ViewPrint.aspx.vb" Inherits="OTScheduling.ViewPrint" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function opendefault() {
            //alert('Hello 1');
            var finalsettings = callsettings('6');
            window.open("printrpt.aspx", "ModalPopUp", finalsettings);
            //alert('Hello 2');
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uProgess1" DynamicLayout="true" DisplayAfter="1">
        <ProgressTemplate>
            <img id="Img1" alt="" src="~/Images/animated.gif" runat="server" style="position: absolute; left: 498px; top: 126px; width: 39px; height: 27px;" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="UpdMain">
        <ContentTemplate>
            <center>
                <table style="width: 60%; border: 1px solid black; margin: 5px 0px 0px 0px;">
                    <tr>
                        <td colspan="4">
                            <asp:Label Text="SELECT PARAMETERS FOR OT SCHEDULING" runat="server" CssClass="label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:RadioButtonList runat="server" CssClass="label" ID="rdbSelectionRpt" AutoPostBack="true" OnSelectedIndexChanged="rdbSelectionRpt_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem Text="OT REGISTER" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="OT REGISTER DATE WISE" Value="2"></asp:ListItem>
                                <asp:ListItem Text="DOCTOR WISE SURGERY LIST" Value="3"></asp:ListItem>
                                <asp:ListItem Text="OT CANCEL LIST" Value="4"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="SELECT OT" runat="server" CssClass="label"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Search.ico" Width="16px" 
                                OnClientClick="javascript:HelpImg(event,this,'txtot','OT','1','OTSearch.aspx','extra');return false;" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtot" runat="server" Width="100px" AutoPostBack="true" MaxLength="4" 
                                onkeypress="ValidateNum(this);" CssClass="textbox"
                                 onkeyup="javascript:Help(event,this,'txtot','OT','1','OTSearch.aspx','extra');return false;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtotname" runat="server" ToolTip="OT Name" MaxLength="4" ReadOnly="true" Width="400px" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="OPERATING DOCTOR" runat="server" CssClass="label"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="imageSearchDoc" runat="server" ImageUrl="~/Images/Search.ico" OnClientClick="javascript:HelpImg(event,this,'txtdctid','DctNo','2','DoctorSearch.aspx','extra');return false;" Width="16px" ToolTip="Doctor Help" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtdctid" AutoPostBack="true" ForeColor="Black" BackColor="white" runat="server" onkeypress="ValidateNum(this);" MaxLength="4"
                                CssClass="textbox" Width="100px" onkeyup="javascript:Help(event,this,'txtdctid','DctNo','2','DoctorSearch.aspx','extra');return false;" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtdctname" ReadOnly="true" runat="server" CssClass="NotEditabletextbox" Width="400px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox Text="DATE RANGE BETWEEN" runat="server" ID="chkDtRng" CssClass="label" AutoPostBack="true" OnCheckedChanged="chkDtRng_CheckedChanged"></asp:CheckBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtFrmDt" runat="server" Width="100px" CssClass="textbox" Enabled="false"></asp:TextBox>
                            <asp:CalendarExtender ID="toCal1" runat="server" CssClass="MyCalendar" Format="dd/MM/yyyy" PopupButtonID="txtFrmDt" TargetControlID="txtFrmDt"></asp:CalendarExtender>
                        </td>
                        <td>
                            <asp:Label Text="AND" runat="server" CssClass="label"></asp:Label>
                            <asp:TextBox ID="txtToDt" runat="server" Width="100px" CssClass="textbox" Enabled="false"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar" Format="dd/MM/yyyy" PopupButtonID="txtToDt" TargetControlID="txtToDt"></asp:CalendarExtender>
                      
                            
                            &nbsp;
                            <asp:Label Text="BOOKING TYPE" runat="server" CssClass="label"></asp:Label>
                      <%--  </td>

                        <td>--%>
                             <asp:DropDownList runat="server" CssClass ="dropdownlist" ID="drpBookingType" Width="185px"></asp:DropDownList>
     
                              </td>
                    </tr>
                </table>
                <div class="bottompanel">
                    <asp:Button runat="server" ID="btnPrint" Text="PRINT" CssClass="buttonstandard" Width="100" OnClick="btnPrint_Click" />
                    <asp:Button runat="server" ID="btnClear" Text="CLEAR" CssClass="buttonstandard" Width="100" OnClick="btnClear_Click" />
                    <asp:Button runat="server" ID="btnBack" Text="BACK" CssClass="buttonstandard" Width="100" OnClick="btnBack_Click" />
                    <asp:HiddenField ID="HfAppMdCd" runat="server" />
                    <asp:HiddenField ID="HfAppSubMdCd" runat="server" />
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
