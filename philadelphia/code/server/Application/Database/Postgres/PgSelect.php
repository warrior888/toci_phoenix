<?php

require_once __DIR__.'/PgQuery.php';
require_once __DIR__.'/../Interfaces/IDbSelect.php';

class PgSelect extends PgQuery implements IDbSelect {


    public function Select($table ,$data , $where = false) {

        if(is_array($data))
        {
            $query = 'SELECT '. implode(', ' , array_values($data)). ' FROM ' . $table. $this->CreateWhereStatement($where);
        }
        else
        {
            $query = 'SELECT '.$data.' FROM ' . $table. $this->CreateWhereStatement($where);
        }

        $result = $query . ';';

        return $result;
    }

}
