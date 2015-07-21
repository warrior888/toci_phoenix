<?php

require_once "DbHandle.php";
require_once 'Db.php';

$dbTable="applicants";

$applicant['name']="'Jan'";
$applicant['surname']="'Magic'";
$applicant['phone']="'666420360'";
$applicant['email']="'ur6000@gmail.com'";

$db=new Db();
$db->Save($dbTable,$applicant);
