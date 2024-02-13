Imports CWReadClasses
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.Text
Imports WcfServices.CashDenomination

<ServiceContract()>
Public Interface icommonFunctions




    <OperationContract()>
    Function GetReportServerUserNamePassword(ByRef strErrMsg As List(Of String), _
                                                   ByRef chrErrFlg As Char, _
                                                   ByVal CoCd As String, _
                                                   ByVal Div As Integer, _
                                                   ByVal Loc As Integer) As List(Of String)

    <OperationContract()>
    Function ConvertYYYYMMDDToSQLDatetime(ByVal yyyymmdd As String, ByVal hhmm As Integer) As Date
    <OperationContract()>
    Function ConvertSQLDatetimeToYYYYMMDD(ByVal sqldate As Date) As String
    <OperationContract()>
    Function GetServerDateTime() As Date
    <OperationContract()>
    Function GetRevenueDate() As Date
    <OperationContract()>
    Function GetRevenueDateDL(ByRef strErrMsg As List(Of String),
                                       ByRef chrErrFlg As Char, ByVal cocd As String, ByVal divcd As Integer, ByVal loccd As Integer) As Date 'anamika 20151208
    <OperationContract()>
    Function GetGenderName(ByRef strErrMsg As List(Of String),
                                     ByRef chrErrFlg As Char, ByVal cocd As String, ByVal divcd As Integer, ByVal loccd As Integer, ByVal Gender As Char) As String 'anamika 20160120
    <OperationContract()>
    Function GetAdmissionDate(ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer, ByVal pipno As Long) As Date
    <OperationContract()>
    Function ChkSysLock(ByRef strErrMsg As List(Of String),
                                    ByRef chrErrFlg As Char,
                                    ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As Boolean
    <OperationContract()>
    Function GetCalRate(ByRef strErrMsg As System.Collections.Generic.List(Of String),
                                          ByRef chrErrFlg As Char, ByVal pcompanycode As String, ByVal pdiv As Integer,
                                          ByVal ploc As Integer, ByVal objcalRate As CommonModule.clsCalRate, Optional ByVal EmergencyFlg As String = "N") As CommonModule.clsCalRate 'anamika 30/05/2013




    <OperationContract()>
    Function GetFinancialYr(ByVal cocd As String, ByVal divcd As Integer, ByVal loccd As Integer) As Integer 'anamika 20140923
    <OperationContract()>
    Function GetCurrancy(ByRef strErrMsg As List(Of String),
                                       ByRef chrErrFlg As Char, ByVal cocd As String, ByVal divcd As Integer, ByVal loccd As Integer) As String 'anamika 20150829





    <OperationContract()>
    Function GetFinancialYrBetweenDt(ByRef strErrMsg As List(Of String), ByRef chrErrFlg As Char, ByVal Cocd As String,
           ByVal DivCd As Integer, ByVal LocCd As Integer, ByVal Dt As Date, ByVal Year As Integer) As Boolean

End Interface
