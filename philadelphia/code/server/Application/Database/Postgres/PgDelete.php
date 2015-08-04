<?php

require_once '../PgQuery.php';
require_once '../Interfaces/IDbDelete.php';

class PgDelete extends PgQuery implements IDbDelete {

    protected $format = 'DELETE FROM ';

    public function Delete($table, $where = false) {

        $this->format .= $table;

        if ($where) {
            $this->format = $this->CreateWhereStatement($where);
        }
        $result = $this->format;

        $result.=';';

        return $result;
    }

}
