$(document).ready(RegistarAllOnLoad);



var validationCallbacks = {
    'CustomEmailPrompterForApllyForm': CustomEmailPrompterForApllyForm,
    'CustomEmailPrompterForContactForm': CustomEmailPrompterForContactForm
};

var validationElements = {
    'applicantFullName': { 'applicantNameId': 'applicantName', 'applicantSurnameId': 'applicantSurname' }

}

/* ************************************************************ */

function ValidateOtherFieldForField(inputFieldId) {

    var referenceInput = $('#' + inputFieldId);

    var otherFieldCallback = referenceInput.attr('data-validate-other-field-if');
    var otherFieldsId = referenceInput.attr('data-other-field-id');

    var elementsValues = GenerateElementsId(otherFieldsId);
    validationCallbacks[otherFieldCallback](elementsValues, referenceInput);
}


function GenerateElementsId(otherFieldsId) {
    var elements = validationElements[otherFieldsId];
    return elements == undefined ? otherFieldsId : elements;
}


/* ************************************************************ */

function RegistarAllOnLoad() {

    $('#applicantEmail').focus(function () { ValidateOtherFieldForField('applicantEmail'); });
    $('#contact-input-email').focus(function () { ValidateOtherFieldForField('contact-input-email'); });
    $('#applicantEmail').blur(function () { $('#'+this.id).attr('placeholder', 'Email'); });
    $('#contact-input-email').blur(function () { $('#' + this.id).attr('placeholder', 'Email'); });
}

/* ************************************************************ */

function SetEmailPrompPlaceholder(inputForEmail, senderName, senderSurname) {
    if (senderName !== undefined && senderSurname !== undefined) {
        inputForEmail.attr('placeholder', senderName + '.' + senderSurname + '@example.com');
    }
}