<?php

require_once '../Interfaces/IDbQuery.php';
require_once 'PgHandle.php';

class PgQuery extends PgHandle implements IDbQuery {

    public function __construct() {
        parent::__construct();
    }

    public function RunQuery($query) {
        $result = pg_query($this->connection, $query);
        parent::__destruct();
        return $result;
    }

}
