<?php

require_once '../Interfaces/IDbInsert.php';
require_once '../DbWhere.php';

class PgInsert extends DbWhere implements IDbInsert {

    protected $dbWhere;
    protected $format = 'INSERT INTO';

    public function Insert($table, $data, $where = false) {
        $this->format .= $table . ' (' . implode(',', array_keys($data)) . ') ';
        $this->format .= " VALUES ('" . implode("' , '", array_values($data)) . "')";


        if ($where) {
            $this->format .= $this->CreateWhereStatement($where);
        }
        
        $result = $this->format . ';';
        
        return $result;
    }

}
