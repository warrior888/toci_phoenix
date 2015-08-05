<?php

require_once 'PgQuery.php';
require_once '../Interfaces/IDbSelect.php';

class PgSelect extends PgQuery implements IDbSelect {


    public function Select($table ,$data , $where = false) {
        $format = 'SELECT ';

        $format .= $data;
        $format .= ' FROM ' . $table;

        if ($where) {
            $this->format .= $this->CreateWhereStatement($where);
        }

        $result = $format . ';';

        return $result;
    }

}
