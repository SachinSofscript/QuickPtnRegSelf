Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
<DataContract()>
Public Class clsFCTAPTREQ
    <DataMember()>
    Public Property CompanyCode() As String
    <DataMember()>
    Public Property DivisionCode() As Integer
    <DataMember()>
    Public Property LocationCode() As Integer
    <DataMember()>
    Public Property REQNO As Integer
    <DataMember()>
    Public Property REQDATE As Date
    <DataMember()>
    Public Property FORSPCFCFCT As Boolean
    <DataMember()>
    Public Property FctCatCode As Integer
    <DataMember()>
    Public Property FctMainCode As Integer
    <DataMember()>
    Public Property FCTCODE As Integer
    <DataMember()>
    Public Property APPTNO As Integer
    <DataMember()>
    Public Property DOCCD As Integer
    <DataMember()>
    Public Property ISPATIENT As Boolean
    <DataMember()>
    Public Property IP_OP As String
    '<DataMember()>
    'Public Property PTNNO As Integer
    <DataMember()>
    Public Property PTNNO As Long   'PRAGYA 01-DESC-2016

    '<DataMember()>
    'Public Property IPOPNO As Integer
    <DataMember()>
    Public Property IPOPNO As Long ' 01-DEC-2016 PRAGYA
    <DataMember()>
    Public Property PTNLNGNM As String
    <DataMember()>
    Public Property APTMTMFROM As Integer
    <DataMember()>
    Public Property APTMTMTO As Integer
    <DataMember()>
    Public Property ISSHIFTED As Boolean
    <DataMember()>
    Public Property NEWFCTCODE As Integer
    <DataMember()>
    Public Property NEWAPPTNO As Integer
    <DataMember()>
    Public Property CRTUSRID As String
    <DataMember()>
    Public Property CRTDTTM As Date
    <DataMember()>
    Public Property UPDUSRID As String
    <DataMember()>
    Public Property UPDDTTM As Date
    <DataMember()>
    Public Property PRMREQCODE As Integer
    <DataMember>
    Public Property APPTRMRK() As String  'Sumit 19-Sep-2018


    'shital 20211204 start

    <DataMember>
    Public Property ANESTYPCD() As Integer

    <DataMember>
    Public Property NurseName() As String

    <DataMember()>
    Public Property BOOKING_TYPE As Integer

    'end
End Class

