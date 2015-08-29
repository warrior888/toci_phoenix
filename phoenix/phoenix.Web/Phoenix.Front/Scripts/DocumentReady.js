$(document).ready(function() {
   
    /******* Datepicker ********/
    $.datepicker.setDefaults($.datepicker.regional['pl']);
    $("#AvailableFrom").datepicker();
    $("#AvailableTo").datepicker();

});