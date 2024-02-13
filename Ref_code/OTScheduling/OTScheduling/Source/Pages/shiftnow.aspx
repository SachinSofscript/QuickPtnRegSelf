<%@ Page Language="VB" AutoEventWireup="false" Inherits="OTScheduling.Pages_shiftnow" CodeBehind="shiftnow.aspx.vb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="~/..\CSS\stylesheet.CSS" type="text/css" rel="stylesheet" />
    <link href="~/..\CSS\ButtonStyles.css" type="text/css" rel="stylesheet" />
    <link href="~/..\CSS\alertify.core.CSS" type="text/css" rel="stylesheet" />
    <link href="~/..\CSS\alertify.bootstrap.CSS" rel="stylesheet" type="text/css" />
    <link href="~/..\CSS\Master.CSS" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\jquery-1.10.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\alertify.min.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\alertify.js"></script>
    <script type="text/javascript" language="javascript" src="~\..\..\..\Scripts\validation.js"></script>

   
<%--        <link runat="server" rel="stylesheet" type="text/css" id="csscommon" href="~/css/stylesheet.css" />
    <link runat="server" rel="stylesheet" type="text/css" id="cssbutton" href="" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssalertify" />
    <link runat="server" rel="stylesheet" type="text/css" href="" id="cssalertifyboot" />
    <script type="text/javascript" src="../scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../scripts/alertify.min.js"></script>
    <script type="text/javascript" src="../scripts/alertify.js"></script>
    <script type="text/javascript" src="../scripts/validation.js"></script>
    <script type="text/javascript" src="../scripts/jquery.min.js"></script> --%>

    <script type="text/javascript" language="javascript">

        function popitupOT(url) {
            var MyArgs = window.showModalDialog(url, 'name', 'height=480,width=800');
            if (MyArgs == null) { }
            else
            {
                document.getElementById("txtot").value = MyArgs[0];
                return false;
            }
            MyArgs = null;
            if (window.focus) {
                MyArgs.focus()
            }
            return false;
        }

        function closewin() {
            if (document.getElementById("txtflag").value == "A") {
                window.opener.setshiftnow();
                window.close();
            }
        }

        function gethrs() {
            document.getElementById("txthrs").value = $('#selhrs>option:selected').text();
        }

        function getmins() {
            document.getElementById("txtmins").value = $('#selmins>option:selected').text();
        }

        function getdetails()
        { return false; }

        function FinalValidations() {
            if (document.getElementById("txthrs").value == '') {
                document.getElementById("txthrs").focus();
                alertify.alert("Enter Hours");
                return false;
            }
            if (document.getElementById("txtmins").value == '') {
                document.getElementById("txtmins").focus();
                alertify.alert("Enter Minutes");
                return false;
            }
            if (document.getElementById("txtstrttm1").value == '') {
                document.getElementById("txtstrttm1").focus();
                alertify.alert("Enter Start Time");
                return false;
            }
            if (document.getElementById("txthrs").value > 24) {
                document.getElementById("txthrs").focus();
                alertify.alert("Enter Valid Hours");
                return false;
            }
            if (document.getElementById("txtmins").value > 59) {
                document.getElementById("txtmins").focus();
                alertify.alert("Enter Valid Minutes");
                return false;
            }
            if (document.getElementById("txthrs").value == '00' && document.getElementById("txtmins").value == '00') {
                document.getElementById("txtmins").focus();
                alertify.alert("Enter Valid Hours & Minutes");
                return false;
            }
            return true;
        }

        function Clr() {
            document.getElementById("txtot").value = '';
            document.getElementById("txthrs").value = '';
            document.getElementById("txthrs").value = '';
            document.getElementById("txthrs").value = '';
            document.getElementById("txthrs").value = '';
            document.getElementById("txthrs").value = '';
            document.getElementById("txthrs").value = '';
            document.getElementById("txthrs").value = '';
            document.getElementById("txthrs").value = '';
        }

        $(document).ready(function () {
            $("#ContentPlaceHolder1_btnsave").bind("click", function () {
                return ChkShiftNowRecord();
            });
        });

        function ChkShiftNowRecord() {
            confirmAction('Are You Sure Want To Shift Appointment', performAction);
            return false;
        }

        function performAction() {
            document.getElementById("ContentPlaceHolder1_btnsave").click();
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

        function validateTime1(time) {
            var d = new Date();
            var hrs = d.getHours();
            var min = d.getMinutes();

            if ((min < 10) || ((min.length) < 2)) {
                min = "0" + min;
            }

            if ((hrs < 10) || ((hrs.length) < 2)) {
                hrs = "0" + hrs;

            }
            var t = document.getElementById(time).value;
            if (t.length == 0) {
                setfocus('Enter Valid Time', time);
            }
            if (t.length > 5) {
                var tm = hrs + ":" + min;
                document.getElementById(time).value = tm;
                setfocus('Invalid Time Format', time);
                return false;
            }

            var t2 = t.split(':')[0];
            var t3 = t.split(':')[1];

            if (t2.length == 1)
                t2 = "0" + t2;

            if (t2.length != 2) {
                var tm = hrs + ":" + min;
                document.getElementById(time).value = tm;
                setfocus('Invalid Time Format', time);
                return false;
            }

            if (t3.length == 1)
                t3 = "0" + t3;
            var temp = t2 + t3;

            var timeValue = "0000" + temp;

            if (timeValue == "") {
                var tm = hrs + ":" + min;
                document.getElementById(time).value = tm;
                setfocus('Invalid Time Format', time);
                return false;
            }
            else {
                var len = timeValue.length;
                var h1 = timeValue.substr((len - 4), (len - 2));
                var sHours = h1.substr(0, 2);
                var sMinutes = timeValue.substr((len - 2), len);

                if (sHours == "" || isNaN(sHours) || parseInt(sHours) > 23 || ((sHours.length) > 2)) {
                    var tm = hrs + ":" + min;
                    ddocument.getElementById(time).value = tm;
                    setfocus('Invalid Time Format', time);
                    return false;
                }
                else if (parseInt(sHours) == 0)
                    sHours = "00";
                else if ((sHours < 10) && ((sHours.length) < 2))
                    sHours = "0" + sHours;

                if (sMinutes == "" || isNaN(sMinutes) || parseInt(sMinutes) > 59 || ((sMinutes.length) > 2)) {
                    var tm = hrs + ":" + min;
                    document.getElementById(time).value = tm;
                    setfocus('Invalid Time Format', time);
                    return false;
                }
                else if (parseInt(sMinutes) == 0)
                    sMinutes = "00";
                else if ((sMinutes < 10) && ((sMinutes.length) < 2))
                    sMinutes = "0" + sMinutes;

                var tm = sHours + ":" + sMinutes;
                document.getElementById(time).value = tm;
            }

            return true;
        }
    </script>
</head>
<body onload="closewin();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress runat="server" ID="uProgess1" DynamicLayout="true" DisplayAfter="1">
            <ProgressTemplate>
                <img id="Img1" alt="" src="~/Images/animated.gif" runat="server" style="position: absolute; left: 298px; top: 126px; width: 39px; height: 27px;" />
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel runat="server" ID="UPShiftNow">
            <ContentTemplate>
                <%--<table id="Table1" runat="server" class="Help2MainPanel">
            <tr>
                <td>
                    <asp:Panel ID="Panel6" runat="server" CssClass="Help3SearchPanel" ScrollBars ="None" >
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ImageButton3" Width="1px" runat="server" ImageUrl="~/Images/Search.ico" Style="visibility: hidden" />
                                    <asp:Label ID="Label2" runat="server" Text="RESOURCE" CssClass="label"></asp:Label>
                                </td>
                                <td>
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Search.ico" Width="16px" OnClientClick="javascript:Help(event,this,'txtot','OT','1','OTSearch.aspx','extra');return false;" /></td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtot" AutoPostBack="true" MaxLength="5" onkeydown="return handleEnter(this, event)" onkeyup="javascript:Help(event,this,'txtot','OT','1','OTSearch.aspx','extra');return false;" runat="server" onkeypress="ValidateNum(this);" CssClass="textbox" Width="137px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbldt" runat="server" Text="DATE" CssClass="label"></asp:Label>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnpre" runat="server" OnClientClick="checkdate();" Width="15px" Height="20px" ImageUrl="~/Images/previous.gif" /></td>
                                <td>
                                    <asp:TextBox ID="txtdate" runat="server" CssClass="textbox" Width="137px" AutoPostBack="true"></asp:TextBox>
                                    <asp:CalendarExtender ID="toCal1" runat="server" CssClass="MyCalendar" Format="dd/MM/yyyy" PopupButtonID="txtdate" TargetControlID="txtdate"></asp:CalendarExtender>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnnext" Width="15px" Height="20px" runat="server" ImageUrl="~/Images/next1.gif" />
                                </td>
                                <td colspan="2">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Proper Date" ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$" ControlToValidate="txtDate" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblhrs" runat="server" Text="HOURS" CssClass="label"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txthrs" onkeypress="ValidateNum(this);" ForeColor="Black" BackColor="White" runat="server" CssClass="textbox" Width="81px" MaxLength="2" onkeydown="return handleEnter(this, event)" Text ="00"></asp:TextBox>
                                    <select id="selhrs" name="selhrs" onchange="javascript:gethrs()">
                                        <option value="1">00</option>
                                        <option value="1">01</option>
                                        <option value="2">02</option>
                                        <option value="3">03</option>
                                        <option value="4">04</option>
                                        <option value="5">05</option>
                                        <option value="6">06</option>
                                        <option value="7">07</option>
                                        <option value="8">08</option>
                                        <option value="9">09</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                        <option value="13">13</option>
                                        <option value="14">14</option>
                                        <option value="15">15</option>
                                        <option value="16">16</option>
                                        <option value="17">17</option>
                                        <option value="18">18</option>
                                        <option value="19">19</option>
                                        <option value="20">20</option>
                                        <option value="21">21</option>
                                        <option value="22">22</option>
                                        <option value="23">23</option>
                                        <option value="24">24</option>
                                    </select>
                                </td>
                                <td>
                                    <asp:Label ID="lblmns" runat="server" Text="MINS" CssClass="label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtmins" onkeypress="ValidateNum(this);" ForeColor="Black" BackColor="White" runat="server" CssClass="textbox" Width="90px" MaxLength="2" onkeydown="return handleEnter(this, event)" Text ="00"></asp:TextBox>
                                    <select id="selmins" name="selmins" onchange="javascript:getmins()">
                                        <option value="1">00</option>
                                        <option value="1">01</option>
                                        <option value="2">02</option>
                                        <option value="3">03</option>
                                        <option value="4">04</option>
                                        <option value="5">05</option>
                                        <option value="6">06</option>
                                        <option value="7">07</option>
                                        <option value="8">08</option>
                                        <option value="9">09</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                        <option value="13">13</option>
                                        <option value="14">14</option>
                                        <option value="15">15</option>
                                        <option value="16">16</option>
                                        <option value="17">17</option>
                                        <option value="18">18</option>
                                        <option value="19">19</option>
                                        <option value="20">20</option>
                                        <option value="21">21</option>
                                        <option value="22">22</option>
                                        <option value="23">23</option>
                                        <option value="24">24</option>
                                        <option value="25">25</option>
                                        <option value="26">26</option>
                                        <option value="27">27</option>
                                        <option value="28">28</option>
                                        <option value="29">29</option>
                                        <option value="30">30</option>
                                        <option value="31">31</option>
                                        <option value="32">32</option>
                                        <option value="33">33</option>
                                        <option value="34">34</option>
                                        <option value="35">35</option>
                                        <option value="36">36</option>
                                        <option value="37">37</option>
                                        <option value="38">38</option>
                                        <option value="39">39</option>
                                        <option value="40">40</option>
                                        <option value="41">41</option>
                                        <option value="42">42</option>
                                        <option value="43">43</option>
                                        <option value="44">44</option>
                                        <option value="45">45</option>
                                        <option value="46">46</option>
                                        <option value="47">47</option>
                                        <option value="48">48</option>
                                        <option value="49">49</option>
                                        <option value="50">50</option>
                                        <option value="51">51</option>
                                        <option value="52">52</option>
                                        <option value="53">53</option>
                                        <option value="54">54</option>
                                        <option value="55">55</option>
                                        <option value="56">56</option>
                                        <option value="57">57</option>
                                        <option value="58">58</option>
                                        <option value="59">59</option>
                                    </select>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="START TIME" CssClass="label"></asp:Label>
                                    <asp:TextBox ID="txtstrttm1" runat="server" CssClass="textbox" ForeColor="Black"
                                        BackColor="White" Width="90px" onkeydown="return handleEnter(this, event)" Text ="00:00" onchange="return validateTime('txtstrttm1');"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="regexpName" runat="server" Display="Dynamic"
                                        ErrorMessage="Please Enter Proper Time" ControlToValidate="txtstrttm1" ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblstrttime" runat="server" Text="START TIME" CssClass="label"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtstrttime" runat="server" ForeColor="Black" BackColor="White"
                                        CssClass="textbox" Width="81px" ReadOnly="True" Text ="00:00"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblendtime" runat="server" Text="END TIME" CssClass="label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtendtime" ForeColor="Black" BackColor="White" runat="server" CssClass="textbox"
                                        Width="90px" ReadOnly="True" Text ="00:00"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnsave" Text="SAVE" CssClass="buttonstandard" OnClientClick="return FinalValidations();" runat="server" />
                                    <asp:Button ID="btncncl" Text="CANCEL" CssClass="buttonstandard" runat="server" />
                                    <input id="txtflag" runat="server" enableviewstate="true" type="text" style="visibility: hidden" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="None" CssClass="Help2GridPanel">
                        <table style="width: 653px">
                            <tr>
                                <td style="position: relative; top: 15px; left: 3px; width: 658px; height: 288px;">
                                    <iframe id='instimage' scrolling="no" name='instimage' runat="server" src='imageshft.aspx?slipno=sdsd'
                                        style="width: 700px; height: 310px;"></iframe>
                                    <asp:Panel ID="pnl001" runat="server" ScrollBars="None" Height="300px" Width="700px">
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>--%>

                <asp:Panel ID="pnlOtDoc" runat="server" CssClass="panel" Style="margin: 0px; padding: 3px; height: 600px">
                    <div class="divSearchHeader" style="padding: 4px; margin-top: 4px; text-align: center">
                        <asp:Label runat="server" ID="lblDocHeading" Text="SHIFT OT" CssClass="headerblue"></asp:Label>
                    </div>

                    <asp:UpdatePanel runat="server" ID="UP1" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <asp:Panel ID="Pnl1" runat="server" ScrollBars="None">
                                <div class="divSearchHeader" style="padding: 4px; margin-top: 4px; height: 100px; text-align: center">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="ImageButton3" Width="1px" runat="server" ImageUrl="~/Images/Search.ico" Style="visibility: hidden" />
                                                <asp:Label ID="Label2" runat="server" Text="RESOURCE" CssClass="label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Search.ico" Width="16px" OnClientClick="javascript:HelpImg(event,this,'txtot','OT','1','OTSearch.aspx','extra');return false;" /></td>
                                            <td>
                                                <asp:TextBox ID="txtot" AutoPostBack="true" MaxLength="5" onkeydown="return handleEnter(this, event)" onkeyup="javascript:Help(event,this,'txtot','OT','1','OTSearch.aspx','extra');return false;" runat="server" onkeypress="ValidateNum(this);" CssClass="textbox" Width="100px"></asp:TextBox>
                                            </td>
                                            <td colspan="5">
                                                <asp:TextBox ID="txtotname" runat="server" Width="350px" CssClass="NotEditabletextbox" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbldt" runat="server" Text="DATE" CssClass="label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnpre" runat="server" OnClientClick="checkdate();" Width="15px" Height="20px" ImageUrl="~/Images/previous.gif" /></td>
                                            <td>
                                                <asp:TextBox ID="txtdate" runat="server" CssClass="textbox" Width="100px" AutoPostBack="true"></asp:TextBox>
                                                <asp:CalendarExtender ID="toCal1" runat="server" CssClass="MyCalendar" Format="dd/MM/yyyy" PopupButtonID="txtdate" TargetControlID="txtdate"></asp:CalendarExtender>
                                                <asp:ImageButton ID="btnnext" Width="15px" Height="20px" runat="server" ImageUrl="~/Images/next1.gif" />
                                            </td>
                                            <td colspan="2">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Proper Date" ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$" ControlToValidate="txtDate" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblstrttime" runat="server" Text="START TIME" CssClass="label"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtstrttime" runat="server" ForeColor="Black" BackColor="White"
                                                    CssClass="textbox" Width="100px" Enabled="false" ReadOnly="True" Text="00:00"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblendtime" runat="server" Text="END TIME" CssClass="label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtendtime" ForeColor="Black" BackColor="White" runat="server" CssClass="textbox"
                                                    Width="100px" ReadOnly="True" Text="00:00"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblhrs" runat="server" Text="HOURS" CssClass="label"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txthrs" onkeypress="ValidateNum(this);" ForeColor="Black" BackColor="White" runat="server" CssClass="textbox" Width="60px" MaxLength="2" onkeydown="return handleEnter(this, event)" Text="00"></asp:TextBox>
                                                <select id="selhrs" name="selhrs" onchange="javascript:gethrs()">
                                                    <option value="1">00</option>
                                                    <option value="1">01</option>
                                                    <option value="2">02</option>
                                                    <option value="3">03</option>
                                                    <option value="4">04</option>
                                                    <option value="5">05</option>
                                                    <option value="6">06</option>
                                                    <option value="7">07</option>
                                                    <option value="8">08</option>
                                                    <option value="9">09</option>
                                                    <option value="10">10</option>
                                                    <option value="11">11</option>
                                                    <option value="12">12</option>
                                                    <option value="13">13</option>
                                                    <option value="14">14</option>
                                                    <option value="15">15</option>
                                                    <option value="16">16</option>
                                                    <option value="17">17</option>
                                                    <option value="18">18</option>
                                                    <option value="19">19</option>
                                                    <option value="20">20</option>
                                                    <option value="21">21</option>
                                                    <option value="22">22</option>
                                                    <option value="23">23</option>
                                                    <option value="24">24</option>
                                                </select>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblmns" runat="server" Text="MINS" CssClass="label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtmins" onkeypress="ValidateNum(this);" ForeColor="Black" BackColor="White" runat="server" CssClass="textbox" Width="60px" MaxLength="2" onkeydown="return handleEnter(this, event)" Text="00"></asp:TextBox>
                                                <select id="selmins" name="selmins" onchange="javascript:getmins()">
                                                    <option value="1">00</option>
                                                    <option value="1">01</option>
                                                    <option value="2">02</option>
                                                    <option value="3">03</option>
                                                    <option value="4">04</option>
                                                    <option value="5">05</option>
                                                    <option value="6">06</option>
                                                    <option value="7">07</option>
                                                    <option value="8">08</option>
                                                    <option value="9">09</option>
                                                    <option value="10">10</option>
                                                    <option value="11">11</option>
                                                    <option value="12">12</option>
                                                    <option value="13">13</option>
                                                    <option value="14">14</option>
                                                    <option value="15">15</option>
                                                    <option value="16">16</option>
                                                    <option value="17">17</option>
                                                    <option value="18">18</option>
                                                    <option value="19">19</option>
                                                    <option value="20">20</option>
                                                    <option value="21">21</option>
                                                    <option value="22">22</option>
                                                    <option value="23">23</option>
                                                    <option value="24">24</option>
                                                    <option value="25">25</option>
                                                    <option value="26">26</option>
                                                    <option value="27">27</option>
                                                    <option value="28">28</option>
                                                    <option value="29">29</option>
                                                    <option value="30">30</option>
                                                    <option value="31">31</option>
                                                    <option value="32">32</option>
                                                    <option value="33">33</option>
                                                    <option value="34">34</option>
                                                    <option value="35">35</option>
                                                    <option value="36">36</option>
                                                    <option value="37">37</option>
                                                    <option value="38">38</option>
                                                    <option value="39">39</option>
                                                    <option value="40">40</option>
                                                    <option value="41">41</option>
                                                    <option value="42">42</option>
                                                    <option value="43">43</option>
                                                    <option value="44">44</option>
                                                    <option value="45">45</option>
                                                    <option value="46">46</option>
                                                    <option value="47">47</option>
                                                    <option value="48">48</option>
                                                    <option value="49">49</option>
                                                    <option value="50">50</option>
                                                    <option value="51">51</option>
                                                    <option value="52">52</option>
                                                    <option value="53">53</option>
                                                    <option value="54">54</option>
                                                    <option value="55">55</option>
                                                    <option value="56">56</option>
                                                    <option value="57">57</option>
                                                    <option value="58">58</option>
                                                    <option value="59">59</option>
                                                </select>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="START TIME" CssClass="label"></asp:Label>
                                                <asp:TextBox ID="txtstrttm1" runat="server" CssClass="textbox" ForeColor="Black"
                                                    BackColor="White" Width="100px" onkeydown="return handleEnter(this, event)"
                                                    Text="00:00" onchange="return validateTime1('txtstrttm1');"></asp:TextBox>
                                                <%--  <asp:RegularExpressionValidator ID="regexpName" runat="server" Display="Dynamic"
                                                    ErrorMessage="Please Enter Proper Time" ControlToValidate="txtstrttm1" ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel runat="server" ID="UP2" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <asp:Panel ID="Pnl2" runat="server" ScrollBars="None">
                                <div class="divSearchHeader" style="padding: 4px;">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnsave" Text="SAVE" CssClass="buttonstandard" OnClientClick="return FinalValidations();"
                                                     runat="server" />
                                                <asp:Button ID="btncncl" Text="CANCEL" CssClass="buttonstandard" runat="server" OnClientClick="return Clr();" />
                                                <input id="txtflag" runat="server" enableviewstate="true" type="text" style="visibility: hidden" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel runat="server" ID="UP3" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <asp:Panel ID="Pnl3" runat="server" ScrollBars="None">
                                <table>
                                    <tr>
                                        <td style="position: relative; top: 10px; left: 5px;">
                                            <iframe id='instimage' scrolling="no" name='instimage' src='imageshft.aspx?slipno=sdsd'
                                                style="width: 1290px; height: 320px;"></iframe>
                                            <asp:Panel ID="pnl001" runat="server" ScrollBars="None" Height="300px" Width="1250px">
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div>
                        <asp:HiddenField ID="ContentPlaceHolder1_HfAppMdCd" runat="server" />
                        <asp:HiddenField ID="ContentPlaceHolder1_HfAppSubMdCd" runat="server" />
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
