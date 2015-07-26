
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
            //set_error_handler(array($this, 'errorHandler'), E_WARNING);
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
