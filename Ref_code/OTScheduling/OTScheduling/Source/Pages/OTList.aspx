
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OTList.aspx.vb" Inherits="OTScheduling.OTList" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxCntrl" %>



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

      <link runat="server" rel="stylesheet" type="text/css" id="CssCommon" href="~/Css/stylesheet.css" />
    <link runat="server" rel="stylesheet" type="text/css" id="CssButton" href="" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssAlertify" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssAlertifyBoot" />
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/validation.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script> 



        <%-- Nikita 20200429 start --%>
     <style>
        .ui-autocomplete{
            max-height :196px;
            overflow-y:auto;
            overflow-x:hidden;
        }

        .grdPadding{
            padding-left:2px;
        }
    </style>
   

  

    <script language="javascript" type="text/javascript">


          function SelectAll(spanChk) {
            var IsChecked = spanChk.checked;
            if (IsChecked) {
                var grid = window["<%= grdOTList.ClientID%>"];
                var totalrowcount = grid.rows.length;
                totalrowcount = totalrowcount - 1;
                Parent = document.getElementById("<%=grdOTList.ClientID%>");
                var items = Parent.getElementsByTagName('input');
                for (i = 0; i < items.length; i++) {
                    if (items[i].type == "checkbox") {
                        if (items[i].disabled == false) {
                            items[i].checked = true;
                        }
                    }
                }
            }
            else {
                var grid = window["<%= grdOTList.ClientID%>"];
                var totalrowcount = grid.rows.length;
                totalrowcount = totalrowcount - 1;
                Parent = document.getElementById("<%=grdOTList.ClientID%>");
                var items = Parent.getElementsByTagName('input');
                for (i = 0; i < items.length; i++) {
                    if (items[i].type == "checkbox") {
                        items[i].checked = false;
                    }
                }
                return false;
            }
        }


        function HelpImg(e, me, cntrl, RequestTyp, StylesheetType, formName, extra) {
            var AppSubMdCd = document.getElementById("ContentPlaceHolder1_HfAppMdCd").valuet
            var AppMdCd = document.getElementById("ContentPlaceHolder1_HfAppMdCd").value
            evt = e || window.event;
            // if (evt.keyCode == 113 || evt.keyCode == 0 || evt.keyCode == undefined) {
            HelpDetails(e, me, cntrl, RequestTyp, StylesheetType, formName, extra)
            //}
        }

        function Help(e, me, cntrl, RequestTyp, StylesheetType, formName, extra) {
            var AppSubMdCd = document.getElementById("ContentPlaceHolder1_HfAppMdCd").value
            var AppMdCd = document.getElementById("ContentPlaceHolder1_HfAppMdCd").value
            evt = e || window.event;
            if (evt.keyCode == 113 || evt.keyCode == 0) {
                //       if (evt.keyCode == 113 || evt.keyCode == 0 || evt.keyCode == undefined) {
                HelpDetails(e, me, cntrl, RequestTyp, StylesheetType, formName, extra)
            }
        }


        function SessionStateConfirmation() {
            alertify.alert("Session Closed", PerformAction);
            return false;
        }

        function PerformAction() {
            document.getElementById("ContentPlaceHolder1_BtnSessionState").click();
        }

        function savecnfirmation() {
            confirmAction('Do you want to save record ?', performAction); return false;
        }

        function performAction() {
            document.getElementById("ContentPlaceHolder1_btnFinalSave").click();
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

      
        function printconfirmation(msg) {
            alertify.set
              ({
                  labels:
                      {
                          ok: "YES",
                          cancel: "NO"
                      }
              });
            confirmPrintAction(msg, performprintAction); return false;
        }

        function confirmPrintAction(message, action) {
            alertify.confirm(message, function (e) {
                if (e) {
                    if (action) {
                        action();
                    }
                }
            });
        }

        function performprintAction() {
            document.getElementById("ContentPlaceHolder1_btnFinalPrint").click();
        }

        function opendefault() {
            var finalsettings = callsettings('6');
            window.open("PrintRpt.aspx", "ModalPopup", finalsettings);

        }

   
    </script>


      <script type="text/javascript">
        
    
        

   
    </script>




    <script type="text/javascript">

        //function keyupe(event) {
        //    var keycode=event.keycode
        //    alert(keycode)
        //}
        //$(document).ready(function () {

          

          

        //    //$('[id$="txtFile"]').live('keyup', function (event) {

        //    //    var keycode = (event.keycode? event.keycode :event.window)
        //    //    if (event.keycode=='13')
        //    //        alert(keycode)
        //    //    else
        //    //        alert('Key not press')
        //    //    alert(keycode)

        //    //})
        //});

    
    </script>



   

   

    <style>
        .alert-header {
            font-weight: bold;
            background: #44C5FD;
            border-bottom: #eee 1px solid;
            border-radius: 2px 2px 0 0;
            margin-bottom: 0;
            padding: 10px 0 10px 24px;
            text-align: left;
            color: #023344;
        }

        .alert-body {
            background-color: #EFEFEF;
            padding: 10px 0 10px 0;
        }

        .alert-footer {
            background: #eae6e6; /*#EFEFEF*/
            padding: 5px 10px 0 0;
            min-height: 36px;
            text-align: right;
        }

        .modal-inner-wrapper {
            background-color: #2F4F4F;
        }

            .modal-inner-wrapper .content {
                background-color: #FFFFFF;
                border: solid 1px Gray;
                z-index: 9999;
                float: right;
                margin-top: 10px;
                margin-right: 10px;
            }

                .modal-inner-wrapper .content .close {
                    float: right;
                }

                .modal-inner-wrapper .content .body {
                    margin-top: 20px;
                }



        .modal-bg {
            background-color: white;
            filter: alpha(opacity=50);
            opacity: 0.6;
            z-index: 999;
        }

        .modal {
            position: absolute;
        }

        .popup-overlay {
            position: fixed;
            left: 0px;
            top: 0px;
            display: none;
            z-index: 990;
            width: 100%;
            height: 100%;
            background-color: #191919;
            opacity: 0.7;
        }

        .btnpopupcss {
            border-radius: 4px;
            background-color: #44C5FD;
            font-family: Helvetica,Arial,sans-serif,verdana;
            color: #051117;
            font-size: 13px;
            height: 25px;
            width: 65px;
            -webkit-box-shadow: none;
            -moz-box-shadow: none;
            box-shadow: none;
            border-width: 1px;
            cursor: pointer;
            text-align: center;
            vertical-align: middle;
        }

            .btnpopupcss:focus, .btnpopupcss:hover {
                color: #fff;
                background-color: rgba(48, 132, 167, 0.95);
                text-decoration: none;
                border: 1px solid #000;
            }
    </style>

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

   <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
       
        <ContentTemplate>
            <div class="panel">
                  <asp:Panel runat="server" ID="pnl" Height="140px">
                <table cellspacing="1" cellpadding="1" style="border: 0px solid gray; padding: 1px;padding-right:1px;margin-top:2px;">
                     
                 
                   

             
                       <tr>
                                                   
                                                    <td  align="left">
                                                       
                                                            
<asp:Panel runat="server"  Width="197px" Wrap="true" GroupingText="Dates" Class="headerblue" Font-Size="Small"   ID="pnlDt" >
    
        <table cellspacing="1" cellpadding="1" border="0">
           
            
                                                            <tr>

                                                               
                                                                     <td  class="label" runat="server" id="td1" align="left" > 
                                                                         <span class="label" style="font-weight:500">
                                                                          From : </span>

                                                                         <span><asp:CheckBox ID="ChkDt" runat="server" AutoPostBack="true" OnCheckedChanged="ChkDt_CheckedChanged"/></span>
                           <asp:TextBox ID="txtFrmDate" CssClass="textbox" Width ="65px" runat="server" AutoPostBack="true"  OnTextChanged="txtFrmDate_TextChanged" ></asp:TextBox>
                                                 <AjaxCntrl:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar" Format="dd/MM/yyyy" PopupButtonID="txtFrmDate" 
                                                      TargetControlID="txtFrmDate">
                                </AjaxCntrl:CalendarExtender>

                       

                    </td>
                                                                

                                                           


                                                                
                                                              
                                                               
                              
                                                              

                                                            </tr>
            <tr>
                <td>
                                                                         <span class="label" style="font-weight:500">To:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                                         <asp:TextBox ID="txtToDate" CssClass="textbox" Width ="65px" runat="server" AutoPostBack="true"   OnTextChanged="txtToDate_TextChanged" ></asp:TextBox>
                                                 <AjaxCntrl:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar" Format="dd/MM/yyyy" PopupButtonID="txtToDate" 
                                                     TargetControlID="txtToDate">
                                </AjaxCntrl:CalendarExtender></td>

            </tr>


           <tr>
                <td style="height:14px;">
                                                                        
                 </td>


            </tr>
                                                        </table>



                                                        </asp:Panel>
   

                                                    
                                                    </td>

                            <td>
                                
<asp:Panel runat="server"  Width="142px" Wrap="true" GroupingText="Criteria" Class="headerblue" Font-Size="Small"   >


        <table cellspacing="1" cellpadding="1" border="0">
           
            
                                                            <tr>

                                                               
                                                                     <td  class="label" runat="server" id="td2" align="left"> 
                                                                         
                                                                         <span class="label" style="font-weight:500">
                                                                             <asp:RadioButton ID="RBSurgary" runat="server" AutoPostBack="true" CssClass="label" GroupName="PtnTyp" Checked="true"
                                Text="Surgary" />
                                                                         </span>
                                                                       

                       

                    </td>
                                                                

                                                           


                                                                
                                                              
                                                               
                              
                                                              

                                                            </tr>

            <tr>
                <td>
                           <span class="label" style="font-weight:500">                                               
                  <asp:RadioButton ID="RBBooking" runat="server" AutoPostBack="true" CssClass="label" GroupName="PtnTyp"
                                Text="Booking" />
                                 <span class="label" style="font-weight:500">
                               </td>



            </tr>

            <tr>
                <td style="height:14px;">
                                                                        
                 </td>


            </tr>

                                                        </table>
</asp:Panel>
                                                    
                                                    </td>


                               <td>
                                   
<asp:Panel runat="server"  Width="142px" Wrap="true" GroupingText="Status" Class="headerblue" Font-Size="Small"   >


        <table cellspacing="1" cellpadding="1" border="0">
     
            
                                                            <tr>

                                                               
                                                                     <td  class="label" runat="server" id="td3" align="left"> 
                                                                           <span class="label" style="font-weight:500">
           <asp:RadioButton ID="rdbActive" runat="server" AutoPostBack="true" CssClass="label" GroupName="Search" 
                                Text="Active" />
                                                                               </span>

                       

                    </td>
                                                                

                                                           


                                                                
                                                              
                                                               
                              
                                                              

                                                            </tr>

            <tr>
                <td>
                          <span class="label" style="font-weight:500">                                                
                  <asp:RadioButton ID="rdbCancelled" runat="server" AutoPostBack="true" CssClass="label" GroupName="Search"
                                Text="Cancelled" />
                              </span></td>


            </tr>
              <tr>
                <td>
                                <span class="label" style="font-weight:500">                                          
                  <asp:RadioButton ID="rdbAll" runat="server" AutoPostBack="true" CssClass="label" GroupName="Search" Checked="true"
                                Text="All" />
                                    
                                    </span>
                                    </td>


            </tr>

                                                        </table>
</asp:Panel>
                                                    
                                                    </td>



                               <td>
                                   
<asp:Panel runat="server"  Width="453px" Wrap="true" GroupingText="SEARCH" Class="headerblue" Font-Size="Small"   >


        <table cellspacing="1" cellpadding="1" border="0" width="430px;">
     
            
                                                            <tr>
                                                                <td>  <span class="label" style="font-weight:500">
                                                                    <asp:Label runat="server" ID="lblIpOpName" Text="OT" CssClass="label"></asp:Label>
                                                                    </span></td>
                                                            
                                                                     <td  class="label" runat="server" id="td4" align="left"> 
                                                                           <span class="label" style="font-weight:500">
                                                                               
                            <asp:ImageButton ID="ImgBtnOT" runat="server" ToolTip="OT HELP" ImageUrl="~/Images/Search.ico"
                                OnClientClick="javascript:HelpImg(event,this,'txtIpOpNo','IpNo','1','InPatientHelp.aspx','extra');"
                                Width="16px" />

             <asp:TextBox ID="txtOT" runat="server" CssClass="textbox" ForeColor="Black"
                                AutoPostBack="true" OnTextChanged="txtOT_TextChanged"
                                Width="100px" BackColor="White"  TabIndex="1"></asp:TextBox>
                   <asp:TextBox ID="txtOTDesc" runat="server" CssClass="textbox" ForeColor="Black" BackColor="White" Width="225px" MaxLength="50"   TabIndex="2"></asp:TextBox>
                  </span>
                        </td>

                                                                               

                       

                 
                                                                

                                                           


                                                                
                                                              
                                                               
                              
                                                              

                                                            </tr>

            <tr>
                

              
                         <td>  <span class="label" style="font-weight:500">
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
                

              
                         <td>  <span class="label" style="font-weight:500">
                                                                    <asp:Label runat="server" ID="Label4" Text="Patient Type:" CssClass="label"></asp:Label>
                                                                    </span>



                         </td>
              

                  <td>
                     &nbsp; &nbsp; &nbsp;

                       <asp:DropDownList ID="ddlPtnTypByUser" runat="server" CssClass="dropdownlist" Width="333px"  AutoPostBack="true" ToolTip="Patient Type"></asp:DropDownList>

                  </td>
                  </tr>

                <tr>
                <td style="height:14px;">
                                                                        
                 </td>


            </tr>

                                                        </table>
</asp:Panel>
                                                    
                                                    </td>



                     
                                              

                                          
                             
                                      <td align="right">
     
        <asp:Button ID="btnSearch" runat="server" CssClass="buttonstandard" Text="SHOW" Height="38px" Width="106px"  OnClick="btnSearch_Click" />
      </td>
                                                </tr>
                 
                             
 
                 
                </table>

                    

                       </asp:Panel>
            </div>

            <div>

                  <asp:Panel runat="server" ID="pnlPrevAdjData" Height="352px" ScrollBars="Auto">


                        <asp:GridView ID="grdOTList" AlternatingRowStyle-CssClass="Alternategridrows" runat="server"   OnRowDataBound="grdOTList_RowDataBound"
                                                AllowSorting="false" AutoGenerateColumns="false" HeaderStyle-CssClass="gridcolumnheader" 
                                                GridLines="Both" CssClass="gridrows" visible="true" Width="1339px" EmptyDataText="No Record Found"
                                                Height="100%" ShowHeaderWhenEmpty="true">
                                                <Columns>
                                                   
                                                    <asp:TemplateField HeaderText="SEL" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">

                                                          <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll"  onclick="javascript:SelectAll(this);" AutoPostBack="true" runat="server" Text="" />
                                </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkselect" AutoPostBack="true"  runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="SR NO" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSrNo" Width="30px" Text='<%#Container.DataItemIndex + 1 %>' 
                                                                CssClass="AlignLeft"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                       <asp:TemplateField HeaderText="SURGERY DATE" Visible="true" HeaderStyle-Width="30px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSurgeryDt"  Text='<%#Eval("APTMDATE", "{0:dd/MM/yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>



                                                    
                                                       <asp:TemplateField HeaderText="BOOKING TIME" Visible="true" HeaderStyle-Width="30px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblBkTm"  Text='<%#Eval("CRTDTTM", "{hh:mm tt}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                  


      <asp:TemplateField HeaderText="OT" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblOT" Width="70px"   Text='<%# Eval("PtnNo")%>' 
                                                                CssClass="AlignLeft"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    
                                                     
                                                       <asp:TemplateField HeaderText="FROM  TIME" Visible="true" HeaderStyle-Width="30px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblfrmtm"   Text='<%#Eval("APTMTMFROM").ToString() %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>




                                                      
                                                      
                                                       <asp:TemplateField HeaderText="TO  TIME" Visible="true" HeaderStyle-Width="30px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbltotm"   Text='<%#Eval("APTMTMTO").ToString() %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>




                                                    
                                                    
                                                         <asp:TemplateField HeaderText="SURGEON" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSurgeon" Width="100px" Text='<%# Eval("DOCNAME")%>' 
                                                                CssClass="AlignLeft"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    
                                                         <asp:TemplateField HeaderText="SURGERY" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblSurgey" Width="100px" Text='<%# Eval("SurgeyName")%>' 
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



                                                        <asp:TemplateField HeaderText="PATIENT NAME" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="200px" HeaderStyle-CssClass="grdPadding" ItemStyle-CssClass="grdPadding">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblPtnName" Width="200px" Text='<%# Eval("PTNLNGNM")%>' 
                                                                CssClass="AlignLeft"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    


                                                 

                                                    
                                                  

                                               

                                                   


                                                      
                                                  

                                                  


                                                   







                                                   

                                                    




                                                    

                                                   

                                                    
                                                    
                                                  



                                                       


                                                    


                                                  




                                                  


                                                    


                                                 
                                                  

                                               
                                                  
                                               
                                                
                                                

                                                   

                                                  



                                                </Columns>
                                            </asp:GridView>


                </asp:Panel>

            </div>

            <div style="text-align: right;" class="label">
          <span style="text-align: right;" class="label">TOTAL:</span>
                   <asp:TextBox ID="txttotal"  runat="server" Width="150px" AutoPostBack="true" CssClass="textboxRightAlign"></asp:TextBox>
                            

               
            </div>
          
            <div class="bottompanel">
                <table>
                    <tr>
                     
                        <td>
                            <asp:Button runat="server" ID="btnClear" Text="CLEAR" CssClass="buttonstandard" />
                        </td>
                      
                        <td>
                            <asp:Button ID="btnExit" runat="server" CssClass="buttonstandard" Text="EXIT" />

                               <asp:Button runat="server" ID="btnexport" Text="export" CssClass="buttonstandard"   Visible="false"/>
                        </td>

                      
                        <td>
                            <asp:Button ID="BtnSessionState" runat="server" Style="visibility: hidden" />
                        </td>
                        <td>
                          
                             <asp:HiddenField runat="server" ID="hdnPtnNo" />
                            <asp:HiddenField runat="server" ID="hfGlDtlsPath" />
                        </td>
                        <td>
                            <asp:HiddenField ID="HfAppMdCd" runat="server" />
                            <asp:HiddenField ID="HfAppSubMdCd" runat="server" />
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







<%--    report popup start--%>

    








                
    
</asp:Content>

</form>
</body>
</html>