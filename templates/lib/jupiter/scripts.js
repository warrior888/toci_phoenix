
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

    GetHtmlByAjax("dane/about.html", function (data) { PutHtmlToContainer("about", data); });   
}

function HowItWorksLinkClick() {

    GetHtmlByAjax("dane/how-it-works.html", function (data) { PutHtmlToContainer("how-it-works", data); });
}

function OrganisersLinkClick() {

    GetHtmlByAjax("dane/organisers.html", function (data) { PutHtmlToContainer("organisers", data); });
}

function FAQLinkClick() {

    GetHtmlByAjax("dane/faq.html", function (data) { PutHtmlToContainer("faq", data); });
}

function ApplyLinkClick() {

    GetHtmlByAjax("dane/apply.html", function (data) { PutHtmlToContainer("apply", data); });
}

function ContactLinkClick() {

    GetHtmlByAjax("dane/contact.html", function (data) { PutHtmlToContainer("contact", data); });
}