<?php
/**
 * Created by PhpStorm.
 * User: ohai
 * Date: 8/4/15
 * Time: 10:07 PM
 */

require_once "Models/Model.php";
require_once "Postgres/PgModel.php";


class ServiceManager extends PgModel{

    private $table="services";

    public function __construct(){
        parent::__construct();
    }

    public function AddService($service){
        $query=$this->dbInsert->Insert($this->table,$service);
        return $this->dbHandle->RunQuery($query);
    }

    public function GetService($select,$where=false){

        $query=$this->dbSelect->Select($this->table,$select,$where);
        return pg_fetch_all($this->dbHandle->RunQuery($query));
    }

    public function UpdateService($set,$where){

        $query=$this->dbUpdate->Update($this->table,$set,$where);
        return $this->dbHandle->RunQuery($query);
    }


    public function DeleteService($where){
        $query=$this->dbDelete->Delete($this->table,$where);
        $result=$this->dbHandle->RunQuery($query);

        return  $result;
    }


    public function CloseConnection()
    {
        $this->dbHandle->CloseConnection();
    }
}