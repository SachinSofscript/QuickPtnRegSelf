<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage.master" CodeBehind="OtDashboardSch.aspx.vb" Inherits="OTScheduling.OtDashboardSch" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxCntrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

       <link href="~/Media/layout.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/DayPilot/modal.js" type="text/javascript"></script>
    <script src="Scripts/DayPilot/event_handling.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript" ></script> 
    
    <link href="../CSS/ModelPopup.css" rel="stylesheet" />


    <script type="text/javascript" > 
        function OpenPopUp(e) { 
            document.getElementById("<%=hdnDeleteValue.ClientID%>").value = e.value();
            document.getElementById("<%=btnAppCancel.ClientID%>").click();
            
        }
        

        function eventClick1(e) { 
            var modal = dialog();
            alert('hi02');
                modal.alert("HID");
               // modal.showUrl("Edit.aspx?id=" + e.value()); 
        }
    </script>

  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
       <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

        <asp:UpdatePanel runat="server" ID="UpPopupCovertOpToIp" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <asp:Panel ID="divOverlayPopupCovertOpToIp" ClientIDMode="Static" runat="server" CssClass="popup-overlay"></asp:Panel>
            <div id="divPopupCovertOpToIp" runat="server" style="position: fixed; z-index: 991; left: 0; height: 100%; width: 100%;" visible="false">
                <center>
                    <div class="alert-header" style="padding: 0px ;width: 521px;">
                    <div class="divHeader">
                        <table>
                            <tr>
                                <td style="width: 500px">
                                    <span runat="server">CANCEL BOOKING</span> <asp:Label runat="server" Text ="" ID="lblApptNo"> </asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="btnclosePopUp" runat="server" CssClass="close" Text="X" />
                                </td>
                            </tr>
                        </table>

                    </div>
                    <div class="alert-body">
                        <table style="width: 100%">
                            <tr>
                                <td colspan="10">
                                    <table>
                                        <tr>
                                            <td style="width: 150px">
                                                <span style="color: darkred;">Cancel Remark</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCnclRmrk"  placeholder="Enter Remark" TextMode="MultiLine" ForeColor="Black" BackColor="White" runat="server" CssClass="textbox" MaxLength="255" Width="400px" Height="79px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Label Text="" ID="lblErrMsg" runat="server" ForeColor="Red" Font-Size="Small" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button Text="CANCEL BOOKING" Width="250px" CssClass="btnpopupcss" ID="btncnclBkng" runat="server" OnClick="btncnclBkng_Click" />

                                                <asp:Button Text="finalCanclBkg" Style="display:none" ID="btnFnlCanclBkg" OnClick="btnFnlCanclBkg_Click" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>

                    </div>
                </div>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
       

    <asp:UpdatePanel ID="pnlMain" runat="server">
        <ContentTemplate>
                <div>
                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                        <tr align="center">
                            <td>
                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                    <tr> 
                                        <td align="center" cellpadding="0" border="0" >
                                            <table >
                                                <tr>
                                                      
                                                   <td class="label" style="color: #cf231b; font-size: larger">SELECT DATE &nbsp;&nbsp;</td>
                                                    <td>
                                                <asp:LinkButton runat="server" ID="lnkPrev" OnClick="lnkPrev_Click" Font-Size="xx-large"  Text="<" ToolTip="Previous"> 
                                    </asp:LinkButton>
                                                </td>

                                        <td> 
                                            <asp:TextBox ID="txtFrmDate"   CssClass="textbox" Width="147px" runat="server" AutoPostBack="true" OnTextChanged="txtFrmDate_TextChanged" Font-Size="Larger" Height="31px"></asp:TextBox>
 
                                                <AjaxCntrl:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar" Format="dd/MM/yyyy" PopupButtonID="txtFrmDate"
                                                    TargetControlID="txtFrmDate">
                                                </AjaxCntrl:CalendarExtender>


                                        </td> <td>
                                    <asp:LinkButton runat="server" ID="lnkNext" OnClick="lnkNext_Click" Font-Size="xx-large"  Text=">" ToolTip="Next">
                                         
                                    </asp:LinkButton>
                                            </td>
                                                </tr>
                                            </table>
                                        </td>

                            <td align="right" style="width:100px">
                              
                            </td>

                                    </tr>
                                </table>
                            </td>
                            <td></td>
                        </tr>
                    </table>

                </div>


            <div class="daypilot-main">

                <DayPilot:DayPilotScheduler
                    ID="DayPilotScheduler1" runat="server" CellDuration="15"  CellGroupBy="Hour" CellWidth="25" DataEndField="ToDTTm"
                    DataStartField="FrmDTtm"
                    DataTextField="SurgeonName"
                    DataValueField="APPTNO"
                    DataResourceField="FCTCODE" Days="1"
                    EventMoveHandling="CallBack"
                    OnEventMenuClick="DayPilotScheduler1_EventMenuClick"
                    EventResizeHandling="CallBack"
                    ContextMenuID="DayPilotMenu1"
                    OnEventResize="DayPilotScheduler1_EventResize"
                    OnEventMove="DayPilotScheduler1_EventMove"
                    TimeRangeSelectedJavaScript="timeRangeSelected(start, end, resource);"
                    TimeRangeSelectedHandling="JavaScript"
                    EventClickHandling="JavaScript"
                    EventClickJavaScript="eventClick(e);" 
                    ClientObjectName="dp"
                    OnCommand="DayPilotScheduler1_Command"
                    ShowEventStartEnd="false"
                    OnBeforeEventRender="DayPilotScheduler1_BeforeEventRender1"
                    Width="100%"
                    Height="420" LoadingLabelText="Loading Data"
                    AfterRenderJavaScript="afterRender();" EventHeight="60" CornerText=""  >
                </DayPilot:DayPilotScheduler> 

                <DayPilot:DayPilotMenu ID="DayPilotMenu1" runat="server">
                    <DayPilot:MenuItem Text="Cancel Appointment" Action="JavaScript"  JavaScript="OpenPopUp(e);"></DayPilot:MenuItem>
                </DayPilot:DayPilotMenu> 
 

                  
                  
            </div>  

             <div class="bottompanel">
              <asp:Button Text="BACK" ID="btnBack" runat="server" CssClass="buttonstandard" OnClick="btnBack_Click" />
               <asp:HiddenField ID="HfAppMdCd" runat="server" />
               <asp:HiddenField ID="HfAppSubMdCd" runat="server" />
                <asp:HiddenField ID="hfaccess" runat="server" />
                    <asp:HiddenField ID="hfsave" runat="server" />
     <asp:HiddenField ID="hfdelete" runat="server" />
    <asp:HiddenField ID="hfprint" runat="server" />
    <asp:HiddenField ID="hfauth" runat="server" />
                    <asp:HiddenField ID="hdnDeleteValue" runat="server" />

             <asp:Button  Style="display:none"   ID="btnAppCancel"  CssClass="buttonstandard" runat="server" OnClick="btnAppCancel_Click" />
                 </div>
         
            </ContentTemplate>
        </asp:UpdatePanel>

    
       
</asp:Content>
