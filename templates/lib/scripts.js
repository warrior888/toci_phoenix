function insertHTMLbyId(data,id){
    $("#"+id).html(data);
}

function sendAJAX(url,callback,elementIDToReplace){

    if(!elementIDToReplace) {
        elementIDToReplace = "info";
    }
    $.ajax({
        type: "GET",
        url: url,

        success: function(data){

            callback(data,elementIDToReplace);
        }

    });



}