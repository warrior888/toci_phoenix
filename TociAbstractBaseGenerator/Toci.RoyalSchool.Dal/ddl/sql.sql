---95 %


drop table personal_data;
drop table phone;
drop table courses;
drop table lookup;
drop table lookup_type;

create table lookup_type (
	id serial primary key,
	name text
);

insert into lookup_type (name) values ('FirstName');
insert into lookup_type (name) values ('Status'); --2 _lector _student
insert into lookup_type (name) values ('Language');
insert into lookup_type (name) values ('Level'); -- 4
insert into lookup_type (name) values ('ClassesKind'); --5

create table lookup (
	id serial primary key,
	id_lookup_type int references lookup_type (id),
	name text
);

insert into lookup (id_lookup_type, name) values (1, 'Marta');
insert into lookup (id_lookup_type, name) values (1, 'Yuriy');
insert into lookup (id_lookup_type, name) values (1, 'Karol');
insert into lookup (id_lookup_type, name) values (1, 'Igor');
insert into lookup (id_lookup_type, name) values (1, 'Micha³');
insert into lookup (id_lookup_type, name) values (1, 'Karol');
insert into lookup (id_lookup_type, name) values (1, 'Rafa³');
insert into lookup (id_lookup_type, name) values (1, 'Tadeusz');
insert into lookup (id_lookup_type, name) values (1, 'Jaros³aw');
insert into lookup (id_lookup_type, name) values (1, 'Janusz');
insert into lookup (id_lookup_type, name) values (1, 'Konrad');
insert into lookup (id_lookup_type, name) values (1, 'Pawe³');
insert into lookup (id_lookup_type, name) values (1, 'Mariusz');
insert into lookup (id_lookup_type, name) values (1, 'Eustachy'');
insert into lookup (id_lookup_type, name) values (1, 'Vladimir'');

create table personal_data (
	id serial primary key,
	id_name int not null references lookup (id),
	surname text not null,
	pesel varchar(11),
	birth_date date,
	registration_date date,
	address text
);

insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (1, 'Kowalski', 84080818074, '1984-08-08','2015-12-10','Pomarañczowa 3');
insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (2, 'Moron',00010244256,'2000-01-01','2016-06-02', 'Krzywa 18/6');
insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (3,'Cebulak',00010244256,'2000-01-01','2016-06-02','Konkretna 32');
insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (4,'Marian',00010244256,'2000-01-01','2016-06-02','D³uga 15');
insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (5, 'Ignacy', 00010244256,'2000-01-01','2016-06-02','Konkretna 32');
insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (6,'Cebulak',00010244256,'2000-01-01','2016-06-02','Konkretna 32');
insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (7,'Cebulak',00010244256,'2000-01-01','2016-06-02','Konkretna 32');
insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (8,'Bu³ka',00010244256,'2000-01-01','2016-06-02','Konkretna 32');
insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (9,'Cebulak',00010244256,'2000-01-01','2016-06-02','Konkretna 32');
insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (10,'Cebulak',00010244256,'2000-01-01','2016-06-02','Konkretna 32');
insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (11,'Cebulak',00010244256,'2000-01-01','2016-06-02','Konkretna 32');
insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (12,'Indiego',00010244256,'2000-01-01','2016-06-02','Konkretna 32');
insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (13,'Cebulak',00010244256,'2000-01-01','2016-06-02','Randomowa 666/666');
insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (14,'Cebulak',00010244256,'2000-01-01','2016-06-02','Konkretna 32');
insert into personal_data (id_name,surname,pesel,birth_date,registration_date,address) values (15,'Putin',00010244256,'1952-10-07','2016-06-02','£agrowa 66/6');

create table courses (
	id serial primary key,
	id_personal_data int references personal_data(id) not null,
	id_personal_data_lector int references personal_data(id) not null,
	id_status_lookup int references lookup(id),
	id_classeskind_lookup int references lookup(id),
	
);

create table phone (
	
);