<?php

require_once 'DbHandle.php';

	class Db
	{
		public function Save($table, $items)
		{
			//generate insert
			//DbHandle Query
			$insert = 'insert into '.$table. " (".implode(',',array_keys($items)).") values (".implode(',',array_values($items)).")";

			$this->DbHandle->Query($query);
		}
	}
