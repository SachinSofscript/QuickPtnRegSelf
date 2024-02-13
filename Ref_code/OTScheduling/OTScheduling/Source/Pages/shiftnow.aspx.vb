#Region "IMPORTS"
Imports OTScheduling.OTSchedulingSerRef
Imports OTScheduling.CmnSecurityFunSrvRef
Imports System.Data
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Drawing
Imports System.IO
Imports Microsoft.VisualBasic
#End Region

Partial Class Pages_shiftnow
    Inherits System.Web.UI.Page

#Region "GLOBAL DECLRATIONS"
    Dim strErrMsg As List(Of String)
    Dim chrErrFlg As Char
    Shared lv_fct_slot_prd_hrs As Integer
    Shared lv_fct_slot_prd_mins As Integer
    Shared lvSessDur As Long
    Shared lvSlotDur As Long
    Dim SessionStartTIme As Date
    Dim SessionEndTIme As Date
    Dim SessionSlotDuration As Integer
    Dim CompleteScale As Boolean
    Public starttime As Date
    Public endtime As Date
    Shared btnarrcnt As Integer = 0
    Dim stdfont As Font = New Font("MS Reference Sans Serif", 10)
    Dim divwt As Integer = 50
    Shared divht As Integer = 30
    Shared sttm As Date = CDate("00:00")
    Shared endtm As Date = CDate("00:00")
    Const sltdur As Integer = 60
    Dim sltcnt As Long = 24
    Dim sessttm As Date
    Dim sessltcnt As Long
    Dim sesdivwt As Integer = 50
    Dim scalewidth As Integer
    Dim leftmargin As Integer
    Public TimeScaleBackcolor As Color
    Public TimeScaleForecolor As Color
    Public BookingAreaBackcolor As Color
    Dim cmpscale As Boolean = False
    Shared sess() As clsSession
    Shared btnarr() As clsTimeSlot
    Shared arrsession() As clsSession
    Shared lvnoofsessions As Integer
    Shared patid As String
    Shared patname As String
    Shared docid As String
    Shared docname As String
    Shared aptno As String
    Shared ipopflg As String
    Shared oldfctcode As String
    Dim Msg As String = Nothing
    'rasik

    Shared Remark As String 'shital 20210807
    Shared BookingType As Integer 'shital 20210809
    Public objArrOTSrvDtls As New List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)
    Public objArrOTDoctorsDtls As New List(Of OTSchedulingSerRef.clsOtDocDtls)
#End Region

#Region "PAGE EVENTS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strErrMsg = New List(Of String)
        chrErrFlg = "N"

        If Not IsPostBack Then
            clsGeneral.CheckSession(Me.Context, Session("USERID"))
            clsGeneral.SetDefaultSessionValue(ContentPlaceHolder1_HfAppMdCd, ContentPlaceHolder1_HfAppSubMdCd, Session("MAINMODCODE"), Session("MAINSUBMODCODE"))

            'Dim CSS_serverpath As String = System.Configuration.ConfigurationManager.AppSettings("CSS_serverpath")
            ''''''cssMaster.Attributes.Add("href", CSS_serverpath & "/Master.css")
            ''''''cssMaster.Attributes.Add("typ", "text/css")
            'csscommon.Attributes.Add("href", CSS_serverpath & "/stylesheet.css")
            'csscommon.Attributes.Add("typ", "text/css")
            'cssbutton.Attributes.Add("href", CSS_serverpath & "/ButtonStyles.css")
            'cssbutton.Attributes.Add("typ", "text/css")
            'cssalertifyboot.Attributes.Add("href", CSS_serverpath & "/alertify.bootstrap.css")
            'cssalertifyboot.Attributes.Add("typ", "text/css")
            'cssalertify.Attributes.Add("href", CSS_serverpath & "/alertify.core.css")
            'cssalertify.Attributes.Add("typ", "text/css")

            txtdate.Text = String.Format(clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")), "yyyy-MM-dd")
            txtot.Focus()

            Session("imgshft123") = Nothing
            patid = Request("patid")
            patname = Request("patname")
            docid = Request("docid")
            docname = Request("docname")
            aptno = Request("aptno")
            ipopflg = Request("ipflag")
            oldfctcode = Request("oldfctcd")

            Remark = Request("Remark") 'shital 20210807

            BookingType = Request("BookingType") 'shital 20210807


        End If
    End Sub
#End Region

#Region "TEXTBOX EVENTS"

    Protected Sub txtot_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtot.TextChanged
        If (txtot.Text <> "" And txtdate.Text <> "") Then
            UP1.Update() 'RasikV 20170125
            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            Dim OTName As String

            If txtot.Text = "" Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 7), "txtot", Page)
                txtot.Text = ""
                ClrPnl1() 'RasikV 20170206
                Exit Sub
            End If

            OTName = OTScheduling.GetOtName(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Val(txtot.Text))

            If OTName = "" And OTName = Nothing Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 11), "txtot", Page)
                txtot.Text = ""
                txtotname.Text = ""
                ClrPnl1() 'RasikV 20170206
            Else
                txtotname.Text = OTName.ToUpper()
                getsessions()
                txtdate.Focus()
            End If
            'getsessions()
            txtstrttm1.Text = IIf(txtstrttime.Text = "", "00:00", txtstrttime.Text)
        Else
            getsessions()
            ClrPnl1() 'RasikV 20170206
        End If
    End Sub

    Protected Sub txtdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdate.TextChanged
        Dim revdt As Date = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))

        UP1.Update() 'RasikV 20170125
        If txtdate.Text = "" Then 'RasikV 20170125
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 40), "txtdate", Page)
            txtdate.Text = Format(revdt, "dd/MM/yyyy")
            Exit Sub
        End If

        If IsDate(txtdate.Text) = False Then 'RasikV 20170125
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 40), "txtdate", Page)
            txtdate.Text = Format(revdt, "dd/MM/yyyy")
            Exit Sub
        End If

        If (CDate(txtdate.Text) < revdt) Then
            txtdate.Text = Format(revdt, "dd/MM/yyyy")
        End If
        getsessions()
    End Sub
#End Region

#Region "BUTTON EVENTS"
    Protected Sub btnnext_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnnext.Click
        If (txtdate.Text <> "") Then
            txtdate.Text = CDate(txtdate.Text).AddDays(1)
            getsessions()
            'btnnewbkng.Enabled = True
        End If
    End Sub

    Protected Sub btnpre_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnpre.Click
        If (txtdate.Text <> "") Then
            Dim revdt As Date = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
            If (CDate(txtdate.Text) = revdt) Then
            Else
                txtdate.Text = CDate(txtdate.Text).AddDays(-1)
                getsessions()
            End If
        End If
    End Sub

    Protected Sub btncncl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncncl.Click
        UP1.Update() 'RasikV 20170125
        UP2.Update() 'RasikV 20170125
        ClrPnl1() 'RasikV 20170206
        txtflag.Value = "A"
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        UP2.Update()
        If (finalvalidations()) Then
            If (CheckSlotAvailable(CDate(txtstrttm1.Text), CDate(txtstrttm1.Text).AddMinutes(txthrs.Text * 60 + txtmins.Text))) Then
                ShiftNowRecord()
            Else
                btnarr = Nothing
                btnarrcnt = 0
                getsessions()
            End If
        Else
            btnarr = Nothing
            btnarrcnt = 0
            getsessions()
        End If
    End Sub
#End Region

#Region "FUNCTIONS"
    Public Function GetpendingDetails() As Boolean
        Try
            UP1.Update() 'RasikV 20170125

            strErrMsg = New List(Of String)
            chrErrFlg = "N"
            Dim day As Integer = Weekday(txtdate.Text, Microsoft.VisualBasic.FirstDayOfWeek.Sunday)

            Dim clsfctmstr As List(Of clsFCTMST)
            clsfctmstr = OTScheduling.GetFCTHoliDayDay(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), CDate(txtdate.Text), Integer.Parse(txtot.Text))

            If (clsfctmstr IsNot Nothing) Then

                If (clsfctmstr(0).FCTRMKS <> "") Then
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 25), "", Page)
                    Return False
                End If
            End If


            Dim strtime As Integer = OTScheduling.GetFCTFCTSTRTTIME(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, Integer.Parse(txtot.Text), day)
            Dim Endtime As Integer = OTScheduling.GetFCTFCTENDTIME(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, Integer.Parse(txtot.Text), day)
            If (strtime = 0.ToString()) Then
                ClearDrawTimeScale()
                AddMessage()
                Return False
            End If
            If (strtime.ToString().Length = 3) Then
                txtstrttime.Text = "0" & Left(strtime.ToString(), 1) & ":" & Right(strtime.ToString(), 2)
            ElseIf (strtime.ToString().Length = 2) Then
                txtstrttime.Text = "00" & ":" & Right(strtime.ToString(), 2)
            ElseIf (strtime.ToString().Length = 1) Then
                txtstrttime.Text = "00" & ":" & "0" & Right(strtime.ToString(), 1)
            Else
                txtstrttime.Text = Left(strtime.ToString(), 2) & ":" & Right(strtime.ToString(), 2)
            End If
            If (Endtime.ToString().Length = 3) Then
                txtendtime.Text = "0" & Left(Endtime.ToString(), 1) & ":" & Right(Endtime.ToString(), 2)
            ElseIf (Endtime.ToString().Length = 2) Then
                txtendtime.Text = "00" & ":" & Right(Endtime.ToString(), 2)
            ElseIf (Endtime.ToString().Length = 1) Then
                txtendtime.Text = "00" & ":" & "0" & Right(Endtime.ToString(), 1)
            Else
                txtendtime.Text = Left(Endtime.ToString(), 2) & ":" & Right(Endtime.ToString(), 2)
            End If
            GetpendingDetails = False
            Dim clsmstr As List(Of OTSchedulingSerRef.clsMaster)
            clsmstr = OTScheduling.GetFctMstDtlList(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Integer.Parse(txtot.Text), 1, 1)
            If (clsmstr IsNot Nothing) Then
                lv_fct_slot_prd_hrs = clsmstr(0).data2
                lv_fct_slot_prd_mins = clsmstr(0).data3
            End If
            GetpendingDetails = True
        Catch ex As Exception
            GetpendingDetails = False
        End Try
        Return GetpendingDetails
    End Function

    Public Sub getsessions()
        Try
            If (txtot.Text <> "") Then
                arrsession = Nothing
                btnarr = Nothing
                btnarrcnt = 0
                If (GetpendingDetails()) Then
                    strErrMsg = New List(Of String)
                    chrErrFlg = "N"
                    GetSlotsCount()
                    Dim day As Integer = Weekday(txtdate.Text, Microsoft.VisualBasic.FirstDayOfWeek.Sunday)
                    Dim clsfctcal As List(Of clsFCTCAL)
                    clsfctcal = OTScheduling.GetFCCAL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Integer.Parse(txtot.Text), 1, 1, day)
                    If (clsfctcal IsNot Nothing) Then
                        'ReDim arrsession(lvnoofsessions - 1)
                        For i As Integer = 0 To clsfctcal.Count - 1
                            Dim tmp As New clsSession
                            ReDim Preserve arrsession(i)
                            If (clsfctcal(i).STRTTIME.ToString().Length = 3) Then
                                tmp.starttime = CDate("0" & Left(clsfctcal(i).STRTTIME.ToString(), 1) & ":" & Right(clsfctcal(i).STRTTIME.ToString(), 2))
                            ElseIf (clsfctcal(i).STRTTIME.ToString().Length = 2) Then
                                tmp.starttime = CDate("00" & ":" & Right(clsfctcal(i).STRTTIME.ToString(), 2))
                            ElseIf (clsfctcal(i).STRTTIME.ToString().Length = 1) Then
                                tmp.starttime = CDate("00" & ":" & "0" & Right(clsfctcal(i).STRTTIME.ToString(), 1))
                            Else
                                tmp.starttime = CDate(Left(clsfctcal(i).STRTTIME.ToString(), 2) & ":" & Right(clsfctcal(i).STRTTIME.ToString(), 2))
                            End If
                            If (clsfctcal(i).ENDTIME.ToString().Length = 3) Then
                                tmp.endtime = CDate("0" & Left(clsfctcal(i).ENDTIME.ToString(), 1) & ":" & Right(clsfctcal(i).ENDTIME.ToString(), 2))
                            ElseIf (clsfctcal(i).ENDTIME.ToString().Length = 2) Then
                                tmp.endtime = CDate("00" & ":" & Right(clsfctcal(i).ENDTIME.ToString(), 2))
                            ElseIf (clsfctcal(i).ENDTIME.ToString().Length = 1) Then
                                tmp.endtime = CDate("00" & ":" & "0" & Right(clsfctcal(i).ENDTIME.ToString(), 1))
                            Else
                                tmp.endtime = CDate(Left(clsfctcal(i).ENDTIME.ToString(), 2) & ":" & Right(clsfctcal(i).ENDTIME.ToString(), 2))
                            End If
                            arrsession(i) = tmp
                        Next
                        sess = arrsession
                    End If
                    If arrsession Is Nothing Then
                        AddMessage()
                    Else
                        DrawTimeControl()
                        FillBooking(Integer.Parse(txtot.Text), CDate(txtdate.Text))
                    End If
                    'Dim dtserverdttm As Date = clsGeneral.getdate()
                End If
                'Dim pstartime As Date = CDate(txtstrttm1.Text)
                'Dim pendime As Date = CDate(txtstrttm1.Text).AddMinutes(txthrs.Text * 60 + txtmins.Text)
                'Dim pslots As Long = CalNoofSlotsRequired(pstartime, pendime, lvSlotDur)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function CalNoofSlotsRequired(ByVal pstartime As Date, ByVal pendime As Date, ByVal pSlotDur As Long) As Long
        If txtstrttime.Text.Trim <> "" And pSlotDur <> 0 Then
            Dim psttmmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(txtstrttime.Text), pstartime)
            Dim pentmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(txtstrttime.Text), pendime)
            Dim pslots As Long = System.Math.Floor((pentmins - psttmmins) / pSlotDur)
            Return pslots
        Else
            Return 0
        End If
    End Function

    Public Function GetSlotsCount() As Long
        Try
            lvSessDur = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(txtstrttime.Text), CDate(txtendtime.Text))
            If lv_fct_slot_prd_hrs <> 0 Then
                lvSlotDur = (lv_fct_slot_prd_hrs * 60) + lv_fct_slot_prd_mins
            Else
                lvSlotDur = lv_fct_slot_prd_mins
            End If
            GetSlotsCount = System.Math.Floor(lvSessDur / lvSlotDur)
        Catch ex As Exception
            GetSlotsCount = 0
        End Try
    End Function

    Public Sub DrawTimeControl()
        Dim bmp As New Bitmap(1500, 2500)
        Dim g As Graphics = System.Drawing.Graphics.FromImage(bmp)
        DrawTimeScale(g)
        CustomPaint(g, bmp)
    End Sub

    Public Sub CustomPaint(ByVal g As Graphics, ByVal bmp As Bitmap)
        Try
            DrawSession(g, sess)
            ' BtnResize()
            g.Flush()
            Dim img_converter As New ImageConverter()
            Dim bytes As Byte() = DirectCast(img_converter.ConvertTo(bmp, GetType(Byte())), Byte())
            Session("imgshft123") = Nothing
            Session("imgshft123") = bytes
        Catch ex As Exception
            Dim i As Integer = 45
        End Try
    End Sub

    Public Sub DrawTimeScale(ByVal g As Graphics)
        Try
            If cmpscale = False Then
                SessionStartTIme = CDate(txtstrttime.Text)
                SessionEndTIme = CDate(txtendtime.Text)
                sttm = CDate(Strings.Right("00" & SessionStartTIme.Hour, 2) & ":00")
                endtm = CDate(Strings.Right("00" & SessionEndTIme.Hour, 2) & ":00")
                If SessionEndTIme.Minute <> 0 Then
                    endtm = endtm.AddHours(1)
                End If
                sltcnt = DateDiff(DateInterval.Minute, sttm, endtm) / sltdur
            Else
                sttm = CDate("00:00")
                endtm = sttm.AddHours(23).AddMinutes(59)
                sltcnt = DateDiff(DateInterval.Minute, sttm, endtm) / sltdur
            End If
            If sltcnt <> 0 Then
                Dim i As Integer = Integer.Parse(pnl001.Width.ToString().Replace("px", "").Trim())
                Dim j As Integer = 30
                scalewidth = i * 0.9
                leftmargin = (i - scalewidth) / 2
                divwt = scalewidth / sltcnt

                Dim b As Brush = New SolidBrush(TimeScaleBackcolor)

                g.FillRectangle(b, 0, 0, i, divht)

                If cmpscale = False Then
                    b = New SolidBrush(BookingAreaBackcolor)
                Else
                    b = New SolidBrush(Color.LightGray)
                End If

                g.FillRectangle(b, 0, 30, i, Integer.Parse(pnl001.Height.ToString().Replace("px", "").Trim()) - 30)
                g.DrawLine(Pens.Black, 0, 30, i, 30)
                Dim k As Integer = 0
                Dim tmp As Date
                tmp = sttm

                While tmp <= endtm
                    Dim drawFont As New Font("Arial", 8, FontStyle.Regular)
                    Dim drawBrush As New SolidBrush(Color.Blue)
                    'g.FillRectangle(Brushes.Black, CInt((35 + (70 * k)) - 0.5), 30 - 10, 1, 10)
                    g.FillRectangle(Brushes.Black, CInt((leftmargin + (divwt * k)) - 0.5), divht - 10, 1, 10)
                    Dim str As String = Strings.Right("00" & tmp.Hour, 2) & Strings.Right("00" & tmp.Minute, 2)
                    Dim sz As SizeF = g.MeasureString(str, drawFont)
                    g.DrawString(str, drawFont, drawBrush, leftmargin + (divwt * (k)) - (sz.Width / 2), 5)
                    tmp = tmp.AddMinutes(sltdur)
                    k = k + 1
                End While
                g.Flush()
            End If
        Catch ex As Exception
            Dim i As Integer = 45
        End Try
    End Sub

    Public Sub DrawSession(ByVal g As Graphics, ByVal pobj() As clsSession)
        Dim psttmmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), CDate(txtstrttime.Text))
        Dim pentmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), CDate(txtendtime.Text))
        Dim xx1 As Integer
        xx1 = (divwt * psttmmins) / sltdur
        Dim xx2 As Integer
        xx2 = (divwt * pentmins) / sltdur
        Dim b As Brush = New SolidBrush(Color.Red)
        g.FillRectangle(b, leftmargin + xx1, divht, xx2 - xx1, Integer.Parse(pnl001.Height.ToString().Replace("px", "")) - divht)
        If Not pobj Is Nothing Then
            For Each obj As clsSession In pobj
                If Not obj Is Nothing Then
                    sessltcnt = System.Math.Floor(DateDiff(Microsoft.VisualBasic.DateInterval.Minute, obj.starttime, obj.endtime) / 30)
                    sesdivwt = (divwt * 30 / sltdur)
                    psttmmins = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), obj.starttime)
                    pentmins = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), obj.endtime)
                    xx1 = (divwt * psttmmins) / sltdur
                    xx2 = (divwt * pentmins) / sltdur
                    b = New SolidBrush(Color.White)
                    g.FillRectangle(b, leftmargin + xx1, divht, xx2 - xx1, Integer.Parse(pnl001.Height.ToString().Replace("px", "")) - divht)
                    If cmpscale = True Then
                        g.DrawLine(Pens.LightGreen, leftmargin + xx1, divht, leftmargin + xx1, Integer.Parse(pnl001.Height.ToString().Replace("px", "")))
                        g.DrawLine(Pens.LightGreen, leftmargin + xx2, divht, leftmargin + xx2, Integer.Parse(pnl001.Height.ToString().Replace("px", "")))
                    End If
                    For i As Integer = 0 To sessltcnt
                        Dim mmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), obj.starttime.AddMinutes(i * 30))
                        Dim xx As Integer = (divwt * mmins) / 60
                        g.FillRectangle(Brushes.Black, CInt((leftmargin + xx) - 0.5), divht - 5, 1, 5)
                    Next
                    g.DrawLine(Pens.Black, 0, divht, Integer.Parse(pnl001.Width.ToString().Replace("px", "")), divht)
                    g.Flush()
                End If
            Next
        End If
    End Sub

    Public Sub BtnResize()
        If Not btnarr Is Nothing Then
            For i As Integer = 0 To btnarr.Length - 1
                Dim psttm As Date = btnarr(i).StartTime
                Dim pentm As Date = btnarr(i).EndTime
                Dim psttmmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), psttm)
                Dim pentmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), pentm)
                Dim xx1 As Integer
                xx1 = (divwt * psttmmins) / sltdur
                Dim xx2 As Integer
                xx2 = (divwt * pentmins) / sltdur
                SetButton(btnarr(i), (xx1 + leftmargin), (xx2 - xx1), psttm, pentm, btnarr(i).Noofslots, btnarr(i).BookingID, btnarr(i).ApptDate, btnarr(i).DoctorCd, btnarr(i).Doctor, btnarr(i).PatCd, btnarr(i).PatName, False)
            Next
        End If
    End Sub
    Private Sub SetButton(ByRef btn As clsTimeSlot, ByVal left As Integer, ByVal width As Integer, ByVal StartTime As Date, ByVal EndTime As Date, ByVal NoofSlots As Long, ByVal pBookingID As Integer, ByVal pApptDate As Date, ByVal pDoctorCd As Long, ByVal pDoctor As String, ByVal pPatcd As Long, ByVal patname As String, ByVal add As Boolean)
        btn.Attributes.Add("style", "position:absolute;top:" & divht + (Integer.Parse(pnl001.Height.ToString().Replace("px", "")) * 0.05) & "px;left:" & left & "px")
        btn.Width = width
        btn.Height = Integer.Parse(pnl001.Height.ToString().Replace("px", "")) - divht - (Integer.Parse(pnl001.Height.ToString().Replace("px", "")) * 0.1) '50
        btn.StartTime = StartTime
        btn.EndTime = EndTime
        btn.Noofslots = NoofSlots
        btn.BookingID = pBookingID
        btn.ApptDate = pApptDate
        btn.Doctor = pDoctor
        btn.PatCd = pPatcd
        btn.PatName = patname
        btn.DoctorCd = pDoctorCd
        btn.BackColor = Color.FromArgb(192, 255, 192)
        btn.ForeColor = Color.Red
        btn.Text = pDoctor
        '   Dim dtTime As String = Format(StartTime, "HH:mm")
        Dim span As TimeSpan = EndTime.Subtract(StartTime)
        'Dim hrs As String = DateDiff(Microsoft.VisualBasic.DateInterval.Hour, StartTime, EndTime)
        Dim valuetobesend As String = NoofSlots.ToString() + "~" + pBookingID.ToString() + "~" + pApptDate.ToString() + "~" + pDoctorCd.ToString() + "~" + pDoctor + "~" + Format(StartTime, "HH:mm") + "~" + Format(EndTime, "HH:mm") + "~" + pPatcd.ToString() + "~" + patname + "~" + span.Hours.ToString() + "~" + span.Minutes.ToString()
        btn.OnClientClick = "javascript:getdetails('" & valuetobesend & "');  return false;"
        If add = True Then
            Addbutton(btn)
        End If
    End Sub
    Private Sub Addbutton(ByRef btn As clsTimeSlot)
        pnl001.Controls.Add(btn)
        For Each abc As System.Web.UI.Control In pnl001.Controls
        Next
        btnarrcnt = btnarrcnt + 1
        ReDim Preserve btnarr(btnarrcnt - 1)
        btnarr(btnarrcnt - 1) = btn
    End Sub

    Public Sub DrawButtons(ByVal psttm As Date, ByVal pentm As Date, ByVal pslots As Long, ByVal pBookingID As Integer, ByVal pApptDate As Date, ByVal pDoctor As String, ByVal pDoctorCd As Long, ByVal pPatCd As Long, ByVal pPatName As String)
        Dim psttmmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), psttm)
        Dim pentmins As Long = DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(sttm), pentm)
        Dim xx1 As Integer
        xx1 = (divwt * psttmmins) / sltdur
        Dim xx2 As Integer
        xx2 = (divwt * pentmins) / sltdur
        Dim btn As New clsTimeSlot
        Dim lft As Integer = xx1 + leftmargin
        SetButton(btn, lft, (xx2 - xx1), psttm, pentm, pslots, pBookingID, pApptDate, pDoctorCd, pDoctor, pPatCd, pPatName, True)
    End Sub

    Public Sub ClearDrawTimeScale()
        Dim revdt As Date = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
        ClearButtons()
        Dim bmp As New Bitmap(1500, 2500)
        Dim g As Graphics = System.Drawing.Graphics.FromImage(bmp)
        DrawTimeScale(g)
        g.Flush()
        Dim img_converter As New ImageConverter()
        Dim bytes As Byte() = DirectCast(img_converter.ConvertTo(bmp, GetType(Byte())), Byte())
        Dim dtm As String = revdt.ToString().Replace("/", "") '.Hour.ToString() + Date.Today.TimeOfDay.ToString()
        Dim dtm1 As String = dtm.Replace(":", "")
        Dim random As New Random()
        Dim ran As String = Convert.ToString(random.[Next](10, 200))
        'File.WriteAllBytes(Server.MapPath("~/Images/" & dtm1 + ran & ".jpeg"), bytes)
        'pnl001.BackColor = Color.White
        'pnl001.BackImageUrl = "~/Images/" & dtm1 + ran & ".jpeg"
        'pnl001.Attributes.Add("style", "background-repeat:no-repeat")
    End Sub

    Public Sub ClearButtons()
        btnarr = Nothing
        btnarrcnt = 0
        pnl001.Controls.Clear()
        For Each CurControl As Object In pnl001.Controls
            If TypeOf CurControl Is clsTimeSlot Then
                CurControl.dispose()
            End If
        Next
    End Sub

    Public Sub AddMessage(Optional ByVal msg As String = "OT CALENDAR NOT SET")
        UP1.Update() 'RasikV 20170125
        UP3.Update() 'RasikV 20170125
        Dim lbl As New WebControls.Label
        lbl.ForeColor = Color.Red
        lbl.Text = msg
        lbl.Attributes.Add("style", "position:absolute;font-size:20px;top:" & (Integer.Parse(pnl001.Height.ToString().Replace("px", "")) * 0.05) + 120 & "px;left:" & 170 & "px")
        pnl001.Controls.Add(lbl)
        Session("imgshft123") = Nothing
    End Sub

    Public Function CheckSlotAvailable(ByVal psttm As Date, ByVal pentm As Date) As Boolean
        ''<--Check Whether Required Slot is betwwen Available Session 
        Try

            If psttm < sessttm Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 26), "", Page)
                Return False
            End If
            If pentm > CDate(txtendtime.Text) Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 26), "", Page)
                Return False
            End If
            Dim sessbool As Boolean = True
            For Each obj As clsSession In sess

                If (obj.starttime <= psttm And obj.endtime >= psttm) And (obj.starttime <= pentm And obj.endtime >= pentm) Then
                    sessbool = True
                    Exit For
                Else
                    sessbool = False
                End If
            Next

            If sessbool = False Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 26), "", Page)
                Return False
            End If

            Dim tmpdt As Date = psttm

            If Not btnarr Is Nothing Then
                If btnarr.Length <> 0 Then
                    While tmpdt < pentm
                        For Each tmpTimeSlot As clsTimeSlot In btnarr
                            If psttm = tmpTimeSlot.StartTime And pentm = tmpTimeSlot.EndTime Then
                                Msg = String.Format(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 27), tmpTimeSlot.StartTime.ToShortTimeString, tmpTimeSlot.EndTime.ToShortTimeString)
                                clsGeneral.ShowErrorPopUp(Msg, "", Page)
                                'clsGeneral.ShowErrorPopUp("Slot is already booked between " & tmpTimeSlot.StartTime.ToShortTimeString & " and " & tmpTimeSlot.EndTime.ToShortTimeString, "", Page)
                                Return False
                            End If
                            If tmpdt >= tmpTimeSlot.StartTime And tmpdt < tmpTimeSlot.EndTime Then
                                Msg = String.Format(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 27), tmpTimeSlot.StartTime.ToShortTimeString, tmpTimeSlot.EndTime.ToShortTimeString)
                                clsGeneral.ShowErrorPopUp(Msg, "", Page)
                                'clsGeneral.ShowErrorPopUp("Slot is already booked between " & tmpTimeSlot.StartTime.ToShortTimeString & " and " & tmpTimeSlot.EndTime.ToShortTimeString, "", Page)
                                Return False
                            End If
                        Next
                        tmpdt = tmpdt.AddMinutes(lvSlotDur)
                    End While
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub FillBooking(ByVal Resource_Code As Integer, ByVal AppointmentDate As Date)
        UP3.Update() 'RasikV 20170125
        Dim clsFCTAPTOT As List(Of clsFCTAPTOT)
        strErrMsg = New List(Of String)
        chrErrFlg = "N"
        clsFCTAPTOT = OTScheduling.GetOTAptDetails(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), Resource_Code, 1, 1, AppointmentDate, 0, 0, 0, "")
        If (clsFCTAPTOT IsNot Nothing) Then
            For i As Integer = 0 To clsFCTAPTOT.Count - 1
                Dim APTM_TM_FROM As String = clsFCTAPTOT(i).APTMTMFROM
                Dim APTM_TM_TO As String = clsFCTAPTOT(i).APTMTMTO
                Dim pstartime As Date = CDate(Strings.Right("00" & Mid(APTM_TM_FROM, 1, APTM_TM_FROM.Length - 2), 2) & ":" & Strings.Right(APTM_TM_FROM, 2))
                Dim pendime As Date = CDate(Strings.Right("00" & Mid(APTM_TM_TO, 1, APTM_TM_TO.Length - 2), 2) & ":" & Strings.Right(APTM_TM_TO, 2))
                Dim pslots As Long = clsFCTAPTOT(i).NOOFSLOTSUSED
                Dim dctcode As Long = clsFCTAPTOT(i).DOCCD
                Dim apptno As Long = clsFCTAPTOT(i).APPTNO
                Dim patno As Long = clsFCTAPTOT(i).PTNNO
                Dim patnname As String = clsFCTAPTOT(i).PTNLNGNM
                Dim DOCNAME As String = clsFCTAPTOT(i).DOCNAME
                DrawButtons(pstartime, pendime, pslots, clsFCTAPTOT(i).APPTNO, AppointmentDate, DOCNAME, dctcode, patno, patnname)
            Next
        End If
    End Sub

    Public Function ShiftNowRecord() As Boolean
        Try

            strErrMsg = New List(Of String)
            chrErrFlg = "N"

            If clsGeneral.ChkSysLock(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE")) = True Then
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 1), "", Page)
                Exit Function
            End If

            Dim dtserverdttm As Date = clsGeneral.getdate()

            GetSlotsCount()

            Dim tomins As String = txtmins.Text

            If (Integer.Parse(txthrs.Text) = 0) Then
                If (Integer.Parse(tomins) <> 0) Then
                    If (Integer.Parse(tomins) < lvSlotDur) Then
                        tomins = lvSlotDur.ToString()
                    End If
                End If
            End If

            If (Integer.Parse(tomins) > lvSlotDur) Then
                Dim tem As Integer
                tem = Integer.Parse(tomins) + (lvSlotDur - (Integer.Parse(tomins) - lvSlotDur))
                tomins = tem.ToString()
            End If

            Dim pstartime As Date = CDate(txtstrttm1.Text)
            Dim pendime As Date = CDate(txtstrttm1.Text).AddMinutes(txthrs.Text * 60 + tomins)

            Dim actstartime As Date = AdjustDate(pstartime, True)
            Dim actpendime As Date = AdjustDate(pendime, False)
            Dim boolmsg As Boolean = False

            If pstartime <> actstartime Then
                boolmsg = True
                actpendime = AdjustDate(CDate(txtstrttm1.Text).AddMinutes(txthrs.Text * 60 + txtmins.Text))
                Dim actpendime1 As Date = AdjustDate(actpendime, False)
                If actpendime <> actpendime1 Then
                    actpendime = actpendime1
                End If
            End If

            If pendime <> actpendime Then
                boolmsg = True
            End If

            Dim actslots As Long = CalNoofSlotsRequired(actstartime, actpendime, lvSlotDur)

            pstartime = actstartime
            pendime = actpendime

            If (CheckSlotAvailable(pstartime, pendime)) Then
            Else
                clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 26), "", Page)
                btnarr = Nothing
                btnarrcnt = 0
                getsessions()
                Exit Function
            End If

            Dim pslots As Long = CalNoofSlotsRequired(pstartime, pendime, lvSlotDur)

            If (pslots = 0) Then
                pslots = 1
            End If

            ShiftNowRecord = False

            Dim obj As New clsFCTAPTOT

            obj.FCTCODE = Integer.Parse(txtot.Text)
            obj.APTMDATE = CDate(txtdate.Text)
            obj.DOCCD = docid
            obj.ISPATIENT = IIf(patid <> "", True, False)
            ' obj.IPOP = "I"
            obj.IPOP = IIf(ipopflg = "I", "I", "O")
            obj.PTNNO = Long.Parse(patid)
            obj.PTNLNGNM = patname
            obj.APTMTMFROM = pstartime.Hour * 100 + pstartime.Minute
            obj.APTMTMTO = pendime.Hour * 100 + pendime.Minute
            obj.NOOFSLOTSUSED = pslots
            obj.DURATION = pslots * lvSlotDur
            obj.ISPERFORMED = False
            obj.ISPOSTED = False
            obj.CRTUSRID = Session("USERID")
            obj.CRTDTTM = dtserverdttm
            obj.FLG = "A"
            obj.APPTRMRK = Remark 'shital 20210807
            obj.BOOKING_TYPE = BookingType 'shital 20210809

            Dim objFCT_APT_MAIN As New clsFCTAPTMAIN
            objFCT_APT_MAIN.FCTCODE = Integer.Parse(txtot.Text)
            objFCT_APT_MAIN.IPOP = Long.Parse(patid)
            objFCT_APT_MAIN.APTMDATE = CDate(txtdate.Text)
            objFCT_APT_MAIN.APTMSTS = 1 '<--BOOKING ( CD_DCD TYP = 404  )
            objFCT_APT_MAIN.REQNO = 0
            objFCT_APT_MAIN.REQSRNO = 0
            objFCT_APT_MAIN.APTMFROMHRS = pstartime.Hour
            objFCT_APT_MAIN.APTMFROMMIN = pstartime.Minute
            objFCT_APT_MAIN.APTMTOHRS = pendime.Hour
            objFCT_APT_MAIN.APTMTOMNS = pendime.Minute
            objFCT_APT_MAIN.APTMACTFROMHRS = 0
            objFCT_APT_MAIN.APTMACTFROMMIN = 0
            objFCT_APT_MAIN.APTMACTTOHRS = 0
            objFCT_APT_MAIN.APTMACTTOMNS = 0
            objFCT_APT_MAIN.pIPOPFLG = IIf(ipopflg = "I", "I", "O")
            objFCT_APT_MAIN.Billed = "1"
            objFCT_APT_MAIN.BookFor = IIf(patid <> "", "P", "O")
            objFCT_APT_MAIN.WARDNO = 0 '<--
            objFCT_APT_MAIN.PTNCLSCD = 0 '<--
            objFCT_APT_MAIN.BEDNO = "" '<--
            objFCT_APT_MAIN.APTMREFBY = ""
            objFCT_APT_MAIN.ICDGRPCD = ""
            objFCT_APT_MAIN.ICDCD = ""
            objFCT_APT_MAIN.DR1CODE = 0
            objFCT_APT_MAIN.DR2CODE = 0
            objFCT_APT_MAIN.DR3CODE = 0
            objFCT_APT_MAIN.DR4CODE = 0
            objFCT_APT_MAIN.ANAS1CODE = 0
            objFCT_APT_MAIN.ANAS2CODE = 0
            objFCT_APT_MAIN.ANAS3CODE = 0
            objFCT_APT_MAIN.SURGNOTE1 = ""
            objFCT_APT_MAIN.SURGNOTE2 = ""
            objFCT_APT_MAIN.OPRSTFTYPE1 = 0
            objFCT_APT_MAIN.TYPE1NOS = 0
            objFCT_APT_MAIN.OPRSTFTYPE2 = 0
            objFCT_APT_MAIN.TYPE2NOS = 0
            objFCT_APT_MAIN.OPRSTFTYPE3 = 0
            objFCT_APT_MAIN.TYPE3NOS = 0
            objFCT_APT_MAIN.OPRSTFTYPE4 = 0
            objFCT_APT_MAIN.TYPE4NOS = 0
            objFCT_APT_MAIN.SPLINST = 0
            objFCT_APT_MAIN.CRTUSRID = Session("USERID")
            objFCT_APT_MAIN.CRTDTTM = dtserverdttm
            objFCT_APT_MAIN.UPDTTTM = dtserverdttm
            objFCT_APT_MAIN.UPDUSRID = Session("USERID")

            'objFCT_APT_MAIN.PTNFSTNAME = IIf(Split(patname, " ").Length >= 2, Split(patname, " ")(2), "") '"" '<--
            'objFCT_APT_MAIN.PTNLSTNAME = IIf(Split(patname, " ").Length >= 3, Split(patname, " ")(3), "") '"" '<--
            'objFCT_APT_MAIN.PTNMIDNAME = IIf(Split(patname, " ").Length >= 1, Split(patname, " ")(1), "") '"" '<--

            If patname <> "" Then
                If Split(patname, " ").Length > 2 Then
                    objFCT_APT_MAIN.PTNFSTNAME = Split(patname, " ")(2)
                Else
                    objFCT_APT_MAIN.PTNFSTNAME = ""
                End If

                If Split(patname, " ").Length > 3 Then
                    objFCT_APT_MAIN.PTNLSTNAME = Split(patname, " ")(3)
                Else
                    objFCT_APT_MAIN.PTNLSTNAME = ""
                End If

                If Split(patname, " ").Length > 1 Then
                    objFCT_APT_MAIN.PTNMIDNAME = Split(patname, " ")(1)
                Else
                    objFCT_APT_MAIN.PTNMIDNAME = ""
                End If
            End If

            Dim objFCTSCH As New clsFCTSCH
            objFCTSCH.FCTCODE = Integer.Parse(txtot.Text)
            objFCTSCH.FctCatCode = 1
            objFCTSCH.FctMainCode = 1
            objFCTSCH.SCHDATE = CDate(txtdate.Text)
            '    objFCTSCH.IPOPFLG = IIf(patid <> "", IIf(ipopflg = "I", "I", "O"), "")

            objFCTSCH.IPOPFLG = IIf(ipopflg = "I", "I", "O")
            objFCTSCH.IPOPNO = Val(patid)
            objFCTSCH.STRTHR = pstartime.Hour
            objFCTSCH.STRTMIN = pstartime.Minute
            objFCTSCH.ENDTHR = pendime.Hour
            objFCTSCH.ENDTMIN = pendime.Minute

            Dim day As Integer = Weekday(txtdate.Text, Microsoft.VisualBasic.FirstDayOfWeek.Sunday)

            Dim objFCTAPTREQ As New clsFCTAPTREQ

            objFCTAPTREQ.FCTCODE = Val(txtot.Text)
            objFCTAPTREQ.REQNO = 1

            Dim objclsFCTAPTCNCL As New clsFCTAPTCNCL
            Dim dtserverdttm1 As Date = clsGeneral.getdate()

            objclsFCTAPTCNCL.FCTCODE = Val(txtot.Text)
            objclsFCTAPTCNCL.APPTNO = Val(aptno)
            objclsFCTAPTCNCL.ISSHIFTED = False
            objclsFCTAPTCNCL.CNCLUSRID = Session("USERID")
            objclsFCTAPTCNCL.CNCLDTTM = dtserverdttm1

            '   GetServicesDtls(Val(txtot.Text), Val(aptno)) 'FETCH OT SERVICES RECORDS : RasikV 20170123

            '   GetServicesDtls(Val(txtot.Text), Val(aptno), ipopflg)

            GetServicesDtls(Val(oldfctcode), Val(aptno), ipopflg) 'shital 20211203 added oldfctcode in case if apt is shifted to another oth



            Dim objArrFctAptOtSrv = New List(Of clsFctAptOtSrv) 'SAVE OT SERVICES RECORDS : RasikV 20170123
            If ViewState("objArrOTSrvDtls") IsNot Nothing Then
                objArrOTSrvDtls = ViewState("objArrOTSrvDtls")
                For i As Integer = 0 To objArrOTSrvDtls.Count - 1
                    Dim objSrv = New clsFctAptOtSrv
                    objSrv.IpOp = IIf(ipopflg = "I", "I", "O")
                    objSrv.PtnNo = Val(ViewState("ActualPtnNo"))
                    objSrv.IpNo = Val(patid)
                    objSrv.FctCode = Val(txtot.Text)
                    objSrv.FctCatCode = 1
                    objSrv.FctMainCode = 1
                    objSrv.ApptNo = Val(aptno)
                    objSrv.ChrgCd = objArrOTSrvDtls(i).chrgcd
                    objSrv.SrvCd = objArrOTSrvDtls(i).srvcd
                    objSrv.SrvRmrk = objArrOTSrvDtls(i).SrvDiagnosis
                    objSrv.UserDtTm = dtserverdttm
                    objSrv.UserId = Session("USERID")
                    objArrFctAptOtSrv.Add(objSrv)
                Next
                '---SAVE DATA INTO FCT_APT_OT IF OT_SERVICES ARE SELECTED
                obj.Diagnosis = objArrOTSrvDtls(0).SrvDiagnosis
                '---SAVE DATA INTO FCT_APT_OT IF OT_SERVICES ARE SELECTED 
            End If

            Dim objArrFctAptOtDoc = New List(Of clsFctAptOtDoc) 'SAVE OT SERVICES RECORDS : RasikV 20170123
            If ViewState("objArrOTDoctorsDtls") IsNot Nothing Then
                Dim objDocSavedDat = New List(Of clsOtDocDtls)
                objDocSavedDat = ViewState("objArrOTDoctorsDtls")
                For i As Integer = 0 To objDocSavedDat.Count - 1
                    Dim objDoc = New clsFctAptOtDoc
                    objDoc.IpOp = IIf(ipopflg = "I", "I", "O")
                    objDoc.PtnNo = Val(ViewState("ActualPtnNo"))
                    objDoc.IpNo = Val(patid)
                    objDoc.FctCode = Val(txtot.Text)
                    objDoc.FctCatCode = 1
                    objDoc.FctMainCode = 1
                    objDoc.ApptNo = Val(aptno)
                    objDoc.DocCd = objDocSavedDat(i).DoctorCode
                    objDoc.UserDtTm = Today.Date
                    objDoc.UserId = ViewState("USERID")
                    ''20211204 START
                    'objDoc.NurseName = objDocSavedDat(0).NurseName
                    'objDoc.ANESTYPCD = objDocSavedDat(0).AnesthesiaCd
                    ''20211204 END
                    objArrFctAptOtDoc.Add(objDoc)
                Next
                '---SAVE DATA INTO FCT_APT_OT IF OT_DOCTRS ARE SELECTED 
                obj.NurseName = objDocSavedDat(0).NurseName
                obj.ANESTYPCD = objDocSavedDat(0).AnesthesiaCd
                '---SAVE DATA INTO FCT_APT_OT IF OT_DOCTRS ARE SELECTED 
            End If

            Dim objArrFctAptOtEmp = New List(Of clsFctAptOtEmp) 'SAVE OT SERVICES RECORDS : RasikV 20170123
            If ViewState("objArrOTEmpDtls") IsNot Nothing Then
                Dim objEmpSavedDat = New List(Of clsFctAptOtEmpDtls)
                objEmpSavedDat = ViewState("objArrOTEmpDtls")
                For i As Integer = 0 To objEmpSavedDat.Count - 1
                    Dim objEmp = New clsFctAptOtEmp
                    objEmp.IpOp = IIf(ipopflg = "I", "I", "O")
                    objEmp.PtnNo = Long.Parse(ViewState("ActualPtnNo"))
                    objEmp.IpNo = Long.Parse(patid)
                    objEmp.FctCode = Integer.Parse(txtot.Text)
                    objEmp.FctCatCode = 1
                    objEmp.FctMainCode = 1
                    objEmp.ApptNo = Integer.Parse(aptno)
                    objEmp.EmpCd = objEmpSavedDat(i).EmpCd
                    objEmp.UserDtTm = Today.Date
                    objEmp.UserId = Session("USERID")
                    objArrFctAptOtEmp.Add(objEmp)
                Next
            End If

            'Dim res As String = OTScheduling.SHIFTNOW(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, Integer.Parse(txtot.Text), Integer.Parse(oldfctcode), day, CDate(txtdate.Text), 1, Integer.Parse(aptno), Long.Parse(patid), obj, objFCT_APT_MAIN, objFCTAPTREQ, objFCTSCH, objclsFCTAPTCNCL)

            Dim res As String = OTScheduling.SHIFTNOW(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, Integer.Parse(txtot.Text), Integer.Parse(oldfctcode), day, CDate(txtdate.Text), 1, Integer.Parse(aptno), Long.Parse(patid), obj, objFCT_APT_MAIN, objFCTAPTREQ, objFCTSCH, objclsFCTAPTCNCL, objArrFctAptOtSrv, objArrFctAptOtDoc, objArrFctAptOtEmp) 'RasikV 20170123

            Dim arr() As String
            arr = res.Split("~")

            If (arr(0).ToString() = "0") Then
                If strErrMsg IsNot Nothing Then
                    If strErrMsg.Count > 0 Then
                        clsGeneral.ShowErrorPopUp(strErrMsg(0), "txtapptno", Page)
                    Else
                        clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 39), "txtapptno", Page)
                    End If
                Else
                    clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 39), "txtapptno", Page)
                End If
            Else
                txtflag.Value = "A"
                Msg = String.Format(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 28), arr(1).ToString(), arr(0).ToString())
                clsGeneral.ShowErrorPopUp(Msg, "", Page)
                'clsGeneral.ShowErrorPopUp("Appoint No " & arr(1).ToString() & " Shifted to Appointment no " & arr(0).ToString() & " ", "", Page)
                'Response.Write("<script language='javascript'> window.close();</javascript>")
                ScriptManager.RegisterClientScriptBlock(UPShiftNow, UPShiftNow.GetType(), "scr12", "parent.setMsg('" + Msg + "');", True) 'RasikV 20170127
            End If
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(Replace(ex.Message, "'", ""), "", Page)
            ShiftNowRecord = False
        End Try
        Return ShiftNowRecord
    End Function

    Public Function finalvalidations() As Boolean
        finalvalidations = False
        If (txthrs.Text = "") Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 29), "txthrs", Page)
            Return False
        ElseIf (txtmins.Text = "") Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 30), "txtmins", Page)
            Return False
        ElseIf (txtstrttm1.Text = "") Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 31), "txtstrttm1", Page)
            Return False
        ElseIf (Integer.Parse(txthrs.Text) > 24) Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 32), "txthrs", Page)
            Return False
        ElseIf (Integer.Parse(txtmins.Text) > 59) Then
            clsGeneral.ShowErrorPopUp(clsGeneral.ReturnErrorMsg(Session("ErrorMsg"), 33), "txtmins", Page)
            Return False
        End If
        Return True
    End Function

    Public Function AdjustDate(ByVal pdt As Date, Optional ByVal ToLower As Boolean = True) As Date

        '  Dim sltduration = GetSlotsCount()
        sessltcnt = System.Math.Floor(DateDiff(Microsoft.VisualBasic.DateInterval.Minute, CDate(txtstrttime.Text), CDate(txtendtime.Text)) / lvSlotDur)
        sessttm = CDate(txtstrttime.Text)
        For i As Integer = 0 To sessltcnt
            Dim tmp As Date = sessttm.AddMinutes(i * lvSlotDur)
            If pdt < tmp Then
                If ToLower = True Then
                    pdt = sessttm.AddMinutes((i - 1) * lvSlotDur)
                Else
                    pdt = tmp
                End If
                Return pdt
            ElseIf pdt = tmp Then
                Return pdt
            End If
        Next
        Return pdt
    End Function

    Public Sub GetServicesDtls(ByVal FCTCd As Integer, ByVal ApptNo As Integer, ByVal IpOpFlag As String) 'FETCH OT SERVICES RECORDS : RasikV 20170124
        Try
            Dim iPtnNo As Long = 0

            If (IpOpFlag = "I") Then

                iPtnNo = OTScheduling.GetPtnNoByIpNo(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), patid)
                ViewState("ActualPtnNo") = iPtnNo

            Else

                ViewState("ActualPtnNo") = patid
            End If

            'iPtnNo = OTScheduling.GetPtnNoByIpNo(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), patid)
            'ViewState("ActualPtnNo") = iPtnNo

            Dim objOtSrvLstDtls As New List(Of OTSchedulingSerRef.ClsOtSrvLstDtls)

            objOtSrvLstDtls = OTScheduling.GetLstOfOtSrvDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), FCTCd, 1, 1, ApptNo, Long.Parse(ViewState("ActualPtnNo")), patid, ipopflg)

            '  objOtSrvLstDtls = OTScheduling.GetLstOfOtSrvDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, FCTCd, ApptNo, Long.Parse(ViewState("ActualPtnNo")), patid, ipopflg)
            If objOtSrvLstDtls IsNot Nothing Then
                ViewState("objArrOTSrvDtls") = objOtSrvLstDtls
                objOtSrvLstDtls = Nothing
            End If


            Dim objOtDocDtls As New List(Of OTSchedulingSerRef.clsOtDocDtls)

            objOtDocDtls = OTScheduling.GetLstOfOtDocDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), FCTCd, 1, 1, ApptNo, Long.Parse(ViewState("ActualPtnNo")), patid, ipopflg)

            '   objOtDocDtls = OTScheduling.GetLstOfOtDocDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, FCTCd, ApptNo, Long.Parse(ViewState("ActualPtnNo")), patid, ipopflg)
            If objOtDocDtls IsNot Nothing Then
                ViewState("objArrOTDoctorsDtls") = objOtDocDtls
                objOtDocDtls = Nothing
            End If

            Dim objFctAptOtEmpDtls As New List(Of OTSchedulingSerRef.clsFctAptOtEmpDtls)

            objFctAptOtEmpDtls = OTScheduling.GetLstOfOtEmpDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), FCTCd, 1, 1, ApptNo, Long.Parse(ViewState("ActualPtnNo")), patid, ipopflg)

            '  objFctAptOtEmpDtls = OTScheduling.GetLstOfOtEmpDtls(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"), 1, 1, FCTCd, ApptNo, Long.Parse(ViewState("ActualPtnNo")), patid, ipopflg)
            If objFctAptOtEmpDtls IsNot Nothing Then
                ViewState("objArrOTEmpDtls") = objFctAptOtEmpDtls
                objFctAptOtEmpDtls = Nothing
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClrPnl1() 'RasikV 20170206
        Try
            txtot.Text = ""
            txtotname.Text = ""
            txtstrttime.Text = ""
            txtendtime.Text = ""
            txthrs.Text = "00"
            txtmins.Text = "00"
            txtstrttm1.Text = "00:00"
            txtdate.Text = clsGeneral.GetRevenueDateDL(strErrMsg, chrErrFlg, Session("COMPANYCODE"), Session("DIVCODE"), Session("LOCCODE"))
        Catch ex As Exception
            clsGeneral.ShowErrorPopUp(ex.Message, "", Page)
        End Try
    End Sub
#End Region

End Class
