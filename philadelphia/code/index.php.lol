<?php
if (!(isset($_COOKIE['currentLanguage']))) {
    setcookie('currentLanguage', 'polish', time() + 60 * 60 * 24 * 365, '/');
} else {
    $language = $_COOKIE['currentLanguage'];
    unset($_COOKIE['currentLanguage']);
    setcookie('currentLanguage', $language, time() + 60 * 60 * 24 * 365, '/');
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="description" content="Bezpłatne i płatne kursy programowania w C# lub PHP">
        <meta name="author" content="Toci Team, tociszkolenia@gmail.com">
        <title>Bezpłatne i płatne kursy programowania w C# lub PHP i innych technologiach</title>
        <link rel="icon" href="favicon.ico" type="image/x-icon">
        <!--		<link rel="shortcut icon" href="images/favicon.png">-->

        <!--loader-->

        <link href="css/loader.css" rel="stylesheet">



        <!-- Main Stylesheet -->

        <link href="css/faq-style.css" rel="stylesheet">
        <link href="css/style.css" rel="stylesheet">
        <!--<link href="css/bootstrap.min.css" rel="stylesheet">-->
        <link href="css/embed-responsive.css" rel="stylesheet">



        <link href="css/owl.carousel.min.css" rel="stylesheet">
        <link href="css/owl.theme.default.min.css" rel="stylesheet">


        <link href='http://fonts.googleapis.com/css?family=Exo&subset=latin,latin-ext' rel='stylesheet' type='text/css'>
        <link href='http://fonts.googleapis.com/css?family=Just+Me+Again+Down+Here&subset=latin,latin-ext' rel='stylesheet' type='text/css'>



        <!-- HTML5 shiv and Respond.js IE8 support of HTML5 elements and media queries -->
        <!--[if lt IE 9]>
        <script src="js/html5shiv.js"></script>
        <script src="js/respond.min.js"></script>
        <![endif]-->


        <link rel="stylesheet" href="css/ladda-themeless.min.css">

        <!--Translation styles:-->
        <link rel="stylesheet" href="css/translation.css">
        <link rel="stylesheet" href="css/hover-min.css">



    </head>



    <body id="homepage" data-spy="scroll" data-target=".navbar" data-offset="100">

        <!--loader-->
        <div id="loader" class="sk-cube-grid">
            <div class="sk-cube sk-cube1"></div>
            <div class="sk-cube sk-cube2"></div>
            <div class="sk-cube sk-cube3"></div>
            <div class="sk-cube sk-cube4"></div>
            <div class="sk-cube sk-cube5"></div>
            <div class="sk-cube sk-cube6"></div>
            <div class="sk-cube sk-cube7"></div>
            <div class="sk-cube sk-cube8"></div>
            <div class="sk-cube sk-cube9"></div>
        </div>

        <script src="js/loader-position.js"></script>
        <!--loader-->



        <div id="home"></div>





        <div id="content" style="visibility: hidden;">
            <!-- ========== HEADER START ========== -->

            <header>

                <!-- ==== TOOLS START ==== -->
                <div class="tools">
                    <div class="container">
                        <ul class="pull-left">
                            <li><a href="tel:1800123456"><i class="fa fa-phone"></i><span style="color:white;">570-751-507</span></a></li>
                            <li><a href="mailto:tociszkolenia@gmail.com"><i class="fa fa-envelope"></i><span style="color:white;">tociszkolenia@gmail.com</span></a></li>
                        </ul>
                        <!--TRANSLATION START-->
                        <ul class="pull-right">
                            <li><input type="image" src="images/state_flags/pl.png" id="flag-pl" class="state-flag"/></li>
                            <li><input type="image" src="images/state_flags/uk.png" id="flag-uk" class="state-flag"/></li>
                            <li><input type="image" src="images/state_flags/de.png" id="flag-de" class="state-flag"/></li>
                        </ul>
                        <!--TRANSLATION END-->
                    </div>
                </div>
                <!-- ==== TOOLS END ==== -->

                <!-- ==== NAVBAR START ==== -->
                <div class="navbar navbar-default navbar-static-top" role="navigation">
                    <div class="container">
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <img src="images/toci-logo.png" alt="{TOCI} szkolenia programowania" class="img-responsive logo" />
                        </div>
                        <nav class="navbar-collapse collapse">
                            <ul class="nav navbar-nav navbar-right">
                                <li><a class="page-scroll" id="homeClick" href="#homepage">Start</a></li>
                                <li><a class="page-scroll" id="aboutClick" href="#about-section">O kursie</a></li>
                                <li><a class="page-scroll" id="howItWorksClick" href="#howItWorks-section">Jak to działa?</a></li>
                                <li><a class="page-scroll" id="organisersClick" href="#organisers-section">Prelegent</a></li>
                                <li><a class="page-scroll" id="videoClick" href="#video-section">Video</a></li>
                                <li><a class="page-scroll" id="faqClick" href="#faq-section">FAQ</a></li>
                                <li><a class="page-scroll" id="promotionClick" href="#promotion-section">PROMOCJE</a></li>
                                <li><a class="page-scroll" id="applyClick" href="#apply-section">Aplikuj</a></li>
                                <li><a class="page-scroll" id="contactClick" href="#contact-section">Kontakt</a></li>
                            </ul>
                        </nav>
                    </div>
                </div>
                <!-- ==== NAVBAR END ==== -->

            </header>

            <!-- ========== HEADER END ========== -->

            <!-- ========== BANNER START ========== -->

            <div id="slides">
                <div class="slides-container">
                    <img src="images/slider1.jpg" class="img-responsive" alt="home background" />
                    <img src="images/slider2.jpg" class="img-responsive" alt="home background" />
                    <img src="images/slider3.jpg" class="img-responsive" alt="home background" />

                    <!--<img src="http://placehold.it/1600x900.jpg" alt="" />
                    <img src="http://placehold.it/1600x900.jpg" alt="" />-->
                </div>
                <div class="tint"></div>
                <div class="slider-offers text-center">
                    <ul>
                        <li>
                            <div id="welcome-text1" class="text-center">
                                <h3>BEZPŁATNA NAUKA PROGRAMOWANIA</h3>
                                <h4>Nasi kursanci otrzymują zatrudnienie</h4>
                                <p><a class="btn btn-primary page-scroll" id="applyHomeClick" href="#apply-section">APLIKUJ</a></p>
                            </div>
                        </li>
                        <li>
                            <div id="welcome-text2" class="text-center">
                                <h3>REKRUTACJA TRWA</h3>
                                <h4>Partnerzy Toci poszukują pracowników</h4>
                                <p><a class="btn btn-primary page-scroll" id="checkHomeClick" href="#howItWorks-section">SPRAWDŹ</a></p>
                            </div>
                        </li>
                        <li>
                            <div id="welcome-text3" class="text-center">
                                <h3>Od zera do programisty</h3>
                                <h4>Wejdź w świat programowania i zdobądź dobrze płatny zawód</h4>
                                <p><a class="btn btn-primary page-scroll" id="coursesHomeClick" href="#about-section">NASZE KURSY</a></p>
                            </div>
                        </li>
                    </ul>
                </div>

                <!-- SLIDER OFFERS START -->

                <!-- SLIDER OFFERS END -->


                <a class="arrow page-scroll" href="#about-section">
                    <i class="fa fa-arrow-down fa-2x"></i>
                </a>
            </div>
            <!-- ========== BANNER END ========== -->

            <!-- ========== WELCOME START ========== -->

            <section id="about-section">
                <div class="container">
                    <div class="row text-center">
                        <div class="col-sm-12" data-scroll-reveal>
                            <h2 class="blackColor headers">O kursie</h2>

                            <p>Pasjonujesz się najnowszymi technologiami IT? Chciałbyś dowiedzieć się jak pracuje programista w profesjonalnym zespole? A może już programujesz, ale interesuje Cię inwestycja w technologię o wzrastającej popularności i popycie na rynku pracy? Ta oferta jest dla Ciebie!</p>
                        </div>

                    </div>

                    <br/>
                    <div class="row">
                        <div class="col-sm-6" data-scroll-reveal>
                            <img src="images/logo-c%23-asp-net_0.jpg" class="img-responsive center-block" alt=".Net logo"/>
                            <h3 class="text-transform-none">Cechy:</h3>
                            <ul data-scroll-reveal>
                                <li>nowoczesny, obiektowo orientowany język programowania</li>
                                <li>głęboka integracja z systemem  Windows i platformą Microsoft .Net, otwartość na inne technologie dzięki DLR</li>
                                <li>silna alternatywa dla Javy, posiadająca dodatkowo takie mechanizmy jak extension methods i LINQ</li>
                            </ul>

                            <br/>

                            <h3 class="text-transform-none">Zalety:</h3>
                            <ul data-scroll-reveal>
                                <li>opanowanie składni opartej na języku C# ułatwia naukę innych technologii (C++, PHP, Java) w przyszłości </li>
                                <li>duże zapotrzebowanie na rynku pracy</li>
                                <li>umiejętność ekspolatowania rozwiązań ofertowanych przez technologię C# i .NET Framework pozwala na budowanie architektur najbardziej złożonych aplikacji</li>
                                <li>jedna z najdynamiczniej rozwijających się technologii określająca nowe standardy tworzenia oprogramowania nieobecne w innych technologiach</li>
                            </ul>
                            <br/>

                            <button type="button" class="btn btn-primary center-block" data-toggle="modal" data-target="#c-sharp-modal">AGENDA</button>
                            <br/>
                        </div>

                        <div class="col-sm-6" data-scroll-reveal>
                            <img src="images/3d_php-logo.jpg" class="img-responsive center-block" alt="PHP logo"/>
                            <h3 class="text-transform-none">Cechy:</h3>
                            <ul data-scroll-reveal>
                                <li>język skryptowy, działający po stronie serwera</li>
                                <li>tworzenie dynamicznych stron WWW</li>
                                <li>komunikacja z bazami danych i wieloma innymi technologiami wsparcia</li>
                            </ul>

                            <br/>
                            <br/>
                            <br/>

                            <h3 class="text-transform-none">Zalety:</h3>
                            <ul data-scroll-reveal>
                                <li>bardzo popularna darmowa technologia z relatywnie niską barierą wejścia</li>
                                <li>możliwość zrealizowania projektu niskobudżetowego przygotowanego na ewentualny sukces na rynku</li>
                                <li>przystępna dla początkującego programisty (uproszczenia składni)</li>
                                <li>umożliwia również tworzenie rozbudowanych i zaawansowanych aplikacji (jak choćby Facebook :-) )</li>
                            </ul>

                            <br/>
                            <br/>
                            <br/>
                            <br/>

                            <button type="button" class="btn btn-primary center-block" data-toggle="modal" data-target="#php-modal">AGENDA</button>

                            <br/>
                        </div>
                    </div>

                </div>


                <br/><br/>
                <br/><br/>
                <div class="row text-center" style="font-size:25px;">
                    <div class="col-sm-12">
                        <p>KODUJ W <span class="greenTemplateColor">C#</span> LUB <span class="greenTemplateColor">PHP</span>, ZDOBĄDŹ POSADĘ <span class="greenTemplateColor">JUNIOR DEVELOPERA</span>!</p>
                    </div>

                </div>


                <!-- MODALS-->

                <!--MODAL C#-->
                <div id="c-sharp-modal" class="modal fade" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">X</button>
                                <h3 class="modal-title">Poglądowa agenda C#</h3>
                            </div>
                            <div class="modal-body" style="font-size: large;">

                                <ol>
                                    <li>
                                        <b>Podstawy</b>
                                        <ul>
                                            <li>Pojecie klasy, obiektu, statyczność vs instancja</li>
                                            <li>Kwalifikatory dostępu do klasy, obiektu, ich zachowanie</li>
                                            <li>Dziedziczenie i kwalifikatory dostępu</li>
                                            <li>Abstract, virtual, override, sealed, new</li>
                                            <li>Typy referencyjne i wartościowe, wzorzec projektowy chain of responsibility</li>
                                            <li>Interfejsy</li>
                                            <li>Przeciążenia</li>
                                            <li>Dziedziczenie vs kompozycja</li>
                                            <li>Delegaty, lambda, generics</li>
                                            <li>Extension methods</li>
                                            <li>Using, idisposable</li>
                                            <li>Struct i enum</li>

                                        </ul>
                                    </li>

                                    <li>
                                        <b>Framework</b>
                                        <ul>
                                            <li>String operations</li>
                                            <li>Interfaces – ilist, ienumerable, idisposable, ICloneable</li>
                                            <li>IO</li>
                                            <li>Collections, arrays</li>
                                            <li>Delegaty - Func<>, Action, Predicate</li>
                                            <li>Dictionary, List, inne Generics</li>
                                            <li>LINQ</li>
                                            <li>Tpl, Async, Await, Taskfactory</li>
                                            <li>Atrybuty</li>
                                            <li>Xml</li>
                                            <li>Refleksja</li>
                                        </ul>
                                    </li>

                                    <li>

                                        <b>Wzorce projektowe</b>

                                        <ul>

                                            <li>SOLID</li>
                                            <li>Singleton</li>
                                            <li>Polimorfizm</li>
                                            <li>Strategia</li>
                                            <li>Fabryka</li>
                                            <li>Łańcuch zależności</li>
                                            <li>Wstrzykiwanie zależności</li>
                                            <li>MVC</li>
                                            <li>TDD(nunit, mock, stub)</li>

                                        </ul>
                                    </li>

                                    <li>
                                        <b>MVC</b>

                                        <ul>
                                            <li>Protokół http</li>
                                            <li>Model</li>
                                            <li>Widok</li>
                                            <li>Kontroler</li>
                                            <li>Komunikacja</li>
                                            <li>Routing</li>
                                            <li>Razor vs aspx</li>
                                            <li>Grid</li>
                                            <li>Security</li>
                                            <li>Web api</li>
                                        </ul>

                                    </li>

                                    <li>
                                        <b>	Windows Service</b>
                                    </li>
                                    <li>
                                        <b>WCF</b>
                                        <ul>
                                            <li>Contract</li>
                                            <li>Proxy</li>
                                        </ul>
                                    </li>

                                    <li>
                                        <b>Bazy danych</b>
                                        <ul>
                                            <li>SQL</li>
                                            <li>ADO</li>
                                            <li>Clustering</li>
                                            <li>Sharding</li>
                                            <li>Polimorficzny db access</li>
                                            <li>Entity framework, pojęcie ORM</li>
                                            <li>Własne polimorficzne generyczne rozwiązanie dostępu do bazy danychy</li>
                                        </ul>
                                    </li>

                                    <li>
                                        <b>JavaScript</b>
                                        <ul>
                                            <li>JSON</li>
                                            <li>Ajax</li>
                                            <li>Jquery</li>
                                            <li>Prototypowe dziedziczenie</li>
                                            <li>Progressive enhancement</li>
                                            <li>Operacje na domie</li>
                                            <li>Walidacje formularzy</li>
                                            <li>Pojęcie SPA (Single Page Apllication)</li>
                                        </ul>
                                    </li>

                                    <li>
                                        <b>SQL</b>
                                        <ul>

                                            <li>CRUD, DDL, DML</li>
                                            <li>Joins</li>
                                            <li>No SQL (memcache, tyrant, redis, mongoDB, casandra)</li>
                                            <li>Join vs sharding</li>
                                            <li>Wydajność</li>
                                            <li>Sphinx</li>
                                            <li>Softbool</li>
                                        </ul>
                                    </li>

                                </ol>

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Zamknij</button>
                            </div>
                        </div>


                    </div>

                </div>

                <!-- /MODAL C#-->


                <!-- MODAL PHP-->

                <div id="php-modal" class="modal fade" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">X</button>
                                <h3 class="modal-title">Agenda PHP</h3>
                            </div>
                            <div class="modal-body" style="font-size: large;">

                                <ol>
                                    <li>
                                        Podstawy
                                        <ul>
                                            <li>Pojęcie zmiennej</li>
                                            <li>Typy danych, tablice</li>
                                            <li>Operatory</li>
                                            <li>Instrukcje warunkowe</li>
                                            <li>Pętle</li>
                                            <li>Algorytmika</li>
                                            <li>Funkcje</li>
                                            <li>Programowanie strukturalne, zasięg zmiennych</li>
                                            <li>Require, zawieranie plików</li>
                                            <li>Funkcje biblioteczne PHP – przegląd</li>
                                            <li>Operacje na plikach/katalogach</li>
                                        </ul>
                                    </li>

                                    <li>

                                        Obiektowość

                                        <ul>
                                            <li>Pojęcie klasy</li>
                                            <li>Obiekt</li>
                                            <li>Modyfikatory dostępu</li>
                                            <li>Statyczność</li>
                                            <li>Interfejsy</li>
                                            <li>Klasy abstrakcyjne</li>
                                            <li>Konstruktory</li>
                                            <li>Dziedziczenie</li>
                                            <li>Przesłonienie, sposób na przeciążenie w PHP</li>
                                            <li>Polimorfizm</li>
                                            <li>Typy referencyjne</li>
                                            <li>Kompozycja, enkapsulacja</li>
                                        </ul>
                                    </li>

                                    <li>

                                        Protokól http

                                        <ul>
                                            <li>Wyjaśnienie komunikacji klient serwer</li>
                                            <li>Formaty i struktura żądania http</li>
                                            <li>Bezstanowość</li>
                                            <li>Snifery, podsłuchiwanie ruchu</li>
                                        </ul>
                                    </li>
                                    <li>

                                        Bezpieczeństwo

                                        <ul>
                                            <li>Session fixation</li>
                                            <li>XSRF</li>
                                            <li>XSS</li>
                                            <li>SQL injection</li>
                                            <li>Code injection</li>
                                        </ul>
                                    </li>
                                    <li>

                                        Wzorce projektowe

                                        <ul>
                                            <li>Strategia</li>
                                            <li>Fabryka</li>
                                            <li>Chain of responsibility</li>
                                            <li>Fasada</li>
                                            <li>Singleton</li>
                                        </ul>
                                    </li>
                                    <li>

                                        MVC

                                        <ul>
                                            <li>Koncepcja</li>
                                            <li>Architektura</li>
                                            <li>Stosowanie</li>
                                            <li>Dependency injection</li>
                                        </ul>
                                    </li>
                                    <li>

                                        Architektury systemow przeznaczonych do wytrzymywania duzego obciążenia, technologie wsparcia

                                        <ul>
                                            <li>Worker</li>
                                            <li>API</li>
                                        </ul>
                                    </li>
                                    <li>

                                        Systemy skalowalne

                                        <ul>
                                            <li>Architektury i rozwiązania algorytmiczne systemów przygotowanych do pracy na dużych obciążeniach</li>
                                            <li>Testowanie jednostkowe, integracyjne, obciążeniowe, nagios</li>
                                        </ul>
                                    </li>
                                </ol>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Zamknij</button>
                            </div>
                        </div>
                    </div>
                    <!-- /MODAL PHP-->
                    <!-- /MODALS-->
                </div>

            </section>





            <!-- ========== RECENT COURSES START ========== -->


            <section id="howItWorks-section" class="alt-background">
                <div class="container">
                    <div class="row text-center">

                        <div class="col-sm-12"  data-scroll-reveal>
                            <h2 class="blackColor headers">Jak to działa?</h2>
                            <p>
                                Kursy prowadzone są przez Bartłomieja Zapart - programistę z 10 letnim doświadczeniem, które zdobywał w wielu prestiżowych firmach - m.in. Microsoft, Gadu-Gadu, Unit4.
                            </p>
                        </div>
                        <br/>


                    </div>
                    <br/>
                    <div class="row">
                        <div class="col-sm-6" data-scroll-reveal>
                            <h3 style="text-transform: none;">Oferujemy:</h3>
                            <ul>
                                <li>intensywny kurs przygotowujący do pracy programisty</li>
                                <li>dla najlepszych płatne staże oraz pracę</li>
                                <li>opracowanie ścieżki indywidualnego rozwoju zawodowego</li>
                            </ul></div>

                        <div class="col-sm-6" data-scroll-reveal>
                            <h3 style="text-transform: none;">Oczekujemy:</h3>
                            <ul>

                                <li>determinacji, pracowitości, ambicji i sumienności</li>
                                <li>komputera z dostępem do internetu oraz słuchawek z mikrofonem</li>
                                <li>co najmniej podstawowej umiejętności komunikacji w języku angielskim</li>
                                <li>w przypadku kursów wyższych niż podstawowy na kurs prowadzona jest rozmowa kwalifikacyjna weryfikująca bazę wiedzy do kursu np. średniozaawansowanego</li>
                            </ul>
                        </div>

                    </div>
                    <br/>
                    <div class="row text-center">
                        <div class="col-sm-6 etapy" data-scroll-reveal>

                            <!--<h2 class="greenTemplateColor">I Etap</h2>-->
                            <h3 class="blackColor">Kurs podstawowy</h3>
                            <p>
                                Kurs podstawowy skierowany jest do osób rozpoczynających swoją przygodę z programowaniem całkowicie od podstaw.
                                Jeśli miałeś/aś styczność z programowaniem, próbuj swoich sił bezpośrednio na darmowym kursie średnio zaawansowanym!
                                Kursanci od podstaw będą uczyć się programowania w języku PHP lub C# w zależności od wyboru przez okres siedmiu tygodni. Cena kursu podstawowego to <strong>492 PLN</strong> brutto za cały kurs - NIE DOTYCZY APLIKUJĄCYCH NA ŚREDNIO ZAAWANSOWANY.
                                Kurs można kontynuować na poziomie średnio zaawansowanym (w PHP LUB C#) bezpłatnie z perspektywą zatrudnienia jako Junior Developer - dobrze do tego przygotowujemy, ale intensywna praca własna jest konieczna!
                                Aby wziąć udział w naszych kursach należy uzupełnić  swoje dane w sekcji <strong><a href="#apply-section">Aplikuj</a></strong>!
                            </p><br><br>

                            <div class="col-sm-6"><button type="button" class="btn btn-primary center-block" style = "margin-bottom: 10px " data-toggle="modal" data-target="#c-sharp-basic-modal">AGENDA podstaw C#</button></div>
                            <div class="col-sm-6"> <button type="button" class="btn btn-primary center-block" style = "margin-bottom: 10px " data-toggle="modal" data-target="#php-basic-modal">AGENDA podstaw PHP</button></div>
                        </div>

                        <div class="col-sm-6"></div>

                        <!--MODAL C# BASIC-->
                        <div id="c-sharp-basic-modal" class="modal fade" role="dialog">
                            <div class="modal-dialog">

                                <!-- Modal content-->
                                <div class="modal-content text-justify">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">X</button>
                                        <h3 class="modal-title">Agenda podstawowego kursu C#</h3>
                                    </div>
                                    <div class="modal-body" style="font-size: large;">

                                        <ol>
                                            <li>
                                                <b>Wprowadzenie</b>
                                                <ul>
                                                    <li>Środowisko</li>
                                                    <li>Typy aplikacji – aplikacja konsolowa</li>
                                                    <li>Repozytorium</li>
                                                </ul>
                                            </li>

                                            <li>
                                                <b>Podstawy</b>
                                                <ul>
                                                    <li>Zmienne / pola</li>
                                                    <li>Typy zmiennych – rewizja elementarnych typów danych</li>
                                                    <li>Operatory</li>
                                                    <li>Instrukcje warunkowe</li>
                                                    <li>Pętle</li>
                                                    <li>Funkcje – metody</li>
                                                    <li>Tablice</li>
                                                    <li>Algorytmika</li>
                                                    <li>Programowanie funkcyjne</li>
                                                </ul>
                                            </li>

                                            <li>

                                                <b>Obiektowość</b>

                                                <ul>

                                                    <li>Klasa</li>
                                                    <li>Obiekt klasy</li>
                                                    <li>Klasa statyczna</li>
                                                    <li>Modyfikatory dostępu</li>
                                                    <li>Dziedziczenie</li>
                                                    <li>Enkapsulacja</li>
                                                    <li>Abstrakcja</li>
                                                    <li>Interfejs</li>
                                                    <li>Polimorfizm</li>

                                                </ul>
                                            </li>

                                        </ol>

                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Zamknij</button>
                                    </div>
                                </div>


                            </div>

                        </div>
                        <!-- /MODAL C# BASIC-->

                        <!--MODAL PHP BASIC-->
                        <div id="php-basic-modal" class="modal fade" role="dialog">
                            <div class="modal-dialog">

                                <!-- Modal content-->
                                <div class="modal-content text-justify">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">X</button>
                                        <h3 class="modal-title">Agenda podstawowego kursu  PHP</h3>
                                        <br>
                                        <h6 class="modal-title">Agenda tego szkolenia nie jest jednoznaczna dlatego,
                                            że najprawdopodobniej zostanie ono
                                            rozdzielone na 2 szkolenia w zależności od postępu
                                            kursantów. Poniżej prawdopodobny przebieg
                                            szkolenia w wariancie optymistycznym: </h6>
                                    </div>
                                    <div class="modal-body" style="font-size: large;">

                                        <ol>
                                            <li>
                                                <b>Fundamentals: </b>
                                                <ul>
                                                    <li>Pojęcie zmiennej</li>
                                                    <li>Typy danych, tablice </li>
                                                    <li>Operatory</li>
                                                    <li>Instrukcje warunkowe</li>
                                                    <li>Pętle</li>
                                                    <li>Algorytmika</li>
                                                    <li>Funkcje</li>
                                                    <li>Programowanie strukturalne, zasięg zmiennych</li>
                                                    <li>Require, zawieranie plików</li>
                                                    <li>Funkcje biblioteczne PHP – przegląd</li>
                                                    <li>Operacje na plikach/katalogach</li>
                                                </ul>
                                            </li>

                                            <li>
                                                <b>Obiektowość (wariant powstania mocniejszej grupy):</b>
                                                <ul>
                                                    <li>Pojęcie klasy</li>
                                                    <li>Obiekt</li>
                                                    <li>Modyfikatory dostępu</li>
                                                    <li>Statyczność</li>
                                                    <li>Interfejsy</li>
                                                    <li>Klasy abstrakcyjne </li>
                                                    <li>Konstruktory</li>
                                                    <li>Dziedziczenie</li>
                                                    <li>Przesłonienie, sposób na przeciążenie w PHP</li>
                                                </ul>
                                            </li>

                                        </ol>

                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Zamknij</button>
                                    </div>
                                </div>


                            </div>

                        </div>
                        <!-- /MODAL PHP BASIC-->

                    </div>
                    <div class="row text-center">
                        <div class="col-sm-6" data-scroll-reveal>
                            <img id="arrow-right" src="images/arrow-right.png" style="float:right;"/>
                        </div>
                    </div>




                    <div class="row text-center">

                        <div  class="col-sm-offset-6 col-sm-6 etapy" data-scroll-reveal>
                            <!--<h2 class="greenTemplateColor">II Etap</h2>-->
                            <h3 class="blackColor" style="">Kurs średniozaawansowany</h3>
                            <p>
                                Został przewidziany dla osób posiadających podstawową wiedzę programistyczną. Kandydat będzie mógł wybrać swoją drogę rozwoju i język programowania spośród PHP lub C#.
                                Ten kurs jest całkowicie bezpłatny!
                            </p>
                        </div>

                        <div class="row text-center">
                            <div class="col-sm-offset-6 col-sm-6" data-scroll-reveal>
                                <img id="arrow-left" src="images/arrow-left.png" style="float:left;"/>
                            </div>
                        </div>


                        <div class="row text-center">
                            <div class="col-sm-6" data-scroll-reveal>
                                <p>
                                    <strong>Kursy są prowadzone online</strong>, nagrywane i udostępniane do ponownego odtworzenia, dodatkowo uczestnicy będą pracować
                                    na wspólnym repozytorium kodu i tworzyć na nim zadania po każdej sesji kursu, a nawet symulowane mikro projekty
                                    przygotowujące uczestników do pracy programisty w rzeczywistych warunkach - przy niekompletnych i niejasnych specyfikacjach oraz nieadekwatnych architekturach ;-).
                                    Po kursie, lub w niektórych przypadkach nawet w trakcie ;-), pomagamy napisać dobre CV oraz wysyłamy na rekutację. Pilni kursanci dostają pracę nawet w trakcie trwania kursu !
                                </p>

                            </div>
                        </div>
                        <br/>
                        <br/>

                        <div class="row text-center">
                            <div class="col-sm-12" data-scroll-reveal>

                                <p>
                                    Dodatkowo uczestnicy kursu zostaną zaproszeni na sesje wykładowe o bazach danych, jako bonus za uczestnictwo w szkoleniu.
                                </p>
                            </div>
                        </div>

                    </div>


                </div>
            </section>

            <!-- ========== RECENT COURSES END ========== -->

            <!-- ========== SEARCH START ========== -->


            <section id="organisers-section">



                <div class="container">
                    <div class="row text-center">
                        <div class="col-sm-12 text-center" data-scroll-reveal>
                            <h2 class="blackColor headers">Prelegent</h2>
                        </div>
                        <br/>
                    </div>




                    <div class="row text-center">

                        <!--<div class="col-sm-6" data-scroll-reveal>-->
                        <!--<img src="images/Vazco.png" class="img-responsive center-block"/>-->

                        <!--<h3 style="text-transform: none;">Vazco</h3>-->
                        <!--<p>-->
                        <!--Dynamicznie rozwijająca się firma, działająca we Wrocławiu od 2008 roku, zajmująca się budową customowych portali w-->
                        <!--technologii Meteor dla klientów z całego świata-->
                        <!--</p>-->
                        <!--<br/>-->

                        <!--<a href="http://www.vazco.eu" target="_blank" class="btn btn-primary">www</a>-->
                        <!--<a href="http://www.vazco.eu" target="_blank" class="btn btn-primary">e-mail</a>-->
                        <!--</div>-->
                        <!--<br/>-->

                        <div class="col-sm-6" data-scroll-reveal>
                            <img src="images/Bartek.png" class="img-responsive center-block" style="border-radius:5px;"/>
                            <h3 style="text-transform: none;">Bartłomiej Zapart</h3>
                            <p>
                                Programista C#, PHP i JavaScript z dziesięcioletnim doświadczeniem komercyjnym w roli Senior Developera m.in. w GG Network, Microsoft, SMT czy Unit4.
                            </p>
                            <br/>
                            <a href="mailto:tociszkolenia@gmail.com" class="btn btn-primary">e-mail</a>
                        </div>
                        <h3 class="blackColor" data-scroll-reveal style="">Byli pracodawcy prelegenta</h3>
                        <div class="col-sm-3" data-scroll-reveal>
                            <img src="images/unit4-logo_partner-page_b.png" class="img-responsive center-block" style="border-radius:5px;"/>
                            <img src="images/gg-logo-small.png" class="img-responsive center-block" style="border-radius:5px;"/>
                            <img src="images/SMT-logo.png" class="img-responsive center-block" style="border-radius:5px;"/>
                        </div>
                        <div class="col-sm-3" data-scroll-reveal>
                            <img src="images/MSFT_logo_png.png" class="img-responsive center-block" style="border-radius:5px;"/>
                            <img src="images/sygnity-logo.jpg" class="img-responsive center-block" style="border-radius:5px;"/>
                            <img src="images/power-media-logo.jpg" class="img-responsive center-block" style="border-radius:5px;"/>
                        </div>
                    </div>
                </div>
            </section>
            <!--References-->

            <script>
                (function (d, s, id) {
                    var js, fjs = d.getElementsByTagName(s)[0];
                    if (d.getElementById(id))
                        return;
                    js = d.createElement(s);
                    js.id = id;
                    js.src = "//connect.facebook.net/pl_PL/sdk.js#xfbml=1&version=v2.3";
                    fjs.parentNode.insertBefore(js, fjs);
                }
                (document, 'script', 'facebook-jssdk'));
            </script>
            <div id="fb-root"></div>
            <div class="container">

                <div class="row text-center">
                    <div class="col-sm-12 text-center" data-scroll-reveal>
                        <h2 class="blackColor headers">Referencje</h2>
                    </div>
                    <br />
                </div>


                <div class="row" data-scroll-reveal>
                    <div id="references-carousel" class="owl-carousel text-center ">
                        <div class="item">
                            <div class="resizable-post">
                                <div class="fb-post" data-href="https://www.facebook.com/ttooccii/posts/1442945452694181" data-width="2000"></div></div>
                        </div>

                        <div class="item">
                            <div class="resizable-post">
                                <div class="fb-post" data-href="https://www.facebook.com/ttooccii/posts/1471130603208999" data-width="2000"></div>
                            </div>
                        </div>

                        <div class="item">
                            <div class="resizable-post">
                                <div class="fb-post" data-href="https://www.facebook.com/ttooccii/posts/1442941959361197" data-width="2000"></div>
                            </div>
                        </div>

                        <div class="item">
                            <div class="resizable-post">
                                <div class="fb-post" data-href="https://www.facebook.com/ttooccii/posts/1442353809420012" data-width="2000"></div>
                            </div>
                        </div>

                        <div class="item">
                            <div class="resizable-post">
                                <div class="fb-post" data-href="https://www.facebook.com/ttooccii/posts/1475893286066064" data-width="2000"></div>
                            </div>
                        </div>

                        <div class="item">
                            <div class="resizable-post">
                                <div class="fb-post" data-href="https://www.facebook.com/ttooccii/posts/1477853565870036" data-width="2000"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- OWL CAROUSEL END -->

                <!--/References-->
                <!--/Organisers-->
            </div>
            <!-- VIDEO SECTION-->
            <section id="video-section">


                <div class="container">
                    <div class="row text-center">
                        <div class="col-sm-12 text-center" data-scroll-reveal>
                            <h2 class="blackColor headers">Video</h2>
                        </div>
                        <br/>
                    </div>

                    <br/>
                    <!-- OWL CAROUSEL START -->

                    <div class="row" data-scroll-reveal>
                        <div id="video-carousel" class="owl-carousel">

                            <div class="item">

                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe id="video1" class="embed-responsive-item" width="350" height="197" src="https://www.youtube.com/embed/lTRyFbfn09U" frameborder="0" allowfullscreen></iframe>

                                </div>

                                <div class="description">
                                    <h3><b>Podstawy PHP</b></h3>
                                    <p>Elementare podstawy PHP stanowiące wprowadzenie do zagadnienia programowania.</p>

                                </div>
                            </div>

                            <div class="item">
                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" width="350" height="197" src="https://www.youtube.com/embed/pq5t7JFFGOU" frameborder="0" allowfullscreen></iframe>
                                </div>
                                <div class="description">
                                    <h3><b>Podstawy obiektowości część 1</b></h3>
                                    <p>Wprowadzenie do programowania obiektowego w C# - klasa, obiekt, statyczność.</p>

                                </div>
                            </div>

                            <div class="item">

                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" width="350" height="197" src="https://www.youtube.com/embed/QmTPgz9isHo" frameborder="0" allowfullscreen></iframe>

                                </div>
                                <div class="description">
                                    <h3><b>Podstawy obiektowości część 2</b></h3>
                                    <p>Wprowadzenie do programowania obiektowego w C# - modyfikatory dostępu.</p>

                                </div>
                            </div>


                            <div class="item">

                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" width="350" height="197" src="https://www.youtube.com/embed/W414zlYHQgQ" frameborder="0" allowfullscreen></iframe>

                                </div>
                                <div class="description">
                                    <h3><b>Podstawy obiektowości część 3</b></h3>
                                    <p>Wprowadzenie do programowania obiektowego w C# - polimorfizm.</p>

                                </div>
                            </div>

                            <div class="item">

                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" width="350" height="197" src="https://www.youtube.com/embed/gmSqt7-PHMQ" frameborder="0" allowfullscreen></iframe>

                                </div>
                                <div class="description">
                                    <h3><b>Programowanie obiektowe</b></h3>
                                    <p>Programowanie obiektowe - kompozycja, hermetyzacja.</p>

                                </div>
                            </div>

                            <div class="item">

                                <div class="embed-responsive embed-responsive-16by9">
                                    <iframe class="embed-responsive-item" width="350" height="197" src="https://www.youtube.com/embed/0LMbOzke_m4" frameborder="0" allowfullscreen></iframe>

                                </div>
                                <div class="description">
                                    <h3><b>Programowanie obiektowe</b></h3>
                                    <p>Wzorce projektowe - Inversion of Control na przykładzie Dependency Injection</p>

                                </div>
                            </div>







                        </div>
                        <!-- OWL CAROUSEL END -->

                        <div id="dots"></div>
                    </div>
                </div>
            </section>
            <!--/ VIDEO SECTION-->


            <!-- ========== FAQ ========== -->

            <section id="faq-section" class="backgroundGreenTemplate">

                <div class="container">
                    <div class="row">
                        <div class="col-sm-12 text-center" data-scroll-reveal>


                            <h2 class="whiteColor headers">FAQ</h2>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#faq1">
                                            Do kogo skierowany jest kurs?</a>
                                    </h4>
                                </div>
                                <div id="faq1" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        Prowadzimy wiele kursów w kilku technologiach, stąd nie ma jednej grupy docelowej. Każdy kandydat musi mieć pewne predyspozycje, weryfikowane na rozmowach rekrutacyjnych. Nie ma bariery wieku, płci czy lokalizacji, ale wskazane jest obycie z komputerem, językiem angielskim, a dla kursów wyższych niż podstawowy również wiedza ze świata programowania weryfikowana na rozmowie.
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#faq2">
                                            Jak przebiega rekrutacja na kurs?</a>
                                    </h4>
                                </div>
                                <div id="faq2" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        Kontaktujemy się głównie wiadomościami e-mail, rozmowa odbywa się przy pomocy programów typu TeamViewer lub Join.me, rekrutujący pokazuje fragmenty kodu lub inne zadania i odpowiadamy na pytania bądź prowadzimy dyskusję.
                                    </div>
                                </div>
                            </div>


                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#faq3">
                                            Czy kursy oferowane jako bezpłatne są absolutnie bezpłatne?</a>
                                    </h4>
                                </div>
                                <div id="faq3" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        Kursy oferowane jako bezpłatne to te, które pozwalają nam rekomendować po kursie do zatrudnienia na stanowisku programisty w firmach w Polsce i na świecie. Te kursy są bezpłatne, ale wymagają przejścia rekrutacji i podpisania umowy, sama umowa zawiera naturalnie kary umowne za jej niedotrzymanie, ale dotrzymanie umowy nie powinno stanowić dla kursantów problemu.
                                    </div>
                                </div>
                            </div>


                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#faq4">
                                            W jakich dniach odbywać się będzie kurs?</a>
                                    </h4>
                                </div>
                                <div id="faq4" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        Najprawdopodobniej kurs będzie prowadzony w sobotę lub niedzielę. Uczestnicy mogą zadecydować inaczej większością głosów po sformułowaniu grupy.
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#faq5">
                                            Co muszę mieć ze sobą na warsztatach?</a>
                                    </h4>
                                </div>
                                <div id="faq5" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        Dobre połączenie z internetem<br/>join.me<br/> Mumble<br/>Odpowiednie IDE<br/> Słuchawki z mikrofonem <br/>Chęci do nauki :)
                                    </div>
                                </div>
                            </div>


                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#faq6">
                                            Jakie doświadczenie muszę mieć by aplikować na kurs?</a>
                                    </h4>
                                </div>
                                <div id="faq6" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        W zależności od poziomu zaawansowania<br/>
                                        Przy poziomie podstawowym nie wymagamy doświadczenia - weryfikujemy predyspozycje. Wszystkiego innego Cię nauczymy.
                                        Jeśli już miałeś(aś) styczność z programowaniem w języku wysokopoziomowym aplikuj na kurs średniozaawansowany - na rekrutacji upewnimy się, czy poziom jest wystarczający, czy potrzebne jest np. uczestnictwo w webinarach pośrednich reklamowanych w sekcji Promocje.
                                    </div>
                                </div>
                            </div>


                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#faq7">
                                            Ile kosztuje kurs?</a>
                                    </h4>
                                </div>
                                <div id="faq7" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        W zależności od zaawansowania od 0 do 492 pln brutto.
                                    </div>
                                </div>
                            </div>


                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#faq8">
                                            Ile osób zostanie przyjętych na kurs?</a>
                                    </h4>
                                </div>
                                <div id="faq8" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        Mamy doświadczenie w pracy z grupami sięgającymi 80 osób, oraz przeświadczenie, że możliwe jest skalowanie kursu nawet dla 200 uczestników, w szczególności w C#.
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#faq11">
                                            Czy otrzymam zaświadczenie po ukończeniu kursu?</a>
                                    </h4>
                                </div>
                                <div id="faq11" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        Dostaniesz referencje oraz będziesz polecany naszą rekomendacją do renomowanych firm IT.
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#faq12">
                                            Jakie można uzyskać wynagrodzenie?</a>
                                    </h4>
                                </div>
                                <div id="faq12" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        Stawka jest uzależniona od umiejętności i doświadczenia. Osoby koncentrujące się na legitymowaniu się wiedzą, która zostanie zweryfikowana w praktyce na etacie mają znacznie większe szanse na aprecjację pracodawców w branży. Przy każdej konkretnej rekomendacji mamy świadomość Twoich widełek i widełek pracodawcy. Przy gotowości wyjazdu za granicę możemy zaoferować atrakcyjniejsze warunki zarobkowe.
                                    </div>
                                </div>
                            </div>



                        </div>
                    </div>
                </div>
            </section>

            <!-- ========== FAQ END ========== -->

            <!-- ========== promotions ========== -->

            <section id="promotion-section" class="alt-background">

                <div class="container">
                    <div class="row text-center">

                        <h2 class="blackColor headers">PROMOCJA</h2>
                        <h3> Webinary dla każdego!</h3>
                    </div>
                    <br/>

                    <div class="row">
                        <div class="col-sm-12" data-scroll-reveal>

                            <p>
                                <span class="glyphicon glyphicon-chevron-right"></span>
                                Oferujemy webinary dla osób, które mają podstawowe pojęcie o programowaniu, ale nie kwalifikują się na kurs średniozaawansowany !
                            </p>

                            <p>
                                <span class="glyphicon glyphicon-chevron-right"></span>
                                Każdy webinar dotyczyć będzie konkretnego problemu lub kilku problemów do rozwiązania
                            </p>

                            <p>
                                <span class="glyphicon glyphicon-chevron-right"></span>
                                Tematyka spotkań ustalana jest odgórnie i/lub też za sprawą głosowania uczestników kilka dni przed spotkaniem
                            </p>

                            <p>
                                <span class="glyphicon glyphicon-chevron-right"></span>
                                Przybliżony czas trwania jednego webinara to 1 godzina dla każdego rozwiązywanego problemu
                            </p>

                            <p>
                                <span class="glyphicon glyphicon-chevron-right"></span>
                                Istnieje możliwośc prowadzenia spotkań w sposób interaktywny - tj.  chętny uczestnik próbuje rozwiązać dany problem pod okiem programisty prowadzącego
                            </p>

                            <p>
                                <span class="glyphicon glyphicon-chevron-right"></span>
                                W ramach promocji nowego typu kursu chcemy przeprowadzić 10 godzin darmowych webinarów.
                            <ul>
                                Takie webinary będą prowadzone według następujących zasad:
                                <li> 2 - 3 dni przed webinarem publikujemy listę zagadnień / problemów do rozwiązania w kodzie w wybranym języku programowania</li>
                                <li> w dniu webinaru programista pośredni pomiędzy początkującym a średniozaawansowanym uruchamia webinar i próbuje rozwiązać problem wspólnie z uczestnikami opowiadając o swoich zamiarach względem rozwiązania i dyskutując z początkującymi programistami</li>
                                <li> powstaje kod, w około 50 minut, na żywo, we współpracy z uczestnikami </li>
                                <li> dla powstałego kodu głos zabiera nadzorujący szkolenie ekspert, który pokazuje błędy, wskazuje optymalniejsze rozwiązania, udziela rad względem czystości powstałego kodu, proponuje refaktoryzację.</li>
                            </ul>
                            </p>

                            <p>
                                <span class="glyphicon glyphicon-chevron-right"></span>
                                Uczestnicy tych webinarów będą mieć szansę kwalifikacji na kurs średniozaawansowany. Docelowo te webinary będą płatne, jednak tańsze niż kurs dla początkujących, ze względu na realizowanie płatności indywidualnie dla poszczególnych sesji.
                            </p>
                            <br/>


                            <h3 class="text-center">Co jest potrzebne aby przystąpić do warsztatów?</h3>

                            <p>Podobnie jak przy uczestnictwie w kurise uczestnik powinien posiadać:</p>
                            <ul class="text-20px">
                                <li>słuchawki z mikrofonem</li>
                                <li>join.me</li>
                                <li>Mumble</li>
                            </ul>



                        </div>


                    </div>
                </div>
            </section>

            <!-- ========== Promotions END ========== -->

            <!-- ========== APPLY ========== -->

            <section id="apply-section" class="tint">
                <div class="container">
                    <div class="row text-center">
                        <div class="col-md-12" data-scroll-reveal>
                            <h2 class="blackColor headers">Aplikuj</h2>
                        </div>

                    </div>

                    <div class="row text-center" data-scroll-reveal>
                        <div style=" margin:0 auto; max-width: 70%">
                            <form method="post" id="apply-form" name="apply-form" action="server/apply.php">

                                <div class="form-group" id="applicant-name-group">
                                    <div class="input-group">
                                        <input type="text" class="form-control" name="applicantName" id="applicantName" placeholder="Imię" required pattern="^[A-Za-ząćęłńóśźżĄĘŁŃÓŚŹŻ]{3,}$">
                                        <div class="input-group-addon">
                                            <i class="fa fa-user"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group" id="applicant-surname-group">
                                    <div class="input-group">
                                        <input type="text" class="form-control" name="applicantSurname" id="applicantSurname" placeholder="Nazwisko" required pattern="^[A-za-ząćęłńóśźżĄĘŁŃÓŚŹŻ-]{3,}$">
                                        <div class="input-group-addon">
                                            <i class="fa fa-user"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group" id="applicant-email-group">
                                    <div class="input-group">
                                        <input type="email" class="form-control" data-validate-other-field-if="CustomEmailPrompterForApllyForm" data-other-field-id="applicantFullName" required name="applicantEmail" id="applicantEmail" placeholder="Email">
                                        <div class="input-group-addon"><i class="fa fa-envelope"></i></div>
                                    </div>
                                </div>
                                <div class="form-group" id="applicant-phone-group">
                                    <div class="input-group">
                                        <input type="text" class="form-control" name="applicantPhone" id="applicantPhone" placeholder="Telefon" title="Format +XX-XXXXXXXXX" required pattern="^\+?[0-9]{2}-?[0-9]{6,12}$">
                                        <div class="input-group-addon"><i class="fa fa-phone"></i></div>
                                    </div>
                                </div>
                                <div class="form-group" id="applicant-choose">
                                    <div class="select.input-group-sm">
                                        <select form="apply-form" class="form-control" id="applicantChosenCourse" name="applicantChosenCourse" required>
                                            <option value="" class="form-control" style="display: none" disabled default selected>-- Wybierz kurs --</option>
                                            <option value="beginnerphp" class="form-control">Podstawowy PHP</option>
                                            <option value="beginnercsharp" class="form-control">Podstawowy C#</option>
                                            <option value="promotional" class="form-control">Promocyjny</option>
                                            <option value="intermediatecsharp" class="form-control">Średniozaawansowany C#</option>
                                            <option value="intermediatephp" class="form-control">Średniozaawansowany PHP</option>
                                        </select>
                                    </div>
                                </div>
                                <br />

                                <button id="applyButton" type="submit" class="btn btn-primary ladda-button center-block" data-style="expand-right">Zgłoś się</button>

                            </form>

                        </div>
                    </div>

                </div>
            </section>

            <!-- ========== /APPLY ========== -->

            <!-- ========== CONTACT ========== -->

            <section id="contact-section" class="yellowColorTemplate">
                <div class="container">
                    <div class="row text-center" data-scroll-reveal>
                        <div class="col-md-12">
                            <h2 class="whiteColor headers">Kontakt</h2>
                        </div>
                    </div>

                    <div class="row text-center" data-scroll-reveal>
                        <div style=" margin:0 auto; max-width: 70%">
                            <form role="form" name="contact-form" id="contact-form" action="server/contact.php">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group" id="contact-name-group">
                                            <label for="contact-input-name">Imię i Nazwisko</label>
                                            <input type="text" class="form-control" id="contact-input-name" name="contact-input-name" placeholder="Wprowadź Twoje imię i nazwisko" required pattern="^[A-za-ząćęłńóśźżĄĘŁŃÓŚŹŻ -]{6,}$">
                                        </div>
                                        <div class="form-group" id="contact-email-group">
                                            <label for="contact-input-email">Email</label>
                                            <input type="email" class="form-control" data-validate-other-field-if="CustomEmailPrompterForContactForm" data-other-field-id="contact-input-name" required id="contact-input-email" name="contact-input-email" placeholder="Wprowadź Twój email">
                                        </div>
                                        <div class="form-group" id="contact-subject-group">
                                            <label for="contact-input-subject">Temat</label>
                                            <input type="text" class="form-control" id="contact-input-subject" name="contact-input-subject" placeholder="Wprowadź temat">
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group" id="contact-message-group">
                                            <label for="contact-input-message">Wiadomość</label>
                                            <textarea class="form-control" id="contact-input-message" name="contact-input-message" rows="8"></textarea>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12 text-center" data-scroll-reveal>
                                        <br/>
                                        <button id="contactButton" type="submit" class="btn btn-primary ladda-button center-block" data-style="expand-right">Wyślij</button>
                                    </div>
                                </div>
                            </form>

                        </div>
                    </div>

                </div>
            </section>

            <!-- ========== /CONTACT ========== -->


            <!-- ========== PREFOOTER START ========== -->

            <div id="prefooter">
                <div class="container">
                    <!-- /mapa-->

                    <div class="row">

                        <!-- ==== ABOUT START == -->
                        <div class="col-sm-6" data-scroll-reveal >
                            <h3>O nas</h3>
                            <div class="row">
                                <div class="col-sm-5" data-scroll-reveal>
                                    <p><img src="images/toci-logo.png" alt="" class="img-responsive" /></p>
                                </div>
                                <div class="col-sm-7" data-scroll-reveal>
                                    <p>
                                        Darmowe lub płatne szkolenia z c#, php, javascript, baz danych, java, abap.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <!-- ==== ABOUT END == -->


                        <!-- ==== CONTACT START == -->
                        <div class="col-sm-6" data-scroll-reveal>

                            <div style="float:right;">

                                <h3>Kontakt</h3>
                                <p>Opole, 45-710<br>
                                    ul. Niemodlińska 20/1<br>
                                    Poland</p>

                                <p>Tel: <a href="tel:570751507">570-751-507</a><br>
                                    Email: <a href="mailto:tociszkolenia@gmail.com">tociszkolenia@gmail.com</a></p>
                            </div>

                        </div>
                    </div>

                    <!-- ==== CONTACT END == -->


                </div>

                <div class="container-fluid">

                    <!--mapa-->

                    <div class="row" data-scroll-reveal>

                        <div class="col-md-12" style="padding:0;">
                            <div id="mapa">
                                <!--<iframe  class="embed-responsive-item" src="https://www.google.com/maps/embed/v1/place?q=Opole%2C%20Poland&key=AIzaSyCiWbba2SAlu0jxLJDKQ9sbukBxzUfFRtg" allowfullscreen></iframe>-->
                            </div>
                        </div>

                        <!--			<iframe  src="https://www.google.com/maps/embed/v1/place?q=Opole%2C%20Poland&key=AIzaSyCiWbba2SAlu0jxLJDKQ9sbukBxzUfFRtg" allowfullscreen></iframe>-->

                    </div>
                </div>

            </div>

            <!-- ========== PREFOOTER END ========== -->

            <!-- ========== FOOTER START ========== -->

            <footer>
                <div class="container">
                    <div class="row">

                        <!-- ==== CREDITS START == -->
                        <div class="col-sm-8">
                            &copy; 2015 TOCI
                        </div>
                        <!-- ==== CREDITS END == -->

                        <!-- ==== SOCIAL ICONS START == -->
                        <div class="col-sm-4 text-right">

                            <a href="https://www.facebook.com/ttooccii" target="_blank"><i class="fa fa-facebook fa-lg"></i> TOCI</a>
                        </div>
                        <!-- ==== SOCIAL ICONS END == -->

                    </div>
                </div>
            </footer>

            <!-- ========== FOOTER END ========== -->



            <!-- Modernizr Plugin -->
            <script src="js/modernizr.custom.97074.js"></script>

            <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
            <script src="js/jquery-1.11.1.min.js"></script>

            <!-- Bootstrap Plugins -->
            <script src="js/bootstrap.min.js"></script>

            <!-- Retina Plugin -->
            <script src="js/retina-1.1.0.min.js"></script>

            <!-- Superslides Plugin -->
            <script src="js/jquery.easing.1.3.js"></script>
            <script src="js/jquery.animate-enhanced.min.js"></script>
            <script src="js/jquery.superslides.js"></script>

            <!-- Owl Carousel Plugin -->
            <script src="js/owl.carousel.min.js"></script>

            <!-- Parallax ImageScroll Plugin -->
            <script src="js/jquery.parallax-1.1.3.js"></script>

            <!-- Fancybox Plugin -->
            <script src="js/jquery.fancybox.js"></script>

            <!-- ImagesLoaded Plugin -->
            <script src="js/imagesloaded.pkgd.min.js"></script>

            <!-- Masonry Plugin -->
            <script src="js/masonry.pkgd.min.js"></script>

            <!-- Progressbar Plugin -->
            <script src="js/bootstrap-progressbar.js"></script>

            <!-- Scroll Reveal Plugin -->
            <script src="js/scrollReveal.js"></script>


            <!-- jQuery Settings -->
            <script src="js/settings.js"></script>

            <!-- Scrolling Nav JavaScript -->
            <script src="js/jquery.easing.min.js"></script>
            <script src="js/scrolling-nav.js"></script>



            <script src="js/FormUtils.js"></script>
            <script src="js/applyValid.js"></script>
            <script src="js/contactValid.js"></script>
            <script src="js/utils.js"></script>
            <script src="js/UtilsForAttrData.js"></script>


            <script src="js/ladda-spin.min.js"></script>

            <script src="js/ladda.min.js"></script>

            <script src="js/fbAutoResize.js"></script>



            <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>

            <script src="js/DocumentReady.js"></script>


            <script src="js/Translate.js"></script>


        </div>
    </body>


</html>