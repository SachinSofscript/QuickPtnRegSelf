Imports OTScheduling.IpPostVoucherServiceReference


Public Class clsIpPostVoucher

    Public Shared IpPostVchrProxy As iIpPostVoucherClient
    Public Shared Function getBalanceDtls(ByRef strErrMsg As List(Of String),
                                      ByRef chrErrFlg As Char,
                                      ByVal pcompanycode As String,
                                      ByVal pdiv As Integer,
                                      ByVal ploc As Integer, ByVal IpNo As Long) As List(Of clsIpDepRcpt)
        getBalanceDtls = Nothing
        Dim tmpstrErrMsg As New List(Of String) 'anamika 20161118
        Dim tmpchrErrFlg As Char = "N"
        Try
            IpPostVchrProxy = New iIpPostVoucherClient()
            getBalanceDtls = IpPostVchrProxy.getBalanceDtls(tmpstrErrMsg, tmpchrErrFlg, pcompanycode, pdiv, ploc, IpNo)
        Catch ex As Exception
            IpPostVchrProxy.Abort()
            tmpstrErrMsg.Add(ex.Message)
            tmpchrErrFlg = "Y"
        Finally
            IpPostVchrProxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return getBalanceDtls
    End Function

End Class
