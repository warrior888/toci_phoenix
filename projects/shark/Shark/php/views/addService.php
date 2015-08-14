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

if(!isset($_POST['add'])) {

	echo '
<form action="addService.php" method="post">
    <table>
    <pre>
    <tr><td>Nazwa</td><td> <input type="text" name="name"></td></tr>
    <tr><td>Cena</td><td> <input type="text" name="price"></td></tr>
    <tr><td></td><td align="right"><input type="submit" name="add" value="Dodaj"></td>
    </pre>
    </table>
</form>
';
} else{

	$service=array();
	$service['name']=$_POST['name'];
	$service['price']=$_POST['price'];

	$manager=new ServiceManager();
	if(!$manager->AddService($service)){
		die("Wystąpił błąd podczas zapisu do db");
	}{
		echo "Dodano usługę<br />";
		echo '<a href="JavaScript:window.close()" id="zamknij" class="button">Zamknij okno</a>';
	}

}

