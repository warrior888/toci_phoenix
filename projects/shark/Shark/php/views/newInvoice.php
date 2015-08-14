
<?php

header('Content-Type: text/html; charset=UTF-8');

include_once __DIR__."/../Database/ClientManager.php";
include_once __DIR__."/../Database/ServiceManager.php";
include_once __DIR__."/../utils.php";


$manager=new ClientManager();
$clients=array_reverse($manager->GetClient("id,name"));

$manager->CloseConnection();

$manager=new ServiceManager();
$services=$services=array_reverse($manager->GetService("*"));


echo '<form action="../Database/Models/generateInvoice.php" method=\'get\'>';
echo "<table border=2>";
echo "<tr>";
echo "<td>Klient: </td>";
echo "<td><select name='client'>";

foreach($clients as $value)
{
	echo '<option value="'.$value['id'].'">'.$value['id']." ".$value['name'].'</option>';
}

echo "</select></td><tr><td>";
echo "Usługa:</td><td>";
echo "<select name='service'>";

foreach($services as $value)
{
	echo '<option value="'.$value['id'].'">'.$value['id']." ".$value['name'].'</option>';
}
echo "</select></td></tr> ";

echo "<tr><td>Płatność</td>";
echo "<td><select name='payment'>";

echo '<option value="Przelew"">Przelew</option>';
echo '<option value="Gotówka"">Gotówka</option>';

echo '</select></td></tr>';


echo "<tr><td>Płatność</td>";
echo '<td>
<input type="text" name="termin" value="7"> dni
</td></tr>';

echo '<tr><td>Nr faktury</td><td><input type="text"  value="'. getNextInvoiceNumber() .'"  name="invoiceNumber"></td></tr>';

echo '<tr><td>Cena</td><td><input type="text" name="price"></td></tr>';


echo '<tr><td colspan="2" align="right"><input type="submit"></td></tr>';
echo "</form></table>";
