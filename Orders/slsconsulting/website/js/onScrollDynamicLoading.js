var sectionContent = [
    'home.html',
    'about.html',
    'services.html',
    'contact.html',
    'footer.html'
]

var sectionId = [
    '#home-section',
    '#about-section',
    '#services-section',
    '#contact-section',
    '#footer-section'
]

function ScrollAjaxHandler(){
    var iterator = undefined ? iterator : 0;

    $(window).scroll(function() {
       var breakpoint = $(document).height()  - $(window).height() - 10;
       var documentEnd = $(document).height()  - $(window).height();

       if (iterator != sectionContent.length - 1) {
           if (($(window).scrollTop() >= breakpoint) && ($(window).scrollTop() <= documentEnd )) {
               $.get('server/content/' + sectionContent[iterator + 1], function (data) {
                   ++iterator;
                   console.log(iterator);
                   $(sectionId[iterator]).append(data);
               });
           }
       }
   })

    return iterator;
}

