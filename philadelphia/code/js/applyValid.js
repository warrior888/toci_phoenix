$(document).ready(function () {

    $('#apply-form').submit(function (event) {
        console.log(this);
        var buttonHandler = Ladda.create( document.querySelector( '#applyButton' ) );
        buttonHandler.start();
        SubmitForm(FormDecorator(this.id, 'server/apply.php'), event,buttonHandler);
    });
});

/* ************************************************************ */

function CustomEmailPrompterForApllyForm(fieldsValues, referenceInput) {
    SetEmailPrompPlaceholder(referenceInput, fieldsValues['applicantNameId'], fieldsValues['applicantSurnameId']);
}

