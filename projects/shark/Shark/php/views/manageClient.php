
<?php

include "../Database/ClientManager.php";

if(isset($_GET['action'])){
	$manager=new ClientManager();
	if(!$manager->DeleteClient("id=".$_GET['client'])){
		echo "Wystąpił błąd";
	}

}

$manager=new ClientManager();
$clients=$manager->GetClient("id, name");

$html='<form method="get"><select name="client">';

foreach($clients as $value)
{
	$html .= '<option value="'.$value['id'].'">'.$value['id']." ".$value['name'].'</option>';
}

$html .= '</select>';


$html .= '
    <button type="submit" name="action" value="delete" formaction="manageClient.php">Delete</button>
    <button formaction="updateClient.php">Modify</button>
    ';
$html .= "</form>";

echo $html;