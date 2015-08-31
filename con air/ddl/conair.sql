
---- klasa ktora jest jednoczesnie tabela w bazie danych

create table ClassStorage(
	id serial primary key,
	classblob text,
	runtimecondition int
);


create table DllStorage(
	id serial primary key,
	dllblob text,
	runtimecondition int
);

create table CodeStorage(
	id serial primary key,
	codeblob text,
	codetype int, -- dll, surewa klasa c#
	codelanguage int, -- 1 - c#, 2 php
	runtimecondition int
);