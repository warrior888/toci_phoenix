<?php

include "Database/InvoiceManager.php";

function getMonth()
{
    var_dump(date_parse(getdate()['month'])['month']);
}

function getNextInvoiceNumber(){
    $manager=new InvoiceManager();
    $lastInvoiceNumber=intval($manager->GetInvoice("max(id)")[0]['max']);
    var_dump($lastInvoiceNumber);
    //$invoice
    //$numbers=explode("/",)
}

getNextInvoiceNumber();