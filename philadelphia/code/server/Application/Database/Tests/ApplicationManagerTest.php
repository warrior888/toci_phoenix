<?php

require_once "../ApplicationManager.php";
/**
 * Created by PhpStorm.
 * User: ohai
 * Date: 8/4/15
 * Time: 10:07 PM
 */
$manager=new ApplicantManager();

var_dump($manager->GetApplicants('*'));
