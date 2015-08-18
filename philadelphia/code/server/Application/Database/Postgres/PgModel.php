<?php

require_once(__DIR__ . '/../Models/Model.php');

require_once(__DIR__ . '/PgDelete.php');
require_once(__DIR__ . '/PgInsert.php');
require_once(__DIR__ . '/PgSelect.php');
require_once(__DIR__ . '/PgUpdate.php');

class PgModel extends Model {

    public $connection;

    public function __construct() {
        parent::__construct(
                new PgDelete(), new PgInsert(), new PgSelect(), new PgUpdate());

        include(__DIR__ . '/../../config.php');
        $this->connection = pg_connect($config['connection_string']);
    }

    public function PgCloseConnection() {
        pg_close($this->connection);
    }

    public function PgQuery($query) {


        $databaseKnock = pg_query($this->connection, $query);

        $result = false;

        if ($databaseKnock) {

            $result = pg_fetch_all($databaseKnock);
        }
        
        $this->PgCloseConnection();
        
        return $result;
    }

}
