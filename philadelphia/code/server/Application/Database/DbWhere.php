<?php

class DbWhere {

    protected function CreateWhereStatement($where) {
        $query .= ' WHERE ';

        foreach ($where as $column => $row) {
            $query.= "$column = '$row'" . ", ";
        }
        $result = rtrim($query, ', ');

        return $result;
    }

}
