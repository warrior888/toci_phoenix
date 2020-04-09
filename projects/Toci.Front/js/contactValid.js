$(document).ready(function() {

    $('#contact-form').submit(function(event) {
        SubmitForm(FormDecorator(this.id, 'index/contact'), event);
    });
});


function CustomEmailPrompterForContactForm(fieldValue, referenceInput) {

    var senderFullName = fieldValue.split(' ');

    var name = senderFullName[0];
    var surname = senderFullName[1];

    SetEmailPrompPlaceholder(referenceInput, name, surname);
}