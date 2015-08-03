<?php

require_once '../DbWhere.php';
require_once '../Interfaces/IDbDelete.php';

class PgDelete extends DbWhere implements IDbDelete {

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
