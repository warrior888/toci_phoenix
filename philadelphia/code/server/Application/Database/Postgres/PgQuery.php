<?php

abstract class PgQuery {

    protected function CreateWhereStatement($where)
    {
        if($where){
        $query = ' WHERE ';

        if (is_array($where)) {
        foreach ($where as $column => $row) {
            $query .= "$column = '$row'" . " AND ";
        }
        $result = rtrim($query, 'AND ');

        } else {
            $result=" ".$query." ".$where;
        }
        return $result;}
    }


    protected function Escape($items)
    {
        foreach($items as $key => $value)
        {
            $items[$key] = pg_escape_string($value);
        }

        return $items;
    }

}
