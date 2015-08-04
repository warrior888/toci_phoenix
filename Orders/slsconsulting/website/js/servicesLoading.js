$( document ).ready(function() {
    AppendOnClick('car-rentals', 'servicesContainer', 'server/Content/car-renting.html');
    AppendOnClick('return', 'servicesContainer', 'server/Content/services.html')
});


function AppendOnClick(actionTrgId, containerId, fileName) {
    $('#'+ actionTrgId).on("click", function(e){
            e.preventDefault();
            $('#'+containerId).hide().load(fileName).fadeIn(1500);
    });
}