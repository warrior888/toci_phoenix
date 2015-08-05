<?php

require_once __DIR__.'/PgQuery.php';
require_once __DIR__.'/../Interfaces/IDbSelect.php';

class PgSelect extends PgQuery implements IDbSelect {


    public function Select($table ,$data , $where = false) {
        $format = 'SELECT ';

        $format .= $data;
        $format .= ' FROM ' . $table;

        if ($where) {
            $format .= $this->CreateWhereStatement($where);
        }

        $result = $format . ';';

        return $result;
    }

}
