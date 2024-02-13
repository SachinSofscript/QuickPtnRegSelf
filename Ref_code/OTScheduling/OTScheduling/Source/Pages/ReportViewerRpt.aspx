<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Pages/MasterPage.master" CodeBehind="ReportViewerRpt.aspx.vb" Inherits="OTScheduling.ReportViewerRpt" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="Scripts/jquery-1.4.4.min.js"></script>
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

        function PrintReport() {
            var finalsettings = callsettings('6');
            window.open("printrpt.aspx", "ModalPopUp", finalsettings);
            return false;
        };
        
        $(document).ready(function () {
            if ($.browser.webkit) {
                $(".reportViewerCtrl table").css('display', 'inline-block');
            }
        });

        $(document).ready(function () {
            $("#VisibleReportContentctl00_ContentPlaceHolder1_rview_ctl09").width('1000px');
        });

        $(DocReady);
        function DocReady() {
            $('option[value = PDF]').remove();
        }

        function opendefault() {
            var finalsettings = callsettings('6');
            window.open("printrpt.aspx", "ModalPopUp", finalsettings);
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     
    <div style="height: 530px; width: 1310px; margin-top: 0px;" class="panel">
        <rsweb:ReportViewer ID="rview" CssClass="reportViewerCtrl" runat="server"
            Width="1310px" ShowPromptAreaButton="True" ShowParameterPrompts="false" Height="535px"
            ZoomMode="Percent" SizeToReportContent="false" AsyncRendering="false"
            ShowBackButton="false">
        </rsweb:ReportViewer>
    </div>

    <div class="bottompanel">
        <asp:Button ID="btnBack" runat="server" CssClass="buttonstandard" Text="BACK" OnClick="btnBack_Click" />
    </div>
</asp:Content>
