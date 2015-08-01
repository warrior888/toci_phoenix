<?php

ob_start();
require_once "Db.php";
require_once 'MailConfirm.php';

/* Nazwy z formularza: narazie sa inne,
 * applicantName
 * applicantSurname
 * applicantEmail
 * applicantPhone
 */

if(!(isset($_SERVER['HTTP_X_REQUESTED_WITH']) && !empty($_SERVER['HTTP_X_REQUESTED_WITH']) && strtolower($_SERVER['HTTP_X_REQUESTED_WITH']) == 'xmlhttprequest')) {
    die("Zablokowano nie-ajax");
}

if(!(isset($_POST['applicantName'])&&
    isset($_POST['applicantSurname'])&&
    isset($_POST['applicantEmail'])&&
    isset($_POST['applicantPhone'])
))
{
    die("Brak wszystkich danych"); // brak wszystkich dnaych
}

$applicant['name'] = $_POST['applicantName'];
$applicant['surname'] = $_POST['applicantSurname'];
$applicant['email'] = $_POST['applicantEmail'];
$applicant['phone'] = $_POST['applicantPhone'];
$mailConf=new MailConfirm();
$applicant['mailconfirmed']="false";
$applicant['signature']=$mailConf->sendConfirmationMail($applicant);
$db=new Db();


$dbTable='applicants';
$result=$db->Save($dbTable,$applicant);

$json=array();

if ($result==false)
{
    $json['message']="Wystąpił błąd przy próbie zapisania:".pg_last_error($db->DbHandle->database);
    $json['result']=false;
}
else{
    $json['message']="Przeczytaj maila aby potwierdzić rejestracje";
    $json['result']=true;
}

ob_clean();

echo json_encode($json);


