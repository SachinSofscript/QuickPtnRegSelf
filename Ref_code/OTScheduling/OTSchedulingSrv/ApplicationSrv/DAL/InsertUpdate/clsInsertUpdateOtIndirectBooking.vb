Imports System.Runtime.Serialization
Imports SofCommon

Public Class clsInsertUpdateOtIndirectBooking   'RasikV 20160922

    Shared Function SpInsOtIndirctBookng(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal obj As ClsOtIndirectBooking) As DBRequest
        Dim oRequest As DBRequest
        oRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "SpInsOtIndirctBookng"
            .CommandType = CommandType.StoredProcedure
            .Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCocd"
            oParam.ParamValue = cocd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDivCd"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoccd"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pTrnNo"
            oParam.ParamValue = obj.TrnNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pPtnNo"
            oParam.ParamValue = obj.PtnNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDocCd"
            oParam.ParamValue = obj.DocCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pStatus"
            oParam.ParamValue = obj.Status
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pExpectedDate"
            oParam.ParamValue = obj.ExpectedDate
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCrtDtTm"
            oParam.ParamValue = obj.UserDtTm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCrtUserId"
            oParam.ParamValue = obj.UserId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUpdtDtTm"
            oParam.ParamValue = obj.UserDtTm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUpdtUserId"
            oParam.ParamValue = obj.UserId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "IsOfficePrmsnGiven"
            oParam.ParamValue = obj.IsOfficePrmsnGiven
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "OfficePrmsnByUsrID"
            oParam.ParamValue = obj.OfficePrmsnByUsrID
            oRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "OfficePrmsnRmrk"
            oParam.ParamValue = obj.OfficePrmsnRmrk
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "OfficePrmsnDtTm"
            oParam.ParamValue = obj.OfficePrmsnDtTm
            oRequest.Parameters.Add(oParam)

        End With
        Return oRequest
    End Function

    Shared Function SpUpOtIndirctBookng(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal obj As ClsOtIndirectBooking) As DBRequest
        Dim oRequest As DBRequest
        oRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "SpUpOtIndirctBookng"
            .CommandType = CommandType.StoredProcedure
            .Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCocd"
            oParam.ParamValue = cocd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDivCd"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoccd"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pTrnNo"
            oParam.ParamValue = obj.TrnNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pPtnNo"
            oParam.ParamValue = obj.PtnNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDocCd"
            oParam.ParamValue = obj.DocCd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pStatus"
            oParam.ParamValue = obj.Status
            .Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "pExpectedDate"
            oParam.ParamValue = obj.ExpectedDate
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCrtDtTm"
            oParam.ParamValue = obj.UserDtTm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCrtUserId"
            oParam.ParamValue = obj.UserId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUpdtDtTm"
            oParam.ParamValue = obj.UserDtTm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUpdtUserId"
            oParam.ParamValue = obj.UserId
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "IsOfficePrmsnGiven"
            oParam.ParamValue = obj.IsOfficePrmsnGiven
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "OfficePrmsnByUsrID"
            oParam.ParamValue = obj.OfficePrmsnByUsrID
            oRequest.Parameters.Add(oParam)


            oParam = New DBRequest.Parameter
            oParam.ParamName = "OfficePrmsnRmrk"
            oParam.ParamValue = obj.OfficePrmsnRmrk
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "OfficePrmsnDtTm"
            oParam.ParamValue = obj.OfficePrmsnDtTm
            oRequest.Parameters.Add(oParam)

        End With
        Return oRequest
    End Function

    Shared Function SpUpOtIndirctBookng001(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal TrnNo As Integer, ByVal PtnNo As Long, ByVal Status As Integer, ByVal UsrId As String, ByVal UsrDtTm As Date) As DBRequest
        Dim oRequest As DBRequest
        oRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "SpUpOtIndirctBookng001"
            .CommandType = CommandType.StoredProcedure
            .Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCocd"
            oParam.ParamValue = cocd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDivCd"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoccd"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pTrnNo"
            oParam.ParamValue = TrnNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pPtnNo"
            oParam.ParamValue = PtnNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pStatus"
            oParam.ParamValue = Status
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUpdtDtTm"
            oParam.ParamValue = UsrDtTm
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pUpdtUserId"
            oParam.ParamValue = UsrId
            .Parameters.Add(oParam)

        End With
        Return oRequest
    End Function
    Shared Function SpUpOtIndirctBookngChkop(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal obj As ClsOtIndirectBooking) As DBRequest   'Nutan 12 Jan 2022
        Dim oRequest As DBRequest
        oRequest = New DBRequest
        Dim oParam As New DBRequest.Parameter
        With oRequest
            .Command = "SpUpOtIndirctBookngChkop"
            .CommandType = CommandType.StoredProcedure
            .Transactional = True

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pCocd"
            oParam.ParamValue = cocd
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pDivCd"
            oParam.ParamValue = div
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pLoccd"
            oParam.ParamValue = loc
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pTrnNo"
            oParam.ParamValue = obj.TrnNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "pPtnNo"
            oParam.ParamValue = obj.PtnNo
            .Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "IsOfficePrmsnGiven"
            oParam.ParamValue = obj.IsOfficePrmsnGiven
            oRequest.Parameters.Add(oParam)

            oParam = New DBRequest.Parameter
            oParam.ParamName = "OfficePrmsnByUsrID"
            oParam.ParamValue = obj.OfficePrmsnByUsrID
            oRequest.Parameters.Add(oParam)

        End With
        Return oRequest
    End Function

End Class
