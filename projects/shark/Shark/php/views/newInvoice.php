

<?php

include_once __DIR__."/../Database/ClientManager.php";
include_once __DIR__."/../Database/ServiceManager.php";



$manager=new ClientsManager();
$clients=array_reverse($manager->GetClient("*"));

$manager->CloseConnection();

$manager=new ServiceManager();
$services=$services=array_reverse($manager->GetService("*"));

echo '<form action="../Database/Models/generateInvoice.php" method=\'get\'>';
echo "Wybierze klienta: ";
echo "<select name='client'>";

foreach($clients as $value)
{
    echo '<option value="'.$value['id'].'">'.$value['id']." ".$value['name'].'</option>';
}

echo "</select> za usługę ";
echo "<select name='service'>";

foreach($services as $value)
{
    echo '<option value="'.$value['id'].'">'.$value['id']." ".$value['name'].'</option>';
}
echo "</select> ";
echo "<input type='submit'>";
echo "</form>";