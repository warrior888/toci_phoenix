<?php

    require_once '../ApplicationManager.php';

    $manager=new ApplicantManager();


    if(isset($_GET['getApplicants'])){
        echo json_encode($manager->GetApplicants($_GET['getApplicants']));
    }
