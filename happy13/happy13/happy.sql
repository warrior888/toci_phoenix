drop table user_statistics;
drop table levels;
drop table results;
drop table pay_to_win;
drop table tasks_requirements;
drop table requirements; 
drop table technologies;
drop table unit_tests;
drop table tasks;
drop table lessons;
drop table modules;

drop table course_references_comments;
drop table course_references;

drop table chosen_course_registration;
drop table course_registration;

drop table course_participants;
drop table course_calendar;
drop table course_technologies;
drop table course_trainers;
drop table courses_list;

drop table developers_skills;
drop table skills_technologies;
drop table users_portfolio;
drop table portfolio;
drop table developers_list;
drop table users;
drop table roles;


------- pkt 1
create table roles ( -- admin, prelegent, firma, uczestnik kursu, zwykly, 
	id serial primary key,
	name text
);


create table users (

	id serial primary key,
	id_roles integer references roles(id) not null,
	login text,
	password varchar(32),
	email text,
	nick text,
	name text,
	surname text
	
);

create table developers_list (

	id serial primary key,
	id_users integer references users(id) not null,
	score float
); 

create table portfolio (
	id serial primary key,
	project_name text
);

create table users_portfolio (
	id serial primary key,
	id_users integer references users(id) not null,
	id_portfolio integer references portfolio(id) not null
);

create table skills_technologies (
	id serial primary key,
	tech_name text
);

create table developers_skills (
	id serial primary key,
	id_users integer references users(id) not null,
	id_skills_technologies integer references skills_technologies(id) not null
);

------ pkt 5

create table courses_list (
	id serial primary key,
	course_name text
);

create table course_trainers (
	id serial primary key,
	id_courses_list integer references courses_list(id) not null,
	id_users integer references users(id) not null
);

create table course_technologies (
	id serial primary key,
	id_courses_list integer references courses_list(id) not null,
	id_skills_technologies integer references skills_technologies(id) not null
);

create table course_calendar (
	id serial primary key,
	id_courses_list integer references courses_list(id) not null,
	hours integer,
	session_date timestamp,
	agenda text
);

create table course_participants (
	id serial primary key,
	id_courses_list integer references courses_list(id) not null,
	id_users integer references users(id) not null
);

------ pkt 6

create table course_registration (
	id serial primary key,
	id_roles integer references roles(id) not null,
	login text,
	password varchar(32),
	email text,
	nick text,
	name text,
	surname text
);

create table chosen_course_registration (
	id serial primary key,
	id_course_registration integer references course_registration(id) not null,
	id_courses_list integer references courses_list(id) not null
);


-------- pkt 9
-------- pkt 10

create table course_references (
	id serial primary key,
	id_courses_list integer references courses_list(id) not null,
	id_users integer references users(id) not null,
	references_text text
	
);

create table course_references_comments (
	id serial primary key,
	id_course_references integer references course_references(id) not null,
	id_users integer references users(id) not null,
	comment_text text
);
------- Happy 13
create table modules
(
	id serial primary key,
	module_name varchar(64) not null
);
create table lessons
(
	id serial primary key,
	lesson_name varchar(64) not null,
	id_modules integer references modules(id) not null
);
create table tasks
(
	id serial primary key,
	task_content text not null,
	average_time_minutes int not null,
	id_lessons integer references lessons(id)not null --:P 
);
create table unit_tests
(
	id serial primary key,
	unit_test_content text not null,
	id_tasks integer references tasks(id) not null
);
create table technologies
(
	id serial primary key,
	name_version varchar(64) not null
);
create table requirements
(
	id serial primary key,
	tag varchar(32) not null,
	id_technologies integer references technologies(id) not null
);
create table tasks_requirements 
(
	id serial primary key,
	id_tasks integer references tasks(id) not null,
	id_requirements integer references requirements(id) not null
);
create table pay_to_win --transfers
(
	id serial primary key,
	transfer_cash_amount decimal not null,  --hajsy LL LL LL LL LL LL LL LL LL LL LL LL LL $_$
	transfer_time timestamp not null,
	id_users integer references users(id) not null
);
create table results
(
	id serial primary key,
	execution_time_ms integer not null, --milisekundy (ile czasu siê wykonuje)
	have_been_compiled boolean not null,
	time_spent_s integer not null, --sekundy (ile czasu ktoœ spêdzi³ nad zadaniem)
	id_users integer references users(id) not null,
	id_tasks integer references tasks(id) not null,
	id_unit_tests integer references unit_tests(id) not null
);
create table levels
(
	id serial primary key,
	level_of_technology integer not null,
	id_users integer references users(id) not null,
	id_technologies integer references technologies(id) not null
);
create table user_statistics
(
	id serial primary key,
	total_time_spent_s integer not null,--sekundy (ile czasu farmi³ w ogóle)
	id_users integer references users(id) not null
);