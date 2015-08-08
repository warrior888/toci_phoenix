<?php

require_once __DIR__.'/PgQuery.php';
require_once __DIR__.'/../Interfaces/IDbSelect.php';

class PgSelect extends PgQuery implements IDbSelect {


    public function Select($table ,$data , $where = false) {

        $query = 'SELECT '.$data.' FROM ' . $table. $this->CreateWhereStatement($where);

        $result = $query . ';';

        return $result;
    }

}
