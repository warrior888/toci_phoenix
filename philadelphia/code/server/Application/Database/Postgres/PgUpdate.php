<?php

require_once 'PgQuery.php';
require_once '../Interfaces/IDbUpdate.php';

class PgUpdate extends PgQuery implements IDbUpdate {

    protected $format = 'UPDATE ';

    public function RenderQuery($table, $elements) {
        $query = sprintf($this->format, $table, implode(', ', array_keys($elements)), implode('\', \'', array_values($elements)));
        return $query;
    }

    public function Update($table, $data, $where = false) {
        $this->format .= $table;
        $this->format .= $this->CreateSetStatement($data);

        if ($where) {
            $this->format = $this->CreateWhereStatement($where);
        }

        $result = $this->format . ';';

        return $result;
    }

    public function CreateSetStatement($data) {

        $setStatement = 'SET ';

        foreach ($data as $column => $row) {
            $setStatement .= $column . ' = ' . "'$row',";
        }
        $result = rtrim($setStatement, ',');

        return $result;
    }

}
