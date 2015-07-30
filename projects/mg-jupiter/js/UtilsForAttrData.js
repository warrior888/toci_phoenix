$(document).ready(RegistarAllOnLoad);



var validationCallbacks = {
    'CustomEmailPrompterForApllyForm': CustomEmailPrompterForApllyForm,
    'CustomEmailPrompterForContactForm': CustomEmailPrompterForContactForm
};

var validationElements = {
    'applicantFullName': { 'applicantNameId': 'applicantName', 'applicantSurnameId': 'applicantSurname' },

}

/* ************************************************************ */

function ValidateOtherFieldForField(inputFieldId) {

    var referenceInput = $('#' + inputFieldId);

    var otherFieldCallback = referenceInput.attr('data-validate-other-field-if');
    var otherFieldsId = referenceInput.attr('data-other-field-id');

    var inputs = GenerateElementsId(otherFieldsId);
    validationCallbacks[otherFieldCallback](inputs, referenceInput);
}


function GenerateElementsId(otherFieldsId) {
    var elements = validationElements[otherFieldsId];
    return elements == undefined ? otherFieldsId : elements;
}

function RegistarAllOnLoad() {

    $('#applicantEmail').focus(function () { ValidateOtherFieldForField('applicantEmail'); });
    $('#contact-input-email').focus(function () { ValidateOtherFieldForField('contact-input-email'); });
}