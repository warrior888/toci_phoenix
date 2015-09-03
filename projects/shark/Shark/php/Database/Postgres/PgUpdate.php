<?php

require_once __DIR__.'/PgQuery.php';
require_once __DIR__.'/../Interfaces/IDbUpdate.php';

class PgUpdate extends PgQuery implements IDbUpdate {


	public function RenderQuery($table, $elements) {
		$query = sprintf($this->format, $table, implode(', ', array_keys($elements)), implode('\', \'', array_values($elements)));
		return $query;
	}

	public function Update($table, $data, $where = false) {
		$query = 'UPDATE ';

		$query .= $table;
		$query .= $this->CreateSetStatement($data);

		$query .= $this->CreateWhereStatement($where);


		$result = $query . ';';

		return $result;
	}

	public function CreateSetStatement($data) {

		$setStatement = ' SET ';

		if(is_array($data)) {
			foreach ($data as $column => $row) {
				$setStatement .=$column.'='."'$row',";
			}
			$setStatement = rtrim($setStatement, ', ');
		}else{
			$setStatement .=$data;
		}
		return $setStatement;
	}

}
