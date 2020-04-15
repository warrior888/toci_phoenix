drop table Trainings;
drop table ApplyForm; --From website
drop table ApplyFormCompany;
drop table ContactForm;
drop table ContactForm;
drop table FAQ;
drop table Students;
drop table Banner;
drop table NavigationBar;

create table NavigationBar
(
	Id int identity primary key,
	NavElement text
);

create table Banner
(
Id int identity primary key,
BannerElement text,
ButtonExist int,
BannerButton text
);

create table Students
(
Id int identity primary key,
Name text,
Description text,
IsSourceLink int,
SourceLink text

);

create table FAQ
(
Id int identity primary key,
Title text,
Description text

);

create table ContactForm
(
	Id int identity primary key,
	ContactTitle varchar(100),
	Name varchar(100),
	Email varchar(100),
	Title varchar(100),
	Message varchar(1000)
);
select * from ContactForm;

create table ApplyFormCompany
(
Id int identity primary key,
Company bool, --company or person
QttyPeoples bool,--one person or group
Name text, --name or names of group
NamesQtty int, --to werivy qtty https://www.alx.pl/zgloszenie/kurs-php-sql/
ContactPerson text,
Email text,
Emailforpayment text,
PhoneNumber text,
Adress text,
City text,
PosteCode text,
PaymentInvoice bool, --paper/electronic
Certificate bool, --electronics/electronics & printed
CompanyName text,
CompanyAdress text,
CompanyCity text,
CompanyPosteCode text,
NIP text,
PublicFinancial bool,
Payment int,
AdditionalInformation text,
Captcha text,
approval text,
Training text,
facebook text,
Captcha text,
ButtonApply text

);

drop table ApplyForm;

create table ApplyForm
(
	Id int identity primary key,
	ApplicantName varchar(100),
	ApplicantSurname varchar(100),
	PhoneNumber varchar(100),
	ApplicantEmail varchar(100),
	Token varchar(100),
	EmailConfirmed bit
);

select * from applyform;

create table Trainings
(
Id int identity primary key,
TrainingName text,
Description text,
LessonLanguage text,
TrainingTime text,
HowOften text,
GroupQtty text,
Place text,
Price text,
Feature text,
Advantage text
);