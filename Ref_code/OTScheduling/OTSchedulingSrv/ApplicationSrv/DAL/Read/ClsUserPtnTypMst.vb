Imports System.Runtime.Serialization

Public Class ClsUserPtnTypMst

    Inherits clsPtnTypeMst
    <DataMember()>
    Public Property HasAccess As Boolean

    <DataMember()>
    Public Property DefAccess As Boolean


    <DataMember()>
    Public Property usr_id As String


    <DataMember()>
    Public Property crtusrid As String
    <DataMember()>
    Public Property crtdttm As DateTime

End Class
