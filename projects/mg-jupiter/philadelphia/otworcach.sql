---select * from testsresultsview;

--select * from applicationtests;

--robby'; drop table admi


--insert into applicationtests (codesnipet, rightanswers) values ('teraz robimy inrty z php a', 'to jest fantastyczna odpowiedz');

drop table authors_social_media;
drop table socialmedia;
drop table authors;

select * from authors;

create table authors (
	id serial primary key,
	name text,
	nick text,
	cv text,
	cvtype text,
	foto text -- blob
	
);

--insert into authors (name, nick ) values ('Mikuœ', 'Per³a');

create table socialmedia ( -- fb linkedin ?
	id serial primary key,
	name text
);

create table authors_social_media  (
	id serial primary key,
	fk_id_authors integer references authors(id),
	fk_id_socialmedia integer references socialmedia(id)
);

--view

-- typ kontaktu

--konatkty do autora







------/////////////////////////-------------

--- TODO dropy


create table jezyk (
	id serial primary key,
	name text
);

create table frazy (
	id serial primary key,
	fraza text
);

create table tlumaczenia (
	id serial primary key,
	fk_id_jezyk integer references jezyk(id) not null,
	fk_id_frazy integer references frazy(id) not null,
	tlumaczenie text
);

---- widok ???

