Imports System
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports SofCommon
Imports System.Data.SqlClient
<DataContract()>
Public Class clsFCTAPTMAIN
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
    Public Property APTMDATE As DateTime
    <DataMember()>
    Public Property DOCCD As Integer
    <DataMember()>
    Public Property ISPATIENT As Integer

    <DataMember()>
    Public Property ICDGRPCD As String
    <DataMember()>
    Public Property APTMSTS As Integer
    <DataMember()>
    Public Property REQNO As Integer
    <DataMember()>
    Public Property APTMFROMHRS As Integer
    <DataMember()>
    Public Property APTMFROMMIN As Integer
    <DataMember()>
    Public Property APTMTOHRS As Integer
    <DataMember()>
    Public Property APTMTOMNS As Integer
    <DataMember()>
    Public Property APTMACTFROMHRS As Integer
    <DataMember()>
    Public Property APTMACTFROMMIN As Integer
    <DataMember()>
    Public Property APTMACTTOHRS As Integer
    <DataMember()>
    Public Property pIPOPFLG As String
    <DataMember()>
    Public Property APTMACTTOMNS As Integer
    <DataMember()>
    Public Property WARDNO As Integer
    <DataMember()>
    Public Property PTNCLSCD As Integer
    <DataMember()>
    Public Property BEDNO As String
    <DataMember()>
    Public Property APTMREFBY As String
    <DataMember()>
    Public Property CHRGCD As Integer
    <DataMember()>
    Public Property TESTCD As Integer
    <DataMember()>
    Public Property ICDCD As String
    <DataMember()>
    Public Property DR1CODE As Integer
    <DataMember()>
    Public Property DR2CODE As Integer
    <DataMember()>
    Public Property DR3CODE As Integer
    <DataMember()>
    Public Property DR4CODE As Integer
    <DataMember()>
    Public Property ANAS1CODE As Integer
    <DataMember()>
    Public Property ANAS2CODE As Integer
    <DataMember()>
    Public Property ANAS3CODE As Integer
    <DataMember()>
    Public Property SURGNOTE1 As String
    <DataMember()>
    Public Property SURGNOTE2 As String
    <DataMember()>
    Public Property TYPE1NOS As Integer
    <DataMember()>
    Public Property OPRSTFTYPE1 As Integer
    <DataMember()>
    Public Property OPRSTFTYPE2 As Integer
    <DataMember()>
    Public Property TYPE2NOS As Integer
    <DataMember()>
    Public Property OPRSTFTYPE3 As Integer
    <DataMember()>
    Public Property OPRSTFTYPE4 As Integer
    <DataMember()>
    Public Property TYPE3NOS As Integer
    <DataMember()>
    Public Property TYPE4NOS As Integer
    <DataMember()>
    Public Property PANASTYPE As String
    <DataMember()>
    Public Property SPLINST As String
    <DataMember()>
    Public Property ANASNOTE1 As String
    <DataMember()>
    Public Property ANASNOTE2 As String
    <DataMember()>
    Public Property CRTUSRID As String
    <DataMember()>
    Public Property CRTDTTM As DateTime
    <DataMember()>
    Public Property UPDUSRID As String
    <DataMember()>
    Public Property UPDTTTM As DateTime
    <DataMember()>
    Public Property REQSRNO As Integer
    <DataMember()>
    Public Property Billed As String
    <DataMember()>
    Public Property BookFor As String
    <DataMember()>
    Public Property PTNLSTNAME As String
    <DataMember()>
    Public Property PTNMIDNAME As String
    <DataMember()>
    Public Property PTNFSTNAME As String
    <DataMember()>
    Public Property ptndet As String
    <DataMember()>
    Public Property SMSSENDFLG As String
    <DataMember()>
    Public Property IPOP As Long 'pragya : 15-oct-2016
    '<DataMember()>
    'Public Property IPOP As Integer
End Class





