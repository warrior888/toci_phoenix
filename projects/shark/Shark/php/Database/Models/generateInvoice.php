<?php

include "../ClientManager.php";
include_once "../ServiceManager.php";
include_once "../../config.php";

    if(isset($_GET['client'])&&
        isset($_GET['service'])
    //    isset($_GET['number'])
    )
    {
        $manager=new ClientsManager();
        $client=$manager->GetClient("*","id=".$_GET['client'])[0];
        $manager->CloseConnection();

        $manager=new ServiceManager();
        $service=$manager->GetService("*","id=".$_GET['service'])[0];
        $manager->CloseConnection();

        $number="02/02/0202";

        //var_dump($client);

        $nabywca="Imie i nazwisko/Tytuł: ".$client['name']."<br />Adres: ".$client['address']."<br />kod pocztowy: ".$client['postalcode'].
            "<br />Miasto: ".$client['city']."<br />NIP:".$client['nip'];



        $invoice = '<table border=1 width=80% align="center">
    <tr><th colspan="2" align="right"><b>ORYGINAŁ</b></th></tr>
    <tr><td colspan="2" align="center"><b>FAKTURA VAT NR ' . $number . '</b></td></tr>
    <tr><td rowspan="4">SPRZEDAWCA<br />' . SPRZEDAWCA . '</td>
        <td>Data Wystawienia:' . getdate() . '</td></tr><tr><td>Data Sprzedaży:' . getdate() . '</td></tr>
     <tr><td rowspan="2">NABYWCA:<br />' . $nabywca . '</td>
        </tr><tr></tr><tr><td colspan="2">koncowa linia</td></tr></table>';

        echo $invoice;
    }