/**
 * Created by Mateusz on 2015-07-16.
 */

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

    $("#" + containerId).html(html);
}