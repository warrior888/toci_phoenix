<?php

abstract class PgQuery {

    protected function CreateWhereStatement($where)
    {
        $query = ' WHERE ';

        if (is_array($where)) {
        foreach ($where as $column => $row) {
            $query .= "$column = '$row'" . " AND ";
        }
        $result = rtrim($query, 'AND ');

        } else {
            $result=" ".$query." ".$where;
        }
        return $result;
    }

    protected function EscapeQuery($query){
        return pg_escape_string($query);
    }
}
