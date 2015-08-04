<?php

class PgQuery {

    protected function CreateWhereStatement($where) {
        $query = ' WHERE ';

        foreach ($where as $column => $row) {
            $query.= "$column = '$row'" . " AND ";
        }
        $result = rtrim($query, 'AND ');

        return $result;
    }

}
