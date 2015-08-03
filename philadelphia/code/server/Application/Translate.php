<?php

if (!(isset($_SERVER['HTTP_X_REQUESTED_WITH']) && !empty($_SERVER['HTTP_X_REQUESTED_WITH']) && strtolower($_SERVER['HTTP_X_REQUESTED_WITH']) == 'xmlhttprequest')) {
    http_response_code(403); //sprawdź ajax
} else {
    require_once('TranslationHandler.php'); //ładuj handler
}