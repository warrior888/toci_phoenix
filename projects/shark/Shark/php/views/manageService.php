
<?php

    include "../Database/ServiceManager.php";

    if(isset($_GET['action'])){
        $manager=new ServiceManager();
        if(!$manager->DeleteService("id=".$_GET['service'])){
            echo "Wystąpił błąd";
        }

    }

    $manager=new ServiceManager();
    $services=$manager->GetService("id, name");

    $html='<form method="get"><select name="service">';

    foreach($services as $value)
    {
        $html .= '<option value="'.$value['id'].'">'.$value['id']." ".$value['name'].'</option>';
    }

    $html .= '</select>';


    $html .= '
    <button type="submit" name="action" value="delete" formaction="manageService.php">Delete</button>
    <button formaction="updateService.php">Modify</button>
    ';
    $html .= "</form>";

    echo $html;