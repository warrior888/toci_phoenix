<?php

require_once '../Interfaces/IDbInsert.php';
require_once 'PgQuery.php';

class PgInsert extends PgQuery implements IDbInsert {

    protected $dbWhere;

    public function Insert($table, $data, $where = false) {

        $query = 'INSERT INTO';
        $query.= $table . ' (' . implode(',', array_keys($data)) . ') ';
        $query.= " VALUES ('" . implode("' , '", array_values($data)) . "')";


        if ($where) {
            $query .= $this->CreateWhereStatement($where);
        }
        
        $result = $this->format . ';';
        
        return $result;
    }

}
