


<?php

include "../ClientManager.php";
include_once "../ServiceManager.php";
include_once "../../config.php";
include_once "../../utils.php";
include_once "../Lib/Kwota.php";


    function prepareNabywca($client){
        return "<b>Imie i nazwisko/Tytuł:</b> ".$client['name']."<br /><b>Adres:</b> ".$client['address']."<br /><b>Kod pocztowy:</b> ".$client['postalcode'].
        "<br /><b>Miasto: </b>".$client['city']."<br /><b>NIP: </b>".$client['nip'];
    }

    function generateInvoiceUpperTable($invoiceNumber,$dataWystawienia, $dataSprzedazy, $nabywca, $original=true){

        $typ=$original?"ORGINAŁ":"KOPIA";

        return '
    <table border=1 width=80% align="center">
    <tr><th colspan="2" align="right"><b>'.$typ.'</b></th></tr>
    <tr><td colspan="2" align="center"><b>FAKTURA VAT NR ' . $invoiceNumber . '</b></td></tr>
    <tr><td rowspan="4"><b>SPRZEDAWCA</b><br />' . SPRZEDAWCA . '</td>
        <td><b>Data Wystawienia:</b>' . $dataWystawienia . '</td></tr><tr><td><b>Data Sprzedaży:</b>' . $dataSprzedazy  . '</td></tr>
     <tr><td rowspan="2"><b>Forma i Termin Płatności:</b><br />' . $_GET['payment'] .', '.getAheadDate($_GET['termin']).'</td>
        </tr><tr></tr><tr><td colspan="2"><b>NABYWCA</b><br>'.$nabywca.'</td></tr></table>';
    }


    function generateInvoiceDownTable($service){

        $price=intval($service['price']);

        $VatAmount=$price*0.23;
        $brutto=$price+$VatAmount;

        return '
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
    <td>'.$price.'</td>
    <td>'.$brutto.'</td>
  </tr>
  <tr>
    <td colspan="5" align="right"><b>Razem</b></td>
    <td>'.$VatAmount.'</td>
    <td>'.$price.'</td>
    <td>'.$brutto.'</td>
  </tr>
</table>
<table width=80% align="center"><tr><td><br><br> <b>Do zapłaty: </b>'.$brutto.' zł. (słownie: '.Kwota::getInstance()->slownie($brutto).').</td></tr></table> ';
    }

    function generateSignPlace($clientName,$sellerName){
        return  '
        <table width=80% align="center">
        <tr><td valign="top"><b>....................................................................<br>'.$clientName.'</b><td>
        <td align="right" valign="top"><b>....................................................................<br>'.$sellerName.',<br> uprawniony do wystawienia<br>
Faktury VAT.<br> </b><td></tr>

        </table>';
    }


    function genereteInvoice($client,$service)
    {
        header('Content-Type: text/html; charset=UTF-8');



        //zwracana faktura
        $returnInvoice=array();
        $returnInvoice['html']="<br>";


        //dane nabywcy do htmla
        $nabywca=prepareNabywca($client);


        $data=getTodaysDate();

        $returnInvoice["number"]=$service['invoiceNumber'];
        $returnInvoice["client_id"]=$client['id'];

        $returnInvoice['html'] .= generateInvoiceUpperTable($returnInvoice['number'],$data,$data, $nabywca);
        $returnInvoice['html'] .= odstep(2);
        $returnInvoice['html'] .= generateInvoiceDownTable($service);
        $returnInvoice['html'] .= odstep(6);
        $returnInvoice['html'] .= generateSignPlace($client['name'], "Bartłomiej Zapart");


        $returnInvoice['html'] .= odstep(21);

        
        $returnInvoice['html'] .= generateInvoiceUpperTable($returnInvoice['number'],$data,$data, $nabywca,false);
        $returnInvoice['html'] .= odstep(2);
        $returnInvoice['html'] .= generateInvoiceDownTable($service);
        $returnInvoice['html'] .= odstep(6);
        $returnInvoice['html'] .= generateSignPlace($client['name'], "Bartłomiej Zapart");



        return $returnInvoice;
    }


        //pobranie danych
        $manager=new ClientManager();
        $client=$manager->GetClient("*","id=".$_GET['client'])[0];
        $manager->CloseConnection();

        $manager=new ServiceManager();
        $service=$manager->GetService("*","id=".$_GET['service'])[0];
        $manager->CloseConnection();


        if(!empty($_GET['price'])){
            $service['price']=$_GET['price'];
        }

        if(!empty($_GET['invoiceNumber'])){
            $service['invoiceNumber']=$_GET['invoiceNumber'];
        }else{
            $service['invoiceNumber']=getNextInvoiceNumber();
        }





//generowanie, wyswietlenie htmla i zapis do bazy
        $invoice=genereteInvoice($client,$service);
        echo $invoice['html'];
        $invoice['html']=base64_encode($invoice['html']);
        $manager=new InvoiceManager();
        $manager->AddInvoice($invoice);


