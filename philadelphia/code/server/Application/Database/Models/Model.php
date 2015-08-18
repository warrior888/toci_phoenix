<?php

require_once(__DIR__.'/../Interfaces/IDbDelete.php');
require_once(__DIR__.'/../Interfaces/IDbInsert.php');
require_once(__DIR__.'/../Interfaces/IDbSelect.php');
require_once(__DIR__.'/../Interfaces/IDbUpdate.php');

require_once(__DIR__.'/../Postgres/PgQuery.php');

abstract class Model {

    protected $dbDelete;
    protected $dbInsert;
    protected $dbSelect;
    protected $dbUpdate;

    public function __construct(
        $deleteInstance,
        $insertInstance,
        $selectInstance,
        $updateInstance
    ) {
        $this->dbDelete = $this->DbDeleteInstance($deleteInstance);
        $this->dbInsert = $this->DbInsertInstance($insertInstance);
        $this->dbSelect = $this->DbSelectInstance($selectInstance);
        $this->dbUpdate = $this->DbUpdateInstance($updateInstance);
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
    protected static function DbHandleInstance(IDbHandle $object) {
        return $object;
    }
    

}
