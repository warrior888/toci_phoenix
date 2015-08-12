<?php
/**
 * Created by PhpStorm.
 * User: ohai
 * Date: 8/4/15
 * Time: 10:07 PM
 */

require_once "Models/Model.php";
require_once "Postgres/PgModel.php";


class ClientsManager extends PgModel{

    private $table="clients";

    public function __construct(){
        parent::__construct();
    }

    public function AddClient($client){
        $query=$this->dbInsert->Insert($this->table,$client);
        return $this->dbHandle->RunQuery($query);
    }

    public function GetClient($select,$where=false){

        $query=$this->dbSelect->Select($this->table,$select,$where);
        return pg_fetch_all($this->dbHandle->RunQuery($query));
    }

    public function UpdateClient($set,$where,$returnString=false){

        $query=$this->dbUpdate->Update($this->table,$set,$where);

        if(!$returnString){
            return $this->dbHandle->RunQuery($query);
        }else{
        return $query;
        }

    }


    public function DeleteClient($where){
        $query=$this->dbDelete->Delete($this->table,$where);
        $result=$this->dbHandle->RunQuery($query);

        return  $result;
    }


    public function CloseConnection()
    {
        $this->dbHandle->CloseConnection();
    }
}