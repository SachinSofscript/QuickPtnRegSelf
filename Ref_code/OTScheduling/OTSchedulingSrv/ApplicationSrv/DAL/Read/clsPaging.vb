Imports System.Runtime.Serialization

Public Class clsPaging

    <DataMember()>
    Public Property Value As String
    <DataMember()>
    Public Property Enabled As Boolean
    <DataMember()>
    Public Property Text As String



    Shared Function PopulatePager(ByRef strErrMsg As List(Of String), _
                                                      ByRef chrErrFlg As Char, _
                                                       ByVal recordCount As Integer, ByVal currentPage As Integer, ByVal DispNum As Integer, ByVal GridType As Char, ByVal Repeater As List(Of clsPaging), ByVal ItemCd As String, ByRef ReturnPageIndex As Integer, ByVal PageSize As Integer) As List(Of clsPaging)
        Try

            Dim dblPageCount As Double = CType((CType(recordCount, Decimal) / Decimal.Parse(PageSize)), Double)
            Dim pageCount As Integer = CType(Math.Ceiling(dblPageCount), Integer)

            Dim Arrlistpages As New List(Of clsPaging)
            Dim objpages As clsPaging
            Dim idx As Integer = 0
            Dim finalpagecount As Integer
            Dim Isenabled As Boolean
            If (pageCount < DispNum) Then
                finalpagecount = pageCount
            Else
                finalpagecount = DispNum
            End If

            If (currentPage = 1) Then
                If (pageCount > 0) Then
                    objpages = New clsPaging
                    objpages.Text = "<<"
                    objpages.Value = "777777777"
                    objpages.Enabled = True

                    Arrlistpages.Add(objpages)

                    If (currentPage > 1) Then
                        Isenabled = True
                    Else
                        Isenabled = False

                    End If


                    objpages = New clsPaging
                    objpages.Text = "<"
                    objpages.Value = "999999999"
                    objpages.Enabled = Isenabled
                    Arrlistpages.Add(objpages)

                    Dim i As Integer = 1
                    Do While (i <= finalpagecount)
                        objpages = New clsPaging
                        objpages.Text = i.ToString()
                        objpages.Value = i.ToString
                        objpages.Enabled = True
                        Arrlistpages.Add(objpages)
                        i = (i + 1)
                    Loop

                    currentPage = i - 1

                    If (currentPage < pageCount) Then
                        Isenabled = True

                    Else
                        Isenabled = False

                    End If


                    objpages = New clsPaging
                    objpages.Text = ">"
                    objpages.Value = "888888888"
                    objpages.Enabled = Isenabled
                    Arrlistpages.Add(objpages)



                    objpages = New clsPaging
                    objpages.Text = ">>"
                    objpages.Value = "666666666"
                    objpages.Enabled = True
                    Arrlistpages.Add(objpages)

                    ReturnPageIndex = 1

                End If

            Else

                If (pageCount > 0) Then
                    Dim idx2 As Integer

                    If (currentPage = 888888888) Then

                        If (Repeater.Count > 0) Then


                            For j As Integer = 0 To Repeater.Count - 1

                                idx = j

                                If (Repeater(j).Value = 888888888) Then
                                    Dim int As Integer = idx
                                    idx = int - 1
                                    idx = Repeater(idx).Value

                                    Exit For
                                End If
                            Next

                        



                            Dim i As Integer = 1


                            If (pageCount <> 0) Then
                                idx2 = idx + 1
                                i = idx + finalpagecount

                                If (i <= pageCount) Then

                                    objpages = New clsPaging
                                    objpages.Text = "<<"
                                    objpages.Value = "777777777"
                                    objpages.Enabled = True
                                    Arrlistpages.Add(objpages)

                                    If (currentPage > 1) Then

                                        Isenabled = True

                                    Else
                                        Isenabled = False


                                    End If


                                    objpages = New clsPaging
                                    objpages.Text = "<"
                                    objpages.Value = "999999999"
                                    objpages.Enabled = Isenabled
                                    Arrlistpages.Add(objpages)

                                    Do While (idx + 1 <= i)

                                        If ((idx + 1) <> currentPage) Then
                                            Isenabled = True
                                        Else
                                            Isenabled = False
                                        End If
                                        objpages = New clsPaging
                                        objpages.Text = (idx + 1).ToString
                                        objpages.Value = (idx + 1).ToString
                                        objpages.Enabled = Isenabled
                                        Arrlistpages.Add(objpages)


                                        idx = (idx + 1)
                                    Loop

                                Else
                                    objpages = New clsPaging
                                    objpages.Text = "<<"
                                    objpages.Value = "777777777"
                                    objpages.Enabled = True
                                    Arrlistpages.Add(objpages)

                                    If (currentPage > 1) Then
                                        Isenabled = True

                                    Else
                                        Isenabled = False


                                    End If
                                    objpages = New clsPaging
                                    objpages.Text = "<"
                                    objpages.Value = "999999999"
                                    objpages.Enabled = Isenabled
                                    Arrlistpages.Add(objpages)

                                    Do While (idx + 1 <= pageCount)

                                        If ((idx + 1) <> currentPage) Then
                                            Isenabled = True


                                        Else
                                            Isenabled = False

                                        End If

                                        objpages = New clsPaging
                                        objpages.Text = (idx + 1).ToString
                                        objpages.Value = (idx + 1).ToString
                                        objpages.Enabled = Isenabled
                                        Arrlistpages.Add(objpages)

                                        idx = (idx + 1)
                                    Loop

                                End If
                            End If

                        End If


                        If (Arrlistpages.Count <> 0) Then

                            If (pageCount - (idx) > 0) Then
                                Isenabled = True

                            Else
                                Isenabled = False

                            End If

                            objpages = New clsPaging
                            objpages.Text = ">"
                            objpages.Value = "888888888"
                            objpages.Enabled = Isenabled
                            Arrlistpages.Add(objpages)

                            objpages = New clsPaging
                            objpages.Text = ">>"
                            objpages.Value = "666666666"
                            objpages.Enabled = True
                            Arrlistpages.Add(objpages)

                            ReturnPageIndex = idx2
                        End If

                    ElseIf (currentPage = 999999999) Then


                        If (Repeater.Count > 0) Then


                            For j As Integer = 0 To Repeater.Count - 1

                                If (j = 2) Then
                                    idx = Repeater(j).Value
                                End If
                            Next


                            Dim i As Integer = 1

                            If (pageCount <> 0) Then


                                If (idx > 1) Then
                                    If (idx < finalpagecount) Then

                                        i = 1

                                        objpages = New clsPaging
                                        objpages.Text = "<<"
                                        objpages.Value = "777777777"
                                        objpages.Enabled = True
                                        Arrlistpages.Add(objpages)

                                        If (currentPage > 1) Then
                                            Isenabled = True
                                        Else
                                            Isenabled = False

                                        End If

                                        objpages = New clsPaging
                                        objpages.Text = "<"
                                        objpages.Value = "999999999"
                                        objpages.Enabled = Isenabled
                                        Arrlistpages.Add(objpages)

                                        Do While (i <= idx - 1)
                                            If ((i) <> currentPage) Then
                                                Isenabled = True
                                            Else
                                                Isenabled = False

                                            End If

                                            objpages = New clsPaging
                                            objpages.Text = (i).ToString
                                            objpages.Value = (i).ToString
                                            objpages.Enabled = Isenabled
                                            Arrlistpages.Add(objpages)

                                            i = i + 1
                                        Loop


                                        If (Arrlistpages.Count <> 0) Then

                                            If ((i - 1) + finalpagecount <= pageCount) Then
                                                Isenabled = True
                                            Else
                                                Isenabled = False

                                            End If

                                            objpages = New clsPaging
                                            objpages.Text = ">"
                                            objpages.Value = "888888888"
                                            objpages.Enabled = Isenabled
                                            Arrlistpages.Add(objpages)


                                            objpages = New clsPaging
                                            objpages.Text = ">>"
                                            objpages.Value = "666666666"
                                            objpages.Enabled = True
                                            Arrlistpages.Add(objpages)

                                            ReturnPageIndex = idx

                                        Else
                                            ReturnPageIndex = 1
                                            
                                        End If

                                    Else
                                        Dim i2 As Integer
                                        i = idx - finalpagecount

                                        If (i = 0 Or i < 0) Then
                                            i = 1
                                        End If

                                        i2 = i


                                        If (i + (finalpagecount - 1) <= pageCount) Then
                                            objpages = New clsPaging
                                            objpages.Text = "<<"
                                            objpages.Value = "777777777"
                                            objpages.Enabled = True
                                            Arrlistpages.Add(objpages)



                                            If (i2 = 1) Then
                                                objpages = New clsPaging
                                                objpages.Text = "<"
                                                objpages.Value = "999999999"
                                                objpages.Enabled = False
                                                Arrlistpages.Add(objpages)



                                            Else
                                                If (currentPage > 1) Then
                                                    Isenabled = True
                                                Else
                                                    Isenabled = False
                                                End If

                                                objpages = New clsPaging
                                                objpages.Text = "<"
                                                objpages.Value = "999999999"
                                                objpages.Enabled = Isenabled
                                                Arrlistpages.Add(objpages)

                                            End If

                                            Do While (i <= idx - 1)

                                                If ((i) <> currentPage) Then
                                                    Isenabled = True
                                                Else
                                                    Isenabled = False

                                                End If
                                                objpages = New clsPaging
                                                objpages.Text = (i).ToString
                                                objpages.Value = (i).ToString
                                                objpages.Enabled = Isenabled
                                                Arrlistpages.Add(objpages)


                                                i = i + 1
                                            Loop

                                        End If
                                        If (Arrlistpages.Count <> 0) Then
                                            objpages = New clsPaging
                                            objpages.Text = ">"
                                            objpages.Value = "888888888"
                                            objpages.Enabled = True
                                            Arrlistpages.Add(objpages)


                                            objpages = New clsPaging
                                            objpages.Text = ">>"
                                            objpages.Value = "666666666"
                                            objpages.Enabled = True
                                            Arrlistpages.Add(objpages)

                                            ReturnPageIndex = i2

                                        Else
                                            ReturnPageIndex = 1
                                         
                                        End If

                                    End If

                                Else
                                    If (idx = 1) Then  'new added
                                        If (pageCount > 0) Then
                                            objpages = New clsPaging
                                            objpages.Text = "<<"
                                            objpages.Value = "777777777"
                                            objpages.Enabled = True

                                            Arrlistpages.Add(objpages)

                                            If (currentPage > 1) Then
                                                Isenabled = True
                                            Else
                                                Isenabled = False

                                            End If


                                            objpages = New clsPaging
                                            objpages.Text = "<"
                                            objpages.Value = "999999999"
                                            objpages.Enabled = Isenabled
                                            Arrlistpages.Add(objpages)

                                            Dim ik As Integer = 1
                                            Do While (ik <= finalpagecount)
                                                objpages = New clsPaging
                                                objpages.Text = ik.ToString()
                                                objpages.Value = ik.ToString
                                                objpages.Enabled = True
                                                Arrlistpages.Add(objpages)
                                                ik = (ik + 1)
                                            Loop

                                            currentPage = ik - 1

                                            If (currentPage < pageCount) Then
                                                Isenabled = True

                                            Else
                                                Isenabled = False

                                            End If


                                            objpages = New clsPaging
                                            objpages.Text = ">"
                                            objpages.Value = "888888888"
                                            objpages.Enabled = Isenabled
                                            Arrlistpages.Add(objpages)



                                            objpages = New clsPaging
                                            objpages.Text = ">>"
                                            objpages.Value = "666666666"
                                            objpages.Enabled = True
                                            Arrlistpages.Add(objpages)

                                            ReturnPageIndex = 1

                                        End If
                                    End If
                                End If




                            End If
                        End If

                    ElseIf currentPage = 777777777 Then

                        Dim i As Integer = 1

                        If (i + (finalpagecount - 1) <= pageCount) Then
                            objpages = New clsPaging
                            objpages.Text = "<<"
                            objpages.Value = "777777777"
                            objpages.Enabled = True
                            Arrlistpages.Add(objpages)

                            objpages = New clsPaging
                            objpages.Text = "<"
                            objpages.Value = "999999999"
                            objpages.Enabled = False
                            Arrlistpages.Add(objpages)


                            Do While (i <= finalpagecount)
                                If ((i) <> currentPage) Then
                                    Isenabled = True
                                Else
                                    Isenabled = False
                                End If

                                objpages = New clsPaging
                                objpages.Text = (i).ToString
                                objpages.Value = (i).ToString
                                objpages.Enabled = Isenabled
                                Arrlistpages.Add(objpages)


                                i = i + 1
                            Loop

                        End If
                        If (Arrlistpages.Count <> 0) Then

                            If (i <= pageCount) Then
                                Isenabled = True
                            Else
                                Isenabled = False
                            End If
                            objpages = New clsPaging
                            objpages.Text = ">"
                            objpages.Value = "888888888"
                            objpages.Enabled = Isenabled
                            Arrlistpages.Add(objpages)


                            objpages = New clsPaging
                            objpages.Text = ">>"
                            objpages.Value = "666666666"
                            objpages.Enabled = True
                            Arrlistpages.Add(objpages)


                        End If

                        If (Arrlistpages IsNot Nothing) Then
                            ReturnPageIndex = Arrlistpages(2).Value
                        Else
                            ReturnPageIndex = 1
                        End If
                        
                    ElseIf currentPage = 666666666 Then

                        Dim i As Integer = 1
                        Dim i2 As Integer
                        i = pageCount - (finalpagecount - 1)

                        If (i = 0 Or i < 0) Then
                            i = 1
                        End If

                        i2 = i
                        If (i <= pageCount) Then
                            objpages = New clsPaging
                            objpages.Text = "<<"
                            objpages.Value = "777777777"
                            objpages.Enabled = True
                            Arrlistpages.Add(objpages)

                            If (currentPage > 1) Then
                                Isenabled = True
                            Else
                                Isenabled = False
                            End If

                            objpages = New clsPaging
                            objpages.Text = "<"
                            objpages.Value = "999999999"
                            objpages.Enabled = Isenabled
                            Arrlistpages.Add(objpages)



                            Do While ((i) <= pageCount)

                                If ((i) <> currentPage) Then
                                    Isenabled = True
                                Else
                                    Isenabled = False
                                End If


                                objpages = New clsPaging
                                objpages.Text = (i).ToString
                                objpages.Value = (i).ToString
                                objpages.Enabled = Isenabled
                                Arrlistpages.Add(objpages)


                                i = i + 1
                            Loop

                        End If
                        If (Arrlistpages.Count <> 0) Then

                            If (i + finalpagecount <= pageCount) Then
                                Isenabled = True
                            Else
                                Isenabled = False
                            End If

                            objpages = New clsPaging
                            objpages.Text = ">"
                            objpages.Value = "888888888"
                            objpages.Enabled = Isenabled
                            Arrlistpages.Add(objpages)


                            objpages = New clsPaging
                            objpages.Text = ">>"
                            objpages.Value = "666666666"
                            objpages.Enabled = True
                            Arrlistpages.Add(objpages)


                        End If

                        ReturnPageIndex = i2


                    Else
                        ReturnPageIndex = currentPage
                        Arrlistpages = Repeater
                    End If


                Else

                End If

            End If
            PopulatePager = Arrlistpages
            Return PopulatePager
        Catch ex As Exception
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
            Return Nothing
        End Try

    End Function
End Class
