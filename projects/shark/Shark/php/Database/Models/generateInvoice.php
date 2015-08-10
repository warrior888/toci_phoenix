<?php

include "../ClientManager.php";
include_once "../ServiceManager.php";
include_once "../../config.php";
include_once "../../utils.php";


    function genereteInvoice($clientId,$serviceId)
    {
        header('Content-Type: text/html; charset=UTF-8');
        $returnInvoice="";

        $manager=new ClientsManager();
        $client=$manager->GetClient("*","id=".$clientId)[0];
        $manager->CloseConnection();

        $manager=new ServiceManager();
        $service=$manager->GetService("*","id=".$serviceId)[0];
        $manager->CloseConnection();


        $nabywca="<b>Imie i nazwisko/Tytuł:</b> ".$client['name']."<br /><b>Adres:</b> ".$client['address']."<br /><b>Kod pocztowy:</b> ".$client['postalcode'].
            "<br /><b>Miasto: </b>".$client['city']."<br /><b>NIP:</b>".$client['nip'];

        $data=getTodaysDate();

        $invoice = '
    <table border=1 width=80% align="center">
    <tr><th colspan="2" align="right"><b>ORYGINAŁ</b></th></tr>
    <tr><td colspan="2" align="center"><b>FAKTURA VAT NR ' . getNextInvoiceNumber() . '</b></td></tr>
    <tr><td rowspan="4"><b>SPRZEDAWCA</b><br />' . SPRZEDAWCA . '</td>
        <td><b>Data Wystawienia:' . $data . '</td></tr><tr><td>Data Sprzedaży:</b>' . $data  . '</td></tr>
     <tr><td rowspan="2"><b>Format itp:</b><br />' . "cośtam" . '</td>
        </tr><tr></tr><tr><td colspan="2"><b>NABYWCA</b><br>'.$nabywca.'</td></tr></table>';

        $returnInvoice .= $invoice;

        $returnInvoice .= "<br><br>";

        //$service=$manager->GetService("*","id='".$_GET['service']."'");
        $price=intval($service['price']);
        $VatAmount=$price*0.23;
        $nettoAmount=$price-$VatAmount;
        $netto=$price-$nettoAmount;
        $brutto=$price+$nettoAmount;

        $table= '
<table border=1 width=80% align="center">
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
    <td>1</td>
    <td>'.$service['name'].'</td>
    <td>1</td>
    <td>'.$price.'</td>
    <td>23</td>
    <td>'.$VatAmount.'</td>
    <td>'.$nettoAmount.'</td>
    <td>'.$brutto.'</td>
  </tr>
  <tr>
    <td colspan="5" align="right"><b>Razem</b></td>
    <td>'.$VatAmount.'</td>
    <td>'.$nettoAmount.'</td>
    <td>'.$brutto.'</td>
  </tr>
</table>
        ';

        $returnInvoice .= $table;

        return $returnInvoice;
    }

    if(isset($_GET['client'])&&
        isset($_GET['service'])){
        echo genereteInvoice($_GET['client'],$_GET['service']);
    }

