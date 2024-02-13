Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
<DataContract()>
Public Class clsFCTAPTCNCL
    <DataMember()>
    Public Property CompanyCode() As String
    <DataMember()>
    Public Property DivisionCode() As Integer
    <DataMember()>
    Public Property LocationCode() As Integer
    <DataMember()>
    Public Property FctCatCode As Integer
    <DataMember()>
    Public Property FctMainCode As Integer
    <DataMember()>
    Public Property FCTCODE As Integer
    <DataMember()>
    Public Property APPTNO As Integer
    <DataMember()>
    Public Property APTMDATE As Date
    <DataMember()>
    Public Property SESSIONCODE As Integer
    <DataMember()>
    Public Property DOCCD As Integer
    <DataMember()>
    Public Property ISPATIENT As Boolean
    <DataMember()>
    Public Property IP_OP As String
    '<DataMember()>
    'Public Property PTNNO As Integer
    <DataMember()>
    Public Property PTNNO As Long 'pragya : 01-dec-2016
    <DataMember()>
    Public Property PTNLNGNM As String
    <DataMember()>
    Public Property APTMTMFROM As Integer
    <DataMember()>
    Public Property APTMTMTO As Integer
    <DataMember()>
    Public Property NOOFSLOTSUSED As Integer
    <DataMember()>
    Public Property DURATION As Integer
    <DataMember()>
    Public Property ISPERFORMED As Boolean
    <DataMember()>
    Public Property ISPOSTED As Boolean
    <DataMember()>
    Public Property ISSHIFTED As Boolean
    <DataMember()>
    Public Property CRTUSRID As String
    <DataMember()>
    Public Property CRTDTTM As Date
    <DataMember()>
    Public Property CNCLUSRID As String
    <DataMember()>
    Public Property CNCLDTTM As Date
    <DataMember()>
    Public Property CNCL_RMRK As String
    <DataMember>
    Public Property APPTRMRK() As String  'Sumit 19-Sep-2018
End Class




