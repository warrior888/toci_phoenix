<?php

	$json['message']="Zapisano aplikacje w bazie danych";
    $json['result']=true;

	echo json_encode($json);

	exit;

require_once "SendMail.php";
require_once "MailAddressValidator.php";

/* Nazwy z formularza:
 * contact-input-name - imie 
 * contact-input-mail - mail
 * contact-input-subject - temat
 * contact-input-message - wiadomosc
 */

//sprawdzenie czy dane istnieja
if(!(isset($_POST['contact-input-name'])&&
isset($_POST['contact-input-email'])&&
isset($_POST['contact-input-subject'])&&
isset($_POST['contact-input-message'])
))
{
die("Brak wszystkich danych"); // brak wszystkich dnaych
}


$askerMailAddress= $_POST['contact-input-email'];

if(!MailAddressValidator::checkMail($askerMailAddress))
{
    die("Podany email:".$askerMailAddress." jest nieprawidłowy");
}

//sprawdzenie czy request jest ajaxowy
if(!(isset($_SERVER['HTTP_X_REQUESTED_WITH']) && !empty($_SERVER['HTTP_X_REQUESTED_WITH']) && strtolower($_SERVER['HTTP_X_REQUESTED_WITH']) == 'xmlhttprequest'))
{
    die("Zablokowano ajax");
}

$askerName = $_POST['contact-input-name'];
$askerSubject= $_POST['contact-input-subject'];
$askerMessage= $_POST['contact-input-message'];

$mail=new MailSender();
$result = $mail->SendMail($askerSubject,$askerMessage,$askerMailAddress,$askerName);

$message = $result ? 'Mail wysłano pomyślnie.' : 'Wystąpił błąd przy próbie wysłania maila.';

echo json_encode(array('result' => $result, 'message' => $message));