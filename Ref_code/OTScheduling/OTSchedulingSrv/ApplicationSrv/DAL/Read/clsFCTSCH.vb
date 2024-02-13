Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
<DataContract()>
Public Class clsFCTSCH
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
    Public Property SCHDATE As Date
    <DataMember()>
    Public Property SESSIONCODE As Integer
    <DataMember()>
    Public Property SLOTNO As Integer
    <DataMember()>
    Public Property SCHTIMEFROMHRS As Integer
    <DataMember()>
    Public Property SCHTIMEFROMMIN As Integer
    <DataMember()>
    Public Property SCHTIMETOHRS As Integer
    <DataMember()>
    Public Property SCHTIMETOMINS As Integer
    <DataMember()>
    Public Property APPTNO As Integer
    <DataMember()>
    Public Property APTMSTS As Integer
    <DataMember()>
    Public Property IPOPFLG As String
    '<DataMember()>
    'Public Property IPOPNO As Integer
    <DataMember()>
    Public Property IPOPNO As Long          'pragya 01-DEC-2016
    <DataMember()>
    Public Property CHRGCD As Integer
    <DataMember()>
    Public Property TESTCD As Integer
    <DataMember()>
    Public Property APTMREFBY As String
    <DataMember()>
    Public Property ICDGRPCD As String
    <DataMember()>
    Public Property ICDCODE As String
    <DataMember()>
    Public Property STRTHR As Integer
    <DataMember()>
    Public Property STRTMIN As Integer
    <DataMember()>
    Public Property ENDTHR As Integer
    <DataMember()>
    Public Property ENDTMIN As Integer

End Class

