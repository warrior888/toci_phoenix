<?php

include "Database/InvoiceManager.php";

function getMonth()
{
    return date_parse(getdate()['month'])['month'];
}

function getNextInvoiceNumber(){
    $manager=new InvoiceManager();
    $numberOfLastInvoice=explode("/",$manager->GetInvoice("number","id=".intval($manager->GetInvoice("max(id)")[0]['max']))[0]["number"]);
    $newNumber=array();

    //sprawdzamy miesiac z ostatniej faktury
    if(intval($numberOfLastInvoice[1])==getMonth()){
        //jeśli nie jest zgodny z aktualnym miesiacem, pobieramy numer ostatniej faktury i dodajemy jeden
        $newNumber[0]=intval($numberOfLastInvoice[0])+1;
    }else{
        //albo ustawiamy 1, jako pierwsza faktura miesiaca
        $newNumber[0]=01;
    }

    //aktualny miesiac
    $newNumber[1]=intval(getMonth());

    //nowy rok narazie bez implementacji
    $newNumber[2]=2015;

    return implode("/",$newNumber);
}

function getTodaysDate()
{
    return getdate()['mday']."/".getMonth()."/".getdate()['year'];
}

$manager=new InvoiceManager();
$numberOfLastInvoice=explode("/",$manager->GetInvoice("number","id=".intval($manager->GetInvoice("max(id)")[0]['max']))[0]["number"]);

