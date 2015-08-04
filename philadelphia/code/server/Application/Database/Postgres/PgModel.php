<?php

require_once('PgDelete.php');
require_once('PgInsert.php');
require_once('PgSelect.php');
require_once('PgUpdate.php');
require_once('PgHandle.php');

class PgModel extends Model {

    public function __construct() {
        parent::__construct(
                new PgDelete(), 
                new PgInsert(), 
                new PgSelect(), 
                new PgUpdate(),
                new PgHandle());
    }
}