$('#icy_tower').click(function ()
{
    
    FirstStep();
    SecoundStep();
    ThirdStep();
    
//    function Fire()
//    {
//        StepZero();
//        FirstStep();
//        setTimeout(function () {
//            SecoundStep();
//        }, 1000);
//        setTimeout(function () {
//            ThirdStep();
//        }, 2000);
//        setTimeout(function () {
//            FourthStep();
//        }, 5000);
//        setTimeout(function () {
//            FivethStep();
//        }, 7500);
//        setTimeout(function () {
//            SixthStep();
//        }, 8500);
//        setTimeout(function () {
//            SeventhStep();
//        }, 11000);
//    }
//    Fire();
//    setInterval(function()
//    {
//        Fire();
//    },13000);
});


function IcyFire(object)
{
    Character = {
        width: $(object).width(),
        height: $(object).height()
    }
    ;
    return Character;
}

function StepZero()
{
    Page = {
        width: $('body').width(),
        height: $('body').height()
    };
    return Page;
}

function FirstStep()
{
    setTimeout(function ()
    {
        ReplaceImage('icy_tower', '0.png');
    }, 500);

}
function SecoundStep()
{
    Move('icy_tower', '2.png', '3.png', 4, 175);
}
function ThirdStep()
{
    ReplaceImage('icy_tower', '6.png');
}
function FourthStep()
{
    ReplaceImage('icy_tower', '7.png');
}
function FivethStep()
{
    Move('icy_tower', '4.png', '5.png', 4, 175);
}
function SixthStep()
{
    ReplaceImage('icy_tower', '8.png');
}
function SeventhStep()
{
    ReplaceImage('icy_tower', '9.png');
}

function Move(imageId, imageOne, imageTwo, cycles, speed)
{
    counter = 0;
    interval = setInterval(function ()
    {
        if (counter === cycles)
        {
            clearInterval(interval);
        }

        if (counter % 2 === 0)
        {
            ReplaceImage(imageId, imageOne);
        }
        else
        {
            ReplaceImage(imageId, imageTwo);
        }
        counter++;
    }, speed);
}

function ReplaceImage(imageId, image)
{
    path = 'images/icy_tower/' + image;
    id = '#' + imageId;
    $(id).attr('src', path);
}

function ReplaceImages(imageId, image1, image2, cycles)
{
    while (counterTwo <= cycles)
    {
        if (counterTwo % 2 === 0)
        {
            ReplaceImage(imageId, image1);
        }
        else
        {
            ReplaceImage(imageId, image2);
        }
        counterTwo++;
    }
    counterTwo = 0;
}

//
//function RunPariodically(ms, method, cycle, param1, param2)
//{
//    var counter = 0;
//
//    setInterval(ms, method, param1, param2)
//    {
//        while (counter <= cycle)
//        {
//            if (counter === cycle)
//            {
//                clearInterval();
//            }
//            counter++;
//        }
//    }
//}
//
//$('document').ready(function()
//{
//    setInterval(function ()
//{
//    var counter = 0;
//
//    while (counter < 50)
//    {
//        if (counter % 2 === 0)
//        {
//            ReplaceImage('icy_tower', '0.png');
//        }
//        else
//        {
//            ReplaceImage('icy_tower', '1.png');
//
//        }
//    }
//}
//,200)
//})
//
//

//var counter = 0;
//
//function Go()
//{
//    setInterval(ReplaceImages,200,'icy_tower','1.png','2.png');
//    Stop();
//    counter ++;
//}
//
//
//
//var counter = 0;
//
//test = setInterval(Image, 1000);
//
//function Stop(cycles)
//{
//    if (counter === cycles)
//    {
//        clearInterval(test);
//
//    }
//}

