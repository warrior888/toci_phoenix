<?php

require_once "../SendMail.php";
require_once "../MailAddressValidator.php";


$askerMailAddress= "1010000i100@gmail.com";
$askerName = "Mailer Janusz";
$askerSubject= "The Police";


if(!MailAddressValidator::checkMail($askerMailAddress))
{
    die("Podany email:".$askerMailAddress." jest nieprawidłowy");
}


$askerMessage= "Przesłał: ".$askerName.", mail: ".$askerMailAddress." <br/ ><br /> Testy raz dwa trzy";


$mail=new MailSender();
$result = $mail->SendMail($askerSubject,$askerMessage,"tociszkolenia@gmail.com",$askerName);

$message = $result ? 'Mail wysłano pomyślnie.' : 'Wystąpił błąd przy próbie wysłania maila.';

echo json_encode(array('result' => $result, 'message' => $message));
