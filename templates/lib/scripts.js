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


function setSize(){

var docHeight = $(document).height();
    var docWidth = $(document).width();

    var style = {height:docHeight, width: docWidth};

var viewports = document.getElementsByClassName("viewport");

    for(var i in viewports){

        $(viewports[i]).css(style); //cos zle
        console.log(viewports[i]);
    }

}