<?php

require_once "SendMail.php";
require_once "MailAddressValidator.php";


//blokowanie nie ajaxa
if(!(isset($_SERVER['HTTP_X_REQUESTED_WITH']) && !empty($_SERVER['HTTP_X_REQUESTED_WITH']) && strtolower($_SERVER['HTTP_X_REQUESTED_WITH']) == 'xmlhttprequest')) {
    die("Niepoprawny request");
}

//sprawdzenie czy dane istnieja
if(!(isset($_POST['met_full_name'])&&
    isset($_POST['Mail'])&&
    isset($_POST['Subject'])&&
    isset($_POST['Message']))) {
    die("Brak wszystkich danych"); // brak wszystkich dnaych
}


$askerMailAddress= $_POST['Mail'];

if(!MailAddressValidator::checkMail($askerMailAddress))
{
    die("Podany email:".$askerMailAddress." jest nieprawidłowy");
}

$askerName = $_POST['met_full_name'];
$askerSubject= $_POST['Subject'];

$askerMessage= "Przesłał: ".$askerName.", mail: ".$askerMailAddress." <br/ ><br />".$_POST['Message'];



$mail=new MailSender();
$result = $mail->SendMail($askerSubject,$askerMessage,"tociszkolenia@gmail.com");

$message = $result ? 'Mail wysłano pomyślnie.' : 'Wystąpił błąd przy próbie wysłania maila.';

echo json_encode(array('result' => $result, 'message' => $message));
