<?php

class PgHandle {

    protected $connectionString;
    private $connection;

    public function __construct() {
        require_once '../../config.php';
        $this->connectionString = $config['connection_string'];
        $this->connection = $this->Connect();
    }

    public function __destruct() {
        pg_close($this->connection);
    }

    protected function Connect() {
        return pg_connect($this->connectionString);
    }

}

new PgHandle();
