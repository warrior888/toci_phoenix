<style>
a.button {
	-webkit-appearance: button;
	-moz-appearance: button;
	appearance: button;
	text-decoration: none;
	color: initial;
}
</style>

<?php

include_once "../Database/ServiceManager.php";

if(!isset($_POST['action'])){

	$manager=new ServiceManager();
	$service=$manager->GetService("*","   id=".$_GET['service']."    ")[0];

	echo '
<form action="updateService.php" method="post">
    <table>
    <pre>
    <tr><td>Nazwa</td><td> <input type="text" name="name" value="'.$service["name"].'"></td></tr>
    <tr><td>Cena</td><td> <input type="text" name="price" value="'.$service["price"].'"></td></tr>

    <input type="hidden" name="id" value="'.$_GET['service'].'">
    <tr><td align="right"><input type="submit" name="action" value="Zapisz"></td>
    </pre>
    </table>
</form>
';}
	else{

		$service=array();
		$service['name']=$_POST['name'];
		$service['price']=$_POST['price'];


		$manager=new ServiceManager();
		//     echo $manager->UpdateService($service,"   id=".$_POST['id']."    ",true);
		if(!$manager->UpdateService($service,"   id=".$_POST['id']."    ")){
			die("Wystąpił błąd podczas zapisu do db");
		}{
			echo "Zaktualizowano<br />";
			echo '<a href="JavaScript:window.close()" id="zamknij" class="button">Zamknij okno</a>';
		}

	}

