<?php

	class DbHandle 
	{
	//postgres lub nie
		public function __construct ($dontUseEnc = false)
        {
            $this->dontUseEnc = $dontUseEnc;
        }

	
        
        public function dbConnect()
        {
            if (!isset($this->database))
	    {
		    //podane dane tylko dla testu czy bedzie w stanie sie polaczyc
		    //wczesniej tutaj byla zmienna con_str
		    //trzeba wstawic dane serwer koncowego
                $this->database = pg_pconnect("host=46.101.236.160 user=toci password=aaa111 dbname=toci");
                if (!$this->dontUseEnc)
                    pg_set_client_encoding ($this->database, 'LATIN2');
            }
            return $this->database;
        }
        public function dbClose()
        {
            pg_close($this->database);
        }
        public function Query($query)
        {
            //$h = fopen('/var/www/html/eena/devel/query', 'a');
            //fputs($h, $query."\n");  
            //echo $query."<br>";
 	    //$this->trySaveAuditLog($query);
            //$time = microtime(true);
            set_error_handler(array($this, 'errorHandler'), E_WARNING);
            $this->currentQuery = $query;
            $this->result = pg_query($this->dbConnect(), $query);
            $this->currentQuery = '';
            restore_error_handler();
            //$end = microtime(true);
            //$res = $end - $time;
            //fputs($h, "pgQuery in ".$res."\n");
            //fclose($h); 
            return $this->result;
        }
        public function PobierzDane($zapytanie, &$ilosc_wierszy = 0)
        {
            //$h = fopen('/var/www/html/eena/devel/query', 'a');
            //fputs($h, $zapytanie."\n");
            set_error_handler(array($this, 'errorHandler'), E_WARNING);
            $this->currentQuery = $zapytanie;
            $result = pg_query($this->dbConnect(), $zapytanie);
            $this->currentQuery = '';
            //fputs($h, "poszlo\n");
            $newArray = pg_fetch_all($result);

            restore_error_handler();
            $ilosc_wierszy = $newArray ? sizeof($newArray) : 0;
            //fclose($h);
            if($newArray)
            {
                return $newArray;
            }            
            else
            {
                return null;
            }
        }
	}
/*

    //converting to singleton - the only reasonable option; construct public - backward compatibility
    class dal
    {
        const STATUS_ID_AKTYWNY   = 1;
        const STATUS_ID_PASYWNY   = 4;
        
        const SESSION_FIELD_USER    = 'user';
        
        protected $database;            
        protected $con_str = DATABASE_CONNECTION_STRING;
        protected $userData;
        
        public $result;
        private $queries = array("queryName" => 'select id, nazwa from imiona order by nazwa asc;', 
                            "queryGender" => 'select id, nazwa from plec order by nazwa asc;',
                            "queryMsc" => 'select id, nazwa from miejscowosc order by nazwa asc;',
                            "queryEdu" => 'select id, nazwa from wyksztalcenie order by nazwa asc;',
                            "queryChar" => 'select id, nazwa from charakter order by nazwa asc;',
                            "queryPas" => 'select id, nazwa from paszport order by nazwa asc;',
                            "queryAn" => 'select id, nazwa from ankieta order by nazwa asc;',
                            "querySrc" => 'select id, nazwa from zrodlo where widoczne = true order by nazwa asc;');
        
        protected $currentQuery = '';
        private $dontUseEnc = false;
        
        private static $instances = array();
        
        public static function getInstance ($dontUseEnc = false) 
        {
            $index = 'LATIN2';
            if ($dontUseEnc)
                $index = 'UTF8';
            
            if (isset(self::$instances[$index]))
            {
                return self::$instances[$index];
            }
            
            self::$instances[$index] = new dal($dontUseEnc);
            
            return self::$instances[$index];
        }
        
        public function __construct ($dontUseEnc = false)
        {
            $this->dontUseEnc = $dontUseEnc;
        }
        
        public function dbConnect()
        {
            if (!isset($this->database))
            {
                $this->database = pg_pconnect($this->con_str);
                if (!$this->dontUseEnc)
                    pg_set_client_encoding ($this->database, 'LATIN2');
            }
            return $this->database;
        }
        public function dbClose()
        {
            pg_close($this->database);
        }
        public function pgQuery($query)
        {
            //$h = fopen('/var/www/html/eena/devel/query', 'a');
            //fputs($h, $query."\n");  
            //echo $query."<br>";
            $this->trySaveAuditLog($query);
            //$time = microtime(true);
            set_error_handler(array($this, 'errorHandler'), E_WARNING);
            $this->currentQuery = $query;
            $this->result = pg_query($this->dbConnect(), $query);
            $this->currentQuery = '';
            restore_error_handler();
            //$end = microtime(true);
            //$res = $end - $time;
            //fputs($h, "pgQuery in ".$res."\n");
            //fclose($h); 
            return $this->result;
        }
        public function PobierzDane($zapytanie, &$ilosc_wierszy = 0)
        {
            //$h = fopen('/var/www/html/eena/devel/query', 'a');
            //fputs($h, $zapytanie."\n");
            set_error_handler(array($this, 'errorHandler'), E_WARNING);
            $this->currentQuery = $zapytanie;
            $result = pg_query($this->dbConnect(), $zapytanie);
            $this->currentQuery = '';
            //fputs($h, "poszlo\n");
            $newArray = pg_fetch_all($result);

            restore_error_handler();
            $ilosc_wierszy = $newArray ? sizeof($newArray) : 0;
            //fclose($h);
            if($newArray)
            {
                return $newArray;
            }            
            else
            {
                return null;
            }
        }
        public function __wakeup ()
        {
            $this->database = null;
            $this->dbConnect();
        }
        public function escapeString ($string)
        {
            if ($string === null) {
                return null;
            }    
            return pg_escape_string($string);
        }
        public function escapeInt($int) 
        {
            return (int)$int;
        }
        
        public function escapeInt64($int) {
            
            if (preg_match('/^[0-9]+$/', $int))
                return $int;
                
            return 0;
        }
        
        public function escapeBool ($bool)
        {
            if ($bool)
                return 'true';
                
            return 'false';
        }
        
        public function errorHandler ($errno, $errstr, $errfile, $errline, $errcontext) {
            
            if (false === pg_connection_status($this->database))
                throw new DBException('Database error running query - db down: '.$errstr);
            else {
                
                LogManager::log($errno, 'DB error: '.$errstr.' in '.$errfile.' on line '.$errline.', sql: '.$this->currentQuery); //.', trace: '.var_export(debug_backtrace(), true)
                throw new DBQueryErrorException('SQL query failure: '.$errstr.' in '.$errfile.' on line '.$errline.', sql: '.$this->currentQuery);
            }
        }
        
        public function trySaveAuditLog($query) {
            
            if (stripos($query, 'insert') !== false || stripos($query, 'update') !== false || stripos($query, 'delete') !== false)
            {
                $_query = $this->escapeString($query);
                
                if (!isset($this->userData[Model::COLUMN_UPR_ID]))
                {
                    $sessionData = SessionManager::get(self::SESSION_FIELD_USER);
                
                    if ($sessionData)
                        $this->userData = $sessionData;
                }
                
                if (isset($this->userData[Model::COLUMN_UPR_ID]))
                {
                    $logEntry = 'insert into audyt_log (id_uprawnienia, zapytanie) values 
                    	('.$this->userData[Model::COLUMN_UPR_ID].', \''.$_query.'\')';
                    $result = pg_query($this->dbConnect(), $logEntry);
                }
            }
        }
    }
	

