$( document ).ready(function() {
    $('#test').on("click", function(){
        $('#servicesTest').hide().load('blog.html').fadeIn(3000);
    });
});