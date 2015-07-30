
$(document).ready(function() {

    $('#contact-form').submit(function(event) {
        SubmitForm(FormDecorator(this.id, 'server/contact.php'), event);
    });
});


function CustomEmailPrompterForContactForm(fieldsId, referenceInput) {

    var senderFullName = $('#' + fieldsId).val().split(' ');

    var name = senderFullName[0];
    var surname = senderFullName[1];

    SetEmailPrompPlaceholder(referenceInput, name, surname);

}