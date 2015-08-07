
var subjects = {
    'import-export'  : 'Import/export',
    'car-sale': 'Sprzedaż samochodów',
    'car-rentals' : 'Wypożyczalnia samochodów',
    'agricultural' : 'Sprzęt rolniczy',
    'intl-transport' : 'Transport międzynarodowy',
    'vegetables' : 'Warzywa/owoce',
    'it-section' : 'Dział IT',
    'holiday-homes' : 'Domki całoroczne'
};


$( document ).ready(function() {
    AppendOnClick2('import-export');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick2('car-sale');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick2('car-rentals');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick2('it-section');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick2('intl-transport');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick2('vegetables');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick2('agricultural');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');

    AppendOnClick2('holiday-homes');
    //AppendOnClick('return', 'servicesContainer', 'server/Content/services.html');
});


function AppendOnClick(actionTrgId, containerId, fileName) {
    $('#'+ actionTrgId).on("click", function(e){
            e.preventDefault();
            $('#'+containerId).hide().load(fileName).fadeIn(1500);
    });
}

function AppendOnClick2(actionTrgId) {
    $('#'+ actionTrgId).on("click", function(){
        $('#met_subject').val(subjects[actionTrgId]);
    });
}
