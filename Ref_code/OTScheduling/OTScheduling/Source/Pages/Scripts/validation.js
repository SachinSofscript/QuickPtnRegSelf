/*  ValidateAlpha has been used for Bank fields only
Keys 65-90 = CAPITAL alphabets, 97-122 =small alphabets, 45=(-/_), 32=space, 46=dot(.). 
*/
function ValidateAlpha(sender) {
    if (((event.keyCode >= 65) && (event.keyCode <= 90)) || ((event.keyCode >= 97) && (event.keyCode <= 122)) || (event.keyCode == 45) || (event.keyCode == 32) || (event.keyCode == 46)) {
        event.returnValue = true;
    }
    else {
        //alert("Enter only letters");
        event.returnValue = true; //updated by anamika  on 20150706(need to change patient help code till that dont change this
        //  sender.focus();
        //sender.value = "";
    }
}

/*ValidateOnlyAlpha used for name fields
Keys 65-90 = CAPITAL alphabets, 97-122 =small alphabets, 32=space
*/
function ValidateOnlyAlpha(sender) {
    if (((event.keyCode >= 65) && (event.keyCode <= 90)) || ((event.keyCode >= 97) && (event.keyCode <= 122)) || (event.keyCode == 32)) {
        event.returnValue = true;
    }
    else {
        alert("Enter only letters");
        event.returnValue = false;
        sender.focus();
    }
}

function ValidateNum(sender) {

    if (((event.keyCode < 48) || (event.keyCode > 57))) {

        event.returnValue = false;
        sender.focus();
    }
    if (event.keyCode == 13)
        event.returnValue = true;
}

function ValidateNumWithNegativeDeci(sender) {


    if ((event.keyCode < 48) || (event.keyCode > 57)) {
        event.returnValue = false;
        sender.focus();
    }
    if ((event.keyCode == 13) || (event.keyCode == 46) || (event.keyCode == 151) || (event.keyCode == 45)) {
        event.returnValue = true;
    }
}

function ValidateNumWithDeci(sender) {


    if ((event.keyCode < 48) || (event.keyCode > 57)) {
        event.returnValue = false;
        sender.focus();
    }
    if ((event.keyCode == 13) || (event.keyCode == 46)) {
        event.returnValue = true;
    }
}

function ValidateDt(sender) {

    if ((event.keyCode < 48) || (event.keyCode > 57)) {
        event.returnValue = false;
        sender.focus();
    }
    if ((event.keyCode == 13) || (event.keyCode == 47)) {
        event.returnValue = true;
    }
}


function ValidateTm(sender) {

    if ((event.keyCode < 48) || (event.keyCode > 57)) {
        event.returnValue = false;
        sender.focus();
    }
    if ((event.keyCode == 13) || (event.keyCode == 58)) {
        event.returnValue = true;
    }
}

function lastDigits(sender) {
    if ((event.keyCode < 48) || (event.keyCode > 57)) {
        event.returnValue = false;
    }
}


function percentage(obj) {
    var digits = obj.value;
    var beforeDeci = digits.split('.')[0];
    var afterDeci = digits.split('.')[1];

    if (beforeDeci == "" || isNaN(beforeDeci) || parseInt(beforeDeci) > 100 || ((beforeDeci.length) > 2)) {
        alert("Invalid");
        obj.focus();
        return false;
    }
    else if (parseInt(beforeDeci) == 0)
        beforeDeci = "00";
    else if (beforeDeci < 10 && (beforeDeci.length == 1))
        beforeDeci = "0" + beforeDeci;

    if (afterDeci == "" || isNaN(afterDeci) || parseInt(afterDeci) > 100 || ((afterDeci.length) > 2)) {
        alert("Invalid");
        obj.focus();
        return false;
    }
    else if (parseInt(afterDeci) == 0)
        afterDeci = "00";
    else if (afterDeci < 10 && (afterDeci.length == 1))
        afterDeci = "0" + afterDeci;

    obj.value = beforeDeci + "." + afterDeci;
    return true;
}

function handleEnter(field, event) {
    var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
    if (keyCode == 13) {
        var i;
        for (i = 0; i < field.form.elements.length; i++)
            if (field == field.form.elements[i])
                break;
        i = (i + 1) % field.form.elements.length;
        field.form.elements[i].focus();
        return false;
    }
    else
        return true;
}

var id1;

function setfocus(msg, id) {
    //alert('ss');
    id1 = id;
    alertify.alert(msg, setfocus1, "");
    return false;
}

//function setfocus1() {
//    document.getElementById("ContentPlaceHolder1_" + id1 + "").focus();
//}

function setfocus1() {


    var address = document.getElementById("ContentPlaceHolder1_" + id1 + "")
    if (address == null) {
        document.getElementById(id1).focus();
        document.getElementById(id1).select();
    }
    else {
        document.getElementById("ContentPlaceHolder1_" + id1 + "").focus();
        document.getElementById("ContentPlaceHolder1_" + id1 + "").select();
    }
}

//commented by anamika on 20150713
//function validate_email(email) {
//    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
//    var address = document.getElementById("ContentPlaceHolder1_" + email + "").value;

//    if (reg.test(address) == false) {
//        document.getElementById("ContentPlaceHolder1_" + email + "").value = "";
//        setfocus('Invalid Email Address', email);
//        return false;
//    }
//}


function validate_email(email) {
    //var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    var reg = /^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$/;    //RasikV 20170106
    var address = document.getElementById("ContentPlaceHolder1_" + email + "")
    if (address == null) {
        var address = document.getElementById(email)
    }
    else {
        var address = document.getElementById("ContentPlaceHolder1_" + email + "")
    }

    if (reg.test(address.value) == false) {
        address.value = "";
        setfocus('Invalid Email Address', email);
        return false;
    }
}

function validateTime(time) {
    var d = new Date();
    var hrs = d.getHours();
    var min = d.getMinutes();

    if ((min < 10) || ((min.length) < 2)) {
        min = "0" + min;
    }

    if ((hrs < 10) || ((hrs.length) < 2)) {
        hrs = "0" + hrs;

    }
    var t = document.getElementById("ContentPlaceHolder1_" + time + "").value; // document.getElementById("<%=txtAdmissionTm.ClientID%>").value;
    if (t.length == 0) {
        // alertify.alert("Enter Valid Time");
        setfocus('Enter Valid Time', time);
    }
    if (t.length > 5) {
        //alertify.alert("Invalid Time Format");
        var tm = hrs + ":" + min;
        //    document.getElementById("<%=txtAdmissionTm.ClientID%>").value = tm;
        document.getElementById("ContentPlaceHolder1_" + time + "").value = tm;
        setfocus('Invalid Time Format', time);
        return false;
    }

    var t2 = t.split(':')[0];
    var t3 = t.split(':')[1];

    if (t2.length == 1)
        t2 = "0" + t2;

    if (t2.length != 2) {
        //        alertify.alert("Invalid Time Format");
        var tm = hrs + ":" + min;
        // document.getElementById("<%=txtAdmissionTm.ClientID%>").value = tm;
        document.getElementById("ContentPlaceHolder1_" + time + "").value = tm;
        setfocus('Invalid Time Format', time);
        return false;
    }

    if (t3.length == 1)
        t3 = "0" + t3;
    var temp = t2 + t3;

    //alert(temp);
    var timeValue = "0000" + temp;
    //alert(timeValue + "   timeValue");


    if (timeValue == "") {
        var tm = hrs + ":" + min;
        //    document.getElementById("<%=txtAdmissionTm.ClientID%>").value = tm;
        document.getElementById("ContentPlaceHolder1_" + time + "").value = tm;
        //        alertify.alert("Invalid Time format");
        setfocus('Invalid Time Format', time);
        return false;
    }
    else {
        var len = timeValue.length;
        var h1 = timeValue.substr((len - 4), (len - 2));
        var sHours = h1.substr(0, 2);
        //alert(sHours + " hrs");
        var sMinutes = timeValue.substr((len - 2), len);
        //alert(sMinutes + " mins");


        if (sHours == "" || isNaN(sHours) || parseInt(sHours) > 23 || ((sHours.length) > 2)) {
            var tm = hrs + ":" + min;
            // document.getElementById("<%=txtAdmissionTm.ClientID%>").value = tm;
            document.getElementById("ContentPlaceHolder1_" + time + "").value = tm;
            //            alertify.alert("Invalid Time format");
            setfocus('Invalid Time Format', time);
            return false;
        }
        else if (parseInt(sHours) == 0)
            sHours = "00";
        else if ((sHours < 10) && ((sHours.length) < 2))
            sHours = "0" + sHours;

        if (sMinutes == "" || isNaN(sMinutes) || parseInt(sMinutes) > 59 || ((sMinutes.length) > 2)) {

            var tm = hrs + ":" + min;
            // document.getElementById("<%=txtAdmissionTm.ClientID%>").value = tm;
            document.getElementById("ContentPlaceHolder1_" + time + "").value = tm;
            //            alertify.alert("Invalid Time format");
            setfocus('Invalid Time Format', time);
            return false;
        }
        else if (parseInt(sMinutes) == 0)
            sMinutes = "00";
        else if ((sMinutes < 10) && ((sMinutes.length) < 2))
            sMinutes = "0" + sMinutes;

        var tm = sHours + ":" + sMinutes;
        //document.getElementById("<%=txtAdmissionTm.ClientID%>").value = tm;
        document.getElementById("ContentPlaceHolder1_" + time + "").value = tm;
    }

    return true;
}




function CheckMaxLength(textBox, maxLength) {
    if (document.getElementById("ContentPlaceHolder1_" + textBox + "").value.length > maxLength) {
        //alertify.alert("Max characters allowed are " + maxLength);
        document.getElementById("ContentPlaceHolder1_" + textBox + "").value = document.getElementById("ContentPlaceHolder1_" + textBox + "").value.substr(0, maxLength);
        setfocus("Max characters allowed are " + maxLength, textBox);
    }
}




$(document).ready(function () {

    if ($('#ContentPlaceHolder1_btnback').length) {
        $("#ContentPlaceHolder1_btnback").click(function () {

            return setsession();
        });
    }


    if ($('#ContentPlaceHolder1_btnBack').length) {
        $("#ContentPlaceHolder1_btnBack").click(function () {

            return setsession();
        });
    }


    if ($('#ContentPlaceHolder1_btnexit').length) {
        $("#ContentPlaceHolder1_btnexit").click(function () {

            return setsession();
        });
    }


    if ($('#ContentPlaceHolder1_brnexit').length) {
        $("#ContentPlaceHolder1_brnexit").click(function () {

            return setsession();
        });
    }


    if ($('#ContentPlaceHolder1_btnExit').length) {
        $("#ContentPlaceHolder1_btnExit").click(function () {

            return setsession();
        });
    }







});




function setsession() {
    //alert();
    sessionStorage.setItem('forcelogout', 1);
    return true;
}

function HelpImg(e, me, cntrl, RequestTyp, StylesheetType, formName, extra) {
    var AppSubMdCd = document.getElementById("ContentPlaceHolder1_HfAppMdCd").value
    var AppMdCd = document.getElementById("ContentPlaceHolder1_HfAppMdCd").value
    evt = e || window.event;
   // if (evt.keyCode == 113 || evt.keyCode == 0 || evt.keyCode == undefined) {
        HelpDetails(e, me, cntrl, RequestTyp, StylesheetType, formName, extra)
    //}
}

function Help(e, me, cntrl, RequestTyp, StylesheetType, formName, extra) {
    var AppSubMdCd = document.getElementById("ContentPlaceHolder1_HfAppMdCd").value
    var AppMdCd = document.getElementById("ContentPlaceHolder1_HfAppMdCd").value
    evt = e || window.event;
    if (evt.keyCode == 113 || evt.keyCode == 0 ) {
 //       if (evt.keyCode == 113 || evt.keyCode == 0 || evt.keyCode == undefined) {
        HelpDetails(e, me, cntrl, RequestTyp, StylesheetType, formName, extra)
    }
}

function HelpDetails(e, me, cntrl, RequestTyp, StylesheetType, formName, extra) {
    var finalsettings = callsettings(StylesheetType);
    var url = formName + "?frmname=" + RequestTyp + " + &control=" + cntrl;
    window.open(url, "ModalPopUp", finalsettings);
}

function HelpWithParamImg(e, me, cntrl, RequestTyp, StylesheetType, formName, extra) {
    var AppSubMdCd = document.getElementById("ContentPlaceHolder1_HfAppSubMdCd").value;
    var AppMdCd = document.getElementById("ContentPlaceHolder1_HfAppMdCd").value;
    evt = e || window.event;
 //   if (evt.keyCode == 113 || evt.keyCode == 0 || evt.keyCode == undefined) {
        HelpDetailsWithParam(e, me, cntrl, RequestTyp, StylesheetType, formName, extra)
   // }
}

function HelpWithParam(e, me, cntrl, RequestTyp, StylesheetType, formName, extra) {
    var AppSubMdCd = document.getElementById("ContentPlaceHolder1_HfAppSubMdCd").value;
    var AppMdCd = document.getElementById("ContentPlaceHolder1_HfAppMdCd").value;
    evt = e || window.event;
    if (evt.keyCode == 113 || evt.keyCode == 0 ) {
    //if (evt.keyCode == 113 || evt.keyCode == 0 || evt.keyCode == undefined) {
        HelpDetailsWithParam(e, me, cntrl, RequestTyp, StylesheetType, formName, extra)
    }
}

function HelpDetailsWithParam(e, me, cntrl, RequestTyp, StylesheetType, formName, extra) {
    var finalsettings = callsettings(StylesheetType);
    var url = formName + "&frmname=" + RequestTyp + " + &control=" + cntrl;
    window.open(url, "ModalPopUp", finalsettings);
}




function ReturnValues(MyArgs, RequestTyp, cntrl, action) {
    if (MyArgs == '') {
        window.opener.ButtonClick(cntrl);
    }
    else {
        window.opener.SetReturnValue(MyArgs, RequestTyp, cntrl, action);
    }

    window.close();
}

function SetReturnValue(MyArgs, RequestTyp, cntrl, action)
{

 
    cntrl = cntrl.value.replace(/^\s+|\s+$/g, '');
    var ArrayCntrl = cntrl.split(',');
    var IsButtonPresent = 'false';
    var IsNameWithContentName = 'false';

    //find out name with content name or not 
    var x = document.getElementById("ContentPlaceHolder1_" + ArrayCntrl[0] + "");
    if (x == null) {
        IsNameWithContentName = 'false';
    }
    else {
        IsNameWithContentName = 'true';
    }


    for (i = 0; i <= ArrayCntrl.length - 1 ; i++) {
        var x = document.getElementById("ContentPlaceHolder1_" + ArrayCntrl[i] + "");


        if (x == null) {

            var x = document.getElementById(ArrayCntrl[i]);
            //  alert(x);
            if (document.getElementById(ArrayCntrl[i]).type == 'submit') {
                document.getElementById(ArrayCntrl[i]).click();
                IsButtonPresent = 'true';
            }
            else {
                document.getElementById(ArrayCntrl[i]).value = MyArgs[i];
            }
        }
        else {
            if (document.getElementById("ContentPlaceHolder1_" + ArrayCntrl[i] + "").type == 'submit') {
                document.getElementById("ContentPlaceHolder1_" + ArrayCntrl[i] + "").click();
                IsButtonPresent = 'true';
            }
            else {
                document.getElementById("ContentPlaceHolder1_" + ArrayCntrl[i] + "").value = MyArgs[i];


            }
        }



    }

    if (action != 'NP') {
        if (IsButtonPresent == 'false') {

            if (IsNameWithContentName == 'false') {
                __doPostBack(ArrayCntrl[0]);
            }
            else {
                __doPostBack("ContentPlaceHolder1_" + ArrayCntrl[0] + "");
            }


        }
    }

}








function ButtonClick(cntrl) {
    cntrl = cntrl.value.replace(/^\s+|\s+$/g, '');
    var ArrayCntrl = cntrl.split(',');
    for (i = 0; i <= ArrayCntrl.length - 1 ; i++) {
        document.getElementById("ContentPlaceHolder1_" + ArrayCntrl[i] + "").click();
    }

}
function callsettings(no) {
    var settings;
    //  alert();
    if (no == '1') {
        settings = "toolbar=no," + "scrollbars=no," + "location=no," + "statusbar=no," + "menubar=no," + "resizable=0," + "width=660," + "height=565," + "left =15," + "top=95"
        return settings;
    }
    if (no == '2') {
        settings = "toolbar=no," + "scrollbars=no," + "location=no," + "statusbar=no," + "menubar=no," + "resizable=0," + "width=1035," + "height=523," + "left =15," + "top=95"
        return settings;
    }
    if (no == '3') {
        settings = "toolbar=no," + "scrollbars=no," + "location=no," + "statusbar=no," + "menubar=no," + "resizable=0," + "width=1325," + "height=568," + "left =15," + "top=95"
        return settings;
    }
    if (no == '4') {
        settings = "toolbar=no," + "scrollbars=no," + "location=no," + "statusbar=no," + "menubar=no," + "resizable=0," + "width=1000," + "height=450," + "left =250," + "top=100"
        return settings;
    }
    if (no == '5') {
        settings = "toolbar=no," + "scrollbars=no," + "location=no," + "statusbar=no," + "menubar=no," + "resizable=0," + "width=414," + "height=474," + "left =50," + "top=100"
        return settings;
    }

    if (no == '6') {
        settings = "toolbar=no," + "scrollbars=no," + "location=no," + "statusbar=no," + "menubar=no," + "resizable=0," + "width=1340," + "height=600," + "left =6," + "top=60"
        return settings;
    }
    if (no == '7') {
        settings = "toolbar=no," + "scrollbars=no," + "location=no," + "statusbar=no," + "menubar=no," + "resizable=0," + "width=1325," + "height=618," + "left =25," + "top=55"
        return settings;
    }
}


function savecnfirmation() {
    confirmAction('Do you want to save record ?', performAction); return false;
}


function performAction() {
    document.getElementById("ContentPlaceHolder1_btnFinalSave").click();
}


function confirmAction(message, action) {
    alertify.confirm(message, function (e) {
        if (e) {
            if (action) {
                action();
            }
        }
    });
}


function ValidatePanNo(PANNO) {
    var RegxPanNo = /[A-Z]{5}\d{4}[A-Z]{1}/;
    var PanNo = document.getElementById("ContentPlaceHolder1_" + PANNO + "").value;
    PanNo = PanNo.toUpperCase();    //RasikV 20170106
    document.getElementById("ContentPlaceHolder1_" + PANNO + "").value = PanNo;    //RasikV 20170106

    if (RegxPanNo.test(PanNo) == false) {
        document.getElementById("ContentPlaceHolder1_" + PANNO + "").value = "";
        setfocus('InValid PAN Card No', PANNO);
        return false;
    }
}


function ValidateAadharNo(AadhrNo) {
    var iAdrNo = document.getElementById("ContentPlaceHolder1_" + AadhrNo + "").value;
    if (iAdrNo.length != 12) {
        document.getElementById("ContentPlaceHolder1_" + AadhrNo + "").value = "";
        setfocus('Aadhar No. cannot be less then 12 digits', AadhrNo);
        return false;
    }
}


function Validate_PanNo(panNo) {
    var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
    var code = /([C,P,H,F,A,T,B,L,J,G])/;
    var address = document.getElementById("ContentPlaceHolder1_" + panNo + "").value;
    var ObjVal = address.toString();
    var code_chk = ObjVal.substring(3, 4).toUpperCase();
    if (ObjVal.search(panPat) == -1) {
        document.getElementById("ContentPlaceHolder1_" + panNo + "").value = "";
        setfocus('Invalid Pan No.', panNo);
        return false;
    }
    if (code.test(code_chk) == false) {
        document.getElementById("ContentPlaceHolder1_" + panNo + "").value = "";
        setfocus('Invaild PAN Card No.', panNo);
        return false;
    }
}

function ValidateNumWithTwoDeci(NUM) {
    var RegxNum = /^(?:\d*\.\d{1,2}|\d+)$/;
    var Num = document.getElementById("ContentPlaceHolder1_" + NUM + "").value;

    if (RegxNum.test(Num) == false) {
        document.getElementById("ContentPlaceHolder1_" + NUM + "").value = "";
        setfocus('Enter Amount Upto 2 Decimals', NUM);
        return false;
    }
}

/*  ValidateAlphaNumeric has been used for PMI Member No fields only
KEYS => 65-90 = CAPITAL ALPHABETS, 97-122 = SMALL ALPHABETS, 32 = SPACE, 48-57 = NUMBERS. 
*/
function ValidateAlphaNumeric(sender) {    //RasikV 20170106
    if (((event.keyCode >= 65) && (event.keyCode <= 90)) || ((event.keyCode >= 97) && (event.keyCode <= 122)) || ((event.keyCode >= 48) && (event.keyCode <= 57)) || (event.keyCode == 32)) {
        event.returnValue = true;
    }
    else {
        event.returnValue = false;
        sender.focus();
    }
}

function ValidateNumWithThreeDeci(txt, event) { //RasikV 20170118
    var charCode = (event.which) ? event.which : event.keyCode
    if (charCode == 46) {
        if (txt.value.indexOf(".") < 0) return true;
        else return false;
    }
    if (txt.value.indexOf(".") > 0) {
        var txtlen = txt.value.length;
        var dotpos = txt.value.indexOf(".");
        if ((txtlen - dotpos) > 4) return false;
    }
    if (charCode > 31 && (charCode < 48 || charCode > 57)) return false;
    return true;
}

$(document).ready(function () {
    $("input:text").focus(function () { $(this).select(); });
});

function ValidateNumWith2Deci(sender) {
    if (((event.keyCode >= 48) && (event.keyCode <= 57)) || (event.keyCode == 46)) {
        if (event.keyCode == 46) {
            if (sender.value.indexOf(".") < 0) return true;
            else event.returnValue = false;
            sender.focus();
        }
        if (sender.value.indexOf(".") > 0) {
            var txtlen = sender.value.length;
            var dotpos = sender.value.indexOf(".");
            if ((txtlen - dotpos) > 2) event.returnValue = false;
            sender.focus();
        }
    } else {
        event.returnValue = false;
        sender.focus();
    }
}

$(document).ready(function () {
    $("input:text").focus(function () { $(this).select(); });
});