
//raczej nie training3 ;)

//window.addEventListener('DOMContentLoaded', )

$(document).ready(RegistarAllOnLoad);

//data-validate-surname-if


//data-validate-other-field-if

var validationCallbacks = {
    'CustomEmailPrompterForApllyForm': CustomEmailPrompterForApllyForm,
    'CustomEmailPrompterForContactForm': CustomEmailPrompterForContactForm
};

var validationInputs = {
    'applicantFullName': { 'applicantNameId': 'applicantName', 'applicantSurnameId': 'applicantSurname' },

}


function ValidateOtherFieldForField(inputFieldId) {

    var referenceInput = $('#' + inputFieldId);

    var otherFieldCallback = referenceInput.attr('data-validate-other-field-if');
    var otherFieldsId = referenceInput.attr('data-other-field-id');

    var inputs = GenerateInputsId(otherFieldsId);
    validationCallbacks[otherFieldCallback](inputs, referenceInput);
}

//to sie powinno inaczej nazywac
function GenerateInputsId(otherFieldsId) {
    var inputs = validationInputs[otherFieldsId];
    return inputs == undefined ? otherFieldsId : inputs;
}

function RegistarAllOnLoad() {

    $('#applicantEmail').focus(function () { ValidateOtherFieldForField('applicantEmail'); });
    $('#contact-input-email').focus(function () { ValidateOtherFieldForField('contact-input-email'); });
}