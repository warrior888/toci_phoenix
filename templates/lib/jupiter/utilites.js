/**
 * Created by Mateusz on 2015-07-16.
 */


function sendAJAX(url, callback, elementIDToReplace) {

    if (!elementIDToReplace) {
        elementIDToReplace = "info";
    }
    $.ajax({
        type: "GET",
        url: url,

        success: function (data) {

            callback(data, elementIDToReplace);
        }

    });

}

function insertHTMLbyId(data, id) {
    $("#" + id).html(data);
}

function RegisterClick(elementId, callback) {

    $(elementId).click(callback);
}

function GetHtmlByAjax(url) {


}

function PutHtmlToContainer(containerId, html) {

}