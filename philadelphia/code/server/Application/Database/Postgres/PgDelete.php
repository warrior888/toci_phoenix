<?php

require_once __DIR__.'/PgQuery.php';
require_once __DIR__.'/../Interfaces/IDbDelete.php';

class PgDelete extends PgQuery implements IDbDelete {


    public function Delete($table, $where = false) {

        $format = 'DELETE FROM '.$table.$this->CreateWhereStatement($where);

        return $format;
    }

}
