<?php

require_once '../PgQuery.php';
require_once '../Interfaces/IDbSelect.php';

class DbSelect extends PgQuery implements IDbSelect {

    protected $format = 'SELECT ';

    public function Select($data, $table, $where = false) {
        $this->format .= implode(',', $data);
        $this->format .= ' FROM ' . $table;

        if ($where) {
            $this->format .= $this->CreateWhereStatement($where);
        }

        $result = $this->format . ';';

        return $result;
    }

}
