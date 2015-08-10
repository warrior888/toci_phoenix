$(document).ready(function() {

    $('#contact-form').submit(function(event) {
		 var buttonHandler = Ladda.create( document.querySelector( '#contactButton' ));
        buttonHandler.start();
        SubmitForm(FormDecorator(this.id, 'server/contact.php'), event,buttonHandler);
    });
});


function CustomEmailPrompterForContactForm(fieldValue, referenceInput) {

    var senderFullName = fieldValue.split(' ');

    var name = senderFullName[0];
    var surname = senderFullName[1];

    SetEmailPrompPlaceholder(referenceInput, name, surname);
}