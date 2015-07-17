
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

    GetHtmlByAjax("dane/about.html", function (data) { PutHtmlToContainer("content", data); });   
}

function HowItWorksLinkClick() {

    GetHtmlByAjax("dane/how-it-works.html", function (data) { PutHtmlToContainer("content", data); });
}

function OrganisersLinkClick() {

    GetHtmlByAjax("dane/organisers.html", function (data) { PutHtmlToContainer("content", data); });
}

function FAQLinkClick() {

    GetHtmlByAjax("dane/faq.html", function (data) { PutHtmlToContainer("content", data); });
}

function ApplyLinkClick() {

    GetHtmlByAjax("dane/apply.html", function (data) { PutHtmlToContainer("content", data); });
}

function ContactLinkClick() {

    GetHtmlByAjax("dane/contact.html", function (data) { PutHtmlToContainer("content", data); });
}