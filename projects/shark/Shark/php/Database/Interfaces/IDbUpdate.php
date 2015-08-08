<?php

interface IDbUpdate {

    public function Update($table, $data, $where = false);
}
