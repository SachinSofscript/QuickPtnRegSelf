<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PtnQuickReg.ascx.vb" Inherits="OTScheduling.PtnQuickReg" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxCntrl" %>

<script type="text/javascript">


</script>

<style type="text/css">
    .TextBoxNewPtnCss {
        border: 2px solid #b6bfc7;
        border-radius: 5px;
        height: 25px;
        width: 412px;
    }

    .TextBoxNewPtnDYMCss {
        border: 2px solid #b6bfc7;
        border-radius: 5px;
        height: 25px;
        margin-left: 5px;
        width: 50px;
    }

    .TextBoxNewPtnDOBCss {
        border: 2px solid #b6bfc7;
        border-radius: 5px;
        height: 25px;
        width: 150px;
    }

    .DdlNewPtnCss {
        border: 2px solid #b6bfc7;
        border-radius: 5px;
        height: 30px;
        width: 420px;
    }
</style>

<div style="background-color: aliceblue; width: 460px;">
    <table>
        <tr>
            <td>
                <span style="font-weight: bold; color: #259a28;">REGISTER NEW PATIENT
                </span>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox runat="server" ID="txtMobileNo" MaxLength="12" AutoPostBack="true" OnTextChanged="txtMobileNo_TextChanged" CssClass="TextBoxNewPtnCss" placeholder="Mobile" onkeypress="ValidateNum(this);"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel runat="server" ID="pnlMultiMobNo" Visible="false">
                    <table colspan="0px" cellspan="0px">
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="This Mobile no is already registered with below patients records" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="overflow: auto; height: 80px; width: 100%;">
                                    <asp:GridView ID="grdMobileNo" runat="server" Height="50px" AllowSorting="True" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
                                        CssClass="Help3rows" GridLines="Horizontal" OnRowCommand="grdMobileNo_RowCommand">
                                        <HeaderStyle CssClass="Help3headerStyle" ForeColor="White" />
                                        <RowStyle CssClass="Help3rowStyle" />
                                        <AlternatingRowStyle CssClass="Help3alternatingRowStyle" />
                                        <FooterStyle CssClass="Help3footerStyle" />
                                        <PagerStyle CssClass="Help3pagerStyle" ForeColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="PATIENT NO" ItemStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPtnNoforContact" runat="server" Text='<%#Eval("PatientNo")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PATIENT FULL NAME" ItemStyle-Width="200px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPtntFullNameforContact" runat="server" Text='<%#Eval("PatientFullName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="20px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblsel" runat="server" CommandName="SEL" CssClass="label" ForeColor="Blue">SEL</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList runat="server" CssClass="DdlNewPtnCss" ID="ddlPtnTtl" AutoPostBack ="true" OnTextChanged ="ddlPtnTtl_TextChanged" ToolTip="Patient Title"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox runat="server" ID="txtLstName" MaxLength="100" CssClass="TextBoxNewPtnCss" placeholder="Last Name" ToolTip="Patient Last Name"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox runat="server" ID="txtFirstName" MaxLength="100" CssClass="TextBoxNewPtnCss" placeholder="First Name" ToolTip="Patient First Name"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:TextBox runat="server" ID="txtMiddleName" MaxLength="100" CssClass="TextBoxNewPtnCss" placeholder="Middle Name" ToolTip="Patient Middle Name"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtBirthDt" placeholder="Birth Date" ToolTip="Patient Birth Date" onkeypress="ValidateNum(this);" CssClass="TextBoxNewPtnDOBCss" AutoPostBack="true" OnTextChanged="txtBirthDt_TextChanged"></asp:TextBox>
                            <AjaxCntrl:CalendarExtender runat="server" ID="calextendr2" CssClass="MyCalendar" PopupButtonID="txtBirthDt" TargetControlID="txtBirthDt" Format="dd/MM/yyyy"></AjaxCntrl:CalendarExtender>
                        </td>
                        <td>
                            <asp:TextBox runat="server" MaxLength="3" CssClass="TextBoxNewPtnDYMCss" onkeypress="ValidateNum(this);" ID="txtYY" Width="50px" placeholder="YY" ToolTip="Year" AutoPostBack="true" OnTextChanged="txtYY_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" MaxLength="2" CssClass="TextBoxNewPtnDYMCss" onkeypress="ValidateNum(this);" ID="txtMM" Width="50px" placeholder="MM" AutoPostBack="true" OnTextChanged="txtMM_TextChanged" ToolTip="Month"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" MaxLength="2" CssClass="TextBoxNewPtnDYMCss" onkeypress="ValidateNum(this);" ID="txtDD" Width="50px" placeholder="DD" AutoPostBack="true" OnTextChanged="txtDD_TextChanged" ToolTip="Day"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList runat="server" ID="ddlGender" CssClass="DdlNewPtnCss" ToolTip="Patient Gender">
                    <asp:ListItem Value="F" Text="Female"></asp:ListItem>
                    <asp:ListItem Value="M" Text="Male"></asp:ListItem>
                    <asp:ListItem Value="T" Text="Transgender"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList runat="server" ID="ddlNtnlity" CssClass="DdlNewPtnCss" placeholder="State" ToolTip="Nationality"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox runat="server" ID="txtstate" CssClass="TextBoxNewPtnCss" placeholder="State" AutoPostBack="true" ToolTip="State" OnTextChanged="txtstate_TextChanged"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtstatecd" Visible="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox runat="server" ID="txtcity" CssClass="TextBoxNewPtnCss" placeholder="City" ToolTip="City"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList runat="server" ID="ddlPtnType" CssClass="DdlNewPtnCss" ToolTip="Patient Type" OnSelectedIndexChanged="ddlPtnType_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" CssClass="btncss" Width="100px" ID="btnRegNewPtn" OnClick="btnRegNewPtn_Click" Text="REGISTER" />
                <asp:Button runat="server" CssClass="btncss" Width="80px" OnClick="btnBck_Click" ID="btnBck" Text="BACK" />
                <asp:Button runat="server" ID="btnFinalSave" OnClick="btnFinalSave_Click" Style="visibility: hidden" />
                <asp:HiddenField runat="server" ID="hdnStCd" />
                <asp:HiddenField runat="server" ID="hdnCityCd" />
                <asp:HiddenField ID="hfNewPtnno" runat="server" />
                <asp:HiddenField ID="hfCountrCd" runat="server" />
            </td>
        </tr>
    </table>
</div>



