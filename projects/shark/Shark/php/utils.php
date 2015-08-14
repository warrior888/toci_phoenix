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
    return date('Y-m-d',strtotime(date("Y-m-d", mktime())));
}

function getAheadDate($days)
{
    return date('Y-m-d',strtotime(date("Y-m-d", mktime()) . " + ".$days." day"));
}

function getClientNameById($id){

    $manager=new ServiceManager();
    $services=$services=array_reverse($manager->GetService("*"));


}


function slownie ($kw) {

    $t_a = array('','sto','dwieście','trzysta','czterysta','pięćset','sześćset','siedemset','osiemset','dziewięćset');
    $t_b = array('','dziesięć','dwadzieścia','trzydzieści','czterdzieści','pięćdziesiąt','sześćdziesiąt','siedemdziesiąt','osiemdziesiąt','dziewięćdziesiąt');
    $t_c = array('','jeden','dwa','trzy','cztery','pięć','sześć','siedem','osiem','dziewięć');
    $t_d = array('dziesięć','jedenaście','dwanaście','trzynaście','czternaście','piętnaście','szesnaście','siednaście','osiemnaście','dziewiętnaście');

    $t_kw_15 = array('septyliard','septyliardów','septyliardy');
    $t_kw_14 = array('septylion','septylionów','septyliony');
    $t_kw_13 = array('sekstyliard','sekstyliardów','sekstyliardy');
    $t_kw_12 = array('sekstylion','sekstylionów','sepstyliony');
    $t_kw_11 = array('kwintyliard','kwintyliardów','kwintyliardy');
    $t_kw_10 = array('kwintylion','kwintylionów','kwintyliony');
    $t_kw_9 = array('kwadryliard','kwadryliardów','kwaryliardy');
    $t_kw_8 = array('kwadrylion','kwadrylionów','kwadryliony');
    $t_kw_7 = array('tryliard','tryliardów','tryliardy');
    $t_kw_6 = array('trylion','trylionów','tryliony');
    $t_kw_5 = array('biliard','biliardów','biliardy');
    $t_kw_4 = array('bilion','bilionów','bilony');
    $t_kw_3 = array('miliard','miliardów','miliardy');
    $t_kw_2 = array('milion','milionów','miliony');
    $t_kw_1 = array('tysiąc','tysięcy','tysiące');
    $t_kw_0 = array('złoty','złotych','złote');

    if ($kw!='') {
        $kw=(substr_count($kw,',')==0) ? $kw.',00':$kw;
        $tmp=explode(",",$kw);
        $ln=strlen($tmp[0]);
        $tmp_a=($ln%3==0) ? (floor($ln/3)*3):((floor($ln/3)+1)*3);
        for($i = $ln; $i < $tmp_a; $i++) {
            $l_pad .= '0';
            $kw_w = $l_pad . $tmp[0];
        }
        $kw_w=($kw_w=='') ? $tmp[0]:$kw_w;
        $paczki=(strlen($kw_w)/3)-1;
        $p_tmp=$paczki;
        for($i=0;$i<=$paczki;$i++) {
            $t_tmp='t_kw_'.$p_tmp;
            $p_tmp--;
            $p_kw=substr($kw_w,($i*3),3);
            $kw_w_s=($p_kw{1}!=1) ? $t_a[$p_kw{0}].' '.$t_b[$p_kw{1}].' '.$t_c[$p_kw{2}]:$t_a[$p_kw{0}].' '.$t_d[$p_kw{2}];
            if(($p_kw{0}==0)&&($p_kw{2}==1)&&($p_kw{1}<1)) $ka=${$t_tmp}[0]; //możliwe że $p_kw{1}!=1
            else if (($p_kw{2}>1 && $p_kw{2}<5)&&$p_kw{1}!=1) $ka=${$t_tmp}[2];
            else $ka=${$t_tmp}[1];
            $kw_slow.=$kw_w_s.' '.$ka.' ';
        }
    }
    $text = $kw_slow.' '.$tmp[1].'/100 gr.';
    return $text;
}


function odstep($int){

    $return="";

    while($int--)
        $return.="<br>";

    return $return;
}