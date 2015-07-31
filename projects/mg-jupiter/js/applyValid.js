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

