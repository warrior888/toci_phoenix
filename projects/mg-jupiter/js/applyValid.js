$(document).ready(function () {

    $('#apply-form').submit(function (event) {
        SubmitForm(FormDecorator(this.id, './'), event);
    });
});

/* ************************************************************ */

function CustomEmailPrompterForApllyForm(fieldsValues, referenceInput) {
    SetEmailPrompPlaceholder(referenceInput, fieldsValues['applicantNameId'], fieldsValues['applicantSurnameId']);
}

