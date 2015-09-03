var elementsStyles = {
    'bootstrapGreenRedStyle' : {'whenSuccess' : 'alert alert-success',
        'whenFailed' : 'alert alert-danger'}
};

var answerContainers = {
    'contact-form' : {'style' : elementsStyles['bootstrapGreenRedStyle'],
        'id' : 'answerContainer_unique44568'}
};

answerContainers.getStyleForAnswer = function(elementId,style){
    return answerContainers[elementId]['style'][style];
}

answerContainers.getContainerId = function(elementId){
    return answerContainers[elementId]['id'];
}

/* ************************************************************ */

function FormDecorator(formId, destination) {

    this.formId = formId;
    this.destination = destination;


    function getData() {
        var values = $('#' + formId).serialize();
        return values;
    }

    function successAction(data) {
        callbackAction(answerContainers.getStyleForAnswer(formId,'whenSuccess'), data.message);
        clearInputs();
    }

    function failAction(data) {
        callbackAction(answerContainers.getStyleForAnswer(formId,'whenFailed'), data.message);
    }

    function getDataType(){
        return 'json';
    }

    function getType(){
        return 'post';
    }

    function clearInputs(){
        $('#' + formId).find(':input').each(function () {
            $(this).val('');
        });
    }

    function appendAnswerContainer(containerId) {
        $('#' + formId).append($("<div>", {
            id: containerId
        }));
    }

    function showAnswerContainer(container,divClass, message){
        container.removeClass().addClass(divClass).text(''+message).show();
        setTimeout(function() {
            container.hide();
        }, 5000);
    }

    function callbackAction(divClass, message) {
        var answerContainerId = answerContainers.getContainerId(formId);
        if (!$('#' + formId).find('#' + answerContainerId).length) {
            appendAnswerContainer(answerContainerId);
        }
        showAnswerContainer($('#' + answerContainerId),divClass,message);
    }

    return {
        getData: getData,
        successAction: successAction,
        failAction : failAction,
        getDataType : getDataType,
        destination: destination,
        getType : getType
    };
}

/* ************************************************************ */

function SubmitForm(form, event) {
    MakeAjaxQuestion(form);
    event.preventDefault();
}

function MakeAjaxQuestion(element){
    $.ajax({
        type: element.getType(),
        url: element.destination,
        data: element.getData(),
        dataType: element.getDataType(),
        encode: true
    })
        .done(function (data) {
            if (data.result === true) {
                element.successAction(data);
            } else {
                element.successAction(data);
            }
        })
        .fail(function (data) {
            element.successAction(data);
        });
}