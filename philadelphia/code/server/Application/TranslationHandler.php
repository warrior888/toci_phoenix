<?php

require_once __DIR__.'/Database/Models/TranslationModel.php';

class TranslationHandler 
{
    private $language;
    private $elementName; //id on html page for which we want get translation, if it's unset we get whole translation
    private $translation; //array(['contentId'] => 'translation' itp)
    
    //query string variables e.g. ?lang=pl&id=title
    private $langString = 'lang';
    private $elementNameString = 'id';
    
    public function __construct() 
    {
        $this->GetLanguage();
        $this->GetTranslation();
    }
            
    private function GetLanguage()
    {
        if(isset($_POST[$this->langString]) && !empty($_POST[$this->langString]))
        {
            $this->language = $_POST[$this->langString];
        }
        else
        {
            $this->language = 'en'; //or another default language
        }
        
        if(isset($_POST[$this->elementNameString]) && !empty($_POST[$this->elementNameString]))
        {
            $this->elementName = $_POST[$this->elementNameString];
        }
    }
    
    private function GetTranslation()
    {
        $translationModel = new TranslationModel();
        $this->translation = $translationModel->GetTranslation($this->language, $this->elementName);
    }
    
    public function CreateJson()
    {
        //array{[lang] => 'pl', [translation] => array([title] => 'Title' itp)}
        return json_encode($this->translation);
    }
}

$translationHandler = new TranslationHandler();
//output e.g. [{"lang_name":"en","element_name":"title","translation":"Title"}]
echo $translationHandler->CreateJson();