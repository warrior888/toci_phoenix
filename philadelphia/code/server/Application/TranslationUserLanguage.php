<?php

require('config.php');
$languages = $config['languages'];

if ((!isset($_SERVER['HTTP_X_REQUESTED_WITH']) && !empty($_SERVER['HTTP_X_REQUESTED_WITH']) && strtolower($_SERVER['HTTP_X_REQUESTED_WITH']) == 'xmlhttprequest')) {
    http_response_code(404); //sprawdź ajax
} else if (
        ($_COOKIE['currentLanguage'] !== 'polish') &&
        (in_array($_COOKIE['currentLanguage'], $languages) !== false)) {

    require_once('TranslationHandler.php');
    $translationHandler = new TranslationHandler('polish', $_COOKIE['currentLanguage']);
    echo $translationHandler->translationJson;
}