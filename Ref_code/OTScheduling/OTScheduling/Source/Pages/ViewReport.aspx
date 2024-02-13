<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage.master" CodeBehind="ViewReport.aspx.vb" Inherits="OTScheduling.ViewReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="Scripts/jquery-1.4.4.min.js"></script>
    <style type="text/css">
        .reportViewerCtrl {
        }
    </style>
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {

            if ($.browser.mozilla || $.browser.webkit) {

                try {

                    showPrintButton();

                }

                catch (e) { alert(e); }

            }

        });



        function showPrintButton() {

            var table = $("table[title='Refresh']");

            var parentTable = $(table).parents('table');

            var parentDiv = $(parentTable).parents('div').parents('div').first();

            //parentDiv.append('<select name="ctl00$ContentPlaceHolder1$reportViewer$rptViewer$ctl01$ctl03$ctl00" title="Zoom" id="ctl00_ContentPlaceHolder1_reportViewer_rptViewer_ctl01_ctl03_ctl00" style="font-family: Verdana; font-size: 8pt; onclick="PrintReport(); onChange="showzoom();"> ');
            //parentDiv.append('<input name="ctl00$ContentPlaceHolder1$reportViewer$rptViewer$ctl01$ctl04$ctl00" title="Find Text" id="ctl00_ContentPlaceHolder1_reportViewer_rptViewer_ctl01_ctl04_ctl00" style="font-family: Verdana; font-size: 8pt;" onkeypress="keyprs();" onpropertychange="propertychnge();" type="text" size="10" maxLength="255"/>');
            //parentDiv.append('<a title="Find" id="ctl00_ContentPlaceHolder1_reportViewer_rptViewer_ctl01_ctl04_ctl01" style="font-family: Verdana; color: gray; font-size: 8pt; text-decoration: none;" href="#" onclick="Find();" onmouseover="mouseover();" onmouseout="mouseout();"  Controller="[object Object]">Find</a>');
            //parentDiv.append('<a title="Find Next" id="ctl00_ContentPlaceHolder1_reportViewer_rptViewer_ctl01_ctl04_ctl03" style="font-family: Verdana; color: gray; font-size: 8pt; text-decoration: none;" onmouseover="this.Controller.OnLinkHover();" onmouseout="this.Controller.OnLinkNormal();" onclick="Next();" href="#" Controller="[object Object]"> | Next</a>');
            //  parentDiv.append('<input type="image" style="border-width: 0px; padding: 3px;margin-top:2px; height:16px; width: 16px; text-decoration:none;" alt="Print" title="Print" src="/Reserved.ReportViewerWebControl.axd?OpType=Resource&Version=10.0.40219.1&Name=Microsoft.Reporting.WebForms.Icons.Print.gif" onclick="PrintReport();">');
            // parentDiv.append('<input type="image" style="border-width: 0px;  padding: 3px;margin-top:2px; height:16px; width: 16px;" alt="Print" src="/Reserved.ReportViewerWebControl.axd?OpType=Resource&amp;Version=10.0.0.0&amp;Name=~/Images/Search.ico";title="Print" onclick="PrintReport();">');

            parentDiv.append('<input type="image" style="border-width: 0px; padding: 3px;margin-top:2px; height:16px; width: 16px; text-decoration:none;" alt="Print" title="Print" src="/CWWEB/OTScheduling/Reserved.ReportViewerWebControl.axd?OpType=Resource&Version=10.0.40219.1&Name=Microsoft.Reporting.WebForms.Icons.Print.gif" onclick="PrintReport();">');
        }

        function Next() {

            document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_rptViewer').ClientController.HandleSearchNext();

            return false;
        }
        function mouseout() {
            this.Controller.OnLinkNormal();
        }
        function mouseover() {
            this.Controller.OnLinkHover();
        }

        function keyprs() {
            if (event.keyCode == 10 || event.keyCode == 13) {
                document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_rptViewer').ClientController.ActionHandler('Search', document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_rptViewer_ctl01_ctl04_ctl00').value);; return false;
            }
        }
        function propertychnge() {

            if (event.propertyName == 'value') {
                document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_rptViewer_ctl01_ctl04_ctl01').Controller.SetViewerLinkActive(this.value != null && this.value != '');
                document.getElementById('ctl00_ContentPlaceHolder1_reportViewer_rptViewer_ctl01_ctl04_ctl03').Controller.SetViewerLinkActive(false);
            }
        }

        // Print Report function

        function PrintReport() {

            ////Code for adding HTML content to report viwer
            //var headstr = "<html><head><title></title></head><body>";
            ////End of body tag
            //var footstr = "</body></html>";
            ////This the main content to get the all the html content inside the report viewer control
            ////"ReportViewer1_ctl10" is the main div inside the report viewer
            ////controls who helds all the tables and divs where our report contents or data is available
            //var newstr = $("#ctl00_ContentPlaceHolder1_reportViewer_rptViewer").html();
            ////open blank html for printing
            //var popupWin = window.open('printrpt.aspx', '_blank');
            ////paste data of printing in blank html page
            //popupWin.document.write(headstr + newstr + footstr);   //Aarti Commented
            ////print the page and see is what you see is what you get
            //popupWin.print();
            //return false;

            var finalsettings = callsettings('6');
            window.open("printrpt.aspx", "ModalPopUp", finalsettings);
            // popupWin.print();
            return false;
        };


        $(document).ready(function () {


            if ($.browser.webkit) {
                $(".reportViewerCtrl table").css('display', 'inline-block');


            }
        });

        $(DocReady);
        function DocReady() {
            $('option[value = PDF]').remove();
        }

        function opendefault() {
            //alert('Hello 1');
            var finalsettings = callsettings('6');
            window.open("printrpt.aspx", "ModalPopUp", finalsettings);
            //alert('Hello 2');
        }



    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <asp:Panel runat="server" ID="Pnl1" Style="height: 525px; width: 1310px" CssClass="panel">
        <%--        <rsweb:ReportViewer ID="rview" runat="server" Width="1330px" ShowPromptAreaButton="True" ShowParameterPrompts="false" PromptAreaCollapsed="True" Height="538px" ShowPrintButton="True"></rsweb:ReportViewer>--%>

        <rsweb:ReportViewer ID="rview" CssClass="reportViewerCtrl" runat="server"
            Width="1330px" ShowPromptAreaButton="True" ShowParameterPrompts="false" Height="538px"
            ZoomMode="Percent" SizeToReportContent="false" AsyncRendering="false"
            ShowBackButton="false">
        </rsweb:ReportViewer>
    </asp:Panel>
    <div class="bottompanel">
        <asp:Button ID="btnBack" runat="server" CssClass="buttonstandard" Text="BACK" OnClick="btnBack_Click" />

    </div>
</asp:Content>

