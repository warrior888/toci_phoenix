$(document).ready(function () {

//    $('#apply-form').submit(function (event) {
//        SubmitForm(FormDecorator(this.id, 'server/apply.php'), event);
//        event.preventDefault();
//    });

    //raczej nie potrzebne

    
    // Contact form process
    $('#apply-form').submit(function(event) {

        //chyba nie potrzebne
        $('.form-group').removeClass('has-error'); // remove the error class
        $('.help-block').remove(); // remove the error text

        // get the form data
        // there are many ways to get this data using jQuery (you can use the class or id also)
        var formData = {
            'applicantName': $('input#applicantName').val(),
            'applicantSurname': $('input#applicantSurname').val(),
            'applicantEmail': $('input#applicantEmail').val(),
            'applicantPhone': $('input#applicantPhone').val()
        };

        // process the form
        $.ajax({
            type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
            url: 'server/apply.php', // the url where we want to POST
            data: formData, // our data object
            dataType: 'json', // what type of data do we expect back from the server
            encode: true
        })
            // using the done promise callback
            .done(function(data) {

                console.log('ajax sie wywolal', data);

                var jsonMessage = (data);

                console.log('debugowanie', data, jsonMessage);

                if (jsonMessage.result == true)
                //var secondOption = JSON.parse()
                // ALL GOOD! just show the success message!
                {
                    $('#apply-form').append('<div class="alert alert-success">' + data.message + '</div>');

                    // usually after form submission, you'll want to redirect
                    // window.location = '/thank-you'; // redirect a user to another page

                    $('input#applicantName').val('');
                    $('input#applicantSurname').val('');
                    $('input#applicantEmail').val('');
                    $('input#applicantPhone').val('');
                } else {
                    $('#apply-form').append('<div class="alert alert-success">nie udalo sie</div>');
                }



            })

            // using the fail promise callback
            .fail(function(data) {

                // show any errors
                // best to remove for production
                console.log(data);
            });

        // stop the form from submitting the normal way and refreshing the page
        event.preventDefault();
    });
    
});

/* ************************************************************ */

function FormDecorator(formId, destination) {

    this.formId = formId;
    this.destination = destination;

    function getFormData() {
        var values = $('#' + formId).serialize();
        return values;
    }

    function successAction(data) {
        $('#' + formId).append('<div class="alert alert-success">' + data.message + '</div>');
        $('#' + formId).find(':input').each(function () {
            $(this).val('');
        }
        );
    }

    function failAction(data) {
        //to na pewno bedzie inaczej wygladac;)
        console.log(data);
    }

    return {
        getFormData: getFormData,
        successAction: successAction,
        failAction: failAction
    };
}

function SubmitForm(form, event) {
    $.ajax({
        type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
        url: form.destination, // the url where we want to POST
        data: form.getFormData(), // our data object
        dataType: 'json', // what type of data do we expect back from the server
        encode: true
    })
        .done(form.successAction(data))
        .fail(form.failAction(data));

    event.preventDefault();
}


//na razie nie potrzebne
/* ************************************************************ */
/*var applyForm = function () {
    this.destination = 'server/apply.php';


}

/* ************************************************************ #1#

var newsletterForm = function() {
    this.destination = 'process-newsletter.php';

    
}

/* ************************************************************ #1#

var teacherForm = function() {
    this.destination = 'process-teacher.php';

   
}

/* ************************************************************ #1#

var contactForm = function () {
    this.destination = 'server/contact.php';

    
}

/* ************************************************************ #1#*/
