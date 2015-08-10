<?php

require_once __DIR__.'/../Interfaces/IDbInsert.php';
require_once __DIR__.'/PgQuery.php';

class PgInsert extends PgQuery implements IDbInsert {

    protected $dbWhere;

    public function Insert($table, $data, $where = false) {

        $data=$this->Escape($data);

        $query = 'INSERT INTO ';
        $query.= $table . ' (' . implode(',', array_keys($data)) . ') ';
        $query.= " VALUES ('" . implode("' , '", array_values($data)) . "')";


        if ($where) {
            $query .= $this->CreateWhereStatement($where);
        }
        
        $query .= ';';
        
        return $query;
    }

}
