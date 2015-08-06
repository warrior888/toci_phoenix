<?php

require_once "../ApplicationManager.php";
///**
// * Created by PhpStorm.
// * User: ohai
// * Date: 8/4/15
// * Time: 10:07 PM
// */

//przykładowy aplicankts
$applicant=array();
$applicant['name'] = "jan";
$applicant['surname'] = "heszki";
$applicant['email'] = "wowowow@lololol.com.pl";
$applicant['phone'] = "wowowoo";
$applicant['mailconfirmed']="false";
$applicant['signature']="lubpelacki";
$applicant['chosencourse'] = "nie wiem";


$manager=new ApplicantManager();

echo "<b>Pobieranie wszystkich aplikantow:</b><br>";

var_dump ($manager->GetApplicants("name"));

echo "<br><b>Dodanie i pobranie z warunkiem</b><br>";

$manager->SaveApplicant($applicant);
var_dump($manager->GetApplicants("name,surname","name='jan' and surname='heszki' "));

echo "<br><b> Update <br></b>";
$manager->UpdateApplicants("name='zmienny'","name='jan'");

echo "<br><b>Usuwanie i zwracanie pustek wyniku</b><br>";
$manager->DeleteApplicant("name='jan' and surname='heszki'");
var_dump($manager->GetApplicants("name,surname","surname='heszki' "));