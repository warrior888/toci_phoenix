<?php

require_once 'DbHandle.php';

	class Db
	{
		private $DbHandle;

		public function Db()
		{
			$this->DbHandle=new DbHandle();
			$this->DbHandle->dbConnect();
		}


		public function Save($table, $items)
		{
			//generate insert
			//DbHandle Query
			$insert = 'insert into '.$table. " (".implode(',',array_keys($items)).") values (".implode(',',array_values($items)).")";

			$this->DbHandle->Query($query);
		}
	}
