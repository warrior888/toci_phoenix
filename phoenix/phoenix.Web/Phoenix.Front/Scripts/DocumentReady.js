$(document).ready(function() {
   
    /******* Datepicker ********/
    $.datepicker.setDefaults($.datepicker.regional['pl']);
    $("#availibility-from").datepicker();
    $("#availibility-to").datepicker();

});