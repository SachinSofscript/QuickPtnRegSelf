/* Event editing helpers - modal dialog */
function dialog() {
    var modal = new DayPilot.Modal();
    modal.top = 60;
    modal.width = 400;
    modal.height = 450;
    modal.opacity = 70;
    modal.border = "10px solid #d0d0d0";
    modal.closed = function () {
        if (this.result == "OK") {
            dp.commandCallBack('refresh');
        }
        dp.clearSelection();
    };
    return modal;
}

function timeRangeSelected(start, end, location, person) {
    var modal = dialog();
    var url = "New.aspx?start=" + start.toStringSortable() + "&end=" + end.toStringSortable();
    if (location) {
        url += "&location=" + location;
    }
    if (person) {
        url += "&person=" + person;
    }
    modal.showUrl(url);
}

function eventClick(e) { 
    var modal = dialog();
    if (e.recurrent()) {
        modal.alert("HID");
        modal.showUrl("Edit.aspx?id=" + e.recurrentMasterId());
    }
    else {
        modal.showUrl("Edit.aspx?id=" + e.value());
    }
}

 
