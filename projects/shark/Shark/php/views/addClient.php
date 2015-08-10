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

if(!isset($_POST['add'])) {

    echo '
<form action="addClient.php" method="post">
    <table>
    <pre>
    <tr><td>Nazwa</td><td> <input type="text" name="name"></td></tr>
    <tr><td>Ulica</td><td> <input type="text" name="address"></td></tr>
    <tr><td>Kod pocztowy</td><td> <input type="text" name="postalcode"></td></tr>
    <tr><td>Miasto</td><td> <input type="text" name="city"></td></tr>
    <tr><td>NIP</td><td> <input type="text" name="nip"></td></tr>
    <tr><td></td><td align="right"><input type="submit" name="add" value="Dodaj"></td>
    </pre>
    </table>
</form>
';
} else{

    $client=array();
    $client['name']=$_POST['name'];
    $client['address']=$_POST['address'];
    $client['postalcode']=$_POST['postalcode'];
    $client['city']=$_POST['city'];
    $client['nip']=$_POST['nip'];

    $manager=new ClientsManager();
    if(!$manager->AddClient($client)){
        die("Wystąpił błąd podczas zapisu do db");
    }{
        echo "Dodano klienta<br />";
        echo '<a href="JavaScript:window.close()" id="zamknij" class="button">Zamknij okno</a>';
    }

}

