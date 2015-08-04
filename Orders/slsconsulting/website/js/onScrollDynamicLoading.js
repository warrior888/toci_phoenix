var sections = [
    'home.html',
    'about.html',
    'services.html',
    'contact.html',
    'footer.html'
]

function ScrollHandler() {
    var iterator = 0;

    if (iterator != sections.length - 1) {
        if ($(window).scrollTop() == $(sections[iterator]).height() - $(window).innerHeight()) {
            $.get(sections[iterator + 1], function (data) {
                $('#suppa-wrappa').append(data);
                iterator++;
            });
        }
    }
}

$(document).ready(function(){
   $(window).scroll(ScrollHandler);
});

