Imports SofCommon
Imports CWReadClasses
Imports WcfServices.CashDenomination

''' <summary>
''' Common functions
''' </summary>
''' <remarks></remarks>
Public Class commonFunctions
    Implements icommonFunctions


    ''' <summary>
    ''' get user name and password of ssrs reporting 
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="CoCd"></param>
    ''' <param name="Div"></param>
    ''' <param name="Loc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetReportServerUserNamePassword(ByRef strErrMsg As List(Of String), _
                                                   ByRef chrErrFlg As Char, _
                                                   ByVal CoCd As String, _
                                                   ByVal Div As Integer, _
                                                   ByVal Loc As Integer) As List(Of String) Implements icommonFunctions.GetReportServerUserNamePassword
        Try
            GetReportServerUserNamePassword = Nothing
            Dim UserName As String = System.Configuration.ConfigurationManager.AppSettings("ReportServerUserName")
            Dim PassWord As String = System.Configuration.ConfigurationManager.AppSettings("ReportServerPassWord")
            '  Dim obj As New Rijndael
            'UserName = obj.Decrypt(UserName)
            'PassWord = obj.Decrypt(PassWord)
            strErrMsg.Add("")
            strErrMsg.Add(UserName)
            strErrMsg.Add(PassWord)
            ' Dim irsc As IReportServerCredentials = New ReportVererCredentials(UserName, PassWord)
            GetReportServerUserNamePassword = strErrMsg
        Catch ex As Exception
            GetReportServerUserNamePassword = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetReportServerUserNamePassword
    End Function






    '20130926
    'mayur 20131010

    ''' <summary>
    ''' Convert 'YYYYMMDD' To SQLDatetime
    ''' </summary>
    ''' <param name="yyyymmdd"></param>
    ''' <param name="hhmm"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ConvertYYYYMMDDToSQLDatetime(ByVal yyyymmdd As String, ByVal hhmm As Integer) As Date Implements icommonFunctions.ConvertYYYYMMDDToSQLDatetime
        Dim orequest As New DBRequest
        orequest.CommandType = CommandType.Text
        orequest.Command = "SELECT  dbo.YYYYMMDDTOSQLDATETIME ('" & yyyymmdd & _
                                              "', " & hhmm & _
                                              " ) converteddate "

        Dim ofactory As New DBFactory
        Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

        If ds.Tables(0).Rows.Count <> 0 Then
            ConvertYYYYMMDDToSQLDatetime = ds.Tables(0).Rows(0).Item("converteddate")
        Else
            ConvertYYYYMMDDToSQLDatetime = Nothing
        End If
        orequest = Nothing
        ofactory = Nothing
        Return ConvertYYYYMMDDToSQLDatetime
    End Function
    ''' <summary>
    ''' Convert SQLDatetime To 'YYYYMMDD'
    ''' </summary>
    ''' <param name="sqldate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ConvertSQLDatetimeToYYYYMMDD(ByVal sqldate As Date) As String Implements icommonFunctions.ConvertSQLDatetimeToYYYYMMDD
        ConvertSQLDatetimeToYYYYMMDD = CStr(sqldate.Year) & Right("00" & CStr(sqldate.Month), 2) & Right("00" & CStr(sqldate.Day), 2)
        Return ConvertSQLDatetimeToYYYYMMDD
    End Function

    ''' <summary>
    ''' Gets Server Date and Time
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetServerDateTime() As Date Implements icommonFunctions.GetServerDateTime
        Dim orequest As New DBRequest
        orequest.CommandType = CommandType.Text
        orequest.Command = "SELECT  Getdate() ServerDateTime "

        Dim ofactory As New DBFactory
        Dim dr1 As Object = ofactory.ExecuteDataReader(orequest)
        If dr1.hasrows Then
            dr1.read()
            GetServerDateTime = dr1.Item("ServerDateTime")
        Else
            GetServerDateTime = Nothing
        End If
        dr1.close()
        orequest = Nothing
        ofactory = Nothing
        Return GetServerDateTime
    End Function
    ''' <summary>
    '''  Gets revenue date from hsp_in_dt table
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRevenueDate() As Date Implements icommonFunctions.GetRevenueDate
        Dim orequest As New DBRequest
        orequest.CommandType = CommandType.Text
        orequest.Command = "SELECT  rev_dt from hsp_in_dt  "
        Dim ofactory As New DBFactory
        Dim dr1 As Object = ofactory.ExecuteDataReader(orequest)
        If dr1.hasrows Then
            dr1.read()
            GetRevenueDate = dr1.Item("rev_dt")
        Else
            GetRevenueDate = Nothing
        End If
        dr1.close()
        orequest = Nothing
        ofactory = Nothing
        Return GetRevenueDate
    End Function

    Public Function GetRevenueDateDL(ByRef strErrMsg As List(Of String),
                                       ByRef chrErrFlg As Char, ByVal cocd As String, ByVal divcd As Integer, ByVal loccd As Integer) As Date Implements icommonFunctions.GetRevenueDateDL
        Dim orequest As New DBRequest
        orequest.CommandType = CommandType.Text
        orequest.Command = "SELECT  rev_dt from hsp_in_dt  "
        Dim ofactory As New DBFactory
        Dim dr1 As Object = ofactory.ExecuteDataReader(orequest)
        If dr1.hasrows Then
            dr1.read()
            GetRevenueDateDL = dr1.Item("rev_dt")
        Else
            GetRevenueDateDL = Nothing
        End If
        dr1.close()
        orequest = Nothing
        ofactory = Nothing
        Return GetRevenueDate()
    End Function

    Public Function GetGenderName(ByRef strErrMsg As List(Of String),
                                      ByRef chrErrFlg As Char, ByVal cocd As String,
                                      ByVal divcd As Integer, ByVal loccd As Integer, ByVal Gender As Char) As String Implements icommonFunctions.GetGenderName 'anamika 20160120
        If Gender = "M" Then
            GetGenderName = "Male"
        ElseIf Gender = "F" Then
            GetGenderName = "Female"
        ElseIf Gender = "T" Then
            GetGenderName = "Transgender"
        Else
            GetGenderName = "Both"
        End If
        Return GetGenderName
    End Function
    'Public Function GetFinancialYr(ByVal cocd As String, ByVal divcd As Integer, ByVal loccd As Integer) As String Implements icommonFunctions.GetFinancialYr
    Public Function GetFinancialYr(ByVal cocd As String, ByVal divcd As Integer, ByVal loccd As Integer) As Integer Implements icommonFunctions.GetFinancialYr
        GetFinancialYr = 0
        Dim dt As Date

        Dim obj As New commonFunctions
        'dt = obj.GetServerDateTime
        dt = obj.GetRevenueDate() 'anamika 20171114
        If dt.Date.Month <= 3 Then
            GetFinancialYr = Year(dt) - 1

        ElseIf dt.Month > 3 Then

            GetFinancialYr = Year(dt)

        End If

        Return GetFinancialYr
    End Function

    Public Function GetCurrancy(ByRef strErrMsg As List(Of String),
                                       ByRef chrErrFlg As Char, ByVal cocd As String, ByVal divcd As Integer, ByVal loccd As Integer) As String Implements icommonFunctions.GetCurrancy
        GetCurrancy = ""

        'used in vouchers
        GetCurrancy = "INR"

        Return GetCurrancy
    End Function



    ''' <summary>
    ''' Gets Admission Date of In patient
    ''' </summary>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="pipno"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAdmissionDate(ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, _
                                     ByVal pipno As Long) As Date Implements icommonFunctions.GetAdmissionDate

        Dim orequest As New DBRequest
        orequest.CommandType = CommandType.Text
        orequest.Command = "select adm_dt from ip_ptn_vst where ip_no =   " & pipno
        Dim ofactory As New DBFactory
        Dim dr1 As Object = ofactory.ExecuteDataReader(orequest)
        If dr1.hasrows Then
            dr1.read()
            If IsDBNull(dr1.Item("adm_dt")) Then
                GetAdmissionDate = Nothing
            Else
                GetAdmissionDate = dr1.Item("adm_dt")
            End If
        Else
            GetAdmissionDate = Nothing
        End If
        dr1.close()
        orequest = Nothing
        ofactory = Nothing
        Return GetAdmissionDate
    End Function
    ''' <summary>
    ''' Function to Check system lock
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ChkSysLock(ByRef strErrMsg As List(Of String),
                                       ByRef chrErrFlg As Char,
                                       ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As Boolean Implements icommonFunctions.ChkSysLock
        ChkSysLock = Nothing
        Try
            ChkSysLock = CommonModule.clsCommonModule.ChkSysLock(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc)
        Catch ex As Exception
            ChkSysLock = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return ChkSysLock

    End Function
    ''' <summary>
    ''' Get Cal Rates
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="pcompanycode"></param>
    ''' <param name="pdiv"></param>
    ''' <param name="ploc"></param>
    ''' <param name="objcalRate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetCalRate(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                      ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer,
                                      ByVal ploc As Integer, ByVal objcalRate As CommonModule.clsCalRate, Optional ByVal EmergencyFlg As String = "N") As CommonModule.clsCalRate Implements icommonFunctions.GetCalRate
        Try
            GetCalRate = Nothing
            GetCalRate = CommonModule.clsCommonModule.calRate(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc, objcalRate)
        Catch ex As Exception
            GetCalRate = Nothing
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        End Try
        Return GetCalRate

    End Function

    ''' <summary>
    ''' Returns common path to save medical record images
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MedicalImagesPath(ByVal obj As CommonModule.MedicalImagesPath) As String
        Dim MedicalImgPath As String = System.Configuration.ConfigurationManager.AppSettings("MedicalImgPath")
        MedicalImagesPath = MedicalImgPath & obj.Year & "\" & UCase(obj.IpOp) & "\" & IIf(UCase(Left(obj.IpOp, 1)) = "I", obj.IpNo, obj.PtnNo) & "\"
        MedicalImagesPath = MedicalImagesPath
        Return MedicalImagesPath
    End Function








#Region "GetFinancialYrBetweenDt"   'RasikV 20161105
    Public Function GetFinancialYrBetweenDt(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal Cocd As String,
           ByVal DivCd As Integer, ByVal LocCd As Integer, ByVal Dt As Date, ByVal Year As Integer) As Boolean Implements icommonFunctions.GetFinancialYrBetweenDt
        Try
            Dim orequest As New DBRequest
            orequest.CommandType = CommandType.Text

            orequest.Command = "SELECT [dbo].[FnGetFinancialYr]  ('" & Format(Dt, "MM/dd/yyyy") & _
                                                  "', " & Year & _
                                                  " ) FinancialYrDt "

            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

            If ds.Tables(0).Rows.Count <> 0 Then
                GetFinancialYrBetweenDt = ds.Tables(0).Rows(0).Item("FinancialYrDt")
            Else
                GetFinancialYrBetweenDt = Nothing
            End If
            orequest = Nothing
            ofactory = Nothing
            Return GetFinancialYrBetweenDt
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            GetFinancialYrBetweenDt = False
        End Try

    End Function
#End Region


#Region "TO CHECK WHETHER EXPIRY DATE WITHIN GIVEN DAYS FROM REVENUE DATE"  'RasikV 20170119
    Shared Function FnChkExpDtWithnRevDt(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal CoCd As String,
           ByVal Div As Integer, ByVal Loc As Integer, ByVal Days As Integer, ByVal ExpDt As Date, ByVal RevDt As Date) As Boolean
        Try
            Dim orequest As New DBRequest
            orequest.CommandType = CommandType.Text
            orequest.Command = "SELECT [dbo].[FnChkExpDtWithnRevDt]  ('" & CoCd & "','" & Div & "','" & Loc & "','" & Days & "','" & Format(ExpDt, "yyyy/MM/dd") & "','" & Format(RevDt, "yyyy/MM/dd") & "') ChkExpDtWithnRevDt"
            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

            If ds.Tables(0).Rows.Count <> 0 Then
                FnChkExpDtWithnRevDt = ds.Tables(0).Rows(0).Item("ChkExpDtWithnRevDt")
            Else
                FnChkExpDtWithnRevDt = False
            End If
            orequest = Nothing
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            FnChkExpDtWithnRevDt = False
        End Try
        Return FnChkExpDtWithnRevDt
    End Function
#End Region
End Class

