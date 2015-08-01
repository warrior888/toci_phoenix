<?php

require_once "Db.php";

	if (isset($_GET['signature']))
	{
		$db=new Db();
		$signature=$_GET['signature'];
		$result=$db->Get("applicants","mailconfirmed, signature"," signature='$signature'");
		$array=pg_fetch_array($result);

		echo "<pre>";
		var_dump($array);

		if($array["mailconfirmed"]=="f")
		{
			$db->Set("applicants","mailconfirmed=true","signature='".pg_escape_string($signature)."'");
			echo "<br><br>Mail zostal potweirdzony";
		}
		else{
			echo "<br><br>ten link aktywacyjny zostal juz wykorzystany";
		}
	}