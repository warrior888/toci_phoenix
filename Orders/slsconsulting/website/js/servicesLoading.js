$( document ).ready(function() {
    AppendOnClick('car-rentals', 'servicesContainer', 'car-renting.html');
    AppendOnClick('return', 'servicesContainer', 'services.html')
});


function AppendOnClick(actionTrgId, containerId, fileName) {
    $('#'+ actionTrgId).on("click", function(e){
            e.preventDefault();
            $('#'+containerId).hide().load(fileName).fadeIn(1500);
    });
}