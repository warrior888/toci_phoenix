
drop table converter_patterns;
drop table pattern_type;
drop table programming_language;


create table programming_language(
	id serial primary key,
	name varchar(50)
);

insert into programming_language (name) values ('C#');
insert into programming_language (name) values ('PHP');
insert into programming_language (name) values ('C++');
insert into programming_language (name) values ('Java');
insert into programming_language (name) values ('Python');
insert into programming_language (name) values ('JavaScript');
INSERT INTO programming_language (name) VALUES ('C');

--select * from programming_language;



create table pattern_type(
	id serial primary key,
	type varchar(50) not null
);

insert into pattern_type (type) values ('Field');
insert into pattern_type (type) values ('Method');
insert into pattern_type (type) values ('Loop');
insert into pattern_type (type) values ('Condition');
insert into pattern_type (type) values ('Class');
insert into pattern_type (type) values ('MethodCall');

create table converter_patterns (
	id serial primary key,
	id_programming_language int references programming_language(id) not null,
	id_pattern_type int references pattern_type(id) not null,
	content text
);

insert into converter_patterns (id_programming_language, id_pattern_type, content) values (2, 4, 'if(\\D*)');

select * from converter_patterns;

--typ jezyka
--typ paternu