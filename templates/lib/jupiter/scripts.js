
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

    var html = GetHtmlByAjax("dane/2.html");

    PutHtmlToContainer("about", html);
}