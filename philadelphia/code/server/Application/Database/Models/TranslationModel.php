<?php

require_once(__DIR__.'/../Postgres/PgModel.php');
/**
 * @author obywatelgcc
 */
class TranslationModel extends PgModel
{
    private $table = 'translation'; //view table
    private $columns = 'content_id, i18n_content';
    
    public function GetTranslation($language, $contentId)
    {
        $whereArray = array('lang_name' => $language);
        if(isset($contentId) && !empty($contentId))
        {
            $whereArray['content_id'] = $contentId;
        }
        $queryResult = $this->dbHandle->RunQuery($this->dbSelect->Select($this->table, $this->columns, $whereArray));
        var_dump($queryResult);
        return pg_fetch_all($queryResult);
    }
}
