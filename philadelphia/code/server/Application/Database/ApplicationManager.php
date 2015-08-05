<?php
/**
 * Created by PhpStorm.
 * User: ohai
 * Date: 8/4/15
 * Time: 10:07 PM
 */

require_once "Models/Model.php";
require_once "Postgres/PgModel.php";

class ApplicantManager extends PgModel{

    public $table="applicants";

    public function SaveApplicant($applicant){
        return $this->dbInsert->Insert($this->table,$applicant);
    }

    public function GetApplicants($select,$where=false){

        $result=$this->dbHandle->RunQuery($this->dbSelect->Select($this->table,$select,$where));
        return pg_fetch_all($result);
    }

}