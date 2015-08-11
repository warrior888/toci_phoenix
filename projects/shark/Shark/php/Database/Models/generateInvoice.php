<?php

include "../ClientManager.php";
include_once "../ServiceManager.php";
include_once "../../config.php";
include_once "../../utils.php";
include_once "../Lib/Kwota.php";

    function genereteInvoice($clientId,$serviceId)
    {
        header('Content-Type: text/html; charset=UTF-8');
        $returnInvoice=array();
        $returnInvoice['html']="";

        $manager=new ClientsManager();
        $client=$manager->GetClient("*","id=".$clientId)[0];
        $manager->CloseConnection();

        $manager=new ServiceManager();
        $service=$manager->GetService("*","id=".$serviceId)[0];
        $manager->CloseConnection();


        $nabywca="<b>Imie i nazwisko/Tytuł:</b> ".$client['name']."<br /><b>Adres:</b> ".$client['address']."<br /><b>Kod pocztowy:</b> ".$client['postalcode'].
            "<br /><b>Miasto: </b>".$client['city']."<br /><b>NIP:</b>".$client['nip'];

        $data=getTodaysDate();

        $returnInvoice["number"]=getNextInvoiceNumber();
        $returnInvoice["client_id"]=$clientId;


        $invoice = '
    <table border=1 width=80% align="center">
    <tr><th colspan="2" align="right"><b>ORYGINAŁ</b></th></tr>
    <tr><td colspan="2" align="center"><b>FAKTURA VAT NR ' . $returnInvoice['number'] . '</b></td></tr>
    <tr><td rowspan="4"><b>SPRZEDAWCA</b><br />' . SPRZEDAWCA . '</td>
        <td><b>Data Wystawienia:</b>' . $data . '</td></tr><tr><td><b>Data Sprzedaży:</b>' . $data  . '</td></tr>
     <tr><td rowspan="2"><b>Format itp:</b><br />' . "cośtam" . '</td>
        </tr><tr></tr><tr><td colspan="2"><b>NABYWCA</b><br>'.$nabywca.'</td></tr></table>';

        $returnInvoice['html'] .= $invoice;

        $returnInvoice['html'] .= "<br><br>";

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

        $returnInvoice['html'] .= $table;

        $returnInvoice['html'] .= '<table width=80% align="center"><tr><td><br><br> <b>Do zapłaty: </b>'.$brutto.' zł. (słownie: '.Kwota::getInstance()->slownie($price).').</td></tr></table> ';

        $returnInvoice['html'] .='<br><br><br><br><br><br>';
        $returnInvoice['html'] .='

        <table width=80% align="center">
        <tr><td valign="top"><b>....................................................................<br>'.$client['name'].'</b><td>
        <td align="right" valign="top"><b>....................................................................<br>Bartłowiej Zapart,<br> uprawniony do wystawienia<br>
Faktury VAT.<br> </b><td></tr>

        </table>';


        $invoice = '
    <table border=1 width=80% align="center">
    <tr><th colspan="2" align="right"><b>KOPIA</b></th></tr>
    <tr><td colspan="2" align="center"><b>FAKTURA VAT NR ' . $returnInvoice['number'] . '</b></td></tr>
    <tr><td rowspan="4"><b>SPRZEDAWCA</b><br />' . SPRZEDAWCA . '</td>
        <td><b>Data Wystawienia:</b>' . $data . '</td></tr><tr><td><b>Data Sprzedaży:</b>' . $data  . '</td></tr>
     <tr><td rowspan="2"><b>Format itp:</b><br />' . "cośtam" . '</td>
        </tr><tr></tr><tr><td colspan="2"><b>NABYWCA</b><br>'.$nabywca.'</td></tr></table>';



        return $returnInvoice;
    }

    if(isset($_GET['client'])&&
        isset($_GET['service'])){
        $invoice=genereteInvoice($_GET['client'],$_GET['service']);
        echo $invoice['html'];
        $invoice['html']=base64_encode($invoice['html']);
        $manager=new InvoiceManager();
        $manager->AddInvoice($invoice);
    }

