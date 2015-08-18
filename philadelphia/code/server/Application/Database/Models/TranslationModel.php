<?php

require_once(__DIR__ . '/../Postgres/PgModel.php');

/*
 * @author obywatelgcc
 * @refactor perla
 * 
 * Model, w którym dane wejściowe z TranslationHandler.php są przetwarzane na 
 * zapytanie do bazy danych o nowe tłumaczenie.
 */
class TranslationModel extends PgModel {

    private $currentLanguage;
    private $newLanguage;

    public function __construct($currentLanguage, $newLanguage) {
        $this->currentLanguage = $currentLanguage;
        $this->newLanguage = $newLanguage;
        parent::__construct();
    }

    public function GetTranslation() {

        $selectArray = array($this->currentLanguage . "_phrase", $this->newLanguage . "_phrase");

        $query = $this->dbSelect->Select('translations', $selectArray);

        $translation = $this->PgQuery($query);

        $result = array();

        foreach ($translation as $row) {

            $tmp = array_values($row);
            $result[strtolower($tmp[0])] = $tmp[1];
        }

        return $result;
    }

}
