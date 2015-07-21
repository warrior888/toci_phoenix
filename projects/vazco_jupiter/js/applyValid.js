$(document).ready(function() {

	// Contact form process
	$('#apply-form').submit(function(event) {

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
			type 		: 'POST', // define the type of HTTP verb we want to use (POST for our form)
			url         : 'server/apply.php', // the url where we want to POST
			data 		: formData, // our data object
			dataType 	: 'json', // what type of data do we expect back from the server
			encode 		: true
		})
			// using the done promise callback
			.done(function(data) {

				// log data to the console so we can see
			    console.log(data, data.result);

				// here we will handle errors and validation messages
				if ( ! data.result) {
					
					if (data.errors.name) {
						$('#applicant-name-group').addClass('has-error'); // add the error class to show red input
						$('#applicant-name-group label').append('<span class="help-block">' + data.errors.name + '</span>'); // add the actual error message under our input
					}

					if (data.errors.surname) {
						$('#applicant-surname-group').addClass('has-error'); // add the error class to show red input
						$('#applicant-surname-group label').append('<span class="help-block">' + data.errors.surname+ '</span>'); // add the actual error message under our input
					}
					
					if (data.errors.email) {
						$('#applicant-email-group').addClass('has-error'); // add the error class to show red input
						$('#applicant-email-group label').append('<span class="help-block">' + data.errors.email + '</span>'); // add the actual error message under our input
					}
					
					if (data.errors.phone) {
						$('#applicant-phone-group').addClass('has-error'); // add the error class to show red input
						$('#applicant-phone-group label').append('<span class="help-block">' + data.errors.phone + '</span>'); // add the actual error message under our input
					}

				} else {

					// ALL GOOD! just show the success message!
					$('#apply-form').append('<div class="alert alert-success">' + data.message + '</div>');

					// usually after form submission, you'll want to redirect
					// window.location = '/thank-you'; // redirect a user to another page

				    $('input#applicantName').val('');
				    $('input#applicantSurname').val('');
				    $('input#applicantEmail').val('');
				    $('input#applicantPhone').val('');
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

	// Newsletter form process
	$('#newsletter-form').submit(function(event) {

		$('.form-group').removeClass('has-error'); // remove the error class
		$('.help-block').remove(); // remove the error text

		// get the form data
		// there are many ways to get this data using jQuery (you can use the class or id also)
		var formData = {
			'input-name' 	        : $('input#newsletter-input-name').val(),
			'input-email' 	    	: $('input#newsletter-input-email').val()
		};

		// process the form
		$.ajax({
			type 		: 'POST', // define the type of HTTP verb we want to use (POST for our form)
			url 		: 'process-newsletter.php', // the url where we want to POST
			data 		: formData, // our data object
			dataType 	: 'json', // what type of data do we expect back from the server
			encode 		: true
		})
			// using the done promise callback
			.done(function(data) {

				// log data to the console so we can see
				console.log(data); 

				// here we will handle errors and validation messages
				if ( ! data.success) {
					
					// handle errors for name ---------------
					if (data.errors.name) {
						$('#newsletter-name-group').addClass('has-error'); // add the error class to show red input
						$('#newsletter-name-group').append('<span class="help-block">' + data.errors.name + '</span>'); // add the actual error message under our input
					}

					// handle errors for email ---------------
					if (data.errors.email) {
						$('#newsletter-email-group').addClass('has-error'); // add the error class to show red input
						$('#newsletter-email-group').append('<span class="help-block">' + data.errors.email + '</span>'); // add the actual error message under our input
					}

				} else {

					// ALL GOOD! just show the success message!
					$('#newsletter-form').append('<div class="alert alert-success">' + data.message + '</div>');

					// usually after form submission, you'll want to redirect
					// window.location = '/thank-you'; // redirect a user to another page

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

