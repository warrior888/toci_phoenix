<?php

	class Db
	{
		protected $DbHandle;

		public function __construct()
		{
			$this->DbHandle = new DbHandle();
		}

		public function Save($table, $items)
		{
			//generate insert
			//DbHandle Query
			$insert = 'insert into '.$table. ' (implode $items keys) values (implode $items values);';



			$this->DbHandle->Query($query);
		}
	}