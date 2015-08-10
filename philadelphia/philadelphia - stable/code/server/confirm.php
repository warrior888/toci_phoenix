<link href="../css/style.css" rel="stylesheet">

<style>

	body {
		margin: 0;
		padding: 0;
	}g

</style>

<?php

require_once "Db.php";

	if (isset($_GET['signature']))
	{
		ob_start();
		
		$db=new Db();
		$signature=$_GET['signature'];
		$result=$db->Get("applicants","mailconfirmed, signature"," signature='$signature'");
		$array=pg_fetch_array($result);


		if($array["mailconfirmed"]=="f")
		{
			$db->Set("applicants","mailconfirmed=true","signature='".pg_escape_string($signature)."'");
			$komunikat = '<div id="answerContainer" class="alert alert-success">Zapisano aplikację w bazie danych.</div>';
		}
		else
		{
			$komunikat = '<div id="answerContainer" class="alert alert-danger">Podany link aktywacyjny został juz wykorzystany.</div>';
		}
		
		ob_clean();
		
		echo $komunikat;
	}

