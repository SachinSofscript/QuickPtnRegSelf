Imports System.Runtime.Serialization
Imports SofCommon


Public Class clsSmsMst

    <DataMember()>
    Public Property SMSType As Integer
    <DataMember()>
    Public Property SMSTypeDesc As String
    <DataMember()>
    Public Property SMSStdMess As String
    <DataMember()>
    Public Property ActiveFlag As Char
    <DataMember()>
    Public Property DelayMins As Integer
    <DataMember()>
    Public Property NoSendChk As Char
    <DataMember()>
    Public Property NoSend1From As Nullable(Of Date)
    <DataMember()>
    Public Property NoSend1To As Nullable(Of Date)
    <DataMember()>
    Public Property NoSend2From As Nullable(Of Date)
    <DataMember()>
    Public Property NoSend2To As Nullable(Of Date)
    <DataMember()>
    Public Property NoSend3From As Nullable(Of Date)
    <DataMember()>
    Public Property NoSend3To As Nullable(Of Date)
    <DataMember()>
    Public Property NoSend4From As Nullable(Of Date)
    <DataMember()>
    Public Property NoSend4To As Nullable(Of Date)
    <DataMember()>
    Public Property NoSend5From As Nullable(Of Date)
    <DataMember()>
    Public Property NoSend5To As Nullable(Of Date)
    <DataMember()>
    Public Property SendMultiParts As Char
    <DataMember()>
    Public Property CategoryTyp As Integer 'Added By trupti 04 AUG 2016
    <DataMember()>
    Public Property CategoryTypDesc As String  'Added By trupti 04 AUG 2016
    <DataMember()>
    Public Property SubModDesc As String  'pragya : 01-apr-2017


#Region "Get Sms Master Detail by Sms Type (SUBMODCD)"
    ''' <summary>
    ''' Get Sms Master Detail by Sms Type (SUBMODCD)
    ''' </summary>
    ''' <param name="strErrMsg"></param>
    ''' <param name="chrErrFlg"></param>
    ''' <param name="COCd"></param>
    ''' <param name="Div"></param>
    ''' <param name="Loc"></param>
    ''' <returns></returns>
    ''' <remarks>Trupti 20160722</remarks>

    Shared Function GetSmsMstBySmsTypCd(ByRef strErrMsg As List(Of String), _
                                             ByRef chrErrFlg As Char, _
                                             ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal SMSTyp As Integer) As List(Of clsSmsMst)

        GetSmsMstBySmsTypCd = Nothing
        Dim str As String
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelSmsMst001(COCd, Div, Loc, SMSTyp))
            Dim objarr As New List(Of clsSmsMst) 'Added By trupti 04 AUG 2016
            If dr1.hasrows Then
                objarr = New List(Of clsSmsMst) 'Added By trupti 04 AUG 2016
                While dr1.Read()
                    With dr1
                        Dim obj As New clsSmsMst 'Added By trupti 04 AUG 2016

                        obj.SMSType = IIf(IsDBNull(.Item("SMS_Type")), 0, .Item("SMS_Type"))
                        obj.SMSTypeDesc = IIf(IsDBNull(.Item("SMS_Type_Desc")), "", .Item("SMS_Type_Desc"))
                        obj.SMSStdMess = IIf(IsDBNull(.Item("SMS_Std_Mess")), "", .Item("SMS_Std_Mess"))
                        obj.ActiveFlag = IIf(IsDBNull(.Item("Active_Flag")), "N", .Item("Active_Flag"))
                        obj.DelayMins = IIf(IsDBNull(.Item("Delay_Mins")), 0, .Item("Delay_Mins"))
                        obj.NoSendChk = IIf(IsDBNull(.Item("No_Send_Chk")), "", .Item("No_Send_Chk"))
                        ' obj.NoSend1From = IIf(IsDBNull(.Item("No_Send_1_from")), Nothing, Date.Today.Add(.Item("No_Send_1_from")))
                        If IsDBNull(.Item("No_Send_1_from")) = True Then
                            obj.NoSend1From = Nothing
                        Else
                            obj.NoSend1From = Date.Today.Add(.Item("No_Send_1_from"))
                        End If
                        ' obj.NoSend1To = IIf(IsDBNull(.Item("No_Send_1_To")), Nothing, Date.Today.Add(.Item("No_Send_1_To")))
                        If IsDBNull(.Item("No_Send_1_To")) = True Then
                            obj.NoSend1To = Nothing
                        Else
                            obj.NoSend1To = Date.Today.Add(.Item("No_Send_1_To"))
                        End If
                        If IsDBNull(.Item("No_Send_2_From")) = True Then
                            obj.NoSend2From = Nothing
                        Else
                            obj.NoSend2From = Date.Today.Add(.Item("No_Send_2_From"))
                        End If
                        ' obj.NoSend2To = IIf(IsDBNull(.Item("No_Send_2_To")), Nothing, Date.Today.Add(.Item("No_Send_2_To")))

                        If IsDBNull(.Item("No_Send_2_To")) = True Then
                            obj.NoSend2To = Nothing
                        Else
                            obj.NoSend2To = Date.Today.Add(.Item("No_Send_2_To"))
                        End If
                        ' obj.NoSend3From = IIf(IsDBNull(.Item("No_Send_3_From")), Nothing, Date.Today.Add(.Item("No_Send_3_From")))
                        If IsDBNull(.Item("No_Send_3_From")) = True Then
                            obj.NoSend3From = Nothing
                        Else
                            obj.NoSend3From = Date.Today.Add(.Item("No_Send_3_From"))
                        End If
                        'obj.NoSend3To = IIf(IsDBNull(.Item("No_Send_3_To")), Nothing, Date.Today.Add(.Item("No_Send_3_To")))
                        If IsDBNull(.Item("No_Send_3_To")) = True Then
                            obj.NoSend3To = Nothing
                        Else
                            obj.NoSend3To = Date.Today.Add(.Item("No_Send_3_To"))
                        End If
                        '  obj.NoSend4From = IIf(IsDBNull(.Item("No_Send_4_From")), Nothing, Date.Today.Add(.Item("No_Send_4_From")))
                        If IsDBNull(.Item("No_Send_4_From")) = True Then
                            obj.NoSend4From = Nothing
                        Else
                            obj.NoSend4From = Date.Today.Add(.Item("No_Send_4_From"))
                        End If
                        ' obj.NoSend4To = IIf(IsDBNull(.Item("No_Send_4_To")), Nothing, Date.Today.Add(.Item("No_Send_4_To")))
                        If IsDBNull(.Item("No_Send_4_To")) = True Then
                            obj.NoSend4To = Nothing
                        Else
                            obj.NoSend4To = Date.Today.Add(.Item("No_Send_4_From"))
                        End If
                        ' obj.NoSend5From = IIf(IsDBNull(.Item("No_Send_5_From")), Nothing, Date.Today.Add(.Item("No_Send_5_From")))
                        If IsDBNull(.Item("No_Send_5_From")) = True Then
                            obj.NoSend5From = Nothing
                        Else
                            obj.NoSend5From = Date.Today.Add(.Item("No_Send_5_From"))
                        End If
                        'obj.NoSend5To = IIf(IsDBNull(.Item("No_Send_5_To")), Nothing, Date.Today.Add(.Item("No_Send_5_To")))
                        If IsDBNull(.Item("No_Send_5_To")) = True Then
                            obj.NoSend5To = Nothing
                        Else
                            obj.NoSend5To = Date.Today.Add(.Item("No_Send_5_To"))
                        End If
                        obj.SendMultiParts = IIf(IsDBNull(.Item("Send_MultiParts")), "N", .Item("Send_MultiParts"))

                        obj.CategoryTyp = IIf(IsDBNull(.Item("CategoryTyp")), "N", .Item("CategoryTyp")) 'Added By trupti 04 AUG 2016
                        obj.CategoryTypDesc = IIf(IsDBNull(.Item("CategoryTypDesc")), "N", .Item("CategoryTypDesc")) 'Added By trupti 04 AUG 2016
                        obj.SubModDesc = IIf(IsDBNull(.Item("SubModName")), "", .Item("SubModName")) 'pragya : 01-apr-2017 
                        objarr.Add(obj) 'Added By trupti 04 AUG 2016

                    End With
                End While
            Else
                objarr = Nothing  'Added By trupti 04 AUG 2016
            End If
            dr1.close()
            GetSmsMstBySmsTypCd = objarr 'Added By trupti 04 AUG 2016
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
        Return GetSmsMstBySmsTypCd
    End Function

    Shared Function SpSelSmsMst001(ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal SmsTyp As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelSmsMst001]"
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
            oParam.ParamName = "pSmsTyp"
            oParam.ParamValue = SmsTyp
            .Parameters.Add(oParam)


        End With

        Return oRequest
    End Function
#End Region

    
#Region "SpSelSmsMst : Get Active Details of SMS_MST by passsing SMS_TYP(MODCD) & CategoryTyp"

    ''' <summary>
    ''' SpSelSmsMst : Get Active Details of SMS_MST by passsing SMS_TYP(MODCD) & CategoryTyp
    ''' </summary>
    ''' <param name="COCd"></param>
    ''' <param name="Div"></param>
    ''' <param name="Loc"></param>
    ''' <param name="SmsTyp"></param>
    ''' <param name="CategoryTyp"></param>
    ''' <returns></returns>
    ''' <remarks>PRAGYA : 28-JUL-2016</remarks>

    Shared Function SpSelSmsMst(ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal SmsTyp As Integer, ByVal CategoryTyp As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelSmsMst]"
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
            oParam.ParamName = "pSmsTyp"
            oParam.ParamValue = SmsTyp
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCategoryTyp"
            oParam.ParamValue = CategoryTyp
            .Parameters.Add(oParam)


        End With

        Return oRequest
    End Function
#End Region




#Region "Get Sms Master Detail by Sms Type (SUBMODCD) and sms CategoryTyp"  'Added By trupti 04 AUG 2016

    Shared Function GetSmsMstBySmsTypSmsCatg(ByRef strErrMsg As List(Of String), _
                                              ByRef chrErrFlg As Char, _
                                              ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal SMSTyp As Integer, ByVal SmsCat As Integer) As clsSmsMst

        GetSmsMstBySmsTypSmsCatg = Nothing
        Try
            Dim ofactory As New DBFactory
            Dim dr1 As Object = ofactory.ExecuteDataReader(SpSelSmsMst002(COCd, Div, Loc, SMSTyp, SmsCat))
            Dim obj As New clsSmsMst

            If dr1.hasrows Then
                While dr1.Read()
                    With dr1
                        obj.SMSType = IIf(IsDBNull(.Item("SMS_Type")), 0, .Item("SMS_Type"))
                        obj.SMSTypeDesc = IIf(IsDBNull(.Item("SMS_Type_Desc")), "", .Item("SMS_Type_Desc"))
                        obj.SMSStdMess = IIf(IsDBNull(.Item("SMS_Std_Mess")), "", .Item("SMS_Std_Mess"))
                        obj.ActiveFlag = IIf(IsDBNull(.Item("Active_Flag")), "N", .Item("Active_Flag"))
                        obj.DelayMins = IIf(IsDBNull(.Item("Delay_Mins")), 0, .Item("Delay_Mins"))
                        obj.NoSendChk = IIf(IsDBNull(.Item("No_Send_Chk")), "", .Item("No_Send_Chk"))
                        If IsDBNull(.Item("No_Send_1_from")) = True Then
                            obj.NoSend1From = Nothing
                        Else
                            obj.NoSend1From = Date.Today.Add(.Item("No_Send_1_from"))
                        End If
                        If IsDBNull(.Item("No_Send_1_To")) = True Then
                            obj.NoSend1To = Nothing
                        Else
                            obj.NoSend1To = Date.Today.Add(.Item("No_Send_1_To"))
                        End If
                        If IsDBNull(.Item("No_Send_2_From")) = True Then
                            obj.NoSend2From = Nothing
                        Else
                            obj.NoSend2From = Date.Today.Add(.Item("No_Send_2_From"))
                        End If
                        If IsDBNull(.Item("No_Send_2_To")) = True Then
                            obj.NoSend2To = Nothing
                        Else
                            obj.NoSend2To = Date.Today.Add(.Item("No_Send_2_To"))
                        End If
                        If IsDBNull(.Item("No_Send_3_From")) = True Then
                            obj.NoSend3From = Nothing
                        Else
                            obj.NoSend3From = Date.Today.Add(.Item("No_Send_3_From"))
                        End If
                        If IsDBNull(.Item("No_Send_3_To")) = True Then
                            obj.NoSend3To = Nothing
                        Else
                            obj.NoSend3To = Date.Today.Add(.Item("No_Send_3_To"))
                        End If
                        If IsDBNull(.Item("No_Send_4_From")) = True Then
                            obj.NoSend4From = Nothing
                        Else
                            obj.NoSend4From = Date.Today.Add(.Item("No_Send_4_From"))
                        End If
                        If IsDBNull(.Item("No_Send_4_To")) = True Then
                            obj.NoSend4To = Nothing
                        Else
                            obj.NoSend4To = Date.Today.Add(.Item("No_Send_4_From"))
                        End If
                        If IsDBNull(.Item("No_Send_5_From")) = True Then
                            obj.NoSend5From = Nothing
                        Else
                            obj.NoSend5From = Date.Today.Add(.Item("No_Send_5_From"))
                        End If
                        If IsDBNull(.Item("No_Send_5_To")) = True Then
                            obj.NoSend5To = Nothing
                        Else
                            obj.NoSend5To = Date.Today.Add(.Item("No_Send_5_To"))
                        End If
                        obj.SendMultiParts = IIf(IsDBNull(.Item("Send_MultiParts")), "N", .Item("Send_MultiParts"))
                        obj.CategoryTyp = IIf(IsDBNull(.Item("CategoryTyp")), "N", .Item("CategoryTyp"))
                        obj.CategoryTypDesc = IIf(IsDBNull(.Item("CategoryTypDesc")), "N", .Item("CategoryTypDesc"))
                    End With
                End While
            Else
                obj = Nothing
            End If
            dr1.close()
            GetSmsMstBySmsTypSmsCatg = obj
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try
        Return GetSmsMstBySmsTypSmsCatg
    End Function


    Shared Function SpSelSmsMst002(ByVal COCd As String, ByVal Div As Integer, ByVal Loc As Integer, ByVal SmsTyp As Integer, ByVal CategoryTyp As Integer) As DBRequest
        Dim oRequest As DBRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "[SpSelSmsMst002]"
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
            oParam.ParamName = "pSmsTyp"
            oParam.ParamValue = SmsTyp
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCategoryTyp"
            oParam.ParamValue = CategoryTyp
            .Parameters.Add(oParam)


        End With

        Return oRequest
    End Function
#End Region



#Region "GET SMS_TYPE ACTIVE OR NOT" 'RasikV 20180627
    Shared Function FnIsSmsTypeActive(ByRef strErrMsg As List(Of String), _
                                      ByRef chrErrFlg As Char, _
                                      ByVal CoCd As String, _
                                      ByVal Div As Integer, _
                                      ByVal Loc As Integer, _
                                      ByVal SmsTyp As Integer, _
                                      ByVal SmsCat As Integer) As Boolean
        Try
            Dim orequest As New DBRequest
            orequest.CommandType = CommandType.Text
            orequest.Command = "SELECT [dbo].[FnIsSmsTypeActive]  ('" & CoCd & "', " & Div & ", " & Loc & ", " & SmsTyp & ", " & SmsCat & ") IsSmsTypeActive"
            Dim ofactory As New DBFactory
            Dim ds As DataSet = ofactory.ExecuteDataSet(orequest)

            If ds.Tables(0).Rows.Count <> 0 Then
                FnIsSmsTypeActive = ds.Tables(0).Rows(0).Item("IsSmsTypeActive")
            Else
                FnIsSmsTypeActive = False
            End If
            orequest = Nothing
            ofactory = Nothing
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            FnIsSmsTypeActive = 0
        End Try
        Return FnIsSmsTypeActive
    End Function
#End Region

End Class
