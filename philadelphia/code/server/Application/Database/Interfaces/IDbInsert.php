<?php

interface IDbInsert {

    public function Insert($table, $data, $where = false);
}
