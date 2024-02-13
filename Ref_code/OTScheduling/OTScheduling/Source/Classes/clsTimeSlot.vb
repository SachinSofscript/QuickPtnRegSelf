Imports Microsoft.VisualBasic
Imports System.Drawing

Public Class clsSession
    Public starttime As Date
    Public endtime As Date
End Class

Public Class clsTimeSlot
    Inherits Button
    Public StartTime As Date
    Public EndTime As Date
    Public Noofslots As Long
    Public BookingID As Integer
    Public ApptDate As Date
    Public Doctor As String
    Public DoctorCd As Long
    Public PatName As String
    'Public PatCd As Integer
    Public PatCd As Long         'pragya : 02-DEC-2016   
    Public AptRmrks As String   'pragya : 02-nov-2016
    Public PtnType As String  '' Amol 2020-11-07 JSK001-147262	
End Class

Public Class clsTimeSlotLbl
    Inherits Label
    Public StartTime As Date
    Public EndTime As Date
    Public Noofslots As Long
    Public BookingID As Integer
    Public ApptDate As Date
    Public Doctor As String
    Public DoctorCd As Long
    Public PatName As String
    Public PatCd As Long         'pragya : 02-DEC-2016   
    Public AptRmrks As String   'pragya : 02-nov-2016
    Public PtnType As String  '' Amol 2020-11-07 JSK001-147262	
End Class
