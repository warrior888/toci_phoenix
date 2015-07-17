function RegisterClick(elementId, callback) {

    $('#' + elementId).click(callback);
}

function GetHtmlByAjax(url, callback) {

    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            callback(data);
        }
    });
}

function PutHtmlToContainer(containerId, html) {
    $("#" + containerId).fadeOut(300);
    setTimeout(function () {
        $("#" + containerId).html(html);
    }, 300);
    $("#" + containerId).fadeIn(300);
}