function FormDecorator(formId, destination) {

    this.formId = formId;
    this.destination = destination;

    function getFormData() {
        var values = $('#' + formId).serialize();
        return values;
    }

    function callbackAction(data) {
        $('#' + formId).append('<div class="alert alert-success">' + data.message + '</div>');
        $('#' + formId).find(':input').each(function () {
            $(this).val('');
        });
    }

    //trzeba podgrac styl, tak zeby napis wyswietlil sie w czerwonej ramce
    /*function failAction(data) {
        $('#' + formId).append('<div class="alert alert-success">' + data.message + '</div>');
        $('#' + formId).find(':input').each(function () {
            $(this).val('');
        });
    }*/

    return {
        getFormData: getFormData,
        callbackAction: callbackAction,
        destination: destination
    };
}

function SubmitForm(form, event) {
    console.log(form);
    $.ajax({
        type: 'POST',
        url: form.destination,
        data: form.getFormData(),
        dataType: 'json',
        encode: true
    })
        .done(function (data) {
            if (data.result === true) {
                form.callbackAction(data);
            }
        })
         .fail(function (data) {
             form.callbackAction(data);
         });

    event.preventDefault();
}