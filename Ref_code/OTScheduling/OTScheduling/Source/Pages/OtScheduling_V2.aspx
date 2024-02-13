<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage.master" CodeBehind="OtScheduling_V2.aspx.vb" Inherits="OTScheduling.OtScheduling_V2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" language="javascript">
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

        function checkdate() {
            var date = new Date();
            var month = (date.getMonth() + 1);
            if (month < 10) {
                month = "0" + month
            }
            var tdate = date.getDate();
            var fullyr = date.getFullYear();
            var fulldate = tdate + "/" + month + "/" + fullyr;
            if (document.getElementById("ContentPlaceHolder1_txtdate").value.toLowerCase().trim() == fulldate.toLowerCase().trim()) {
                alertify.alert("Date Can't Be Previous");
                return flase;
            }
        }

        function getdetails(txt) {
            var spltvalues = txt.split('~~');

            //if + "~~" + PtnType.ToString() '''' Amol 2020-11-07 JSK001-147262	 [PtnType]

            var PtnType = spltvalues[12];


            document.getElementById("ContentPlaceHolder1_txtslots").value = spltvalues[0];
            document.getElementById("ContentPlaceHolder1_txtapptno").value = spltvalues[1];
            document.getElementById("ContentPlaceHolder1_txtdctid").value = spltvalues[3];
            document.getElementById("ContentPlaceHolder1_txtdctname").value = spltvalues[4];
            document.getElementById("ContentPlaceHolder1_txtstrttm1").value = spltvalues[5];
            document.getElementById("ContentPlaceHolder1_txtpatid").value = spltvalues[7];

            document.getElementById("ContentPlaceHolder1_hfPtnType").value = spltvalues[12];

            //if (PtnType == "I") {
            //    document.getElementById("ContentPlaceHolder1_txtpatid").style.display = "block";
            //    document.getElementById("ContentPlaceHolder1_txtOpPtnCd").style.display = "none";

            //    //document.getElementById("ContentPlaceHolder1_rdbPatientType_1").checked = false;
            //    //document.getElementById("ContentPlaceHolder1_rdbPatientType_0").checked = true;

            //} else {
            //    document.getElementById("ContentPlaceHolder1_txtpatid").style.display = "none";
            //    document.getElementById("ContentPlaceHolder1_txtOpPtnCd").style.display = "block";
            //    document.getElementById("ContentPlaceHolder1_txtOpPtnCd").value = spltvalues[7];

            //    //document.getElementById("ContentPlaceHolder1_rdbPatientType_0").checked = false;
            //    //document.getElementById("ContentPlaceHolder1_rdbPatientType_1").checked = true;

            //}

            document.getElementById("ContentPlaceHolder1_txtpatname").value = spltvalues[8];

            document.getElementById("ContentPlaceHolder1_txthrs").value = spltvalues[9];
            document.getElementById("ContentPlaceHolder1_txtmins").value = spltvalues[10];
            document.getElementById("ContentPlaceHolder1_txtRmrk").value = spltvalues[11];

            document.getElementById("ContentPlaceHolder1_txtflag").value = "EDIT";
            document.getElementById("ContentPlaceHolder1_btnnewbkng").disabled = true;
            document.getElementById("ContentPlaceHolder1_btncnclbkng").disabled = false;
            document.getElementById("ContentPlaceHolder1_btnshft").disabled = false;
            document.getElementById("ContentPlaceHolder1_btnshftnow").disabled = false;
            document.getElementById("ContentPlaceHolder1_btnsave").disabled = true;
            $("#ContentPlaceHolder1_btnnewbkng").removeClass('buttonstandard').addClass("divskyblue");
            $("#ContentPlaceHolder1_btncnclbkng").removeClass('divskyblue').addClass("buttonstandard");
            $("#ContentPlaceHolder1_btnshft").removeClass('divskyblue').addClass("buttonstandard");
            $("#ContentPlaceHolder1_btnshftnow").removeClass('divskyblue').addClass("buttonstandard");
            document.getElementById("ContentPlaceHolder1_btnmdfybkng").disabled = false;
            $("#ContentPlaceHolder1_btnmdfybkng").removeClass('divskyblue').addClass("buttonstandard");
            document.getElementById("ContentPlaceHolder1_txtdctid").disabled = true;
            document.getElementById("ContentPlaceHolder1_txtpatid").disabled = true;
            document.getElementById("ContentPlaceHolder1_txthrs").disabled = true;
            document.getElementById("ContentPlaceHolder1_txtmins").disabled = true;
            document.getElementById("selhrs").disabled = true;
            document.getElementById("selmins").disabled = true;
            document.getElementById("ContentPlaceHolder1_txtapptno").disabled = true;

            document.getElementById("ContentPlaceHolder1_Imgsearchptn").disabled = true; //RasikV 20170127
            document.getElementById("ContentPlaceHolder1_imageSearchDoc").disabled = true; //RasikV 20170127
            $("#ContentPlaceHolder1_btnsave").removeClass('buttonstandard').addClass("divskyblue"); //RasikV 20170127

            $("#ContentPlaceHolder1_btncnclbkng").bind("click", function () {
                //    alert('1');
                return ChkCnclRecord();
            });

            $("#ContentPlaceHolder1_btnshft").bind("click", function () {
                //  alert('2');
                return ChkShiftManualRecord();
            });

            $("#ContentPlaceHolder1_btnsave").bind("click", function () {
                //   alert('3');
                return FinalValidations();
            });

            var save = document.getElementById("ContentPlaceHolder1_hfsave").value;
            if (save == "False") {
                document.getElementById("<%=btnsave.ClientID()%>").disabled = true;
                document.getElementById("<%=btnnewbkng.ClientID()%>").disabled = true;
                $("#<%=btnsave.ClientID()%>").removeClass('buttonstandard').addClass("divskyblue");
                $("#<%=btnnewbkng.ClientID()%>").removeClass('buttonstandard').addClass("divskyblue");
            }

            var access = document.getElementById("ContentPlaceHolder1_hfsave").value;
            if (access == "False") {
                document.getElementById("btnmdfybkng").disabled = true;
                $("#btnmdfybkng").removeClass('buttonstandard').addClass("divskyblue");
            }

            var access = document.getElementById("ContentPlaceHolder1_hfdelete").value;
            if (access == "False") {
                document.getElementById("<%=btncnclbkng.ClientID()%>").disabled = true;
                $("#<%=btncnclbkng.ClientID()%>").removeClass('buttonstandard').addClass("divskyblue");
            }

            var access = document.getElementById("ContentPlaceHolder1_hfsave").value;
            if (access == "False") {
                document.getElementById("<%=btnshft.ClientID()%>").disabled = true;
                $("#<%=btnshft.ClientID()%>").removeClass('buttonstandard').addClass("divskyblue");
            }

            var access = document.getElementById("ContentPlaceHolder1_hfsave").value;
            if (access == "False") {
                document.getElementById("btnshftnow").disabled = true;
                $("#btnshftnow").removeClass('buttonstandard').addClass("divskyblue");
            }
            return false;
        }

        //---------- MODIFIED DATA  ABOVE CODE---------------

        function getdetailsToModifiedData(txt) {
            var spltvalues = txt.split('~~');
            document.getElementById("ContentPlaceHolder1_txtslots").value = spltvalues[0];
            document.getElementById("ContentPlaceHolder1_txtapptno").value = spltvalues[1];
            document.getElementById("ContentPlaceHolder1_txtdctid").value = spltvalues[3];
            document.getElementById("ContentPlaceHolder1_txtdctname").value = spltvalues[4];
            document.getElementById("ContentPlaceHolder1_txtstrttm1").value = spltvalues[5];
            document.getElementById("ContentPlaceHolder1_txtpatid").value = spltvalues[7];
            document.getElementById("ContentPlaceHolder1_txtpatname").value = spltvalues[8];
            document.getElementById("ContentPlaceHolder1_txthrs").value = spltvalues[9];
            document.getElementById("ContentPlaceHolder1_txtmins").value = spltvalues[10];
            document.getElementById("ContentPlaceHolder1_txtRmrk").value = spltvalues[11];
            document.getElementById("ContentPlaceHolder1_txtflag").value = "EDIT";
            document.getElementById("ContentPlaceHolder1_btnnewbkng").disabled = false;
            document.getElementById("ContentPlaceHolder1_btncnclbkng").disabled = true;
            document.getElementById("ContentPlaceHolder1_btnshft").disabled = true;
            document.getElementById("ContentPlaceHolder1_btnshftnow").disabled = true;
            document.getElementById("ContentPlaceHolder1_btnsave").disabled = true;
            $("#ContentPlaceHolder1_btnnewbkng").removeClass('buttonstandard').addClass("divskyblue");
            $("#ContentPlaceHolder1_btncnclbkng").removeClass('divskyblue').addClass("buttonstandard");
            $("#ContentPlaceHolder1_btnshft").removeClass('divskyblue').addClass("buttonstandard");
            $("#ContentPlaceHolder1_btnshftnow").removeClass('divskyblue').addClass("buttonstandard");
            document.getElementById("ContentPlaceHolder1_btnmdfybkng").disabled = true;
            $("#ContentPlaceHolder1_btnmdfybkng").removeClass('divskyblue').addClass("buttonstandard");
            document.getElementById("ContentPlaceHolder1_txtdctid").disabled = true;
            document.getElementById("ContentPlaceHolder1_txtpatid").disabled = true;
            document.getElementById("ContentPlaceHolder1_txthrs").disabled = true;
            document.getElementById("ContentPlaceHolder1_txtmins").disabled = true;
            document.getElementById("selhrs").disabled = true;
            document.getElementById("selmins").disabled = true;
            document.getElementById("ContentPlaceHolder1_txtapptno").disabled = true;

            document.getElementById("ContentPlaceHolder1_Imgsearchptn").disabled = true; //RasikV 20170127
            document.getElementById("ContentPlaceHolder1_imageSearchDoc").disabled = true; //RasikV 20170127
            $("#ContentPlaceHolder1_btnsave").removeClass('buttonstandard').addClass("divskyblue"); //RasikV 20170127

            $("#ContentPlaceHolder1_btncnclbkng").bind("click", function () {
                return ChkCnclRecord();
            });

            $("#ContentPlaceHolder1_btnshft").bind("click", function () {
                return ChkShiftManualRecord();
            });

            $("#ContentPlaceHolder1_btnsave").bind("click", function () {
                return FinalValidations();
            });

            var save = document.getElementById("ContentPlaceHolder1_hfsave").value;
            if (save == "False") {
                document.getElementById("<%=btnsave.ClientID()%>").disabled = true;
                document.getElementById("<%=btnnewbkng.ClientID()%>").disabled = true;
                $("#<%=btnsave.ClientID()%>").removeClass('buttonstandard').addClass("divskyblue");
                $("#<%=btnnewbkng.ClientID()%>").removeClass('buttonstandard').addClass("divskyblue");
            }

            var access = document.getElementById("ContentPlaceHolder1_hfsave").value;
            if (access == "False") {
                document.getElementById("btnmdfybkng").disabled = true;
                $("#btnmdfybkng").removeClass('buttonstandard').addClass("divskyblue");
            }

            var access = document.getElementById("ContentPlaceHolder1_hfdelete").value;
            if (access == "False") {
                document.getElementById("<%=btncnclbkng.ClientID()%>").disabled = true;
                $("#<%=btncnclbkng.ClientID()%>").removeClass('buttonstandard').addClass("divskyblue");
            }

            var access = document.getElementById("ContentPlaceHolder1_hfsave").value;
            if (access == "False") {
                document.getElementById("<%=btnshft.ClientID()%>").disabled = true;
                $("#<%=btnshft.ClientID()%>").removeClass('buttonstandard').addClass("divskyblue");
            }

            var access = document.getElementById("ContentPlaceHolder1_hfsave").value;
            if (access == "False") {
                document.getElementById("btnshftnow").disabled = true;
                $("#btnshftnow").removeClass('buttonstandard').addClass("divskyblue");
            }
            return false;
        }
        //---------- MODIFIED DATA  ABOVE CODE---------------

        function FinalSave(Msg) {
            confirmAction(Msg + ', Do you want to save record ?', performAction); return false;
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
                    else {
                        document.getElementById("ContentPlaceHolder1_btnCancelSave").click();
                    }
                } else {
                    document.getElementById("ContentPlaceHolder1_btnCancelSave").click();
                }
            });
        }

        function ChkCnclRecord() {
            confirmAction1('Are You Sure Want To Cancel Appointment', performAction1);
            return false;
        }

        function performAction1() {
            document.getElementById("ContentPlaceHolder1_btnFinalCncl").click();
        }

        function confirmAction1(message, action) {
            alertify.confirm(message, function (e) {
                if (e) {
                    if (action) {
                        action();
                    }
                }
            });
        }

        function ChkShiftManualRecord() {
            confirmAction2('Are You Sure Want To Shift Appointment', performAction2);
            return false;
        }

        function performAction2() {
            document.getElementById("ContentPlaceHolder1_btnFinalShift").click();
        }

        function confirmAction2(message, action) {
            alertify.confirm(message, function (e) {
                if (e) {
                    if (action) {
                        action();
                    }
                }
            });
        }

        function RedirectRecord(Msg) {
            alertify.alert(Msg, performAction3)
            return false;
        }

        function performAction3() {
            document.getElementById("ContentPlaceHolder1_btnRedirect").click();
        }

        function confirmAction3(message, action) {
            alertify.confirm(message, function (e) {
                if (e) {
                    if (action) {
                        action();
                    }
                }
            });
        }

        function FinalValidations() {
            if (document.getElementById("ContentPlaceHolder1_txtdctid").value == '' || document.getElementById("ContentPlaceHolder1_txtdctid").value == '0') {
                document.getElementById("ContentPlaceHolder1_txtdctid").focus();
                alertify.alert("Enter Valid Doctor Code & Name");
                return false;
            }
            // Amol 2020-11-07 JSK001-147262	
            //if (document.getElementById("ContentPlaceHolder1_txtpatid").value == '' || document.getElementById("ContentPlaceHolder1_txtpatid").value == '0') {
            //    document.getElementById("ContentPlaceHolder1_txtpatid").focus();
            //    alertify.alert("Enter Valid Patient Code & Name");
            //    return false;
            //}
            // Amol 2020-11-07 JSK001-147262	

            if (document.getElementById("ContentPlaceHolder1_txthrs").value == '') {
                document.getElementById("ContentPlaceHolder1_txthrs").focus();
                alertify.alert("Enter Hours");
                return false;
            }
            if (document.getElementById("ContentPlaceHolder1_txtmins").value == '') {
                document.getElementById("ContentPlaceHolder1_txtmins").focus();
                alertify.alert("Enter Minutes");
                return false;
            }
            if (document.getElementById("ContentPlaceHolder1_txtstrttm1").value == '') {
                document.getElementById("ContentPlaceHolder1_txtstrttm1").focus();
                alertify.alert("Enter Start Time");
                return false;
            }
            if (document.getElementById("ContentPlaceHolder1_txthrs").value > 24) {
                document.getElementById("ContentPlaceHolder1_txthrs").focus();
                alertify.alert("Enter Valid Hours");
                return false;
            }
            if (document.getElementById("ContentPlaceHolder1_txtmins").value > 59) {
                document.getElementById("ContentPlaceHolder1_txtmins").focus();
                alertify.alert("Enter Valid Minutes");
                return false;
            }
            if (document.getElementById("ContentPlaceHolder1_txthrs").value == '00' && document.getElementById("ContentPlaceHolder1_txtmins").value == '00') {
                document.getElementById("ContentPlaceHolder1_txtdctid").focus();
                alertify.alert("Enter Valid Hours & Minutes");
                return false;
            }
            return true;
        }

        function gethrs() {
            document.getElementById("ContentPlaceHolder1_txthrs").value = $('#selhrs>option:selected').text();
            __doPostBack("<%=txthrs.ClientID%>", "TextChanged")
        }

        function getmins() {
            document.getElementById("ContentPlaceHolder1_txtmins").value = $('#selmins>option:selected').text();
            __doPostBack("<%=txtmins.ClientID%>", "TextChanged")
        }

        function RowDblclicked(txt) {
            var spltvalues = txt.split('~');
            document.getElementById("ContentPlaceHolder1_txtdctid").value = spltvalues[0];
            document.getElementById("ContentPlaceHolder1_txtdctname").value = spltvalues[1];
            document.getElementById("ContentPlaceHolder1_txtpatid").value = spltvalues[2];
            document.getElementById("ContentPlaceHolder1_txtpatname").value = spltvalues[3];
            document.getElementById("ContentPlaceHolder1_txtstrttm1").value = spltvalues[4];
            document.getElementById("ContentPlaceHolder1_txtslots").value = spltvalues[5];
            document.getElementById("ContentPlaceHolder1_txthrs").value = spltvalues[7];
            document.getElementById("ContentPlaceHolder1_txtmins").value = spltvalues[8];
            document.getElementById("ContentPlaceHolder1_txtreqno").value = spltvalues[6];
            document.getElementById("ContentPlaceHolder1_txtflag").value = ""; //"EDIT";
            document.getElementById("ContentPlaceHolder1_txtapptno").value = spltvalues[10];  //"";
            var ipflg = spltvalues[9];
            if (ipflg == "o") {
                document.getElementById("ContentPlaceHolder1_rdoip").checked = false
                document.getElementById("ContentPlaceHolder1_rdoop").checked = true
            }
            else {
                document.getElementById("ContentPlaceHolder1_rdoip").checked = true
                document.getElementById("ContentPlaceHolder1_rdoop").checked = false
            }
            document.getElementById("ContentPlaceHolder1_btnnewbkng").disabled = false;
            document.getElementById("ContentPlaceHolder1_btnmdfybkng").disabled = true;
            document.getElementById("ContentPlaceHolder1_btncnclbkng").disabled = true;
            document.getElementById("ContentPlaceHolder1_btnshft").disabled = true;
            document.getElementById("ContentPlaceHolder1_btnshftnow").disabled = true;

            $("#ContentPlaceHolder1_btnnewbkng").addClass("buttonstandard");
            $("#ContentPlaceHolder1_btnmdfybkng").removeClass('buttonstandard').addClass("divskyblue");
            $("#ContentPlaceHolder1_btncnclbkng").removeClass('buttonstandard').addClass("divskyblue");
            $("#ContentPlaceHolder1_btnshft").removeClass('buttonstandard').addClass("divskyblue");
            $("#ContentPlaceHolder1_btnshftnow").removeClass('buttonstandard').addClass("divskyblue");

            document.getElementById("ContentPlaceHolder1_imageSearchDoc").disabled = false;
            document.getElementById("ContentPlaceHolder1_txtdctid").disabled = false;
            document.getElementById("ContentPlaceHolder1_Imgsearchptn").disabled = false;
            document.getElementById("ContentPlaceHolder1_txtpatid").disabled = false;
            document.getElementById("ContentPlaceHolder1_txthrs").disabled = false;
            document.getElementById("ContentPlaceHolder1_txtmins").disabled = false;
            document.getElementById("ContentPlaceHolder1_txtstrttm1").disabled = false;
            document.getElementById("ContentPlaceHolder1_txtRmrk").disabled = false;
            document.getElementById("ContentPlaceHolder1_btnSelSrvDtls").disabled = false;
            document.getElementById("ContentPlaceHolder1_BtnSelDoc").disabled = false;
            document.getElementById("ContentPlaceHolder1_BtnSelEmp").disabled = false;
            document.getElementById("ContentPlaceHolder1_btnsave").disabled = false;
            document.getElementById("ContentPlaceHolder1_btncncl").disabled = false;
            document.getElementById("ContentPlaceHolder1_btnexit").disabled = false;


        }

        function funAddValues(Code, Desc, txt1, txt2) {
            var newElem1 = document.getElementById("<%=txtpatid.ClientID%>");
            newElem1.value = Code;
            var newElem1 = document.getElementById("<%=txtpatname.ClientID%>");
            newElem1.value = Desc;
            document.getElementById("<%=txthrs.ClientID%>").focus();
            enablepanel()
            return false;
        }

        var closeAppWindow = function () {
            document.getElementById("<%=btnCloseFrame.ClientID%>").click();
        }

            function setMsg(Msg) {
                document.getElementById("<%=btnCloseFrame.ClientID%>").click();
                alertify.alert(Msg, performAction3)
                return false;
            }

            function EnabledDisabledPnl2(iFlg) {
                if (iFlg == "False") {
                    document.getElementById("selhrs").disabled = true;
                    document.getElementById("selmins").disabled = true;
                }
                else {
                    document.getElementById("selhrs").disabled = false;
                    document.getElementById("selmins").disabled = false;
                }
            }

            function ValidateTime1(txt, event) { //RasikV 20170118
                var charCode = (event.which) ? event.which : event.keyCode
                if (charCode == 58) {
                    if (txt.value.indexOf(":") < 0) return true;
                    else return false;
                }
                if (txt.value.indexOf(":") > 0) {
                    var txtlen = txt.value.length;
                    var dotpos = txt.value.indexOf(":");
                    if ((txtlen - dotpos) > 3) return false;
                }
                if (charCode > 31 && (charCode < 48 || charCode > 57)) return false;
                return true;
            }



            //shital 20190921
            function printconfirmation(msg) {
                alertify.set
                  ({
                      labels:
                          {
                              ok: "YES",
                              cancel: "NO"
                          }
                  });
                // confirmPrintAction(msg, performprintAction); return false;
                confirmAction123(msg, performprintAction); return false;
            }
            function resettext() {
                alertify.set
                    ({
                        labels:
                            {
                                ok: "OK",
                                cancel: "CANCEL"
                            }
                    });
            }
            function performprintAction() {
                document.getElementById("ContentPlaceHolder1_btnFinalPrint").click();
            }

            function confirmAction123(message, printaction) {
                alertify.confirm(message, function (e) {
                    if (e) {
                        if (printaction) {
                            resettext()
                            printaction();
                        }
                        else {
                            resettext()
                            document.getElementById("ContentPlaceHolder1_btnFinalPrintCancel").click();
                        }
                    }
                    else {
                        resettext()
                        document.getElementById("ContentPlaceHolder1_btnFinalPrintCancel").click();
                    }
                });
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



            function opendefault() {
                var finalsettings = callsettings('6');
                window.open("PrintRpt.aspx", "ModalPopUp", finalsettings);
            }

    </script>
    <style type="text/css">
        .ButtonTab {
            content: "ON";
            padding-left: 10px;
            background-color: #EEEEEE;
            color: #999999;
            display: block;
            overflow: hidden;
            cursor: pointer;
            border: 2px solid #999999;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress runat="server" ID="uProgess1" DynamicLayout="true" DisplayAfter="1">
        <ProgressTemplate>
            <img id="Img1" alt="" src="~/Images/animated.gif" runat="server" style="position: absolute; left: 498px; top: 126px; width: 39px; height: 27px;" />
        </ProgressTemplate>
    </asp:UpdateProgress>


    <asp:UpdatePanel runat="server" ID="upFrame" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="divOverlayPopupFrame" ClientIDMode="Static" runat="server" Style="position: fixed; left: 0px; top: 0px; display: none; z-index: 998; width: 100%; height: 100%; background-color: #252525; opacity: 0.5"></asp:Panel>
            <asp:ImageButton ID="ImageButton1" Width="1px" runat="server" ImageUrl="~/Images/Search.ico" Style="visibility: hidden" />
            <div id="divPopupFrame" runat="server" style="left: 0; top: 0; position: fixed; z-index: 999; height: 100%; width: 100%; margin-top: -20px" visible="false">
                <center>
                    <div style="width: 100%; height: auto; display: inline-table; padding-bottom: 10px;">
                        <div class="" style="margin: 20px auto; height: 100%; box-shadow: 0px 15px 20px 0px rgba(0, 0, 0, 0.25); border-radius: 2px;">
                            <div class="div">
                                <div class="" style="background-color: white;">
                                    <div style="text-align: right; padding-right: 10px;">
                                        <asp:LinkButton ID="btnCloseFrame" runat="server" CssClass="btn btn-xs btn-flat button pull-right"
                                            CausesValidation="false" OnClick="btnCloseFrame_Click">
                                        <i class="buttonstandard" style="font-size: larger;">X</i>
                                        </asp:LinkButton>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 table-responsive" style="max-width: 100%; height: 100%; top: -25px;">
                                            <asp:Panel ID="pnlFrame" runat="server">
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server" ID="UpdMain">
        <ContentTemplate>
            <asp:Panel ID="PnlMain" runat="server">
                <div id="divmain" style="width: 100%">
                    <asp:ImageButton ID="ImageButton3" Width="1px" runat="server" ImageUrl="~/Images/Search.ico"
                        Style="visibility: hidden" />
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 290px;">
                                <asp:Panel ID="Pnl1" runat="server" CssClass="panel" Height="185px" Style="margin: 0px; padding: 0px">
                                    <div style="vertical-align: top; width: 300px;">
                                        <table style="vertical-align: top; height: 100%; width: 100%;">
                                            <tr>
                                                <td class="style1">
                                                    <asp:Label ID="lblot" runat="server" Text="OT" CssClass="label"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageButton2" runat="server"
                                                        ImageUrl="~/Images/Search.ico" Width="16px" ForeColor="Black"
                                                        BackColor="White" OnClientClick="javascript:HelpImg(event,this,'txtot','OT','1','OTSearch.aspx','extra');return false;" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtot" runat="server" MaxLength="4" OnTextChanged="txtot_TextChanged" AutoPostBack="true" onkeypress="ValidateNum(this);"
                                                        Width="150px" CssClass="textbox" onkeyup="javascript:Help(event,this,'txtot','OT','1','OTSearch.aspx','extra');return false;"
                                                        ForeColor="Black" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td>
                                                    <asp:TextBox ID="txtotname" runat="server" Width="150px" CssClass="NotEditabletextbox" ReadOnly="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    <asp:Label ID="lbldt" runat="server" Text="DATE" CssClass="label"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <asp:ImageButton ID="btnpre" runat="server" OnClientClick="javascript:checkdate();"
                                                        Width="20px" Height="20px"
                                                        ImageUrl="~/Images/previous.gif" ForeColor="Black" BackColor="White" />
                                                    <asp:TextBox ID="txtdate" runat="server" CssClass="textbox" AutoPostBack="true"
                                                        Width="130px" ForeColor="Black" BackColor="White"></asp:TextBox>
                                                    <asp:CalendarExtender ID="toCal1" runat="server" CssClass="MyCalendar"
                                                        Format="dd/MM/yyyy" PopupButtonID="txtdate" TargetControlID="txtdate"></asp:CalendarExtender>
                                                    <asp:ImageButton ID="btnnext" Width="20px" Height="20px" runat="server"
                                                        ImageUrl="~/Images/next1.gif" ForeColor="Black" BackColor="White" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    <asp:Label ID="lblstrttime" runat="server" Text="START TIME" CssClass="label"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:TextBox ID="txtstrttime" Width="150px" runat="server"
                                                        CssClass="NotEditabletextbox" ReadOnly="True"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    <asp:Label ID="lblendtime" runat="server" Text="END TIME" CssClass="label"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:TextBox ID="txtendtime" Width="150px" runat="server"
                                                        CssClass="NotEditabletextbox" ReadOnly="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1" colspan="3">
                                                    <asp:Label ID="lblHeaderReqNo" runat="server" Text="REQUEST NO :- " CssClass="label"
                                                        Font-Bold="true" Font-Size="12px" ForeColor="Maroon"></asp:Label>
                                                    <asp:Label ID="lblRequestNo" runat="server" Text="0" CssClass="label" Font-Bold="true"
                                                        Font-Size="12px" ForeColor="Red"></asp:Label>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="style1" colspan="3">
                                                    <asp:Label ID="lblHeaderDate" runat="server" Text="FOR DATE :- " CssClass="label" Font-Bold="true" Font-Size="12px"
                                                        ForeColor="Maroon"></asp:Label>
                                                    <asp:Label ID="lblOtAppxDate" runat="server" Text="" CssClass="label" Font-Bold="true" Font-Size="12px"
                                                        ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </td>
                            <td align="left" style="width: 850px">
                                <asp:Panel ID="Pnl2" runat="server" CssClass="panel" Height="185px" Style="margin: 0px; padding: 0px">
                                    <table>
                                        <tr>
                                            <td></td>

                                            <td align="left">
                                                <asp:Label ID="lbldct" runat="server" Text="DOCTOR" CssClass="label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="imageSearchDoc" runat="server" ImageUrl="~/Images/Search.ico"
                                                    OnClientClick="javascript:HelpImg(event,this,'txtdctid','DctNo','2','DoctorSearch.aspx','extra');return false;"
                                                    Width="16px" ToolTip="Doctor Help" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtdctid" AutoPostBack="true" ForeColor="Black" BackColor="white" runat="server" onkeypress="ValidateNum(this);" MaxLength="4" CssClass="textbox" Width="120px" onkeyup="javascript:Help(event,this,'txtdctid','DctNo','2','DoctorSearch.aspx','extra');return false;" />

                                                <asp:TextBox ID="txtdctname" ReadOnly="true" runat="server" CssClass="NotEditabletextbox" Width="450px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td align="left">
                                                <asp:Label ID="Label2" runat="server" Text="PAT TYPE" CssClass="label"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:RadioButtonList ID="rdbPatientType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                                    AutoPostBack="true" OnSelectedIndexChanged="rdbPatientType_SelectedIndexChanged">
                                                    <asp:ListItem Value="I" Text="In Patient" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="O" Text="Out Patient"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td></td>

                                            <td align="left">
                                                <asp:Label ID="lblpat" runat="server" Text="PATIENT" CssClass="label"></asp:Label>
                                            </td>
                                            <td>

                                                <asp:ImageButton ID="Imgsearchptn" runat="server" ImageUrl="~/Images/Search.ico"
                                                    OnClientClick="javascript:HelpImg(event,this,'txtpatid','PatNo','3','InPatientHelp.aspx','extra');return false;"
                                                    Width="16px" ToolTip="Patient Help" />

                                                <asp:ImageButton ID="imgOpPtnHelp" runat="server" ImageUrl="~/Images/Search.ico"
                                                    OnClientClick="javascript:HelpImg(event,this,'txtOpPtnCd','PatNo','3','PatientSearch.aspx','extra');return false;"
                                                    Width="16px" ToolTip="Patient Help" />

                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtpatid" AutoPostBack="true" MaxLength="12" runat="server" onkeypress="ValidateNum(this);"
                                                    CssClass="textbox" ForeColor="Black" BackColor="white" Width="120px" OnTextChanged="txtpatid_TextChanged"
                                                    onkeyup="javascript:Help(event,this,'txtpatid','PatNo','3','InPatientHelp.aspx','extra');return false;" />

                                                <asp:TextBox ID="txtpatname" runat="server" CssClass="NotEditabletextbox" Width="450px" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>

                                            <td colspan="2">
                                                <asp:Label ID="Label1" runat="server" Text="START TIME" CssClass="label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtstrttm1" runat="server" ForeColor="Black" BackColor="White" CssClass="textbox" Width="100px"
                                                    OnTextChanged="txtstrttm1_TextChanged" AutoPostBack="true" MaxLength="5"></asp:TextBox>

                                                <asp:Label ID="lblhrs" runat="server" Text="HOURS" CssClass="label"></asp:Label>

                                                <asp:TextBox ID="txthrs" onkeypress="ValidateNum(this);" ForeColor="Black" BackColor="white" runat="server" CssClass="textbox" AutoPostBack="true" Width="60px" MaxLength="2" onkeydown="return handleEnter(this, event)" Text="00"></asp:TextBox>
                                                <select id="selhrs" name="selhrs" style="width: 55px; height: 20px" onchange="javascript:gethrs()" class="textbox">
                                                    <option value="0">00</option>
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

                                                <asp:Label ID="lblmns" runat="server" Text="MINS" CssClass="label"></asp:Label>

                                                <asp:TextBox ID="txtmins" MaxLength="2" ForeColor="Black" BackColor="white" onkeypress="ValidateNum(this);" AutoPostBack="true" Text="00" runat="server" CssClass="textbox" Width="60px" onkeydown="return handleEnter(this, event)"></asp:TextBox>
                                                <select id="selmins" name="selmins" style="width: 55px; height: 20px" class="textbox" onchange="javascript:getmins()">
                                                    <option value="0">00</option>
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
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td align="left">
                                                <asp:Label ID="lblapptno" runat="server" Text="APPT NO." CssClass="label"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtapptno" ForeColor="Black" Enabled="false" runat="server" CssClass="NotEditabletextbox" Width="120px" onkeypress="ValidateNum(this);"></asp:TextBox>

                                                <asp:Label ID="lblslots" runat="server" Text="NO OF SLOTS" CssClass="label"></asp:Label>
                                                <asp:TextBox ID="txtslots" Enabled="false" ForeColor="Black" runat="server" CssClass="NotEditabletextbox" Width="80px"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td align="left">
                                                <asp:Label ID="lblRmrk" runat="server" Text="REMARKS" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="color: red">*</td>
                                            <td>
                                                <asp:TextBox ID="txtRmrk" ForeColor="Black" BackColor="White" runat="server" CssClass="textbox" Width="585px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Button ID="btnSelSrvDtls" Enabled="true" runat="server"
                                                    CssClass="buttonstandard" Text="OPERATION SERVICES" Style="text-align: center"
                                                    Width="200px" />

                                                <asp:Button ID="BtnSelDoc" Enabled="true" runat="server"
                                                    CssClass="buttonstandard" Text="OPERATION DOCTORS" Style="text-align: center" Width="200px" />

                                                <asp:Button ID="BtnSelEmp" Enabled="true" runat="server"
                                                    CssClass="buttonstandard" Text="SELECT EMPLOYEES" Style="text-align: center" Width="200px" />

                                                <asp:Button ID="btnsave" AccessKey="S" Text="SAVE" CssClass="buttonstandard" runat="server" Width="80px"
                                                    OnClientClick="return FinalValidations();" />

                                                <asp:Button ID="btncncl" Text="CANCEL" CssClass="buttonstandard" runat="server" Width="80px" />
                                                <asp:Button ID="btnCancelSave" runat="server" CssClass="buttonstandard" Style="display: none" />

                                            </td>
                                        </tr>
                                    </table>

                                    <div id="HdnDiv" runat="server" style="width: 100%; height: 1px; visibility: hidden">
                                        <table border="1" style="width: 100%; height: 1px; visibility: hidden">
                                            <tr>
                                                <td align="left" style="visibility: hidden">
                                                    <asp:RadioButton ID="rdoip" runat="server" Checked="True" Text="IP" Style="visibility: hidden" />
                                                </td>
                                                <td style="visibility: hidden">
                                                    <asp:RadioButton ID="rdoop" runat="server" Text="OP" Style="visibility: hidden" />
                                                </td>
                                                <td style="visibility: hidden">
                                                    <input id="txtflag" runat="server" enableviewstate="true" type="text" style="visibility: hidden" />
                                                </td>
                                            </tr>
                                            <caption>
                                                <input id="txtreqno" runat="server" enableviewstate="true" type="text" style="visibility: hidden" />
                                                <input id="txtimgsession" runat="server" enableviewstate="true" type="text" style="visibility: hidden" />
                                                <input id="txtactionflag" runat="server" enableviewstate="true" type="text" style="visibility: hidden" />
                                                <asp:Button ID="btnFinalSave" runat="server" Width="1px" Height="1px" Style="visibility: hidden" />
                                                <asp:Button ID="btnFinalCncl" runat="server" Width="1px" Height="1px" Style="visibility: hidden" />
                                                <asp:Button ID="btnFinalShift" runat="server" Width="1px" Height="1px" Style="visibility: hidden" />
                                                <asp:Button ID="btnRedirect" runat="server" Width="1px" Height="1px" Style="visibility: hidden" />
                                                <asp:Button ID="btnRowDblclicked" runat="server" Width="1px" Height="1px" Style="visibility: hidden" />
                                            </caption>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </td>
                            <td align="left" style="width: 180px;">
                                <asp:Panel ID="Pnl3" runat="server" CssClass="panel" Height="185px" Style="margin: 0px; padding: 0px">
                                    <div style="width: 100px; height: 180px;">
                                        <table style="height: 220px;">
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="btnnewbkng" Text="NEW BOOKING" CssClass="buttonstandard" runat="server" Width="170px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="btnmdfybkng" runat="server" CssClass="buttonstandard" Text="MODIFY BOOKING" Style="width: 170px;" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="btncnclbkng" CssClass="buttonstandard" runat="server" Text="CANCEL BOOKING" Width="170px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="btnshft" Text="SHIFT MANUAL" CssClass="buttonstandard" runat="server" Width="170px" Height="26px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="btnshftnow" runat="server" CssClass="buttonstandard" Text="SHIFT NOW" Style="width: 170px;" />
                                                </td>
                                            </tr>
                                            <tr style="visibility: hidden">
                                                <%-- <td style="visibility: hidden" />--%>
                                                <td>
                                                    <asp:Button ID="Button1" Text="TEST" CssClass="divskyblue" runat="server" Width="1px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>

            <div id="divschedule" runat="server" style="width: 100%; position: relative; top: 0px; left: 0px;">
                <table>
                    <tr>
                        <td style="position: relative;">
                            <asp:Panel ID="Pnl4" runat="server" CssClass="panel" Height="175px" Style="margin: 0px; padding: 0px">
                                <asp:Panel ID="pnlMainFrm" runat="server" Height="100%" Width="100%">
                                    <iframe id='instimage' scrolling="no" name='instimage'
                                        style="width: 1325px; height: 175px;" src='image.aspx?slipno=sdsd'></iframe>
                                </asp:Panel>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Pnl5" runat="server" CssClass="panel" Height="164px" Style="margin: 0px; padding: 0px;">
                                <asp:Panel ID="pnl001" runat="server" Width="1325px" Height="150px" ScrollBars="Vertical">
                                    <asp:GridView ID="GrdReqDetails" runat="server" AlternatingRowStyle-CssClass="Alternategridrows"
                                        AllowSorting="True"
                                        AutoGenerateColumns="False"
                                        HeaderStyle-CssClass="gridcolumnheader" GridLines="Horizontal" CssClass="gridrows"
                                        Width="100%" Style="cursor: pointer">
                                        <RowStyle Height="5px" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="REQNO" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblReqNo" Text='<%#Eval("REQ_NO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DOCTOR" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblDocCd" Text='<%#Eval("DOC_CD")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DOCTOR NAME" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblDocName" Text='<%#Eval("doc_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="START TIME" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblaptmfrm" Text='<%#Eval("APTM_TM_FROM")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="END TIME" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblaptmto" Text='<%#Eval("APTM_TM_TO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PATIENT NO" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblptnNo" Text='<%#Eval("PTN_NO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PATIENT NAME" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblptnname" Text='<%#Eval("PTN_LNG_NM")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="IP/OP" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblIPOP" Text='<%#Eval("IP_OP")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="APPT NO" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblAppNo" Text='<%#Eval("APPT_NO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>

            <div class="bottompanel">
                <asp:Button ID="btnPrint" runat="server" CssClass="buttonstandard" Text="PRINT" Visible="false" />
                <asp:Button ID="btnexit" runat="server" CssClass="buttonstandard" Text="BACK" OnClientClick="return setsession1();" />
                <asp:Button ID="btnFinalPrint" Style="visibility: hidden" runat="server" Height="1px" Width="1px" />
                <asp:Button ID="btnFinalPrintCancel" Style="visibility: hidden" runat="server" Height="1px" Width="1px"
                    OnClick="btnFinalPrintCancel_Click" />
                <asp:Button ID="Button4" Style="visibility: hidden" runat="server" Height="1px" Width="1px" />
            </div>

            <div>
                <asp:HiddenField ID="hfPtnType" runat="server" />
                <asp:HiddenField ID="HfAppMdCd" runat="server" />
                <asp:HiddenField ID="HfAppSubMdCd" runat="server" />
                <asp:HiddenField ID="hfaccess" runat="server" />
                <asp:HiddenField ID="hfsave" runat="server" />
                <asp:HiddenField ID="hfdelete" runat="server" />
                <asp:HiddenField ID="hfprint" runat="server" />
                <asp:HiddenField ID="hfauth" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
