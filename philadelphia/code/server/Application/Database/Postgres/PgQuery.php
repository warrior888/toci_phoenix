<?php

abstract class PgQuery {

    protected function CreateWhereStatement($where) {
        $query = ' WHERE ';

        foreach ($where as $column => $row) {
            $query.= "$column = '$row'" . " AND ";
        }
        $result = rtrim($query, 'AND ');

        return $result;
    }

    protected function EscapeQuery($query){
        return pg_escape_string($query);
    }
}
