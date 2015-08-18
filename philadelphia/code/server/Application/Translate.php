<?php

/*
 * @author : Perła
 * 
 * Przelotka dla AJAX tłumaczenia strony. Walidacja nagłówka i danych wejściowych.
 * Ładowanie kontrolera TranslationHandler.php.
 */
// @map - languages
require('config.php');
$languages = $config['languages'];

if ((!isset($_SERVER['HTTP_X_REQUESTED_WITH']) && !empty($_SERVER['HTTP_X_REQUESTED_WITH']) && strtolower($_SERVER['HTTP_X_REQUESTED_WITH']) == 'xmlhttprequest')) {
    http_response_code(404); //sprawdź ajax

} else if (!(isset($_POST['newLanguage']) AND in_array($_POST['newLanguage'], $languages))) {
    //walidacja danych z POST
    http_response_code(404);
} else {
    require_once('TranslationHandler.php'); //ładuj handler
    $translationHandler = new TranslationHandler(
            $_COOKIE['currentLanguage'], 
            $_POST['newLanguage']);
    echo $translationHandler->translationJson;
    
}

