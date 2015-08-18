<?php

/*
 * @author: Perła
 * 
 *  Kontroler, w którym przetworzone zapytanie z Translate.php 
 * jest kierowane jako zapytanie do bazy danych i jako rezultat
 * zwraca JSON z tłumaczeniem {'fraza w aktualnym języku' : 'fraza w nowym języku'}
 */

require_once __DIR__ . '/Database/Models/TranslationModel.php';

class TranslationHandler {

    private $currentLanguage;
    private $newLanguage;
    public $translationJson;

    public function __construct($currentLanguage, $newLanguage) {
        if ($currentLanguage !== $newLanguage) {
            $this->currentLanguage = $currentLanguage;
            $this->newLanguage = $newLanguage;
            $this->translationJson = $this->CreateJson();
        } else {
            $this->translationJson = false;
        }
    }

    protected function CreateJson() {
        $translationModel = new TranslationModel($this->currentLanguage, $this->newLanguage);

        $result = $translationModel->GetTranslation();

        $this->SetNewLanguage();

        return json_encode($result);
    }

    protected function SetNewLanguage() {
        unset($this->currentLanguage);
        setcookie('currentLanguage', $this->newLanguage, time() + 60 * 60 * 24 * 365, '/');
    }

}


