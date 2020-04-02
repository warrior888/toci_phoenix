drop table Users;
drop table Occupations;

create table Occupations
(
	Id integer identity primary key,
	IdOccupations integer references Occupations(Id),
	Name text
);


create table Users
(
	Id integer identity primary key,
	ComesFrom int,
	Gender int,
	Name text,
	Surname text,
	Email text,
	Phone text,
	Password text,
	EmailVerified int,
	City text,
	PostCode text,
	Street text,
	IdLanguages bigint references Languages(Id),
	IdOccupations integer references Occupations(Id),
	IdGeographicRegions integer references GeographicRegions(Id)
);
