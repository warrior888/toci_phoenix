<?php
/**
 * Created by PhpStorm.
 * User: ohai
 * Date: 8/4/15
 * Time: 10:07 PM
 */

require_once "Models/Model.php";
require_once "Postgres/PgModel.php";


class InvoiceManager extends PgModel{

    private $table="invoices";

    public function __construct(){
        parent::__construct();
    }

    public function AddInvoice($Invoice){
        $query=$this->dbInsert->Insert($this->table,$Invoice);
        return $this->dbHandle->RunQuery($query);
    }

    public function GetInvoice($select,$where=false){

        $query=$this->dbSelect->Select($this->table,$select,$where);
        return pg_fetch_all($this->dbHandle->RunQuery($query));
    }

    public function UpdateInvoice($set,$where){

        $query=$this->dbUpdate->Update($this->table,$set,$where);
        return $this->dbHandle->RunQuery($query);
    }


    public function DeleteInvoice($where){
        $query=$this->dbDelete->Delete($this->table,$where);
        $result=$this->dbHandle->RunQuery($query);

        return  $result;
    }


    public function CloseConnection()
    {
        $this->dbHandle->CloseConnection();
    }
}