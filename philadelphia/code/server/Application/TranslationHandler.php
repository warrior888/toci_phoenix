<?php

require_once __DIR__.'/Database/Models/TranslationModel.php';

class TranslationHandler 
{
    private $language;
    private $contentId; //id on html page for which we want get translation, if it's unset we get whole translation
    private $translation; //array(['contentId'] => 'translation' itp)
    
    private $langString = 'lang';
    private $contentIdString = 'id';
    
    public function __construct() {
        $this->GetLanguage();
        $this->GetTranslation();
    }
    private function GetLanguage()
    {
        //get from POST
        if(isset($_POST[$this->langString]) && !empty($_POST[$this->langString]))
        {
            $this->language = $_POST[$this->langString];
        }
        else
        {
            $this->language = 'pol';
        }
        
        if(isset($_POST[$this->contentIdString]) && !empty($_POST[$this->contentIdString]))
        {
            $this->$contentId = $_POST[$this->contentIdString];
        }
        
    }
    
    private function GetTranslation()
    {
        $translationModel = new TranslationModel();
        $this->translation = $translationModel->GetTranslation($this->language, $this->contentId);
    }
    
    public function CreateJson()
    {
        //array{[lang] => 'pl', [translation] => array([title] => 'Title' itp)}
        return json_encode($this->translation);
    }
    /*
     * TODO:
     * filtracja danych
     * *if($POST['lang']=="")
     * Get_content() -> pobierze odpowiednie tłumaczenie w oparciu o database
     * callback - getconent w json - jako echo
     */ 
}

$translationHandler = new TranslationHandler();
echo $translationHandler->CreateJson();