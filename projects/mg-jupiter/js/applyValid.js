$(document).ready(function () {

    $('#apply-form').submit(function (event) {
        SubmitForm(FormDecorator(this.id, 'server/apply.php'), event);
    });

    $('#contact-form').submit(function (event) {
        SubmitForm(FormDecorator(this.id, 'server/contact.php'), event);
    });
});

/* ************************************************************ */

function FormDecorator(formId, destination) {

    this.formId = formId;
    this.destination = destination;

    function getFormData() {
        var values = $('#' + formId).serialize();
        console.log('wartosci serializowane: ', values);
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
         .fail(function(data) {
             form.callbackAction(data);
         });

    event.preventDefault();
}

function CustomEmailPrompterForApllyForm(fieldsId, referenceInput) {

    var applicantNameValue = $('#' + fieldsId['applicantNameId']).val();
    var applicantSurnameValue = $('#' + fieldsId['applicantSurnameId']).val();

    SetEmailPrompPlaceholder(referenceInput, applicantNameValue, applicantSurnameValue);
}


function SetEmailPrompPlaceholder(inputFormEmail, senderName, senderSurname) {
    if (senderName + senderSurname !== '') {
        inputFormEmail.attr('placeholder', senderName + '.' + senderSurname + '@example.com');
    }
}


//na razie nie potrzebne
/* ************************************************************ */
/*var applyForm = function () {
    this.destination = 'server/apply.php';


}

/* ************************************************************ #1#

var newsletterForm = function() {
    this.destination = 'process-newsletter.php';

    
}

/* ************************************************************ #1#

var teacherForm = function() {
    this.destination = 'process-teacher.php';

   
}

/* ************************************************************ #1#

var contactForm = function () {
    this.destination = 'server/contact.php';

    
}

/* ************************************************************ #1#*/
