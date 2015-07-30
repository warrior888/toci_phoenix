$(document).ready(function () {

    $('#apply-form').submit(function (event) {
        SubmitForm(FormDecorator(this.id, 'server/apply.php'), event);
    });
});

/* ************************************************************ */

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
