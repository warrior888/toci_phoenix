<?php

require_once '../ApplicationManager.php';

echo "Pobranie 100x wszystkich aplikantow bez cache:<br><br>";

$manager=new ApplicantManager();
$manager->cache=false;

$time=microtime(true);
for($i=0;$i<100;$i++)
    $manager->GetApplicants('*');
echo "Czas: ".(microtime(true)-$time);

//tracimy połączenie do pierwsze Managera bya destruktor mógł zamknąć bazę

$manager=0;

echo "<br><br>Pobranie 100x wszystkich aplikantow z cache:<br><br>";


$manager=new ApplicantManager();
$manager->cache=new Memcache();
$manager->cache->connect("127.0.0.1","11211");

$time=microtime(true);
for($i=0;$i<100;$i++)
    $manager->GetApplicants('*');


echo "Czas: ".(microtime(true)-$time);

