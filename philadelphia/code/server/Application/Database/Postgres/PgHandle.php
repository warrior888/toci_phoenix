<?php

require_once __DIR__."/../Interfaces/IDbHandle.php";

class PgHandle implements IDbHandle {

    protected $connectionString;
    private $connection;

    public function __construct() {
        require __DIR__.'/../../config.php';
        $this->connectionString = $config['connection_string'];
        $this->connection = $this->Connect();

    }

    public function __destruct() {
        pg_close($this->connection);
    }

    public function CloseConnection() {
        return pg_close($this->connection);
    }

    protected function Connect() {
        return pg_connect($this->connectionString);
    }

    public function RunQuery($query)
    {
        $query=pg_escape_string($query);
        return pg_query($this->connection,$query);
    }


}

