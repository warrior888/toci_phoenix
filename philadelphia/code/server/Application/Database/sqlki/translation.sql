
drop view if exists translation_view;

drop table if exists i18n;
drop table if exists text_element;
drop table if exists language;

create table language (
	id serial primary key,
	lang_name text
);

-- IDs of text elements on the html page
create table text_element (
	id serial primary key,
	element_name text
);

create table i18n (
	id serial primary key,
	fk_id_language integer references language(id) not null,
	fk_id_text_element integer references text_element(id) not null,
	translation text
);

create or replace view translation_view as
	select language.lang_name, text_element.element_name, i18n.translation from i18n join language on i18n.fk_id_language = language.id 
	join text_element on i18n.fk_id_text_element = text_element.id;


--TESTS--
insert into language(lang_name) values ('pl'), ('en');
insert into text_element(element_name) values ('title'), ('faq');
insert into i18n(fk_id_language, fk_id_text_element, translation) values (1, 1, 'Tytuł'), (1, 2, 'Najczęściej zadawane pytania'), (2, 1, 'Title'), (2, 2, 'Frequently Asked Questions');


select * from language;
select * from text_element;
select * from i18n;
select * from translation_view;
