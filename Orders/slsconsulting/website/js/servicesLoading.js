$( document ).ready(function() {
    /*AppendOnClick2('car-rentals', 'servicesContainer', 'server/Content/car-renting.html');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick2('car-rentals1', 'servicesContainer', 'server/Content/car-renting.html');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick2('car-rentals2', 'servicesContainer', 'server/Content/car-renting.html');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick2('car-rentals3', 'servicesContainer', 'server/Content/car-renting.html');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick2('car-rentals4', 'servicesContainer', 'server/Content/car-renting.html');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick2('car-rentals5', 'servicesContainer', 'server/Content/car-renting.html');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick2('car-rentals6', 'servicesContainer', 'server/Content/car-renting.html');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick2('car-rentals7', 'servicesContainer', 'server/Content/car-renting.html');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');*/
});


function AppendOnClick(actionTrgId, containerId, fileName) {
    $('#'+ actionTrgId).on("click", function(e){
            e.preventDefault();
            $('#'+containerId).hide().load(fileName).fadeIn(1500);
    });
}
