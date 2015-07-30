/**
 * Created by Michal on 2015-07-26.
 */
function changeArrowOnResize() {

    var arrowRight=$("#arrow-right");
    var arrowLeft=$("#arrow-left");


    if(window.innerWidth<768) {
        arrowRight.attr('src','images/arrow-down.png');
        arrowLeft.attr('src','images/arrow-down.png');

        arrowLeft.css('float','none');
        arrowRight.css('float','none');

        arrowLeft.addClass('center-block');
        arrowRight.addClass('center-block');


    }
    else {
        arrowRight.attr('src','images/arrow-right.png');
        arrowLeft.attr('src','images/arrow-left.png');

        arrowLeft.css('float','left');
        arrowRight.css('float','right');

        arrowLeft.removeClass('center-block');
        arrowRight.removeClass('center-block');

    }
}

