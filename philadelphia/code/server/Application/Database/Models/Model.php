<?php

require_once('../Interfaces/IDbDelete.php');
require_once('../Interfaces/IDbInsert.php');
require_once('../Interfaces/IDbSelect.php');
require_once('../Interfaces/IDbUpdate.php');

require_once('../DbWhere.php');

abstract class Model {

    public $dbDelete;
    public $dbInsert;
    public $dbSelect;
    public $dbUpdate;
    public $dbQuery;

    public function __construct(
            $deleteInstance, 
            $insertInstance, 
            $selectInstance, 
            $updateInstance,
            $queryInstance) {
        $this->dbDelete = $this->DbDeleteInstance($deleteInstance);
        $this->dbInsert = $this->DbInsertInstance($insertInstance);
        $this->dbSelect = $this->DbSelectInstance($selectInstance);
        $this->dbUpdate = $this->DbUpdateInstance($updateInstance);
        $this->dbQuery = $this->DbQueryInstance($queryInstance);
    }

    protected static function DbDeleteInstance(IDbDelete $object) {
        return $object;
    }

    protected static function DbInsertInstance(IDbInsert $object) {
        return $object;
    }

    protected static function DbSelectInstance(IDbSelect $object) {
        return $object;
    }

    protected static function DbUpdateInstance(IDbUpdate $object) {
        return $object;
    }

    protected static function DbQueryInstance(IDbQuery $object) {
        return $object;
    }

}
