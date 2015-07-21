<?php

require_once "Db.php";


$dbTable='applicants';

/* Nazwy z formularza: narazie sa inne,
 * applicantName
 * applicantSurname
 * applicantEmail
 * applicantPhone
 */



$applicant['name'] = $_POST['applicantName'];
$applicant['surname'] = $_POST['applicantSurname'];
$applicant['email'] = $_POST['applicantEmail'];
$applicant['phone'] = $_POST['applicantPhone'];



$db=new Db();

$db->Save($dbTable,$applicant);
$db->DbHandle->dbClose();
