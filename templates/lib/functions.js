/**
 * Created by Mateusz on 2015-07-16.
 */



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

function writeHTML(elementID){
    $(elementID).click(function(){
        var data =  sendAJAX("http://localhost/meteor/dane/1.txt",insertHTMLbyId);
    }