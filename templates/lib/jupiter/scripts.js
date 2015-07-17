
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

function AboutLinkClick() {

    GetHtmlByAjax("dane/2.html", function (data) { PutHtmlToContainer("about", data); });   
}

function HowItWorksLinkClick() {

    GetHtmlByAjax("?", function (data) { PutHtmlToContainer("how-it-works", data); });
}