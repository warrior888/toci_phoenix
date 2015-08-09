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

        $nabywca="Imie i nazwisko/Tytuł: ".$client['name']."<br />Adres: ".$client['address']."<br />kod pocztowy: ".$client['postalcode'].
            "<br />Miasto: ".$client['city']."<br />NIP:".$client['nip'];



        $invoice = '<table border=1 width=80% align="center">
    <tr><th colspan="2" align="right"><b>ORYGINAŁ</b></th></tr>
    <tr><td colspan="2" align="center"><b>FAKTURA VAT NR ' . $number . '</b></td></tr>
    <tr><td rowspan="4">SPRZEDAWCA<br />' . SPRZEDAWCA . '</td>
        <td>Data Wystawienia:' . getdate() . '</td></tr><tr><td>Data Sprzedaży:' . getdate() . '</td></tr>
     <tr><td rowspan="2">NABYWCA:<br />' . $nabywca . '</td>
        </tr><tr></tr><tr><td colspan="2">koncowa linia</td></tr></table>';

        echo $invoice+"<br/><br/>";




        $table= '
<table>
  <tr>
    <th>Lp.</th>
    <th>Nazwa</th>
    <th>Ilość</th>
    <th>Cena <br />jedn.<br />(zł.)</th>
    <th>VAT<br />(%)</th>
    <th>Kwota<br />VAT(zł.)</th>
    <th>Wartość<br />Netto(zł.)</th>
    <th>Wartość<br />Brutto(zł.)</th>
  </tr>
  <tr>
    <td>11</td>
    <td>22</td>
    <td>33</td>
    <td>44</td>
    <td>55</td>
    <td>66</td>
    <td>77</td>
    <td>88</td>
  </tr>
  <tr>
    <td colspan="5">999</td>
    <td>111</td>
    <td>222</td>
    <td></td>
  </tr>
</table>
        ';












    }