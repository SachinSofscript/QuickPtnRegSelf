<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage.master" CodeBehind="OTRequest.aspx.vb" Inherits="OTScheduling.OTRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript">

        function SetReturnValue1() {

            __doPostBack();
        }
    </script>

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

        function finalvalidations() {


            if (document.getElementById("<%=txtpatid.ClientID%>").value == "") {
                document.getElementById("<%=txtpatid.ClientID%>").focus();
                alertify.alert("Enter Valid Patient Number");
                return false;
            }
            if (document.getElementById("<%=txtdctid.ClientID%>").value == "") {
                document.getElementById("<%=txtdctid.ClientID%>").focus();
                alertify.alert("Enter Valid Doctor Number");
                return false;

            }
            if (document.getElementById("<%=txtpatname.ClientID%>").value == "") {
                document.getElementById("<%=txtpatname.ClientID%>").focus();
                alertify.alert("Enter Valid Patient Code & Name");
                return false;
            }
            if (document.getElementById("<%=txtdctname.ClientID%>").value == "") {
                document.getElementById("<%=txtdctname.ClientID%>").focus();
          alertify.alert("Enter Valid Doctor Code & Name");
          return false;
      }

            //else {
            //    return savecnfirmation();
            //}
  }

  function clearall() {
      document.getElementById("ContentPlaceHolder1_txtpatid").value = '';
      document.getElementById("ContentPlaceHolder1_txtpatname").value = '';
      document.getElementById("ContentPlaceHolder1_txtdctid").value = '';
      document.getElementById("ContentPlaceHolder1_txtdctname").value = '';


      document.getElementById("ContentPlaceHolder1_txtflag").value = '';
      document.getElementById("ContentPlaceHolder1_txtreqno").value = '';

      document.getElementById("ContentPlaceHolder1_txtpatid").disabled = true;
      document.getElementById("ContentPlaceHolder1_txtdctid").disabled = true;



      document.getElementById("ContentPlaceHolder1_btnsave").disabled = true;

      $("#ContentPlaceHolder1_btnsave").removeClass('buttonstandard').addClass("divskyblue");

      document.getElementById("ContentPlaceHolder1_btnsave").disabled = true;

  }




  function setshiftnow() {
      document.getElementById("ContentPlaceHolder1_Button1").click();
      return true;
  }
  //Nutan 11.01.2022
  function PermCheck(chk) {
      if (chk.checked == true) {
          document.getElementById("ContentPlaceHolder1_lblchkSts").innerText = "Given";

      }
      else {
          document.getElementById("ContentPlaceHolder1_lblchkSts").innerText = "Not Given";
      }
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
    <asp:UpdatePanel ID="pnlMain" runat="server">
        <ContentTemplate>
            

            <asp:Label ID="LblHeaderTitle" runat="server" class="headerblue" Text="NEW OT REQUEST"></asp:Label>
            <div id="divmain" style="width: 100%">
                <table cellpadding="0" cellspacing="0" border="1" style="width: 100%">
                    <asp:ImageButton ID="ImageButton3" Width="1px" runat="server" ImageUrl="~/Images/Search.ico"
                        Style="visibility: hidden" />

                    <tr>
                        <td align="left">
                            <div id="maindiv">
                                <table style="height: 175px;">
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblpat" runat="server" Text="PATIENT NO" CssClass="label"></asp:Label>
                                            <span class="mandatory">*</span>
                                            <asp:ImageButton ID="Imgsearchptn" runat="server" ImageUrl="~/Images/Search.ico"
                                                OnClientClick="javascript:HelpImg(event,this,'txtpatid','PatNo','3','InPatientHelp.aspx','extra');return false;"
                                                Width="16px" ToolTip="Patient Help" />

                                            <asp:TextBox ID="txtpatid" ToolTip="Enter Patient Number" ForeColor="Black" BackColor="White" runat="server" AutoPostBack="true" MaxLength="12"
                                                onkeypress="ValidateNum(this);" CssClass="textbox" Width="120px" onkeyup="javascript:Help(event,this,'txtpatid','PatNo','3','InPatientHelp.aspx','extra');return false;"></asp:TextBox>

                                            <asp:TextBox ID="txtpatname" Enabled="false" ForeColor="Black" runat="server" CssClass="NotEditabletextbox" Width="400px"></asp:TextBox>
                                            <%----%>

                                            <asp:Image ID="imgIsolated" runat="server" ImageUrl="~/Images/isolated_ptn_24px.png" Visible ="false"  ToolTip="Patient Isolated" Height="15px" Width ="15px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lbldct" runat="server" Text="DOCTOR NO" CssClass="label"></asp:Label>
                                            <span class="mandatory">*</span>
                                            <asp:ImageButton ID="imageSearchDoc" runat="server" ImageUrl="~/Images/Search.ico"
                                                Width="16px" OnClientClick="javascript:HelpImg(event,this,'txtdctid','DctNo','2','DoctorSearch.aspx','extra');return false;" ToolTip="Doctor Help" />
                                            <asp:TextBox ID="txtdctid" ToolTip="Enter Doctor Number" ForeColor="Black" BackColor="White" runat="server" AutoPostBack="true" MaxLength="4"
                                                onkeypress="ValidateNum(this);" CssClass="textbox" Width="120px" onkeyup="javascript:Help(event,this,'txtdctid','DctNo','2','DoctorSearch.aspx','extra');return false;"></asp:TextBox>
                                            <asp:TextBox ID="txtdctname" Enabled="false" ForeColor="Black" runat="server" CssClass="NotEditabletextbox" Width="400px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style1">
                                            <asp:Label ID="lbldt" runat="server" Text="GET EXPECTED DATE" CssClass="label"></asp:Label>
                                            &nbsp;
                                            <asp:TextBox ID="txtdate" runat="server" AutoPostBack="true" CssClass="textbox" ToolTip="Enter Date" Height="16px"></asp:TextBox>
                                            <asp:CalendarExtender ID="toCal1" runat="server" CssClass="MyCalendar" Format="dd/MM/yyyy" PopupButtonID="txtdate" TargetControlID="txtdate"></asp:CalendarExtender>
                                        </td>
                                    </tr>
                                    <%--Nutan 11.01.2022--%>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblIsOffPerm" runat="server" Text="OFFICE PERMISSION?" CssClass="label"></asp:Label>
                                             <asp:CheckBox ID="chkIsOffPerm" runat="server" onclick="PermCheck(this);" />
                                            <asp:Label ID="lblchkSts" runat="server" ForeColor="Red" Width="50px" CssClass="label"></asp:Label>
                                            <asp:TextBox ID="txtoffPermRmrk" Width="200px" runat="server" CssClass="textbox" placeHolder="Enter Remark" MaxLength="100" Text='<%# Eval("OfficePrmsnRmrk")%>'></asp:TextBox>
                                        </td>

                                    </tr>
                                    <%--Nutan 11.01.2022--%>

                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
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
            <div>
                <label class="headerblue">FUTURE OT LIST</label>
                <asp:Panel ID="Panel1" runat="server" CssClass="panel" Height="305px" ScrollBars="Vertical">
                    <asp:GridView ID="grdOtList" runat="server" AlternatingRowStyle-CssClass="Alternategridrows"
                        HeaderStyle-CssClass="gridcolumnheader" AutoGenerateColumns="False" CssClass="gridrows"
                        Width="100%" ShowHeaderWhenEmpty="true" HeaderStyle-Wrap ="false" RowStyle-Wrap ="false" >
                        <AlternatingRowStyle CssClass="Alternategridrows" />
                        <Columns>
                            <asp:BoundField DataField="ExpectedDate" HeaderText="DATE" ItemStyle-CssClass="label" DataFormatString="{0:d}" HeaderStyle-Width="80px" />
                            <asp:TemplateField HeaderText="IP NO" HeaderStyle-Width="90px">
                                <ItemTemplate>
                                    <asp:Label ID="lblptnno" runat="server" Text='<%#  Eval("PtnNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PtnFrstNm" HeaderText="PATIENT FIRST NAME" Visible="false" ItemStyle-CssClass="label" />
                            <asp:BoundField DataField="PtnFullNm" HeaderText="PATIENT NAME" ItemStyle-CssClass="label" HeaderStyle-Width="300px" />
                            <asp:BoundField DataField="DocCd" HeaderText="DOCTOR cODE" Visible="false" ItemStyle-CssClass="label" HeaderStyle-Width="300px" />
                            <asp:BoundField DataField="DocFullNm" HeaderText="DOCTOR NAME" Visible="true" ItemStyle-CssClass="label" HeaderStyle-Width="300px" />
                               <asp:BoundField DataField="Title" HeaderText="STATUS" Visible="true" ItemStyle-CssClass="label" HeaderStyle-Width="300px" />
                            <asp:BoundField DataField="TrnNo" HeaderText="REQ/APP NO" ItemStyle-CssClass="label" HeaderStyle-Width="50px" />

                        </Columns>

                    </asp:GridView>
                </asp:Panel>
            </div>

            <div class="bottompanel">
                <asp:Button ID="btnsave" runat="server" Text="SAVE" CssClass="buttonstandard"
                    OnClientClick="return finalvalidations();" />
                <asp:Button ID="btnCancel" runat="server" CssClass="buttonstandard" Text="CLEAR"
                    TabIndex="24" />
                <asp:Button ID="btnExit" runat="server" CssClass="buttonstandard" Text="EXIT" TabIndex="26"
                    OnClientClick="return setsession1()" />
                <asp:Button ID="btnFinalPrint" Style="visibility: hidden" runat="server" Height="1px" Width="1px" />
                <asp:Button ID="Button1" Style="visibility: hidden" runat="server" Height="1px" Width="1px" />
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
    <asp:HiddenField ID="hfOffPermDtl" runat="server" />   <%--Nutan 12-Jan-2022--%>
</asp:Content>
