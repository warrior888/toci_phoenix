/**
 * Created by Mg on 2015-07-30.
 */

$(document).ready(function()
{
    $("#video-carousel").owlCarousel(
        {
            autoPlay: 3000,
            lazyLoad : true,
            responsive: {

                0: {
                    items: 1
                },
                760: {
                    items: 2
                }
            }
        }
    );
    window.onresize =changeArrowOnResize;


    google.maps.event.addDomListener(window, 'load', initMap);

    turnLoaderOff();

});


