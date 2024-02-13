Imports SofCommon

Public Class clsInsertUpdatePatMst
    Shared Function SpInsPtnMst1001(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                         ByRef chrErrFlg As Char,
                                         ByVal Cocd As String,
                                         ByVal Div As Integer, ByVal Loc As Integer, ByVal obj As clsPatient) As DBRequest
        SpInsPtnMst1001 = Nothing
        Dim oParam As DBRequest.Parameter

        Try
            Dim Request As New DBRequest
            Request.Command = "[SpInsPtnMst1001]"
            Request.CommandType = CommandType.StoredProcedure
            Request.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ptn_no"
            oParam.ParamValue = obj.PatientNo
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "typ_flg"
            oParam.ParamValue = obj.TYPFLG
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ttl_cd"
            oParam.ParamValue = obj.PatientTitleCode
            Request.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "ptn_lst_nm"
            oParam.ParamValue = obj.PatientLastName
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ptn_frst_nm"
            oParam.ParamValue = obj.PatientFirstName
            Request.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "ptn_mid_nm"
            oParam.ParamValue = obj.PatientMiddleName
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "sex"
            oParam.ParamValue = obj.Gender
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "brth_dt"
            oParam.ParamValue = obj.BirthDate
            Request.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "age_yy"
            oParam.ParamValue = obj.AgeYY
            Request.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "age_mm"
            oParam.ParamValue = obj.Agemm
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "age_dd"
            oParam.ParamValue = obj.Agedd
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "prmnt_city"
            oParam.ParamValue = obj.cityCode
            Request.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "prmnt_tel"
            oParam.ParamValue = obj.prmnt_tel
            Request.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "prmnt_cntry"
            oParam.ParamValue = obj.prmnt_cntry
            Request.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "ntnlty_cd"
            oParam.ParamValue = obj.NtnltyCd
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "doc_cd"
            oParam.ParamValue = obj.DocCd
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "exp_dt"
            oParam.ParamValue = obj.UserDtTm
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "crt_dt"
            oParam.ParamValue = obj.UserDtTm
            Request.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "crt_tm"
            oParam.ParamValue = obj.UserDtTm
            Request.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "crt_usr_id"
            oParam.ParamValue = obj.UserId
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "updt_dt"
            oParam.ParamValue = obj.UserDtTm
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "updt_tm"
            oParam.ParamValue = obj.UserDtTm
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "updt_usr_id"
            oParam.ParamValue = obj.UserId
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "clnc_cd"
            oParam.ParamValue = obj.ClncCd
            Request.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "statecd"
            oParam.ParamValue = obj.StateCode
            Request.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "bill_type"
            oParam.ParamValue = obj.BillType
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "no"
            oParam.ParamValue = 0
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pIsPtnBlackListed"
            oParam.ParamValue = 0
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pISEmergencyPtn"
            oParam.ParamValue = 0
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "istranblocked"
            oParam.ParamValue = 0
            Request.Parameters.Add(oParam)



            SpInsPtnMst1001 = Request
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SpInsPtnMst1001 = Nothing

        End Try

        Return SpInsPtnMst1001
    End Function


    Shared Function SpInsPtnMst2001(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                         ByRef chrErrFlg As Char,
                                         ByVal Cocd As String,
                                         ByVal Div As Integer, ByVal Loc As Integer, ByVal obj As clsPtnMst2) As DBRequest
        SpInsPtnMst2001 = Nothing
        Dim oParam As DBRequest.Parameter

        Try
            Dim Request As New DBRequest
            Request.Command = "[SP2]"
            Request.CommandType = CommandType.StoredProcedure
            Request.Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "ptn_no"
            oParam.ParamValue = obj.PtnNo
            Request.Parameters.Add(oParam)
            oParam = New DBRequest.Parameter
            oParam.ParamName = "crt_dt"
            oParam.ParamValue = obj.UserDtTm
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "crt_tm"
            oParam.ParamValue = obj.UserDtTm
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "crt_usr_id"
            oParam.ParamValue = obj.UserId
            Request.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "updt_dt"
            oParam.ParamValue = obj.UserDtTm
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "updt_tm"
            oParam.ParamValue = obj.UserDtTm
            Request.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "updt_usr_id"
            oParam.ParamValue = obj.UserId
            Request.Parameters.Add(oParam)


            SpInsPtnMst2001 = Request
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            SpInsPtnMst2001 = Nothing
        End Try

        Return SpInsPtnMst2001
    End Function

End Class
