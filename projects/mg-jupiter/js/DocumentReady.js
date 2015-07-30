/**
 * Created by Mg on 2015-07-30.
 */

$(document).ready(function()
{
    $("#video-carousel").owlCarousel(
        {
            autoPlay: 3000,
            lazyLoad : true,
            items:3,




        }


    );
    window.onresize =changeArrowOnResize;

});