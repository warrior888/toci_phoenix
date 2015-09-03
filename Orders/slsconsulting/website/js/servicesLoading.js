
var subjects = {
    'import-export'  : 'Import/export',
    'car-sale': 'Sprzedaż samochodów',
    'car-rentals' : 'Wypożyczalnia samochodów',
    'agricultural' : 'Sprzęt rolniczy',
    'intl-transport' : 'Transport międzynarodowy',
    'vegetables' : 'Warzywa/owoce',
    'it-section' : 'Dział IT',
    'holiday-homes-more' : 'Domki całoroczne'
};


$( document ).ready(function() {

    AppendOnClick('holiday-homes', 'servicesContainer', 'server/Content/holiday-homes.html');
    AppendOnClick('return', 'servicesContainer', 'server/Content/empty.html');

    AddTitleToContactForm('import-export');
    AddTitleToContactForm('car-sale');
    AddTitleToContactForm('car-rentals');
    AddTitleToContactForm('it-section');
    AddTitleToContactForm('intl-transport');
    AddTitleToContactForm('vegetables');
    AddTitleToContactForm('agricultural');
    AddTitleToContactForm('holiday-homes-more');
});


function AppendOnClick(actionTrgId, containerId, fileName) {
    $('#'+ actionTrgId).on("click", function(e){
            e.preventDefault();
            $('#'+containerId).hide().load(fileName).fadeIn(1500);
    });
}

function AddTitleToContactForm(actionTrgId) {
    $('#'+ actionTrgId).on("click", function(){
        $('#met_subject').val(subjects[actionTrgId]);
    });
}
