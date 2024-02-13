Imports System.Runtime.Serialization

Public Class clsPtnMst2
    <DataMember()>
    Public Property PtnNo() As Long  'Integer 'anamika 20160829
    <DataMember()>
    Public Property MrtlStsCd() As Integer
    <DataMember()>
    Public Property OccpnCd() As Integer
    <DataMember()>
    Public Property EdctnCd() As Integer
    <DataMember()>
    Public Property IncmCd() As Integer
    <DataMember()>
    Public Property RlgnCd() As Integer
    <DataMember()>
    Public Property CmntyCd() As Integer
    <DataMember()>
    Public Property KinTtlCd() As Integer
    <DataMember()>
    Public Property KinLstNm() As String
    <DataMember()>
    Public Property KinFrstNm() As String
    <DataMember()>
    Public Property KinMidNm() As String
    <DataMember()>
    Public Property KinRelCd() As Integer
    <DataMember()>
    Public Property Ht() As Double
    <DataMember()>
    Public Property HtUnitCd() As Integer
    <DataMember()>
    Public Property DtHt() As Date
    <DataMember()>
    Public Property Wt() As Double
    <DataMember()>
    Public Property WtUnitCd() As Integer
    <DataMember()>
    Public Property DtWt() As Date
    <DataMember()>
    Public Property BldGrpCd() As Integer
    <DataMember()>
    Public Property RhFctr() As Char
    <DataMember()>
    Public Property PsprtNo() As String
    <DataMember()>
    Public Property PsprtIssPlc() As String
    <DataMember()>
    Public Property PsprtVldDt() As Date
    <DataMember()>
    Public Property WpNo() As String
    <DataMember()>
    Public Property WpIssAthrty() As String
    <DataMember()>
    Public Property WpVldDt() As Date
    <DataMember()>
    Public Property UserDtTm() As Date
    <DataMember()>
    Public Property UserId() As String
    <DataMember()>
    Public Property No() As Integer
    '<DataMember()>
    'Public Property KinPtnNo As Integer  'anamika 20160128
    <DataMember()>
    Public Property KinPtnNo As Long  'anamika 20160830
    <DataMember()>
    Public Property KinAddrs1() As String
    <DataMember()>
    Public Property KinAddrs2() As String
    <DataMember()>
    Public Property KinAddrs3() As String
    <DataMember()>
    Public Property kinCity() As Integer
    <DataMember()>
    Public Property KinCntry() As Integer
    <DataMember()>
    Public Property KinPin() As String
    <DataMember()>
    Public Property KinTel() As String
    <DataMember()>
    Public Property KinOffTel() As String
    <DataMember()>
    Public Property KinPager() As String
    <DataMember()>
    Public Property KinMobile() As String
    <DataMember()>
    Public Property Alergy() As String
    <DataMember()>
    Public Property DrugAlergy() As String
    <DataMember()>
    Public Property PatType() As Integer
    <DataMember()>
    Public Property VipFlag() As Integer
    <DataMember()>
    Public Property Rmrk() As String
    <DataMember()>
    Public Property Mothtng() As String
    <DataMember()>
    Public Property KinAreaCd() As Integer 'anamika 20160714
    <DataMember()>
    Public Property KinLandmark() As String 'anamika 20160714
    <DataMember()>
    Public Property NRIContactPersonName() As String 'anamika 20160714
    <DataMember()>
    Public Property NRIContactPersonaddrs1() As String 'anamika 20160714
    <DataMember()>
    Public Property NRIContactPersonaddrs2() As String 'anamika 20160714
    <DataMember()>
    Public Property NRIContactPersoncity() As Integer 'anamika 20160714
    <DataMember()>
    Public Property NRIContactPersoncntry() As Integer 'anamika 20160714
    <DataMember()>
    Public Property NRIContactPersonpin() As String 'anamika 20160714
    <DataMember()>
    Public Property NRIContactPersonTeHome() As String 'anamika 20160714
    <DataMember()>
    Public Property NRIContactPersonTelWork() As String 'anamika 20160714
    <DataMember()>
    Public Property NRIContactPersonMobile() As String 'anamika 20160714
    <DataMember()>
    Public Property NRIContactPersonAreaCd() As Integer 'anamika 20160714
    <DataMember()>
    Public Property NRIContactPersonLandMark() As String 'anamika 20160714
    <DataMember()>
    Public Property NRIContactPersonState() As Integer  'Amol 2018-02-13
    <DataMember()>
    Public Property KinState() As Integer 'Amol 2018-02-13
End Class
