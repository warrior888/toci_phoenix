// @map - flag-id: language

Languages =
        {
            'flag-pl': 'polish',
            'flag-uk': 'english',
            'flag-de': 'german'
        };

// @stack - delegaty dla tłumaczenia

$(document).ready(function ()
{
    CheckUserLanguage();

    $('.state-flag').click(function ()
    {
        GetTranslation(this);
    });
});

// @api - AJAX

function AjaxRequest(method, address, handler, informations)
{
    method = method.toUpperCase();

    var Request = {
        type: method,
        url: address,
        success: function (callback) {
            window[handler](callback);
        }
    };

    if (typeof informations !== undefined)
    {
        Request['data'] = informations;
    }

    $.ajax(Request);

}

function CheckUserLanguage()
{
    AjaxRequest(
            'post',
            'server/Application/TranslationUserLanguage.php',
            'TranslationHandler'
            );
}

function GetTranslation(attribute) {

    var id = attribute.getAttribute('id');
    var language = Languages[id];
    Translate(language);

}

function Translate(language)
{
    LanguageRequest = {newLanguage: language};

//    $.ajax({
//        method: "POST",
//        url: 'server/Application/Translate.php',
//        data: LanguageRequest,
//        success: function (callback)
//        {
//            TranslationHandler(callback);
//        }
//    });

    AjaxRequest(
            'post',
            'server/Application/Translate.php',
            'TranslationHandler',
            LanguageRequest);
}

    function TranslationHandler(callback)
    {   
        var Translation = JSON.parse(callback);
        if (Translation !== false)
        {
            RecursiveReplace(document.body, Translation);
        }
    }

    function RecursiveReplace(node, Translation) {

        if (node.nodeType === 3) { //text

            var key = node.nodeValue.toLowerCase().trim();
            if (Translation[key] !== undefined)
            {
                node.nodeValue = Translation[key];
            }
        }

        else if (node.nodeType === 1) { // element
            if (!(node.nodeName.toLowerCase().indexOf('iframe') > -1))
            {
                $(node).contents().each(function () {
                    RecursiveReplace(this, Translation);
                });
            }

        }

    }


