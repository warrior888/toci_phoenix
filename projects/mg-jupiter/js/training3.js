
//window.addEventListener('DOMContentLoaded', )

$(document).ready(RegistarAllOnLoad);

//data-validate-surname-if


//data-validate-other-field-if

var validationCallbacks = {
    'CustomSurnameValidator': CustomSurnameValidator
};

function ValidateOtherFieldForField(inputFieldId) {

    var input = $('#' + inputFieldId);

    var otherFieldCallback = input.attr('data-validate-other-field-if');
    var otherFieldId = input.attr('data-other-field-id');

    console.log('edt', otherFieldCallback);

    validationCallbacks[otherFieldCallback](otherFieldId, input.val());
}


function RegistarAllOnLoad() {
    //console.log('tr 3 ready loaded');

    $('#applicantName').blur(function (ev) { ValidateOtherFieldForField('applicantName'); }); //ValidateOtherFieldForField

}

function CustomSurnameValidator(fieldId, referenceValue) {
    
    if (referenceValue === 'bartek') { // == 2 === '2'
        if ($('#' + fieldId).val() == 'zapart') {
            console.log('potencjlanie ładny komunikat');
        } else {
            $('#' + fieldId).val('');
        }
    }
}