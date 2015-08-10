<?php

ob_start();
require_once "Db.php";
require_once 'MailConfirm.php';
require_once "MailAddressValidator.php";
require_once 'Application/Database/ApplicationManager.php';

if(!(isset($_SERVER['HTTP_X_REQUESTED_WITH']) && !empty($_SERVER['HTTP_X_REQUESTED_WITH']) && strtolower($_SERVER['HTTP_X_REQUESTED_WITH']) == 'xmlhttprequest')) {
    die("Niepoprawne żądanie. ");
}

if(!(isset($_POST['applicantName'])&&
    isset($_POST['applicantSurname'])&&
    isset($_POST['applicantEmail'])&&
    isset($_POST['applicantPhone'])&&
    isset($_POST['applicantChosenCourse'])
))
{
    die("Brak wszystkich danych"); 
}



$json=array();

//walidacja maila
$applicant['email'] = $_POST['applicantEmail'];
if(!MailAddressValidator::checkMail($applicant['email']))
{
    $json['message'] = "Podany email: ".htmlentities($applicant['email'])." jest nieprawidłowy.";
    $json['result']=false;
    
    ob_clean();
    
    echo json_encode($json);
    die();
}

$mailConf=new MailConfirm();
$applicant['name'] = $_POST['applicantName'];
$applicant['surname'] = $_POST['applicantSurname'];
$applicant['phone'] = $_POST['applicantPhone'];
$applicant['mailconfirmed']="false";
$applicant['signature']=$mailConf->sendConfirmationMail($applicant);
$applicant['chosencourse'] = $_POST['applicantChosenCourse'];

$manager=new ApplicantManager();


$result=$manager->SaveApplicant($applicant);

if ($result==false)
{
    $json['message']="Wystąpił nieoczekiwany błąd przy próbie zapisania."; //.pg_last_error($db->DbHandle->database);
    $json['result']=false;
}
else{
    $json['message']="Na podany adres e-mail wysłano wiadomość. Aby potwierdzić rejestrację należy postąpić zgodnie z instrukcjami w wiadomości.";
    $json['result']=true;
}

ob_clean();

echo json_encode($json);


