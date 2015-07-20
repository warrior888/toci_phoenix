function RegisterClick(elementId, callback) {

    $('#' + elementId).click(callback);
}

function GetHtmlByAjax(url, callback, idToReplace) {

    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            callback(data,idToReplace);
        }
    });
}

function insertHTML(html,containerId) {
    $("#" + containerId).html(html);
}

/*function PutHtmlToContainer(containerId, elementId, html) {
    $("#" + containerId).fadeOut(300);
    setTimeout(function () {
        $("#" + containerId).html(html);
    }, 300);
    $("#" + containerId).fadeIn(300);
}*/



