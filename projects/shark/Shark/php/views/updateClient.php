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

include_once "../Database/ClientManager.php";

if(!isset($_POST['action'])){

    $manager=new ClientManager();
    $client=$manager->GetClient("*","   id=".$_GET['client']."    ")[0];

    echo '
<form action="updateClient.php" method="post">
    <table>
    <pre>
    <tr><td>Nazwa</td><td> <input type="text" name="name" value="'.$client["name"].'"></td></tr>
    <tr><td>Ulica</td><td> <input type="text" name="address" value="'.$client["address"].'"></td></tr>
    <tr><td>Kod pocztowy</td><td> <input type="text" name="postalcode" value="'.$client["postalcode"].'"></td></tr>
    <tr><td>Miasto</td><td> <input type="text" name="city" value="'.$client["city"].'"></td></tr>
    <tr><td>NIP</td><td> <input type="text" name="nip" value="'.$client["nip"].'"></td></tr>
    <input type="hidden" name="id" value="'.$_GET['client'].'">
    <tr><td align="right"><input type="submit" name="action" value="Zapisz"></td>
    </pre>
    </table>
</form>
';}
 else{

    $client=array();
    $client['name']=$_POST['name'];
    $client['address']=$_POST['address'];
    $client['postalcode']=$_POST['postalcode'];
    $client['city']=$_POST['city'];
    $client['nip']=$_POST['nip'];

    $manager=new ClientManager();
//     echo $manager->UpdateClient($client,"   id=".$_POST['id']."    ",true);
     if(!$manager->UpdateClient($client,"   id=".$_POST['id']."    ")){
        die("Wystąpił błąd podczas zapisu do db");
    }{
        echo "Dodano klienta<br />";
        echo '<a href="JavaScript:window.close()" id="zamknij" class="button">Zamknij okno</a>';
    }

}

