<?php

require_once "../Interfaces/IDbHandle.php";

class PgHandle implements IDbHandle {

    protected $connectionString;
    private $connection;

    public function __construct() {
        require '../../config.php';
        $this->connectionString = "host=46.101.222.238 user=postgres password=q1 dbname=postgres";
        $this->connection = $this->Connect();

    }

    public function __destruct() {
        pg_close($this->connection);
    }

    protected function Connect() {
        return pg_connect($this->connectionString);
    }

    public function RunQuery($query)
    {
        return pg_query($this->connection,$query);
    }
}

new PgHandle();
