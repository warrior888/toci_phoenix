drop table Languages;
drop table Phrases;
drop table Translations;
drop table Apps;

create table Languages
(
	Id bigint identity primary key,
	Name text,
	Currency text
);

insert into Languages (name, currency) values ('Polski', 'PLN');

create table Phrases
(
	Id bigint identity primary key,
	Phrase text
);

insert into Phrases (Phrase) values ('_welcome');

insert into Languages (name) values ('_polish');

insert into Phrases (Phrase) values ('_unknown_database_error');

create table Translations
(
	Id bigint identity primary key,
	IdLanguages bigint references Languages(Id),
	IdPhrases bigint references Phrases(Id),
	Translation text
);

create table Apps
(
	Id int identity primary key,
	Name text,
	Url text,
	Description text
);