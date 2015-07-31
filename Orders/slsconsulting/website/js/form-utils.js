function FormDecorator(formId, destination) {

    this.formId = formId;
    this.destination = destination;

    var answerContainer = $("<div>");
    $(answerContainer).attr('id', 'answerContainer');


    function callbackAction(divClass, message) {
        //na razie nie wiadomo co tam wstawic
        /*if (!$('#' + formId).find('#answerContainer').length) {
            $('#' + formId).append(answerContainer);
        }       
        $(answerContainer).append(''+message)
                          .addClass(divClass);*/

        $('#' + formId).find(':input').each(function () {
            $(this).val('');
        });
    }

    function getFormData() {
        var values = $('#' + formId).serialize();
        console.log('serializowane wartosci',values);
        return values;
    }

    function successAction(data) {
        callbackAction('alert alert-success', data.message);
    }

    function failAction(data) {
        callbackAction('alert alert-danger', data.message);
    }

    return {
        getFormData: getFormData,
        successAction: successAction,
        failAction : failAction,
        destination: destination
    };
}

/* ************************************************************ */

function SubmitForm(form, event) {
    $.ajax({
        type: 'POST',
        url: form.destination,
        data: form.getFormData(),
        dataType: 'json',
        encode: true
    })
        .done(function (data) {
            if (data.result === true) {
                form.successAction(data);
            } else {
                form.failAction(data);
            }
        })
         .fail(function (data) {
             form.failAction(data);
         });

    event.preventDefault();
}