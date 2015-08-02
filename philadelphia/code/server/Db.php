
<?php

require_once 'DbHandle.php';

	class Db
	{
		public $DbHandle;

		public function Db()
		{
			$this->DbHandle=new DbHandle();
			$this->DbHandle->dbConnect();
		}

		

		public function Save($table, $items)
		{
			$items = $this->DbHandle->Escape($items);
			
			//generate insert
			//DbHandle Query                  //kol1, kol2
			$insert = 'insert into '.$table. " (".implode(',',array_keys($items)).") values ('".implode('\',\'',array_values($items))."')";

			return $this->DbHandle->Query($insert);
		}

		public function Get($table,$items,$where){
			
			//$items = pg_escape_string($items);
			//$where = pg_escape_string($where);
			
			$query="select $items from $table where $where";
			return $this->DbHandle->Query($query);
		}

		public function Set($table,$set,$where){

			//$items = pg_escape_string($items);
			//$where = pg_escape_string($where);
			
			$query="update $table set $set where $where";
			return $this->DbHandle->Query($query);
		}

	}
