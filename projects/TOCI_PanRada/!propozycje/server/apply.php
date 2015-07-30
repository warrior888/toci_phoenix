<?php
ob_start();
require_once "Db.php";

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
$dbTable='applicants';


$db=new Db();

$result=$db->Save($dbTable,$applicant);


//$db->save zwraca wiadomość od postrgresa zamiast boola przy poprawnym zapisaniu
//dane trzeba skompletować w ten sposób innaczej będzie miało to wpływ na zapytanie ajaxowske z jsa
$json=array();

if ($result==false)
{
    $json['message']="Wystąpił błąd przy próbie zapisania";
    $json['result']=false;
}
else{
    $json['message']="Zapisano aplikacje w bazie danych";
    $json['result']=true;
}

ob_clean();
//if (isset($_SERVER['HHTP_X_XML']))
echo json_encode($json);
//else
//header();

