#Region "IMPORTS"
Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports CWReadClasses
Imports System.Text.RegularExpressions

#End Region


#Region "EnumSmsCategoryTyp"
<DataContract()>
Public Enum EnumSmsCategoryTyp   'PRAGYA : 30-OCT-2017 : SMS CATEGORY TYPES FOR SENDING SMS TO DIFF CATEGORY(same as typ_cd.typ=5010)
    <EnumMember()>
      IpPatient = 1
    <EnumMember()>
      OpPatient = 2
    <EnumMember()>
      Doctor = 3
    <EnumMember()>
      Employee = 4
    <EnumMember()>
      Other = 5
    <EnumMember()>
      Equipment = 6
End Enum
#End Region

<DataContract()>
Public Class clsSmsDtl      'PRAGYA : 26-JUL-2016
    <DataMember()>
    Public Property SmsSrl() As Integer
    <DataMember()>
    Public Property SmsSubSrl() As Integer
    <DataMember()>
    Public Property SmsType() As Integer            'SUB MOD CD
    <DataMember()>
    Public Property SmsStsCd() As Integer
    <DataMember()>
    Public Property SmsMobile() As String
    <DataMember()>
    Public Property SmsMessage() As String
    <DataMember()>
    Public Property SmsTimeToSend() As Date
    <DataMember()>
    Public Property SmsCrtby() As String
    <DataMember()>
    Public Property SmsCrtTm() As Date
    <DataMember()>
    Public Property SmsSentTm() As Date
    <DataMember()>
    Public Property SmsParts() As Integer
    <DataMember()>
    Public Property SmsPTNNo() As Long 'pragya : 01-nov-2017
    'Public Property SmsPTNNo() As String
    <DataMember()>
    Public Property SmsVchNo() As String







    'Shared Function ValidateSMSMain(ByVal Cocd As String,
    '                                ByVal Div As Integer,
    '                                ByVal loc As Integer,
    '                                ByVal SMSTyp As Integer,
    '                                ByVal dtGetServerDate As Date,
    '                                ByVal UserId As String,
    '                                ByVal DefCatTyp As clsMainModule.EnumSmsInternal,
    '                                ByVal objSms As List(Of clsSMSMstDetails),
    '                                ByVal dtDataToReplace As DataSet) As List(Of clsSmsDtl)
    '    Try
    '        ValidateSMSMain = Nothing

    '        Dim ofactory As New DBFactory
    '        Dim arrSmsDtl As New List(Of clsSmsDtl)
    '        Dim dsMain, dsSmsMst, dsGrpDtl As New DataSet
    '        dsMain = Nothing
    '        dsSmsMst = Nothing
    '        dsGrpDtl = Nothing
    '        'Dim drSmsMst As Object
    '        Dim iMxLenMob As Integer
    '        Dim strValidMobStart As String = ""
    '        Dim arrValidMobileStart As Object = Nothing
    '        Dim bytValidTypes, bytStsCd As Byte
    '        ' Dim bytStsCd As Byte
    '        Dim objParam As New clsSmsParam
    '        objParam = clsSmsParam.GetSmsParamDataWithNoParamters(Cocd, Div, loc)
    '        If objParam IsNot Nothing Then
    '            iMxLenMob = objParam.SmsMobileLength
    '            strValidMobStart = objParam.SmsValidMobStart
    '            arrValidMobileStart = Split(strValidMobStart, "|")
    '            bytValidTypes = UBound(arrValidMobileStart) - 1
    '        Else
    '            iMxLenMob = 12 '10
    '            strValidMobStart = ""
    '            arrValidMobileStart = Nothing
    '        End If

    '        If objSms IsNot Nothing Then
    '            If objSms.Count > 0 Then
    '                For icnt As Integer = 0 To objSms.Count - 1

    '                    Dim iCatTyp As Integer = 0
    '                    If DefCatTyp = clsMainModule.EnumSmsInternal.OtherHardcoded Then
    '                        iCatTyp = DefCatTyp
    '                    Else
    '                        iCatTyp = objSms(icnt).CategoryCd
    '                    End If

    '                    dsSmsMst = ofactory.ExecuteDataSet(clsSmsMst.SpSelSmsMst(Cocd, Div, loc, SMSTyp, iCatTyp))
    '                    Dim dsFetchData As New DataSet
    '                    Dim StrMainString As String = ""
    '                    '  Dim arrMainString As Object = Nothing
    '                    Dim SplitSmsString As New List(Of String)
    '                    If dsSmsMst.Tables.Count > 0 Then
    '                        If dsSmsMst.Tables(0).Rows.Count > 0 Then
    '                            StrMainString = dsSmsMst.Tables(0).Rows(0).Item("SMS_Std_Mess")
    '                            '   arrMainString = Split(StrMainString, "|")
    '                            SplitSmsString = CommonFunctionSplitSmsString(StrMainString)

    '                            Dim CategaoryCd As Integer = dsSmsMst.Tables(0).Rows(0).Item("CategoryTyp")

    '                            '' Amol 2018-04-23
    '                            '' Using Linq Find only  categaory wise data single data & add into datarow and then bind  to dsFetchData
    '                            ''  IEnumerable <DataRow> test =    From product In dtDataToReplace.AsEnumerable() Select product Distinct

    '                            'Dim data = (From cntable In dt Where cntable.Item("Category") = CategaoryCd Select cntable).FirstOrDefault()

    '                            '
    '                            'Dim dtDataToReplace1 As New DataSet
    '                            'Dim q As DataRow = From d In QT.AsEnumerable() Where d.Field(Of Integer)("CategoryCd") = CategaoryCd Select d
    '                            'dtDataToReplace1 = q.

    '                            Dim dtFetchData As DataTable

    '                            dtFetchData = New DataTable("CHECK")
    '                            dtFetchData.Columns.Add("SMS_Typ", GetType(String))
    '                            dtFetchData.Columns.Add("Category", GetType(Integer))
    '                            dtFetchData.Columns.Add("PTN_NAME", GetType(String))
    '                            dtFetchData.Columns.Add("MaxAge/Gender", GetType(String))
    '                            dtFetchData.Columns.Add("IP_NO", GetType(Long))
    '                            dtFetchData.Columns.Add("WARD_NAME", GetType(String))
    '                            dtFetchData.Columns.Add("BED_NO", GetType(String))
    '                            dtFetchData.Columns.Add("MOBILENO", GetType(Long))
    '                            dtFetchData.Columns.Add("Doc_Name", GetType(String))
    '                            dtFetchData.Columns.Add("DocMobile_No", GetType(Long))
    '                            dtFetchData.Columns.Add("Discharge_Status", GetType(Long))


    '                            'SMS_Typ, Category, PTN_NAME, MaxAge/Gender, IP_NO, WARD_NAME, BED_NO, MOBILE_NO, Doc_Name, DocMobile_No



    '                            If dtDataToReplace IsNot Nothing Then
    '                                If dtDataToReplace.Tables.Count > 0 Then
    '                                    For ds As Integer = 0 To dtDataToReplace.Tables(0).Rows.Count - 1

    '                                        If Val(dtDataToReplace.Tables(0).Rows(ds).Item("Category")) = Val(CategaoryCd) Then

    '                                            Dim dtRow As DataRow

    '                                            dtRow = dtFetchData.NewRow()
    '                                            Try
    '                                                dtRow.Item("SMS_Typ") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("SMS_Typ").ToString().Trim())
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("Category") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("Category").ToString().Trim())
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("PTN_NAME") = dtDataToReplace.Tables(0).Rows(ds).Item("PTN_NAME").ToString().Trim()
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("MaxAge/Gender") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("MaxAge/Gender").ToString().Trim())
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("IP_NO") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("IP_NO").ToString().Trim())
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("WARD_NAME") = dtDataToReplace.Tables(0).Rows(ds).Item("WARD_NAME").ToString().Trim()
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("BED_NO") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("BED_NO").ToString().Trim())
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("MOBILENO") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("MOBILE_NO").ToString().Trim())
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("Doc_Name") = dtDataToReplace.Tables(0).Rows(ds).Item("Doc_Name").ToString().Trim()
    '                                            Catch

    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("DocMobile_No") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("DocMobile_No").ToString().Trim())
    '                                            Catch

    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("Discharge_Status") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("Discharge_Status").ToString().Trim())
    '                                            Catch
    '                                            End Try


    '                                            dtFetchData.Rows.Add(dtRow)
    '                                        End If

    '                                        ' If dtDataToReplace.Tables(0).Rows(ds).Then Then
    '                                    Next
    '                                End If
    '                            End If

    '                            dsFetchData.Tables.Add(dtFetchData)




    '                            '-----------------------------------------------------------------------------------------------------------------------------------
    '                            'VALIDATE MOBILE NO LENGTH : shd nt be greater thn length assigned in SMS_PARAM
    '                            Dim strMobileNo As String = ""
    '                            Try
    '                                strMobileNo = dsFetchData.Tables(0).Rows(0).Item("MOBILENO").ToString()
    '                            Catch ex As Exception
    '                                strMobileNo = ""
    '                            End Try

    '                            If strMobileNo <> "." Then
    '                                If Mid(Val(strMobileNo), 1, 1) = 0 Then
    '                                    If Len(Mid(strMobileNo, 2, Len(strMobileNo))) <> iMxLenMob Then
    '                                        ' Exit For
    '                                        bytStsCd = 2
    '                                    End If
    '                                ElseIf Len(strMobileNo) <> iMxLenMob Then
    '                                    'Exit For
    '                                    bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '                                End If
    '                            End If

    '                            If strMobileNo = "" Then Exit Function

    '                            If strValidMobStart = "" Or arrValidMobileStart Is Nothing Then
    '                                Exit Function
    '                            Else
    '                                Dim N As Short
    '                                Dim strThisPart As String
    '                                Dim bytMobChkStart As Byte = 1

    '                                If Len(strMobileNo) < iMxLenMob Then
    '                                    bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '                                End If

    '                                For N = 1 To bytValidTypes
    '                                    strThisPart = Trim(arrValidMobileStart(N))
    '                                    If Len(strThisPart) > 0 Then
    '                                        If Mid(strMobileNo, bytMobChkStart, Len(strThisPart)) = Trim(arrValidMobileStart(N)) Then
    '                                            bytStsCd = 0        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '                                            Exit For
    '                                        End If
    '                                    End If
    '                                Next
    '                            End If
    '                            '-----------------------------------------------------------------------------------------------------------------------------------
    '                            ' IPNO "your IPNO is |IPNO|"
    '                            'IMPORTANT NOTE : StrMainString : STRING WITHIN DELIMETERS SHD BE EXACTLY SAME AS dsFetchData.TABLES(0).COLUMNS.COLUMNNAME
    '                            'IF THY ARE NOT SAME THE STRING WIL NOT BE REPLACED

    '                            If dsFetchData.Tables.Count > 0 Then
    '                                If dsFetchData.Tables(0).Rows.Count > 0 Then

    '                                    Dim iColCountData As Integer
    '                                    iColCountData = dsFetchData.Tables(0).Columns.Count
    '                                    If iColCountData > 0 Then
    '                                        For iCol As Integer = 0 To iColCountData - 1

    '                                            If SplitSmsString IsNot Nothing Then

    '                                                For j As Integer = 0 To SplitSmsString.Count - 1
    '                                                    If dsFetchData.Tables(0).Columns(iCol).ColumnName = SplitSmsString(j) Then
    '                                                        StrMainString = Replace(StrMainString, SplitSmsString(j), dsFetchData.Tables(0).Rows(0).Item(iCol), 1, -1, CompareMethod.Text)
    '                                                        Exit For
    '                                                    End If
    '                                                Next

    '                                            End If

    '                                        Next
    '                                    End If

    '                                    Dim objDtl As New clsSmsDtl
    '                                    objDtl.SmsSubSrl = 1
    '                                    objDtl.SmsType = SMSTyp
    '                                    objDtl.SmsMobile = strMobileNo
    '                                    objDtl.SmsMessage = StrMainString.ToString.Trim
    '                                    objDtl.SmsCrtby = UserId
    '                                    objDtl.SmsParts = 101
    '                                    'objDtl.SmsPTNNo = objSms(icnt).IpNo 
    '                                    objDtl.SmsStsCd = bytStsCd
    '                                    objDtl.SmsCrtTm = dtGetServerDate
    '                                    objDtl.SmsSentTm = dtGetServerDate
    '                                    objDtl.SmsTimeToSend = dtGetServerDate
    '                                    objDtl.SmsVchNo = 0

    '                                    arrSmsDtl.Add(objDtl)
    '                                End If
    '                            End If

    '                        End If
    '                    End If
    '                Next
    '            End If
    '        End If



    '        'Dim iCatTyp = 1
    '        'dsSmsMst = ofactory.ExecuteDataSet(clsSmsMst.SpSelSmsMst(Cocd, Div, loc, SMSTyp, iCatTyp))
    '        'Dim dsFetchData As New DataSet
    '        'Dim StrMainString As String = ""
    '        ''  Dim arrMainString As Object = Nothing
    '        'Dim SplitSmsString As New List(Of String)
    '        'If dsSmsMst.Tables.Count > 0 Then
    '        '    If dsSmsMst.Tables(0).Rows.Count > 0 Then
    '        '        StrMainString = dsSmsMst.Tables(0).Rows(0).Item("SMS_Std_Mess")
    '        '        '   arrMainString = Split(StrMainString, "|")
    '        '        SplitSmsString = CommonFunctionSplitSmsString(StrMainString)



    '        '        dsFetchData = ofactory.ExecuteDataSet(SpSelGetDataForSmsDtlFrmSmsMst(Cocd, Div, loc, 0, SMSTyp, iCatTyp, objPtnNo))


    '        '        '-----------------------------------------------------------------------------------------------------------------------------------
    '        '        'VALIDATE MOBILE NO LENGTH : shd nt be greater thn length assigned in SMS_PARAM
    '        '        Dim strMobileNo As String = ""
    '        '        Try
    '        '            strMobileNo = dsFetchData.Tables(0).Rows(0).Item("MOBILENO").ToString()

    '        '        Catch ex As Exception
    '        '            strMobileNo = ""
    '        '        End Try

    '        '        If strMobileNo <> "." Then
    '        '            If Mid(Val(strMobileNo), 1, 1) = 0 Then
    '        '                If Len(Mid(strMobileNo, 2, Len(strMobileNo))) <> iMxLenMob Then
    '        '                    ' Exit For
    '        '                    bytStsCd = 2
    '        '                End If
    '        '            ElseIf Len(strMobileNo) <> iMxLenMob Then
    '        '                'Exit For
    '        '                bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '        '            End If
    '        '        End If

    '        '        If strMobileNo = "" Then Exit Function

    '        '        If strValidMobStart = "" Or arrValidMobileStart Is Nothing Then
    '        '            Exit Function
    '        '        Else
    '        '            Dim N As Short
    '        '            Dim strThisPart As String
    '        '            Dim bytMobChkStart As Byte = 1

    '        '            If Len(strMobileNo) < iMxLenMob Then
    '        '                bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '        '            End If

    '        '            For N = 1 To bytValidTypes
    '        '                strThisPart = Trim(arrValidMobileStart(N))
    '        '                If Len(strThisPart) > 0 Then
    '        '                    If Mid(strMobileNo, bytMobChkStart, Len(strThisPart)) = Trim(arrValidMobileStart(N)) Then
    '        '                        bytStsCd = 0        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '        '                        Exit For
    '        '                    End If
    '        '                End If
    '        '            Next
    '        '        End If
    '        '        '-----------------------------------------------------------------------------------------------------------------------------------
    '        '        ' IPNO "your IPNO is |IPNO|"
    '        '        'IMPORTANT NOTE : StrMainString : STRING WITHIN DELIMETERS SHD BE EXACTLY SAME AS dsFetchData.TABLES(0).COLUMNS.COLUMNNAME
    '        '        'IF THY ARE NOT SAME THE STRING WIL NOT BE REPLACED

    '        '        If dsFetchData.Tables.Count > 0 Then
    '        '            If dsFetchData.Tables(0).Rows.Count > 0 Then

    '        '                Dim iColCountData As Integer
    '        '                iColCountData = dsFetchData.Tables(0).Columns.Count
    '        '                If iColCountData > 0 Then
    '        '                    For iCol As Integer = 0 To iColCountData - 1

    '        '                        If SplitSmsString IsNot Nothing Then

    '        '                            For j As Integer = 0 To SplitSmsString.Count - 1
    '        '                                If dsFetchData.Tables(0).Columns(iCol).ColumnName = SplitSmsString(j) Then
    '        '                                    StrMainString = Replace(StrMainString, SplitSmsString(j), dsFetchData.Tables(0).Rows(0).Item(iCol), 1, -1, CompareMethod.Text)
    '        '                                    Exit For
    '        '                                End If
    '        '                            Next

    '        '                        End If

    '        '                    Next
    '        '                End If

    '        '                Dim objDtl As New clsSmsDtl
    '        '                objDtl.SmsSubSrl = 1
    '        '                objDtl.SmsType = SMSTyp
    '        '                objDtl.SmsMobile = strMobileNo
    '        '                objDtl.SmsMessage = StrMainString.ToString.Trim
    '        '                objDtl.SmsCrtby = UserId
    '        '                objDtl.SmsParts = 101
    '        '                objDtl.SmsPTNNo = objPtnNo
    '        '                objDtl.SmsStsCd = bytStsCd
    '        '                objDtl.SmsCrtTm = dtGetServerDate
    '        '                objDtl.SmsSentTm = dtGetServerDate
    '        '                objDtl.SmsTimeToSend = dtGetServerDate
    '        '                objDtl.SmsVchNo = 0

    '        '                arrSmsDtl.Add(objDtl)
    '        '            End If
    '        '        End If

    '        '    End If
    '        'End If


    '        ValidateSMSMain = arrSmsDtl

    '        ''data not present in sms_gep_dtl for sms_typ 
    '        'ValidateSmsForPatient = Nothing


    '        ''dsGrpDtl.Dispose()
    '        dsSmsMst.Dispose()
    '        objParam = Nothing
    '    Catch ex As Exception
    '        ValidateSMSMain = Nothing
    '        ' strSmsErrMsg.Add(ex.Message)
    '    End Try

    '    Return ValidateSMSMain
    'End Function




#Region "SpSelGetSmsDtlForReplaceStr : Get the Data for replacing string for SMS Main"
    'pragya : 20-apr-2018
    Shared Function SpSelGetSmsDtlForReplaceStr(ByVal COCd As String,
                                                      ByVal Div As Integer,
                                                      ByVal Loc As Integer,
                                                      ByVal ModCd As Integer,
                                                      ByVal SmsTyp As Integer,
                                                      ByVal CategoryTyp As Integer,
                                                      ByVal PtnNo As Long,
                                                      ByVal IpNo As Long,
                                                      ByVal DocCd As Integer,
                                                      ByVal BedNo As String,
                                                      Optional ByVal CompNo As Integer = 0,
                                                      Optional ByVal CompDt As DateTime = Nothing,
                                                      Optional ByVal UsrNm As String = Nothing,
                                                      Optional ByVal FrmDeptCd As Integer = 0,
                                                      Optional ByVal ToDeptCd As Integer = 0,
                                                      Optional ByVal ItemCd As String = Nothing,
                                                      Optional ByVal CompDesc As String = Nothing,
                                                      Optional ByVal PriorityCd As Integer = 0,
                                                      Optional ByVal EmpId As String = Nothing,
                                                      Optional ByVal FctCd As Integer = 0,
                                                      Optional ByVal ApptNo As Integer = 0,
                                                      Optional ByVal ApptDt As DateTime = Nothing,
                                                      Optional ByVal ApptFrmTm As String = Nothing,
                                                      Optional ByVal ApptToTm As String = Nothing,
                                                      Optional ByVal DischrgeStsCd As Integer = 0) As DBRequest

        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelGetSmsDtlForReplaceStr]"
            .CommandType = CommandType.StoredProcedure

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCOCD"
            oParam.ParamValue = COCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDIVcd"
            oParam.ParamValue = Div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLOCcd"
            oParam.ParamValue = Loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pModcd"
            oParam.ParamValue = ModCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pSubModCd"
            oParam.ParamValue = SmsTyp
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCategoryCd"
            oParam.ParamValue = CategoryTyp
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pPtnNo"
            oParam.ParamValue = PtnNo   'pragya : 20-apr-2018
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIpNo"
            oParam.ParamValue = IpNo    'pragya : 20-apr-2018
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter   'pragya : 20-apr-2018
            oParam.ParamName = "pDocCd"
            oParam.ParamValue = DocCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter   'pragya : 20-apr-2018
            oParam.ParamName = "pBedNo"
            oParam.ParamValue = BedNo
            .Parameters.Add(oParam)


            'RasikV 20180605 : Start Here
            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCompNo"
            oParam.ParamValue = CompNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCompDt"
            oParam.ParamValue = IIf(CompDt = Nothing, Date.MaxValue, CompDt)
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUsrNm"
            oParam.ParamValue = UsrNm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFrmDeptCd"
            oParam.ParamValue = FrmDeptCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pToDeptCd"
            oParam.ParamValue = ToDeptCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pItemCd"
            oParam.ParamValue = ItemCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCompDesc"
            oParam.ParamValue = CompDesc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pPriorityCd"
            oParam.ParamValue = PriorityCd
            .Parameters.Add(oParam)
            'RasikV 20180605 : End Here


            'RasikV 20180918 : Start Here
            oParam = New DBRequest.Parameter
            oParam.ParamName = "pEmpId"
            oParam.ParamValue = EmpId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pFctCd"
            oParam.ParamValue = FctCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pApptNo"
            oParam.ParamValue = ApptNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pApptDt"
            oParam.ParamValue = IIf(ApptDt = Nothing, Date.MaxValue, ApptDt)
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pApptFrmTm"
            oParam.ParamValue = ApptFrmTm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pApptToTm"
            oParam.ParamValue = ApptToTm
            .Parameters.Add(oParam)
            'RasikV 20180918 : End Here


            oParam = New DBRequest.Parameter  '''added by aparna 31 dec 2018
            oParam.ParamName = "pDiscSts"
            oParam.ParamValue = DischrgeStsCd
            .Parameters.Add(oParam)

        End With

        Return oRequest
    End Function
#End Region

#Region "ValidateSMSMain"
    'pragya : 18-apr-2018





    'Shared Function ValidateSMSMain(ByVal Cocd As String,
    '                                ByVal Div As Integer,
    '                                ByVal loc As Integer,
    '                                ByVal SMSTyp As Integer,
    '                                ByVal dtGetServerDate As Date,
    '                                ByVal UserId As String,
    '                                ByVal DefCatTyp As clsMainModule.EnumSmsInternal,
    '                                ByVal objSms As List(Of clsSMSMstDetails),
    '                                ByVal dtDataToReplace As DataSet) As List(Of clsSmsDtl)
    '    Try
    '        ValidateSMSMain = Nothing

    '        Dim ofactory As New DBFactory
    '        Dim arrSmsDtl As New List(Of clsSmsDtl)
    '        Dim dsMain, dsSmsMst, dsGrpDtl As New DataSet
    '        dsMain = Nothing
    '        dsSmsMst = Nothing
    '        dsGrpDtl = Nothing
    '        'Dim drSmsMst As Object
    '        Dim iMxLenMob As Integer
    '        Dim strValidMobStart As String = ""
    '        Dim arrValidMobileStart As Object = Nothing
    '        Dim bytValidTypes, bytStsCd As Byte
    '        ' Dim bytStsCd As Byte
    '        Dim objParam As New clsSmsParam
    '        objParam = clsSmsParam.GetSmsParamDataWithNoParamters(Cocd, Div, loc)
    '        If objParam IsNot Nothing Then
    '            iMxLenMob = objParam.SmsMobileLength
    '            strValidMobStart = objParam.SmsValidMobStart
    '            arrValidMobileStart = Split(strValidMobStart, "|")
    '            bytValidTypes = UBound(arrValidMobileStart) - 1
    '        Else
    '            iMxLenMob = 12 '10
    '            strValidMobStart = ""
    '            arrValidMobileStart = Nothing
    '        End If

    '        If objSms IsNot Nothing Then
    '            If objSms.Count > 0 Then
    '                For icnt As Integer = 0 To objSms.Count - 1

    '                    Dim iCatTyp As Integer = 0
    '                    If DefCatTyp = clsMainModule.EnumSmsInternal.OtherHardcoded Then
    '                        iCatTyp = DefCatTyp
    '                    Else
    '                        iCatTyp = objSms(icnt).CategoryCd
    '                    End If

    '                    dsSmsMst = ofactory.ExecuteDataSet(clsSmsMst.SpSelSmsMst(Cocd, Div, loc, SMSTyp, iCatTyp))
    '                    Dim dsFetchData As New DataSet
    '                    Dim StrMainString As String = ""
    '                    '  Dim arrMainString As Object = Nothing
    '                    Dim SplitSmsString As New List(Of String)
    '                    If dsSmsMst.Tables.Count > 0 Then
    '                        If dsSmsMst.Tables(0).Rows.Count > 0 Then
    '                            StrMainString = dsSmsMst.Tables(0).Rows(0).Item("SMS_Std_Mess")
    '                            '   arrMainString = Split(StrMainString, "|")
    '                            SplitSmsString = CommonFunctionSplitSmsString(StrMainString)

    '                            Dim CategaoryCd As Integer = dsSmsMst.Tables(0).Rows(0).Item("CategoryTyp")

    '                            '' Amol 2018-04-23
    '                            '' Using Linq Find only  categaory wise data single data & add into datarow and then bind  to dsFetchData
    '                            ''  IEnumerable <DataRow> test =    From product In dtDataToReplace.AsEnumerable() Select product Distinct

    '                            'Dim data = (From cntable In dt Where cntable.Item("Category") = CategaoryCd Select cntable).FirstOrDefault()

    '                            '
    '                            'Dim dtDataToReplace1 As New DataSet
    '                            'Dim q As DataRow = From d In QT.AsEnumerable() Where d.Field(Of Integer)("CategoryCd") = CategaoryCd Select d
    '                            'dtDataToReplace1 = q.

    '                            Dim dtFetchData As DataTable

    '                            dtFetchData = New DataTable("CHECK")
    '                            dtFetchData.Columns.Add("SMS_Typ", GetType(String))
    '                            dtFetchData.Columns.Add("Category", GetType(Integer))
    '                            dtFetchData.Columns.Add("PTN_NAME", GetType(String))
    '                            dtFetchData.Columns.Add("MaxAge/Gender", GetType(String))
    '                            dtFetchData.Columns.Add("IP_NO", GetType(Long))
    '                            dtFetchData.Columns.Add("WARD_NAME", GetType(String))
    '                            dtFetchData.Columns.Add("BED_NO", GetType(String))
    '                            dtFetchData.Columns.Add("MOBILENO", GetType(Long))
    '                            dtFetchData.Columns.Add("Doc_Name", GetType(String))
    '                            dtFetchData.Columns.Add("DocMobile_No", GetType(Long))
    '                            dtFetchData.Columns.Add("Discharge_Status", GetType(Long))


    '                            'SMS_Typ, Category, PTN_NAME, MaxAge/Gender, IP_NO, WARD_NAME, BED_NO, MOBILE_NO, Doc_Name, DocMobile_No



    '                            If dtDataToReplace IsNot Nothing Then
    '                                If dtDataToReplace.Tables.Count > 0 Then
    '                                    For ds As Integer = 0 To dtDataToReplace.Tables(0).Rows.Count - 1

    '                                        If Val(dtDataToReplace.Tables(0).Rows(ds).Item("Category")) = Val(CategaoryCd) Then

    '                                            Dim dtRow As DataRow

    '                                            dtRow = dtFetchData.NewRow()
    '                                            Try
    '                                                dtRow.Item("SMS_Typ") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("SMS_Typ").ToString().Trim())
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("Category") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("Category").ToString().Trim())
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("PTN_NAME") = dtDataToReplace.Tables(0).Rows(ds).Item("PTN_NAME").ToString().Trim()
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("MaxAge/Gender") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("MaxAge/Gender").ToString().Trim())
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("IP_NO") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("IP_NO").ToString().Trim())
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("WARD_NAME") = dtDataToReplace.Tables(0).Rows(ds).Item("WARD_NAME").ToString().Trim()
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("BED_NO") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("BED_NO").ToString().Trim())
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("MOBILENO") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("MOBILE_NO").ToString().Trim())
    '                                            Catch
    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("Doc_Name") = dtDataToReplace.Tables(0).Rows(ds).Item("Doc_Name").ToString().Trim()
    '                                            Catch

    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("DocMobile_No") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("DocMobile_No").ToString().Trim())
    '                                            Catch

    '                                            End Try
    '                                            Try
    '                                                dtRow.Item("Discharge_Status") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("Discharge_Status").ToString().Trim())
    '                                            Catch
    '                                            End Try


    '                                            dtFetchData.Rows.Add(dtRow)
    '                                        End If

    '                                        ' If dtDataToReplace.Tables(0).Rows(ds).Then Then
    '                                    Next
    '                                End If
    '                            End If

    '                            dsFetchData.Tables.Add(dtFetchData)




    '                            '-----------------------------------------------------------------------------------------------------------------------------------
    '                            'VALIDATE MOBILE NO LENGTH : shd nt be greater thn length assigned in SMS_PARAM
    '                            Dim strMobileNo As String = ""
    '                            Try
    '                                strMobileNo = dsFetchData.Tables(0).Rows(0).Item("MOBILENO").ToString()
    '                            Catch ex As Exception
    '                                strMobileNo = ""
    '                            End Try

    '                            If strMobileNo <> "." Then
    '                                If Mid(Val(strMobileNo), 1, 1) = 0 Then
    '                                    If Len(Mid(strMobileNo, 2, Len(strMobileNo))) <> iMxLenMob Then
    '                                        ' Exit For
    '                                        bytStsCd = 2
    '                                    End If
    '                                ElseIf Len(strMobileNo) <> iMxLenMob Then
    '                                    'Exit For
    '                                    bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '                                End If
    '                            End If

    '                            If strMobileNo = "" Then Exit Function

    '                            If strValidMobStart = "" Or arrValidMobileStart Is Nothing Then
    '                                Exit Function
    '                            Else
    '                                Dim N As Short
    '                                Dim strThisPart As String
    '                                Dim bytMobChkStart As Byte = 1

    '                                If Len(strMobileNo) < iMxLenMob Then
    '                                    bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '                                End If

    '                                For N = 1 To bytValidTypes
    '                                    strThisPart = Trim(arrValidMobileStart(N))
    '                                    If Len(strThisPart) > 0 Then
    '                                        If Mid(strMobileNo, bytMobChkStart, Len(strThisPart)) = Trim(arrValidMobileStart(N)) Then
    '                                            bytStsCd = 0        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '                                            Exit For
    '                                        End If
    '                                    End If
    '                                Next
    '                            End If
    '                            '-----------------------------------------------------------------------------------------------------------------------------------
    '                            ' IPNO "your IPNO is |IPNO|"
    '                            'IMPORTANT NOTE : StrMainString : STRING WITHIN DELIMETERS SHD BE EXACTLY SAME AS dsFetchData.TABLES(0).COLUMNS.COLUMNNAME
    '                            'IF THY ARE NOT SAME THE STRING WIL NOT BE REPLACED

    '                            If dsFetchData.Tables.Count > 0 Then
    '                                If dsFetchData.Tables(0).Rows.Count > 0 Then

    '                                    Dim iColCountData As Integer
    '                                    iColCountData = dsFetchData.Tables(0).Columns.Count
    '                                    If iColCountData > 0 Then
    '                                        For iCol As Integer = 0 To iColCountData - 1

    '                                            If SplitSmsString IsNot Nothing Then

    '                                                For j As Integer = 0 To SplitSmsString.Count - 1
    '                                                    If dsFetchData.Tables(0).Columns(iCol).ColumnName = SplitSmsString(j) Then
    '                                                        StrMainString = Replace(StrMainString, SplitSmsString(j), dsFetchData.Tables(0).Rows(0).Item(iCol), 1, -1, CompareMethod.Text)
    '                                                        Exit For
    '                                                    End If
    '                                                Next

    '                                            End If

    '                                        Next
    '                                    End If

    '                                    Dim objDtl As New clsSmsDtl
    '                                    objDtl.SmsSubSrl = 1
    '                                    objDtl.SmsType = SMSTyp
    '                                    objDtl.SmsMobile = strMobileNo
    '                                    objDtl.SmsMessage = StrMainString.ToString.Trim
    '                                    objDtl.SmsCrtby = UserId
    '                                    objDtl.SmsParts = 101
    '                                    'objDtl.SmsPTNNo = objSms(icnt).IpNo 
    '                                    objDtl.SmsStsCd = bytStsCd
    '                                    objDtl.SmsCrtTm = dtGetServerDate
    '                                    objDtl.SmsSentTm = dtGetServerDate
    '                                    objDtl.SmsTimeToSend = dtGetServerDate
    '                                    objDtl.SmsVchNo = 0

    '                                    arrSmsDtl.Add(objDtl)
    '                                End If
    '                            End If

    '                        End If
    '                    End If
    '                Next
    '            End If
    '        End If



    '        'Dim iCatTyp = 1
    '        'dsSmsMst = ofactory.ExecuteDataSet(clsSmsMst.SpSelSmsMst(Cocd, Div, loc, SMSTyp, iCatTyp))
    '        'Dim dsFetchData As New DataSet
    '        'Dim StrMainString As String = ""
    '        ''  Dim arrMainString As Object = Nothing
    '        'Dim SplitSmsString As New List(Of String)
    '        'If dsSmsMst.Tables.Count > 0 Then
    '        '    If dsSmsMst.Tables(0).Rows.Count > 0 Then
    '        '        StrMainString = dsSmsMst.Tables(0).Rows(0).Item("SMS_Std_Mess")
    '        '        '   arrMainString = Split(StrMainString, "|")
    '        '        SplitSmsString = CommonFunctionSplitSmsString(StrMainString)



    '        '        dsFetchData = ofactory.ExecuteDataSet(SpSelGetDataForSmsDtlFrmSmsMst(Cocd, Div, loc, 0, SMSTyp, iCatTyp, objPtnNo))


    '        '        '-----------------------------------------------------------------------------------------------------------------------------------
    '        '        'VALIDATE MOBILE NO LENGTH : shd nt be greater thn length assigned in SMS_PARAM
    '        '        Dim strMobileNo As String = ""
    '        '        Try
    '        '            strMobileNo = dsFetchData.Tables(0).Rows(0).Item("MOBILENO").ToString()

    '        '        Catch ex As Exception
    '        '            strMobileNo = ""
    '        '        End Try

    '        '        If strMobileNo <> "." Then
    '        '            If Mid(Val(strMobileNo), 1, 1) = 0 Then
    '        '                If Len(Mid(strMobileNo, 2, Len(strMobileNo))) <> iMxLenMob Then
    '        '                    ' Exit For
    '        '                    bytStsCd = 2
    '        '                End If
    '        '            ElseIf Len(strMobileNo) <> iMxLenMob Then
    '        '                'Exit For
    '        '                bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '        '            End If
    '        '        End If

    '        '        If strMobileNo = "" Then Exit Function

    '        '        If strValidMobStart = "" Or arrValidMobileStart Is Nothing Then
    '        '            Exit Function
    '        '        Else
    '        '            Dim N As Short
    '        '            Dim strThisPart As String
    '        '            Dim bytMobChkStart As Byte = 1

    '        '            If Len(strMobileNo) < iMxLenMob Then
    '        '                bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '        '            End If

    '        '            For N = 1 To bytValidTypes
    '        '                strThisPart = Trim(arrValidMobileStart(N))
    '        '                If Len(strThisPart) > 0 Then
    '        '                    If Mid(strMobileNo, bytMobChkStart, Len(strThisPart)) = Trim(arrValidMobileStart(N)) Then
    '        '                        bytStsCd = 0        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '        '                        Exit For
    '        '                    End If
    '        '                End If
    '        '            Next
    '        '        End If
    '        '        '-----------------------------------------------------------------------------------------------------------------------------------
    '        '        ' IPNO "your IPNO is |IPNO|"
    '        '        'IMPORTANT NOTE : StrMainString : STRING WITHIN DELIMETERS SHD BE EXACTLY SAME AS dsFetchData.TABLES(0).COLUMNS.COLUMNNAME
    '        '        'IF THY ARE NOT SAME THE STRING WIL NOT BE REPLACED

    '        '        If dsFetchData.Tables.Count > 0 Then
    '        '            If dsFetchData.Tables(0).Rows.Count > 0 Then

    '        '                Dim iColCountData As Integer
    '        '                iColCountData = dsFetchData.Tables(0).Columns.Count
    '        '                If iColCountData > 0 Then
    '        '                    For iCol As Integer = 0 To iColCountData - 1

    '        '                        If SplitSmsString IsNot Nothing Then

    '        '                            For j As Integer = 0 To SplitSmsString.Count - 1
    '        '                                If dsFetchData.Tables(0).Columns(iCol).ColumnName = SplitSmsString(j) Then
    '        '                                    StrMainString = Replace(StrMainString, SplitSmsString(j), dsFetchData.Tables(0).Rows(0).Item(iCol), 1, -1, CompareMethod.Text)
    '        '                                    Exit For
    '        '                                End If
    '        '                            Next

    '        '                        End If

    '        '                    Next
    '        '                End If

    '        '                Dim objDtl As New clsSmsDtl
    '        '                objDtl.SmsSubSrl = 1
    '        '                objDtl.SmsType = SMSTyp
    '        '                objDtl.SmsMobile = strMobileNo
    '        '                objDtl.SmsMessage = StrMainString.ToString.Trim
    '        '                objDtl.SmsCrtby = UserId
    '        '                objDtl.SmsParts = 101
    '        '                objDtl.SmsPTNNo = objPtnNo
    '        '                objDtl.SmsStsCd = bytStsCd
    '        '                objDtl.SmsCrtTm = dtGetServerDate
    '        '                objDtl.SmsSentTm = dtGetServerDate
    '        '                objDtl.SmsTimeToSend = dtGetServerDate
    '        '                objDtl.SmsVchNo = 0

    '        '                arrSmsDtl.Add(objDtl)
    '        '            End If
    '        '        End If

    '        '    End If
    '        'End If


    '        ValidateSMSMain = arrSmsDtl

    '        ''data not present in sms_gep_dtl for sms_typ 
    '        'ValidateSmsForPatient = Nothing


    '        ''dsGrpDtl.Dispose()
    '        dsSmsMst.Dispose()
    '        objParam = Nothing
    '    Catch ex As Exception
    '        ValidateSMSMain = Nothing
    '        ' strSmsErrMsg.Add(ex.Message)
    '    End Try

    '    Return ValidateSMSMain
    'End Function


    'Shared Function ValidateSMSMain(ByVal Cocd As String,
    '                                ByVal Div As Integer,
    '                                ByVal loc As Integer,
    '                                ByVal SMSTyp As Integer,
    '                                ByVal dtGetServerDate As Date,
    '                                ByVal UserId As String,
    '                                ByVal DefCatTyp As clsMainModule.EnumSmsInternal,
    '                                ByVal objSms As List(Of clsSMSMstDetails),
    '                                ByVal dtDataToReplace As DataSet) As List(Of clsSmsDtl)
    '    Try
    '        ValidateSMSMain = Nothing

    '        Dim ofactory As New DBFactory
    '        Dim arrSmsDtl As New List(Of clsSmsDtl)
    '        Dim dsMain, dsSmsMst, dsGrpDtl As New DataSet
    '        dsMain = Nothing
    '        dsSmsMst = Nothing
    '        dsGrpDtl = Nothing
    '        'Dim drSmsMst As Object
    '        Dim iMxLenMob As Integer
    '        Dim strValidMobStart As String = ""
    '        Dim arrValidMobileStart As Object = Nothing
    '        Dim bytValidTypes, bytStsCd As Byte
    '        ' Dim bytStsCd As Byte
    '        Dim objParam As New clsSmsParam
    '        objParam = clsSmsParam.GetSmsParamDataWithNoParamters(Cocd, Div, loc)
    '        If objParam IsNot Nothing Then
    '            iMxLenMob = objParam.SmsMobileLength
    '            strValidMobStart = objParam.SmsValidMobStart
    '            arrValidMobileStart = Split(strValidMobStart, "|")
    '            bytValidTypes = UBound(arrValidMobileStart) - 1
    '        Else
    '            iMxLenMob = 12 '10
    '            strValidMobStart = ""
    '            arrValidMobileStart = Nothing
    '        End If

    '        If objSms IsNot Nothing Then
    '            If objSms.Count > 0 Then
    '                For icnt As Integer = 0 To objSms.Count - 1

    '                    Dim iCatTyp As Integer = 0
    '                    If DefCatTyp = clsMainModule.EnumSmsInternal.OtherHardcoded Then
    '                        iCatTyp = DefCatTyp
    '                    Else
    '                        iCatTyp = objSms(icnt).CategoryCd
    '                    End If

    '                    dsSmsMst = ofactory.ExecuteDataSet(clsSmsMst.SpSelSmsMst(Cocd, Div, loc, SMSTyp, iCatTyp))
    '                    Dim dsFetchData As New DataSet
    '                    Dim StrMainString As String = ""
    '                    '  Dim arrMainString As Object = Nothing
    '                    Dim SplitSmsString As New List(Of String)
    '                    If dsSmsMst.Tables.Count > 0 Then
    '                        If dsSmsMst.Tables(0).Rows.Count > 0 Then
    '                            StrMainString = dsSmsMst.Tables(0).Rows(0).Item("SMS_Std_Mess")
    '                            '   arrMainString = Split(StrMainString, "|")
    '                            SplitSmsString = CommonFunctionSplitSmsString(StrMainString)

    '                            'dsFetchData = ofactory.ExecuteDataSet(SpSelGetDataForSmsDtlFrmSmsMst(Cocd, Div, loc, 0, SMSTyp, iCatTyp, objPtnNo))


    '                            '-----------------------------------------------------------------------------------------------------------------------------------
    '                            'VALIDATE MOBILE NO LENGTH : shd nt be greater thn length assigned in SMS_PARAM
    '                            Dim strMobileNo As String = ""
    '                            Try
    '                                strMobileNo = dsFetchData.Tables(0).Rows(0).Item("MOBILENO").ToString()
    '                            Catch ex As Exception
    '                                strMobileNo = ""
    '                            End Try

    '                            If strMobileNo <> "." Then
    '                                If Mid(Val(strMobileNo), 1, 1) = 0 Then
    '                                    If Len(Mid(strMobileNo, 2, Len(strMobileNo))) <> iMxLenMob Then
    '                                        ' Exit For
    '                                        bytStsCd = 2
    '                                    End If
    '                                ElseIf Len(strMobileNo) <> iMxLenMob Then
    '                                    'Exit For
    '                                    bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '                                End If
    '                            End If

    '                            If strMobileNo = "" Then Exit Function

    '                            If strValidMobStart = "" Or arrValidMobileStart Is Nothing Then
    '                                Exit Function
    '                            Else
    '                                Dim N As Short
    '                                Dim strThisPart As String
    '                                Dim bytMobChkStart As Byte = 1

    '                                If Len(strMobileNo) < iMxLenMob Then
    '                                    bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '                                End If

    '                                For N = 1 To bytValidTypes
    '                                    strThisPart = Trim(arrValidMobileStart(N))
    '                                    If Len(strThisPart) > 0 Then
    '                                        If Mid(strMobileNo, bytMobChkStart, Len(strThisPart)) = Trim(arrValidMobileStart(N)) Then
    '                                            bytStsCd = 0        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '                                            Exit For
    '                                        End If
    '                                    End If
    '                                Next
    '                            End If
    '                            '-----------------------------------------------------------------------------------------------------------------------------------
    '                            ' IPNO "your IPNO is |IPNO|"
    '                            'IMPORTANT NOTE : StrMainString : STRING WITHIN DELIMETERS SHD BE EXACTLY SAME AS dsFetchData.TABLES(0).COLUMNS.COLUMNNAME
    '                            'IF THY ARE NOT SAME THE STRING WIL NOT BE REPLACED

    '                            If dsFetchData.Tables.Count > 0 Then
    '                                If dsFetchData.Tables(0).Rows.Count > 0 Then

    '                                    Dim iColCountData As Integer
    '                                    iColCountData = dsFetchData.Tables(0).Columns.Count
    '                                    If iColCountData > 0 Then
    '                                        For iCol As Integer = 0 To iColCountData - 1

    '                                            If SplitSmsString IsNot Nothing Then

    '                                                For j As Integer = 0 To SplitSmsString.Count - 1
    '                                                    If dsFetchData.Tables(0).Columns(iCol).ColumnName = SplitSmsString(j) Then
    '                                                        StrMainString = Replace(StrMainString, SplitSmsString(j), dsFetchData.Tables(0).Rows(0).Item(iCol), 1, -1, CompareMethod.Text)
    '                                                        Exit For
    '                                                    End If
    '                                                Next

    '                                            End If

    '                                        Next
    '                                    End If

    '                                    Dim objDtl As New clsSmsDtl
    '                                    objDtl.SmsSubSrl = 1
    '                                    objDtl.SmsType = SMSTyp
    '                                    objDtl.SmsMobile = strMobileNo
    '                                    objDtl.SmsMessage = StrMainString.ToString.Trim
    '                                    objDtl.SmsCrtby = UserId
    '                                    objDtl.SmsParts = 101
    '                                    objDtl.SmsPTNNo = objPtnNo
    '                                    objDtl.SmsStsCd = bytStsCd
    '                                    objDtl.SmsCrtTm = dtGetServerDate
    '                                    objDtl.SmsSentTm = dtGetServerDate
    '                                    objDtl.SmsTimeToSend = dtGetServerDate
    '                                    objDtl.SmsVchNo = 0

    '                                    arrSmsDtl.Add(objDtl)
    '                                End If
    '                            End If

    '                        End If
    '                    End If
    '                Next
    '            End If
    '        End If



    '        'Dim iCatTyp = 1
    '        'dsSmsMst = ofactory.ExecuteDataSet(clsSmsMst.SpSelSmsMst(Cocd, Div, loc, SMSTyp, iCatTyp))
    '        'Dim dsFetchData As New DataSet
    '        'Dim StrMainString As String = ""
    '        ''  Dim arrMainString As Object = Nothing
    '        'Dim SplitSmsString As New List(Of String)
    '        'If dsSmsMst.Tables.Count > 0 Then
    '        '    If dsSmsMst.Tables(0).Rows.Count > 0 Then
    '        '        StrMainString = dsSmsMst.Tables(0).Rows(0).Item("SMS_Std_Mess")
    '        '        '   arrMainString = Split(StrMainString, "|")
    '        '        SplitSmsString = CommonFunctionSplitSmsString(StrMainString)



    '        '        dsFetchData = ofactory.ExecuteDataSet(SpSelGetDataForSmsDtlFrmSmsMst(Cocd, Div, loc, 0, SMSTyp, iCatTyp, objPtnNo))


    '        '        '-----------------------------------------------------------------------------------------------------------------------------------
    '        '        'VALIDATE MOBILE NO LENGTH : shd nt be greater thn length assigned in SMS_PARAM
    '        '        Dim strMobileNo As String = ""
    '        '        Try
    '        '            strMobileNo = dsFetchData.Tables(0).Rows(0).Item("MOBILENO").ToString()

    '        '        Catch ex As Exception
    '        '            strMobileNo = ""
    '        '        End Try

    '        '        If strMobileNo <> "." Then
    '        '            If Mid(Val(strMobileNo), 1, 1) = 0 Then
    '        '                If Len(Mid(strMobileNo, 2, Len(strMobileNo))) <> iMxLenMob Then
    '        '                    ' Exit For
    '        '                    bytStsCd = 2
    '        '                End If
    '        '            ElseIf Len(strMobileNo) <> iMxLenMob Then
    '        '                'Exit For
    '        '                bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '        '            End If
    '        '        End If

    '        '        If strMobileNo = "" Then Exit Function

    '        '        If strValidMobStart = "" Or arrValidMobileStart Is Nothing Then
    '        '            Exit Function
    '        '        Else
    '        '            Dim N As Short
    '        '            Dim strThisPart As String
    '        '            Dim bytMobChkStart As Byte = 1

    '        '            If Len(strMobileNo) < iMxLenMob Then
    '        '                bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '        '            End If

    '        '            For N = 1 To bytValidTypes
    '        '                strThisPart = Trim(arrValidMobileStart(N))
    '        '                If Len(strThisPart) > 0 Then
    '        '                    If Mid(strMobileNo, bytMobChkStart, Len(strThisPart)) = Trim(arrValidMobileStart(N)) Then
    '        '                        bytStsCd = 0        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
    '        '                        Exit For
    '        '                    End If
    '        '                End If
    '        '            Next
    '        '        End If
    '        '        '-----------------------------------------------------------------------------------------------------------------------------------
    '        '        ' IPNO "your IPNO is |IPNO|"
    '        '        'IMPORTANT NOTE : StrMainString : STRING WITHIN DELIMETERS SHD BE EXACTLY SAME AS dsFetchData.TABLES(0).COLUMNS.COLUMNNAME
    '        '        'IF THY ARE NOT SAME THE STRING WIL NOT BE REPLACED

    '        '        If dsFetchData.Tables.Count > 0 Then
    '        '            If dsFetchData.Tables(0).Rows.Count > 0 Then

    '        '                Dim iColCountData As Integer
    '        '                iColCountData = dsFetchData.Tables(0).Columns.Count
    '        '                If iColCountData > 0 Then
    '        '                    For iCol As Integer = 0 To iColCountData - 1

    '        '                        If SplitSmsString IsNot Nothing Then

    '        '                            For j As Integer = 0 To SplitSmsString.Count - 1
    '        '                                If dsFetchData.Tables(0).Columns(iCol).ColumnName = SplitSmsString(j) Then
    '        '                                    StrMainString = Replace(StrMainString, SplitSmsString(j), dsFetchData.Tables(0).Rows(0).Item(iCol), 1, -1, CompareMethod.Text)
    '        '                                    Exit For
    '        '                                End If
    '        '                            Next

    '        '                        End If

    '        '                    Next
    '        '                End If

    '        '                Dim objDtl As New clsSmsDtl
    '        '                objDtl.SmsSubSrl = 1
    '        '                objDtl.SmsType = SMSTyp
    '        '                objDtl.SmsMobile = strMobileNo
    '        '                objDtl.SmsMessage = StrMainString.ToString.Trim
    '        '                objDtl.SmsCrtby = UserId
    '        '                objDtl.SmsParts = 101
    '        '                objDtl.SmsPTNNo = objPtnNo
    '        '                objDtl.SmsStsCd = bytStsCd
    '        '                objDtl.SmsCrtTm = dtGetServerDate
    '        '                objDtl.SmsSentTm = dtGetServerDate
    '        '                objDtl.SmsTimeToSend = dtGetServerDate
    '        '                objDtl.SmsVchNo = 0

    '        '                arrSmsDtl.Add(objDtl)
    '        '            End If
    '        '        End If

    '        '    End If
    '        'End If


    '        ValidateSMSMain = arrSmsDtl

    '        ''data not present in sms_gep_dtl for sms_typ 
    '        'ValidateSmsForPatient = Nothing


    '        ''dsGrpDtl.Dispose()
    '        dsSmsMst.Dispose()
    '        objParam = Nothing
    '    Catch ex As Exception
    '        ValidateSMSMain = Nothing
    '        ' strSmsErrMsg.Add(ex.Message)
    '    End Try

    '    Return ValidateSMSMain
    'End Function




    Shared Function ValidateSMSMain(ByRef strErrMsg As List(Of String),
                                    ByRef chrErrFlg As Char, ByVal Cocd As String,
                                    ByVal Div As Integer,
                                    ByVal loc As Integer,
                                    ByVal SMSTyp As Integer,
                                    ByVal dtGetServerDate As Date,
                                    ByVal UserId As String,
                                    ByVal DefCatTyp As clsMainModule.EnumSmsInternal,
                                    ByVal objSms As List(Of clsSMSMstDetails),
                                    ByVal dtDataToReplace As DataSet) As List(Of clsSmsDtl)
        Try
            ValidateSMSMain = Nothing

            Dim ofactory As New DBFactory
            Dim arrSmsDtl As New List(Of clsSmsDtl)
            Dim dsMain, dsSmsMst, dsGrpDtl As New DataSet
            dsMain = Nothing
            dsSmsMst = Nothing
            dsGrpDtl = Nothing
            'Dim drSmsMst As Object
            Dim iMxLenMob As Integer
            Dim strValidMobStart As String = ""
            Dim arrValidMobileStart As Object = Nothing
            Dim bytValidTypes, bytStsCd As Byte
            ' Dim bytStsCd As Byte
            Dim objParam As New clsSmsParam
            objParam = clsSmsParam.GetSmsParamDataWithNoParamters(Cocd, Div, loc)
            If objParam IsNot Nothing Then
                iMxLenMob = objParam.SmsMobileLength
                strValidMobStart = objParam.SmsValidMobStart
                arrValidMobileStart = Split(strValidMobStart, "|")
                'bytValidTypes = UBound(arrValidMobileStart) - 1
                bytValidTypes = UBound(arrValidMobileStart) '#.SACHIN 20180428
            Else
                iMxLenMob = 12 '10
                strValidMobStart = ""
                arrValidMobileStart = Nothing
            End If

            If objSms IsNot Nothing Then
                If objSms.Count > 0 Then
                    For icnt As Integer = 0 To objSms.Count - 1

                        Dim iCatTyp As Integer = 0
                        If DefCatTyp = clsMainModule.EnumSmsInternal.OtherHardcoded Then
                            iCatTyp = DefCatTyp
                        Else
                            iCatTyp = objSms(icnt).CategoryCd
                        End If

                        dsSmsMst = ofactory.ExecuteDataSet(clsSmsMst.SpSelSmsMst(Cocd, Div, loc, SMSTyp, iCatTyp))
                        Dim dsFetchData As New DataSet
                        Dim StrMainString As String = ""
                        '  Dim arrMainString As Object = Nothing
                        Dim SplitSmsString As New List(Of String)
                        Dim actualFieldName As String

                        If dsSmsMst.Tables.Count > 0 Then
                            If dsSmsMst.Tables(0).Rows.Count > 0 Then
                                StrMainString = dsSmsMst.Tables(0).Rows(0).Item("SMS_Std_Mess")
                                '   arrMainString = Split(StrMainString, "|")

                                ''#.SACHIN 20180428------------------------------------------
                                'SplitSmsString = CommonFunctionSplitSmsString(StrMainString)
                                SplitSmsString = GetSMSParamList(StrMainString)
                                ''#.SACHIN 20180428------------------------------------------

                                Dim CategaoryCd As Integer = dsSmsMst.Tables(0).Rows(0).Item("CategoryTyp")

                                '' Amol 2018-04-23
                                '' Using Linq Find only  categaory wise data single data & add into datarow and then bind  to dsFetchData
                                ''  IEnumerable <DataRow> test =    From product In dtDataToReplace.AsEnumerable() Select product Distinct

                                'Dim data = (From cntable In dt Where cntable.Item("Category") = CategaoryCd Select cntable).FirstOrDefault()

                                '
                                'Dim dtDataToReplace1 As New DataSet
                                'Dim q As DataRow = From d In QT.AsEnumerable() Where d.Field(Of Integer)("CategoryCd") = CategaoryCd Select d
                                'dtDataToReplace1 = q.

                                Dim dtFetchData As DataTable

                                dtFetchData = New DataTable("CHECK")
                                dtFetchData.Columns.Add("SMS_Typ", GetType(String))
                                dtFetchData.Columns.Add("Category", GetType(Integer))
                                dtFetchData.Columns.Add("PTN_NAME", GetType(String))
                                'RasikV 20180918 - Start Here
                                'dtFetchData.Columns.Add("MaxAge/Gender", GetType(String))
                                dtFetchData.Columns.Add("MaxAge_Gender", GetType(String))
                                'RasikV 20180918 - End Here
                                dtFetchData.Columns.Add("IP_NO", GetType(Long))
                                dtFetchData.Columns.Add("WARD_NAME", GetType(String))
                                dtFetchData.Columns.Add("BED_NO", GetType(String))
                                dtFetchData.Columns.Add("MOBILENO", GetType(Long))
                                dtFetchData.Columns.Add("Doc_Name", GetType(String))
                                dtFetchData.Columns.Add("DocMobile_No", GetType(Long))
                                'dtFetchData.Columns.Add("Discharge_Status", GetType(Long)) '''commented by aparna 31 dec 2018
                                dtFetchData.Columns.Add("Discharge_Status", GetType(String))

                                'RasikV 20180605 - Start Here
                                dtFetchData.Columns.Add("COMPNO", GetType(Long))
                                dtFetchData.Columns.Add("COMPDT", GetType(Date))
                                dtFetchData.Columns.Add("USERNAME", GetType(String))
                                dtFetchData.Columns.Add("FROMDEPT", GetType(String))
                                dtFetchData.Columns.Add("ITEMDESC", GetType(String))
                                dtFetchData.Columns.Add("COMPDESC", GetType(String))
                                dtFetchData.Columns.Add("PRIORITY", GetType(String))
                                'RasikV 20180605 - End Here

                                'RasikV 20180918 - Start Here
                                dtFetchData.Columns.Add("OT_NAME", GetType(String))
                                dtFetchData.Columns.Add("APPT_NO", GetType(Integer))
                                dtFetchData.Columns.Add("APPT_DT", GetType(Date))
                                dtFetchData.Columns.Add("APPT_FRMTM", GetType(String))
                                dtFetchData.Columns.Add("APPT_TOTM", GetType(String))
                                'RasikV 20180918 - End Here


                                'SMS_Typ, Category, PTN_NAME, MaxAge/Gender, IP_NO, WARD_NAME, BED_NO, MOBILE_NO, Doc_Name, DocMobile_No




                                If dtDataToReplace IsNot Nothing Then
                                    If dtDataToReplace.Tables.Count > 0 Then
                                        For ds As Integer = 0 To dtDataToReplace.Tables(0).Rows.Count - 1

                                            If Val(dtDataToReplace.Tables(0).Rows(ds).Item("Category")) = Val(CategaoryCd) Then

                                                Dim dtRow As DataRow

                                                dtRow = dtFetchData.NewRow()
                                                Try
                                                    dtRow.Item("SMS_Typ") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("SMS_Typ").ToString().Trim())
                                                Catch
                                                End Try
                                                Try
                                                    dtRow.Item("Category") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("Category").ToString().Trim())
                                                Catch
                                                End Try
                                                Try
                                                    dtRow.Item("PTN_NAME") = dtDataToReplace.Tables(0).Rows(ds).Item("PTN_NAME").ToString().Trim()
                                                Catch
                                                End Try
                                                Try
                                                    'dtRow.Item("MaxAge/Gender") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("MaxAge/Gender").ToString().Trim())
                                                    dtRow.Item("MaxAge_Gender") = dtDataToReplace.Tables(0).Rows(ds).Item("MaxAge_Gender").ToString().Trim() 'RasikV 20180918
                                                Catch
                                                End Try
                                                Try
                                                    dtRow.Item("IP_NO") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("IP_NO").ToString().Trim())
                                                Catch
                                                End Try
                                                Try
                                                    dtRow.Item("WARD_NAME") = dtDataToReplace.Tables(0).Rows(ds).Item("WARD_NAME").ToString().Trim()
                                                Catch
                                                End Try
                                                Try
                                                    'dtRow.Item("BED_NO") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("BED_NO").ToString().Trim())  commented by aparna 26 dec 2018
                                                    dtRow.Item("BED_NO") = (dtDataToReplace.Tables(0).Rows(ds).Item("BED_NO").ToString().Trim())
                                                Catch
                                                End Try
                                                Try
                                                    dtRow.Item("MOBILENO") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("MOBILE_NO").ToString().Trim())
                                                Catch
                                                End Try
                                                Try
                                                    dtRow.Item("Doc_Name") = dtDataToReplace.Tables(0).Rows(ds).Item("Doc_Name").ToString().Trim()
                                                Catch

                                                End Try
                                                Try
                                                    dtRow.Item("DocMobile_No") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("DocMobile_No").ToString().Trim())
                                                Catch

                                                End Try
                                                Try
                                                    'dtRow.Item("Discharge_Status") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("Discharge_Status").ToString().Trim())  ''commented by aparna 31 dec 2018

                                                    dtRow.Item("Discharge_Status") = (dtDataToReplace.Tables(0).Rows(ds).Item("Discharge_Status").ToString().Trim())
                                                Catch
                                                End Try

                                                'RasikV 20180605 - Start Here
                                                Try
                                                    dtRow.Item("COMPNO") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("COMPNO").ToString().Trim())
                                                Catch
                                                End Try

                                                Try
                                                    'dtRow.Item("COMPDT") = Format(CDate(dtDataToReplace.Tables(0).Rows(ds).Item("COMPDT")), "dd/MM/yyyy HH:mm")
                                                    dtRow.Item("COMPDT") = CDate(dtDataToReplace.Tables(0).Rows(ds).Item("COMPDT")) 'RasikV 20180627
                                                Catch
                                                End Try

                                                Try
                                                    dtRow.Item("USERNAME") = dtDataToReplace.Tables(0).Rows(ds).Item("USERNAME").ToString().Trim()
                                                Catch
                                                End Try

                                                Try
                                                    dtRow.Item("FROMDEPT") = dtDataToReplace.Tables(0).Rows(ds).Item("FROMDEPT").ToString().Trim()
                                                Catch
                                                End Try

                                                Try
                                                    dtRow.Item("ITEMDESC") = dtDataToReplace.Tables(0).Rows(ds).Item("ITEMDESC").ToString().Trim()
                                                Catch
                                                End Try

                                                Try
                                                    dtRow.Item("COMPDESC") = dtDataToReplace.Tables(0).Rows(ds).Item("COMPDESC").ToString().Trim()
                                                Catch
                                                End Try

                                                Try
                                                    dtRow.Item("PRIORITY") = dtDataToReplace.Tables(0).Rows(ds).Item("PRIORITY").ToString().Trim()
                                                Catch
                                                End Try
                                                'RasikV 20180605 - End Here


                                                'RasikV 20180918 - Start Here
                                                Try
                                                    dtRow.Item("OT_NAME") = dtDataToReplace.Tables(0).Rows(ds).Item("OT_NAME").ToString().Trim()
                                                Catch
                                                End Try

                                                Try
                                                    dtRow.Item("APPT_NO") = Val(dtDataToReplace.Tables(0).Rows(ds).Item("APPT_NO").ToString().Trim())
                                                Catch
                                                End Try

                                                Try
                                                    dtRow.Item("APPT_DT") = CDate(dtDataToReplace.Tables(0).Rows(ds).Item("APPT_DT"))
                                                Catch
                                                End Try

                                                Try
                                                    dtRow.Item("APPT_FRMTM") = dtDataToReplace.Tables(0).Rows(ds).Item("APPT_FRMTM")
                                                Catch
                                                End Try

                                                Try
                                                    dtRow.Item("APPT_TOTM") = dtDataToReplace.Tables(0).Rows(ds).Item("APPT_TOTM")
                                                Catch
                                                End Try
                                                'RasikV 20180918 - End Here

                                                dtFetchData.Rows.Add(dtRow)
                                            End If

                                            ' If dtDataToReplace.Tables(0).Rows(ds).Then Then
                                        Next
                                    End If
                                End If

                                dsFetchData.Tables.Add(dtFetchData)

                                ''ADDED BY RASIK 6 JUN 2018
                                If dsFetchData.Tables.Count > 0 Then
                                    If dsFetchData.Tables(0).Rows.Count > 0 Then
                                        ''ADDED BY RASIK 6 JUN 2018

                                        For DsTmp As Integer = 0 To dsFetchData.Tables(0).Rows.Count - 1
                                            '-----------------------------------------------------------------------------------------------------------------------------------
                                            'VALIDATE MOBILE NO LENGTH : shd nt be greater thn length assigned in SMS_PARAM
                                            Dim strMobileNo As String = ""
                                            Try
                                                ' strMobileNo = dsFetchData.Tables(0).Rows(0).Item("MOBILENO").ToString()
                                                strMobileNo = dsFetchData.Tables(0).Rows(DsTmp).Item("MOBILENO").ToString() 'RasikV 20180606
                                            Catch ex As Exception
                                                strMobileNo = ""
                                            End Try

                                            If strMobileNo <> "." Then
                                                If Mid(Val(strMobileNo), 1, 1) = 0 Then
                                                    If Len(Mid(strMobileNo, 2, Len(strMobileNo))) <> iMxLenMob Then
                                                        ' Exit For
                                                        bytStsCd = 2
                                                    End If
                                                ElseIf Len(strMobileNo) <> iMxLenMob Then
                                                    'Exit For
                                                    bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
                                                End If
                                            End If

                                            If strMobileNo = "" Then Exit Function

                                            If strValidMobStart = "" Or arrValidMobileStart Is Nothing Then
                                                Exit Function
                                            Else
                                                Dim N As Short
                                                Dim strThisPart As String
                                                Dim bytMobChkStart As Byte = 1

                                                If Len(strMobileNo) < iMxLenMob Then
                                                    bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
                                                End If

                                                For N = 1 To bytValidTypes
                                                    strThisPart = Trim(arrValidMobileStart(N))
                                                    If Len(strThisPart) > 0 Then
                                                        If Mid(strMobileNo, bytMobChkStart, Len(strThisPart)) = Trim(arrValidMobileStart(N)) Then
                                                            bytStsCd = 0        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
                                                            Exit For
                                                        End If
                                                    End If
                                                Next
                                            End If
                                            '-----------------------------------------------------------------------------------------------------------------------------------
                                            ' IPNO "your IPNO is |IPNO|"
                                            'IMPORTANT NOTE : StrMainString : STRING WITHIN DELIMETERS SHD BE EXACTLY SAME AS dsFetchData.TABLES(0).COLUMNS.COLUMNNAME
                                            'IF THY ARE NOT SAME THE STRING WIL NOT BE REPLACED


                                            ''COMMENTED BY RASIK 6 JUN 2018
                                            'If dsFetchData.Tables.Count > 0 Then
                                            '    If dsFetchData.Tables(0).Rows.Count > 0 Then
                                            ''COMMENTED BY RASIK 6 JUN 2018

                                            Dim iColCountData As Integer
                                            iColCountData = dsFetchData.Tables(0).Columns.Count
                                            If iColCountData > 0 Then
                                                For iCol As Integer = 0 To iColCountData - 1

                                                    If SplitSmsString IsNot Nothing Then

                                                        For j As Integer = 0 To SplitSmsString.Count - 1
                                                            actualFieldName = SplitSmsString(j).Replace("|", "")
                                                            If dsFetchData.Tables(0).Columns(iCol).ColumnName = actualFieldName Then
                                                                'StrMainString = Replace(StrMainString, SplitSmsString(j), dsFetchData.Tables(0).Rows(0).Item(iCol), 1, -1, CompareMethod.Text)

                                                                StrMainString = Replace(StrMainString, SplitSmsString(j), dsFetchData.Tables(0).Rows(DsTmp).Item(iCol), 1, -1, CompareMethod.Text) 'RasikV 20180606


                                                                Exit For
                                                            End If
                                                        Next

                                                    End If

                                                Next
                                            End If

                                            Dim objDtl As New clsSmsDtl
                                            objDtl.SmsSubSrl = 1
                                            objDtl.SmsType = SMSTyp
                                            objDtl.SmsMobile = strMobileNo
                                            objDtl.SmsMessage = StrMainString.ToString.Trim
                                            objDtl.SmsCrtby = UserId
                                            objDtl.SmsParts = 101
                                            'objDtl.SmsPTNNo = objSms(icnt).IpNo 
                                            objDtl.SmsStsCd = bytStsCd
                                            objDtl.SmsCrtTm = dtGetServerDate
                                            objDtl.SmsSentTm = dtGetServerDate
                                            objDtl.SmsTimeToSend = dtGetServerDate
                                            objDtl.SmsVchNo = 0

                                            arrSmsDtl.Add(objDtl)
                                        Next
                                        dsFetchData.Dispose()
                                    End If
                                End If

                            End If
                        End If
                    Next
                End If
            End If



            'Dim iCatTyp = 1
            'dsSmsMst = ofactory.ExecuteDataSet(clsSmsMst.SpSelSmsMst(Cocd, Div, loc, SMSTyp, iCatTyp))
            'Dim dsFetchData As New DataSet
            'Dim StrMainString As String = ""
            ''  Dim arrMainString As Object = Nothing
            'Dim SplitSmsString As New List(Of String)
            'If dsSmsMst.Tables.Count > 0 Then
            '    If dsSmsMst.Tables(0).Rows.Count > 0 Then
            '        StrMainString = dsSmsMst.Tables(0).Rows(0).Item("SMS_Std_Mess")
            '        '   arrMainString = Split(StrMainString, "|")
            '        SplitSmsString = CommonFunctionSplitSmsString(StrMainString)



            '        dsFetchData = ofactory.ExecuteDataSet(SpSelGetDataForSmsDtlFrmSmsMst(Cocd, Div, loc, 0, SMSTyp, iCatTyp, objPtnNo))


            '        '-----------------------------------------------------------------------------------------------------------------------------------
            '        'VALIDATE MOBILE NO LENGTH : shd nt be greater thn length assigned in SMS_PARAM
            '        Dim strMobileNo As String = ""
            '        Try
            '            strMobileNo = dsFetchData.Tables(0).Rows(0).Item("MOBILENO").ToString()

            '        Catch ex As Exception
            '            strMobileNo = ""
            '        End Try

            '        If strMobileNo <> "." Then
            '            If Mid(Val(strMobileNo), 1, 1) = 0 Then
            '                If Len(Mid(strMobileNo, 2, Len(strMobileNo))) <> iMxLenMob Then
            '                    ' Exit For
            '                    bytStsCd = 2
            '                End If
            '            ElseIf Len(strMobileNo) <> iMxLenMob Then
            '                'Exit For
            '                bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
            '            End If
            '        End If

            '        If strMobileNo = "" Then Exit Function

            '        If strValidMobStart = "" Or arrValidMobileStart Is Nothing Then
            '            Exit Function
            '        Else
            '            Dim N As Short
            '            Dim strThisPart As String
            '            Dim bytMobChkStart As Byte = 1

            '            If Len(strMobileNo) < iMxLenMob Then
            '                bytStsCd = 2        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
            '            End If

            '            For N = 1 To bytValidTypes
            '                strThisPart = Trim(arrValidMobileStart(N))
            '                If Len(strThisPart) > 0 Then
            '                    If Mid(strMobileNo, bytMobChkStart, Len(strThisPart)) = Trim(arrValidMobileStart(N)) Then
            '                        bytStsCd = 0        '(TABLE : SMS_STATUS :- 0-pending / 1-Sent / 2-Invalid Mobile No / 3-SMS Type Inactive / 4-Timed Out)
            '                        Exit For
            '                    End If
            '                End If
            '            Next
            '        End If
            '        '-----------------------------------------------------------------------------------------------------------------------------------
            '        ' IPNO "your IPNO is |IPNO|"
            '        'IMPORTANT NOTE : StrMainString : STRING WITHIN DELIMETERS SHD BE EXACTLY SAME AS dsFetchData.TABLES(0).COLUMNS.COLUMNNAME
            '        'IF THY ARE NOT SAME THE STRING WIL NOT BE REPLACED

            '        If dsFetchData.Tables.Count > 0 Then
            '            If dsFetchData.Tables(0).Rows.Count > 0 Then

            '                Dim iColCountData As Integer
            '                iColCountData = dsFetchData.Tables(0).Columns.Count
            '                If iColCountData > 0 Then
            '                    For iCol As Integer = 0 To iColCountData - 1

            '                        If SplitSmsString IsNot Nothing Then

            '                            For j As Integer = 0 To SplitSmsString.Count - 1
            '                                If dsFetchData.Tables(0).Columns(iCol).ColumnName = SplitSmsString(j) Then
            '                                    StrMainString = Replace(StrMainString, SplitSmsString(j), dsFetchData.Tables(0).Rows(0).Item(iCol), 1, -1, CompareMethod.Text)
            '                                    Exit For
            '                                End If
            '                            Next

            '                        End If

            '                    Next
            '                End If

            '                Dim objDtl As New clsSmsDtl
            '                objDtl.SmsSubSrl = 1
            '                objDtl.SmsType = SMSTyp
            '                objDtl.SmsMobile = strMobileNo
            '                objDtl.SmsMessage = StrMainString.ToString.Trim
            '                objDtl.SmsCrtby = UserId
            '                objDtl.SmsParts = 101
            '                objDtl.SmsPTNNo = objPtnNo
            '                objDtl.SmsStsCd = bytStsCd
            '                objDtl.SmsCrtTm = dtGetServerDate
            '                objDtl.SmsSentTm = dtGetServerDate
            '                objDtl.SmsTimeToSend = dtGetServerDate
            '                objDtl.SmsVchNo = 0

            '                arrSmsDtl.Add(objDtl)
            '            End If
            '        End If

            '    End If
            'End If


            ValidateSMSMain = arrSmsDtl

            ''data not present in sms_gep_dtl for sms_typ 
            'ValidateSmsForPatient = Nothing


            ''dsGrpDtl.Dispose()
            dsSmsMst.Dispose()
            objParam = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            ValidateSMSMain = Nothing
            'strSmsErrMsg.Add(ex.Message)
        End Try

        Return ValidateSMSMain
    End Function

    Public Shared Function GetSMSParamList(ByVal Source As String) As List(Of String)
        Dim lstMatches As MatchCollection = Regex.Matches(Source, "[|]([A-Z])\w+[|]", RegexOptions.IgnoreCase)
        Dim Result As New List(Of String)
        For Each m As Match In lstMatches
            For Each c As Capture In m.Captures
                Result.Add(c.Value)
            Next
        Next
        Return Result
    End Function
#End Region

End Class



#Region "CLASS :  clsSMSMstDetails  : CLASS FOR SENDING SMS"
'pragya : 18-apr-2018
<DataContract>
Public Class clsSMSMstDetails
    <DataMember()>
    Public Property PtnNo() As Long
    <DataMember()>
    Public Property IpNo() As Long
    <DataMember()>
    Public Property PtnTtlCd() As Integer
    <DataMember()>
    Public Property PtnTtlDcd() As String
    <DataMember()>
    Public Property PtnLstName() As String
    <DataMember()>
    Public Property PtnFrstName() As String
    <DataMember()>
    Public Property PtnMidName() As String
    <DataMember()>
    Public Property PtnFullName() As String
    <DataMember()>
    Public Property PtnGender() As String
    <DataMember()>
    Public Property AgeMax() As Integer
    <DataMember()>
    Public Property BedNo() As String
    <DataMember()>
    Public Property DocCd() As Integer
    <DataMember()>
    Public Property PtnMobileNo() As String
    <DataMember()>
    Public Property CategoryCd() As Integer
    <DataMember()>
    Public Property DischrgeStsCd() As Integer
  

End Class

#End Region