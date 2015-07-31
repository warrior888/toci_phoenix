<?php

require_once "SendMail.php";

//var_dump($_POST);

/* Nazwy z formularza:
 * contact-input-name - imie 
 * contact-input-mail - mail
 * contact-input-subject - temat
 * contact-input-message - wiadomosc
 */

//sprawdzenie czy dane istnieja
if(!(isset($_POST['contact-input-name'])&&
isset($_POST['contact-input-mail'])&&
isset($_POST['contact-input-subject'])&&
isset($_POST['contact-input-message'])
))
{
die("Brak wszystkich danych"); // brak wszystkich dnaych
}

$askerName = $_POST['contact-input-name'];
$askerMailAddress= $_POST['contact-input-mail'];

//???

$askerSubject= $_POST['contact-input-subject'];
$askerMessage= $_POST['contact-input-message'];


$mail=new MailSender();
$result = $mail->SendMail($askerSubject,$askerMessage,$askerMailAddress,$askerName);

$message = $result ? 'Mail wysłano pomyślnie.' : 'Wystąpił błąd przy próbie wysłania maila.';

echo json_encode(array('result' => $result, 'message' => $message));
