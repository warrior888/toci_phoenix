/**
 * Created by Mg on 2015-07-30.
 */

$(document).ready(function()
{
    $("#video-carousel").owlCarousel(
        {
            loop: true,
            autoplay: true,
            autoplaySpeed: 1500,
            autoplayHoverPause: true,
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

    $("#references-carousel").owlCarousel(
        {
            loop: true,
            autoplay: false,
            autoplaySpeed: 8800,
	    paginationSpeed : 4800,
            autoplayHoverPause: true,
            responsive: {

                0: {
                    items: 1
                },
                760: {
                    items: 1
                }
            }
        }
    );

    $("#developers-carousel").owlCarousel(
        {
            loop: true,
            autoplay: true,
            autoplaySpeed: 1500,
            autoplayHoverPause: true,
            responsive: {

                0: {
                    items: 2
                },
                760: {
                    items: 3
                }
            }
        }
    );

    
    $("div.resizable-post").autoResizeFbPost();
    

    window.onresize =changeArrowOnResize;


    google.maps.event.addDomListener(window, 'load', initMap);

    turnLoaderOff();

});


