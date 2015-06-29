drop table user_priviliege;
drop table contact;
drop table threemb_user_position;
drop table threemb_user;
drop table position;
drop table privilege;
drop table geographic_region;
drop table contact_type;
drop table i18n ;
drop table language ;

create table language ( --dictionary
	id serial primary key,
	name varchar(50) not null
);

create table i18n (
	id serial primary key,
	id_language integer references language(id),
	name varchar(100) not null, -- _name dla jez 1 -> imie, 2 -> name
	content text
);

create table contact_type ( --dictionary
	id serial primary key,
	name varchar(50) not null
);

create table geographic_region ( --dictionary
	id serial primary key,
	id_geographic_region_parent integer references geographic_region(id),
-- type ? 
	name varchar(100) not null,
	coordinates varchar(100)
);

create table privilege ( --dictionary
	id serial primary key,
	name varchar(50) not null
);

create table position (
	id serial primary key,
	name varchar(50) not null,
	min_monthly_salary decimal,
	max_monthly_salary decimal
);

create table threemb_user (
	id serial primary key,
	id_threemb_user_parent integer references threemb_user(id), -- bezposredni przelozony
-- id pozycji
	login varchar(32),
	password varchar(32),
	name varchar(50) not null,
	surname varchar(100) not null,
	guid varchar(36) ,
	postal_code varchar(10),
	street varchar(100),
	id_geographic_region integer references geographic_region(id)
);

create table threemb_user_position (
	id serial primary key,
	id_threemb_user integer references threemb_user(id) not null,
	id_position integer references position(id) not null
);

create table contact (
	id serial primary key,
	id_threemb_user integer references threemb_user(id) not null,
	id_contact_type integer references contact_type(id) not null,
	content varchar(100) not null
);

--select * from threemb_user;

create table user_priviliege (
	id serial primary key,
	id_threemb_user integer references threemb_user(id),
	id_privilege integer references privilege(id)
);

-- position privileges

--data

insert into contact_type (name) values ('Phone');

insert  into threemb_user (name, surname) values ('Ghost', 'Rider');

insert  into contact (id_threemb_user, id_contact_type, content) values ((select id from threemb_user where name = 'Ghost'), (select id from contact_type where name = 'Phone'), '664324432');
insert  into contact (id_threemb_user, id_contact_type, content) values ((select id from threemb_user where name = 'Ghost'), (select id from contact_type where name = 'Phone'), '506345645');

--select * from contact_type;

select * from threemb_user join contact on threemb_user.id = contact.id_threemb_user;