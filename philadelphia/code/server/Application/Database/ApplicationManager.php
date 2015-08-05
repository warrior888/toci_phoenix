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

    private $table="applicants";
    public $cache;

    public function __construct(){
        parent::__construct();

        require __DIR__.'/../config.php';
        if($config['useCache'])
        {   $this->cache=new Memcache();
            $this->cache->connect($config['MEMCACHED_HOST'],$config['MEMCACHED_PORT']);
        }
        else
            $this->cache=false;

    }

    public function SaveApplicant($applicant){
        $query=$this->dbInsert->Insert($this->table,$applicant);
        return $this->dbHandle->RunQuery($query);
    }

    public function GetApplicants($select,$where=false){

        $query=$this->dbSelect->Select($this->table,$select,$where);

        if($this->cache) {
             return $this->GetFromCache($query);
            $result = pg_fetch_all($this->dbHandle->RunQuery($query));
            return $result;
        }
        else {
            return pg_fetch_all($this->dbHandle->RunQuery($query));
        }
    }

    public function DeleteApplicant($where){
        $query=$this->dbDelete->Delete($this->table,$where);
        $result=$this->dbHandle->RunQuery($query);
        if($this->cache)
            $this->cache->flush();

        return  $result;
    }

    private function GetFromCache($query)
    {
        //sprawdzamy czy korzystamy z cache
        if($this->cache){
            //sprawdzamy w cache
            if($result=$this->cache->get($query))
                return $result;

    //        jeśli nie ma, robimy query na bazie
            $result = pg_fetch_all($this->dbHandle->RunQuery($query));
            //wstawiamy od cachu
            $this->cache->set($query,$result);
         return $result;
        }
    }


    public function CloseConnection()
    {
        $this->dbHandle->CloseConnection();
    }
}