
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

    GetHtmlByAjax("dane/about.html", insertHTML);
}

function HowItWorksLinkClick() {

    GetHtmlByAjax("dane/how-it-works.html", insertHTML);
}

function OrganisersLinkClick() {

    GetHtmlByAjax("dane/organisers.html", insertHTML);
}

function FAQLinkClick() {

    GetHtmlByAjax("dane/faq.html", insertHTML);
}

function ApplyLinkClick() {

    GetHtmlByAjax("dane/apply.html", insertHTML);
}

function ContactLinkClick() {

    GetHtmlByAjax("dane/contact.html", insertHTML);
}

function About2Click() {

    GetHtmlByAjax("dane/about2.html", insertHTML);
}