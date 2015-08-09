



<?php echo $_SESSION['user_name']; ?>

<a href="" onclick="window.open('views/addClient.php', 'newwindow', 'width=300, height=250'); return false;"> Dodaj klienta</a>
<a href="" onclick="window.open('views/addService.php', 'newwindow', 'width=300, height=250'); return false;"> Dodaj usługę</a>
<a href="" onclick="window.open('views/manageClient.php', 'newwindow', 'width=300, height=250'); return false;"> Zarządzaj klientami</a>
<a href="" onclick="window.open('views/manageService.php', 'newwindow', 'width=300, height=250'); return false;"> Zarządzaj usługami</a>
<a href="" onclick="window.open('views/newInvoice.php', 'newwindow', 'width=300, height=250'); return false;"> Generuj fakturę</a>


<a href="index.php?logout">Logout</a>