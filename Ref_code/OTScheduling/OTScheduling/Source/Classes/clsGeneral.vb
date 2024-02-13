Imports Microsoft.VisualBasic
Imports OTScheduling.CmnSecurityFunSrvRef

Public Class clsGeneral
    Public Shared userid As String = ""
    Public Shared companycode As String = ""
    Public Shared div As Integer = 0
    Public Shared loc As Integer = 0
    Public Shared commonfuncproxy As iCmnSecurityFunClient
    Public Shared SecurityProxy As iCmnSecurityFunClient

    Shared Function GetRevenueDateDL(ByVal strErrMsg As List(Of String), ByVal chrErrFlg As Char, ByVal cocd As String, ByVal divcd As Integer, ByVal loccd As Integer) As Date
        Try
            commonfuncproxy = New iCmnSecurityFunClient() 'instantiate Proxy
            Dim serverdttm As Date = commonfuncproxy.GetRevenueDateDL(strErrMsg, chrErrFlg, cocd, divcd, loccd) 'call functions
            commonfuncproxy.Close() '--close proxy
            GetRevenueDateDL = serverdttm
        Catch ex As Exception
            commonfuncproxy.Abort()
            Return Nothing
        Finally
            commonfuncproxy.Close()
        End Try
    End Function

    Shared Sub CheckSession(ByVal Context As HttpContext, ByVal sessionID As Object)
        If sessionID = Nothing Then
            Dim LoginPath As String = ConfigurationManager.AppSettings("LoginPath")
            'strScript = "<script>"
            'strScript = strScript & "parent.location.href('" + LoginPath + "')"
            'strScript = strScript & "</script>"
            'Context.Response.Write(strScript)
            Context.Response.Redirect(LoginPath)
        End If
    End Sub

    Public Shared Sub SetDefaultSessionValue(ByVal ModCd As HiddenField, ByVal SubModCd As HiddenField, ByVal ValModCd As Integer, ByVal ValSubModCd As Integer)
        ModCd.Value = ValModCd
        SubModCd.Value = ValSubModCd
    End Sub


    Shared Sub SetValues(ByVal reqString As String)
        Dim strArray() As String = Split(reqString, ";")
        UserId = strArray(0)
        companycode = strArray(1)
        div = strArray(2)
        loc = strArray(3)

    End Sub

    Shared Function singleQuote(ByVal Message As String) As String
        Dim tmpStr As String
        tmpStr = ""
        If (Message.Contains("'")) Then
            Dim str As String()
            str = Message.Split("'")
            For i As Integer = 0 To str.Length - 1
                tmpStr = tmpStr + str(i) + "\'"
            Next
            Message = tmpStr.Substring(0, tmpStr.Length - 2)
        End If
        Return Message
    End Function

    Public Shared Sub GetPopup(ByVal popupWindowPage As String,
                              ByVal Height As Short,
                              ByVal width As Short,
                              ByVal txtCodeFld As String,
                              ByVal txtDescFld As String,
                              ByRef tmpPage As System.Web.UI.Page)
        Dim Script As String = ""
        Dim ParentLoadScript As String = ""




        Script += "<script type=""text/javascript"" language=""javascript"" id='PopupWindow'> "
        'Script += "Function OpenPOPUp(){ "
        'Script += "try{ "
        Script += "window.open('" + popupWindowPage + "','','width=" & width & ",height=" & Height & ",resizable=yes'); "
        'Script += "return false; "
        'Script += "} "
        'Script += "catch(err){ "
        'Script += "window.status = err.message; "
        'Script += "}"
        'Script += "}"
        Script += "</script>"

        'ParentLoadScript += "<script type=""text/javascript"" language=""javascript"" id='ParentLoad'> "
        'ParentLoadScript += "function funAddInvite(Code,Desc){ "
        'ParentLoadScript += "var newElem1 = document.getElementById(""<%= " & txtCodeFld & ".clientID %>""); "
        'ParentLoadScript += "newElem1.value = Code; "
        'ParentLoadScript += "var newElem2 = document.getElementById(""<%= " & txtDescFld & ".clientID %>""); "
        'ParentLoadScript += "newElem2.value = Desc; "
        'ParentLoadScript += "return false; } "
        'ParentLoadScript += "</script>"

        tmpPage.RegisterClientScriptBlock("PopupWindow", Script)
        'tmpPage.RegisterClientScriptBlock("ParentLoad", ParentLoadScript)

    End Sub
    'anamika 12032013
    Public Shared Sub ExitChildPopup(ByVal dataC As String, ByVal dataD As String, ByVal txtCodeFld As String, ByVal txtDescFld As String, ByRef myPage As Web.UI.Page)
        Dim Script As String
        Script = "<script language='javascript' id='ExitChildPopup'> "
        Script = Script + "window.opener.funAddValues('" + dataC + "','" + dataD + "','" + txtCodeFld + "','" + txtDescFld + "'); "
        'Script = Script + "window.opener.funAddInvite('" + dataC + "','" + dataD + "'); "

        Script = Script + "window.close(); "

        Script = Script + "</script> "

        myPage.RegisterClientScriptBlock("ExitChildPopup", Script)

        'Script += "<script language=JavaScript id='test1'>"
        'Script += "window.opener.addOption('" + dataC + "','" + dataD + "'); "
        'Script += "self.close();"
        'Script += "</script>"
        'myPage.RegisterClientScriptBlock("ExitChildPopup", Script)
    End Sub
    ' 12032013
    ' 12032013
    'Public Shared Sub ShowErrorPopUp(ByVal ErrMsg As String, ByVal id As String, ByRef myPage As Web.UI.Page)
    '    ErrMsg = Regex.Replace(ErrMsg, "[^0-9a-zA-Z]+", " ")
    '    If (id = "") Then
    '        ScriptManager.RegisterClientScriptBlock(myPage, myPage.GetType(), Guid.NewGuid().ToString(), "alertify.alert('" & ErrMsg & "');", True)
    '    Else
    '        ScriptManager.RegisterClientScriptBlock(myPage, myPage.GetType(), Guid.NewGuid().ToString(), "setfocus('" & ErrMsg & "','" & id & "');", True)
    '    End If
    'End Sub


    Public Shared Sub ShowErrorPopUp(ByVal ErrMsg As String, ByVal id As String, ByRef myPage As Web.UI.Page, Optional ByVal UseNotification As Boolean = False, Optional ByVal NotificationType As Char = "")
        ErrMsg = Regex.Replace(ErrMsg, "[^0-9a-zA-Z]+", " ")

        If UseNotification Then 'Rushikesh 20200218
            If NotificationType = "S" Then
                ScriptManager.RegisterClientScriptBlock(myPage, myPage.GetType(), Guid.NewGuid().ToString(), "alertify.success('" & ErrMsg & "');", True)
            Else
                ScriptManager.RegisterClientScriptBlock(myPage, myPage.GetType(), Guid.NewGuid().ToString(), "alertify.error('" & ErrMsg & "');", True)
            End If
            Return
        End If
        If (id = "") Then
            ScriptManager.RegisterClientScriptBlock(myPage, myPage.GetType(), Guid.NewGuid().ToString(), "alertify.alert('" & ErrMsg & "');", True)
        Else
            ScriptManager.RegisterClientScriptBlock(myPage, myPage.GetType(), Guid.NewGuid().ToString(), "setfocus('" & ErrMsg & "','" & id & "');", True)
        End If
    End Sub

    Public Shared Sub ShowSweetalert(ByVal ErrMsg As String, ByVal id As String, ByRef myPage As Web.UI.Page, Optional isNotification As Boolean = False, Optional isError As Boolean = False)
        'ErrMsg = Regex.Replace(ErrMsg, "[^0-9a-zA-Z]+", " ")
        If isNotification Then
            If isError Then
                ScriptManager.RegisterClientScriptBlock(myPage, myPage.GetType(), Guid.NewGuid().ToString(), "swal('" & ErrMsg & "','','error');", True)
            Else
                ScriptManager.RegisterClientScriptBlock(myPage, myPage.GetType(), Guid.NewGuid().ToString(), "swal('" & ErrMsg & "','','success');", True)
            End If

        ElseIf (id = "") Then
            ScriptManager.RegisterClientScriptBlock(myPage, myPage.GetType(), Guid.NewGuid().ToString(), "alertify.alert('" & ErrMsg & "');", True)
        Else
            ScriptManager.RegisterClientScriptBlock(myPage, myPage.GetType(), Guid.NewGuid().ToString(), "setfocus('" & ErrMsg & "','" & id & "');", True)
        End If
    End Sub


    Public Shared Function ConvertToDecimal(ByVal value As String) As String
        ConvertToDecimal = Format(Conversion.Val(value), "0.00")
        Return ConvertToDecimal
    End Function
    Public Shared Function ChkSysLock(ByRef strErrMsg As List(Of String),
                                      ByRef chrErrFlg As Char,
                                      ByVal pcompanycode As String, ByVal pdiv As Integer, ByVal ploc As Integer) As Boolean
        ChkSysLock = False

        Try
            commonfuncproxy = New iCmnSecurityFunClient
            ChkSysLock = commonfuncproxy.ChkSysLock(strErrMsg, chrErrFlg, pcompanycode, pdiv, ploc)
        Catch ex As Exception
            commonfuncproxy.Abort()
        Finally
            commonfuncproxy.Close()
            If chrErrFlg = "Y" And strErrMsg.ToArray.Count <> 1 Then
                strErrMsg.AddRange(strErrMsg.ToArray)
                chrErrFlg = "Y"
            End If

        End Try

        Return ChkSysLock
    End Function
    Shared Function getdate() As Date
        Try
            commonfuncproxy = New iCmnSecurityFunClient() 'instantiate Proxy
            Dim serverdttm As Date = commonfuncproxy.GetServerDateTime() 'call functions
            commonfuncproxy.Close() '--close proxy
            getdate = serverdttm

        Catch ex As Exception
            commonfuncproxy.Abort()
            Return Nothing
        Finally
            commonfuncproxy.Close()
        End Try
    End Function

    Public Shared Sub FillDropDownList(ByVal ddl As DropDownList, ByVal Decode As String, ByVal Code As String, ByVal obj As Object, ByVal flag As Integer, Optional ByVal FlagValue As String = "")
        ddl.DataSource = Nothing
        ddl.DataBind()
        ddl.DataSource = obj
        ddl.DataTextField = Decode
        ddl.DataValueField = Code
        ddl.DataBind()
        If (flag = 1) Then
            AddDefField(ddl, FlagValue)
        End If
    End Sub
    Public Shared Sub AddDefField(ByVal ddl As DropDownList, ByVal FlagValue As String)
        ddl.Items.Add(FlagValue)
        ddl.DataMember = FlagValue
        ddl.DataValueField = FlagValue
        ddl.SelectedValue = FlagValue
    End Sub

    Public Shared Function UserRights(ByRef strErrMsg As List(Of String), _
                                                          ByRef chrErrFlg As Char, _
                                                          ByVal Cocd As String, _
                                                          ByVal div As Integer, _
                                                          ByVal loc As Integer, _
                                                          ByVal UserId As String, _
                                                             ByVal ModCd As Integer, ByVal SubModCd As Integer
                                                         ) As String
        UserRights = ""
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            SecurityProxy = New iCmnSecurityFunClient
            UserRights = SecurityProxy.UserRights(tmpstrErrMsg, chrErrFlg, Cocd, div, loc, UserId, ModCd, SubModCd)
        Catch ex As Exception
            SecurityProxy.Abort()
        Finally
            SecurityProxy.Close()
            If chrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(strErrMsg)
                chrErrFlg = "Y"
            End If
        End Try

        Return UserRights
    End Function


#Region "Error Msg"


    Public Shared Function GetmsgmstList(ByRef strErrMsg As List(Of String), _
                                                       ByRef chrErrFlg As Char, ByVal cocd As String, ByVal div As Integer, ByVal loc As Integer, ByVal modcd As Integer,
                                   ByVal submodcd As Integer) As List(Of clsMsgMst)
        GetmsgmstList = Nothing
        Dim tmpstrErrMsg As New List(Of String)
        Dim tmpchrErrFlg As Char = "N"
        Try
            commonfuncproxy = New iCmnSecurityFunClient()
            GetmsgmstList = commonfuncproxy.GetmsgmstList(tmpstrErrMsg, tmpchrErrFlg, cocd, div, loc, modcd, submodcd)
        Catch ex As Exception
            commonfuncproxy.Abort()
            strErrMsg.Add(ex.Message)
            chrErrFlg = "Y"
        Finally
            commonfuncproxy.Close()
            If tmpchrErrFlg = "Y" And tmpstrErrMsg.Count > 0 Then
                strErrMsg.AddRange(tmpstrErrMsg)
                chrErrFlg = "Y"
            End If
        End Try
        Return GetmsgmstList

    End Function

    Public Shared Function ReturnErrorMsg(ByVal objMsgMst As List(Of clsMsgMst), ByVal SrNo As Integer) As String 'anamika 20151208

        ReturnErrorMsg = ""
        Try


            If objMsgMst IsNot Nothing Then

                Dim x = From obj In objMsgMst Where obj.MsgSrno = SrNo Select obj
                If x.Any Then
                    ReturnErrorMsg = x(0).MsgDesc.Trim.ToString
                End If

            End If
        Catch ex As Exception

        Finally
            objMsgMst = Nothing
        End Try
        Return ReturnErrorMsg
    End Function
#End Region


    Public Shared Sub ShowConsoleTrack(ByVal ErrMsg As String, ByVal id As String, ByRef myPage As Web.UI.Page)
        Try

            ScriptManager.RegisterClientScriptBlock(myPage, myPage.GetType(), Guid.NewGuid().ToString(), "console.log('" & ErrMsg & "');", True)

        Catch ex As Exception

        End Try

    End Sub

End Class
