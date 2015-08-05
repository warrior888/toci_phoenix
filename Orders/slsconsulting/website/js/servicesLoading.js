$( document ).ready(function() {
    AppendOnClick('car-rentals', 'servicesContainer', 'server/Content/car-renting.html');
    AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick('car-rentals1', 'servicesContainer', 'server/Content/car-renting.html');
    AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick('car-rentals2', 'servicesContainer', 'server/Content/car-renting.html');
    AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick('car-rentals3', 'servicesContainer', 'server/Content/car-renting.html');
    AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick('car-rentals4', 'servicesContainer', 'server/Content/car-renting.html');
    AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick('car-rentals5', 'servicesContainer', 'server/Content/car-renting.html');
    AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick('car-rentals6', 'servicesContainer', 'server/Content/car-renting.html');
    AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick('car-rentals7', 'servicesContainer', 'server/Content/car-renting.html');
    AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');
});


function AppendOnClick(actionTrgId, containerId, fileName) {
    $('#'+ actionTrgId).on("click", function(e){
            e.preventDefault();
            $('#'+containerId).hide().load(fileName).fadeIn(1500);
    });
}