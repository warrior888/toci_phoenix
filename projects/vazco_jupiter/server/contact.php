﻿<?php

require_once "Mail.php";

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
die("Brak wszystkic hdanych"); // brak wszystkich dnaych
}

$askerName = $_POST['contact-input-name'];
$askerMailAddress= $_POST['contact-input-mail'];
$askerSubject= $_POST['contact-input-subject'];
$askerMessage= $_POST['contact-input-message'];


$mail=new MailSend();
$mail->WyslijMail($askerMessage,$askerSubject,$askerMailAddress,$askerMailAddress);
