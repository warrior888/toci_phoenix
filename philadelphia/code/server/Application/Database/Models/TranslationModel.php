<?php

require_once(__DIR__.'/../Postgres/PgModel.php');
/**
 * @author obywatelgcc
 */
class TranslationModel extends PgModel
{
    private $table = 'translation_view';
    private $columns = 'lang_name, element_name, translation';
    
    public function GetTranslation($language, $elementName)
    {
        $whereArray = array('lang_name' => $language);
        if(isset($elementName) && !empty($elementName))
        {
            $whereArray['element_name'] = $elementName;
        }
        $queryResult = $this->dbHandle->RunQuery($this->dbSelect->Select($this->table, $this->columns, $whereArray));
        return pg_fetch_all($queryResult);
    }
}
