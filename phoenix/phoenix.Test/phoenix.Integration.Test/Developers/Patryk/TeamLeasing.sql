
---
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

---- TeamLeasing drop

drop view users_portfolio_view;
drop view developer_skills_view;
drop view developer_list_view;

drop table developers_list;
drop table course_trainers;
drop table course_technologies;
drop table course_calendar;
drop table course_participants;
drop table chosen_course_registration;
drop table course_references;
drop table users_portfolio;
drop table portfolio_skills_technologies;
drop table developers_skills;
drop table skills_technologies;
drop table courses_list;
drop table course_registration;
drop table portfolio;
drop table users;
drop table roles;
drop table developers_available;

-- EO TeamLeasing drop

-- TeamLeasing tables

create table roles ( 
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

create table developers_available(
	id serial primary key,
	availble_for timestamp,
	start_work_hour integer,
	end_work_hour integer
);

create table developers_list(
	id serial primary key,
	experience_from timestamp,
	id_users integer references users(id) not null,
	fk_id_developers_avaible integer references developers_available(id) not null	
); 

create table portfolio (
	id serial primary key,
	project_name text,
	project_start_date timestamp,
	project_completion_date timestamp,
	fk_id_users integer references users(id) not null -- team leader
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

create table portfolio_skills_technologies(
	id serial primary key,
	fk_id_portfolio integer references portfolio(id) not null,
	fk_id_skills_technologies integer references skills_technologies(id) not null
);

create table developers_skills (
	id serial primary key,
	id_users integer references users(id) not null,
	id_skills_technologies integer references skills_technologies(id) not null,
	skill_level float --
);

--do kursów 

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


create table course_references (
	id serial primary key,
	id_courses_list integer references courses_list(id) not null,
	id_users integer references users(id) not null,
	references_text text
);

-- EO TeamLeasing tables

---happy13

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
	execution_time_ms integer not null, --milisekundy (ile czasu się wykonuje)
	have_been_compiled boolean not null,
	time_spent_s integer not null, --sekundy (ile czasu ktoś spędził nad zadaniem)
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
	total_time_spent_s integer not null,--sekundy (ile czasu farmił w ogóle)
	id_users integer references users(id) not null
);

--eo happy13

-- TeamLeasing seed

--role

insert into roles (name) values ('uzytkownik');
insert into roles (name) values ('administrator');


--users


insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='uzytkownik'),'pa','tr','ww@costam','patrykj123','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='administrator'),'qwq','tertre','sasd@costam','kuba455','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='uzytkownik'),'dawda','hgghhgf','xz@costam','terry','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='administrator'),'cxzczx','nbvnbv','mn@costam','warrior','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='uzytkownik'),'cxzczx','nbvnbv','mn@costam','janek999','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='uzytkownik'),'cxzczx','nbvnbv','mn@costam','pawel344','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='uzytkownik'),'cxzczx','nbvnbv','mn@costam','optimus','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='uzytkownik'),'cxzczx','nbvnbv','mn@costam','ronal633','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='uzytkownik'),'cxzczx','nbvnbv','mn@costam','rion','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='uzytkownik'),'cxzczx','nbvnbv','mn@costam','magnus','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='administrator'),'cxzczx','nbvnbv','mn@costam','ronal777','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='uzytkownik'),'cxzczx','nbvnbv','mn@costam','lars667','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='uzytkownik'),'cxzczx','nbvnbv','mn@costam','wicio','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='administrator'),'cxzczx','nbvnbv','mn@costam','razor88','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='uzytkownik'),'cxzczx','nbvnbv','mn@costam','fenek31','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='uzytkownik'),'cxzczx','nbvnbv','mn@costam','checix76','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='uzytkownik'),'cxzczx','nbvnbv','mn@costam','zielen689','piotr','nowak');

insert into users (id_roles,login,password,email,nick,name,surname) 
values ((select id from roles where name='administrator'),'cxzczx','nbvnbv','mn@costam','snakus92','piotr','nowak');


--developer available

insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-12-05',8,16);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-07-03',8,16);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-12-10',8,16);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-12-05',9,13);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-12-17',8,16);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-06-05',17,22);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-12-05',8,16);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-12-22',10,15);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-12-05',8,16);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-12-05',17,22);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-12-23',17,22);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-03-05',17,22);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-12-05',17,22);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-12-07',17,22);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-12-05',8,16);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-09-05',6,12);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-12-05',8,16);
insert into developers_available (availble_for, start_work_hour, end_work_hour) values('2015-12-05',8,16);

--portfolio

insert into portfolio(project_name, project_completion_date, fk_id_users) values('pentagram','2015-04-13',(select id from users where nick = 'janek999'));
insert into portfolio(project_name, project_completion_date, fk_id_users) values('philadelphia','2012-07-5',(select id from users where nick = 'pawel344'));
insert into portfolio(project_name, project_completion_date, fk_id_users) values('phoenix','2010-05-17',(select id from users where nick = 'warrior'));
insert into portfolio(project_name, project_completion_date, fk_id_users) values('cambridge','2014-09-22',(select id from users where nick = 'kuba455'));


--technologies 

insert into skills_technologies (tech_name) values('C#');
insert into skills_technologies (tech_name) values('PHP');
insert into skills_technologies (tech_name) values('Java');
insert into skills_technologies (tech_name) values('Python');
insert into skills_technologies (tech_name) values('JavaScript');
insert into skills_technologies (tech_name) values('SQL');
insert into skills_technologies (tech_name) values('HTML');


-- developers_list
  

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2014-05-12',(select id from users where users.nick = 'patrykj123'),
												       (select id from developers_available where start_work_hour = 8 limit 1));

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2013-05-17',(select id from users where users.nick = 'kuba455'),
												       (select id from developers_available where start_work_hour = 8 limit 1));												       

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2014-06-15',(select id from users where users.nick = 'terry'),
												       (select id from developers_available where start_work_hour = 8 limit 1));												       

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('1999-01-01',(select id from users where users.nick = 'warrior'),
												       (select id from developers_available where start_work_hour = 8 limit 1));

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2013-07-16',(select id from users where users.nick = 'janek999'),
												       (select id from developers_available where start_work_hour = 17 limit 1));

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2014-05-12',(select id from users where users.nick = 'pawel344'),
												       (select id from developers_available where start_work_hour = 8 limit 1));

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2014-05-12',(select id from users where users.nick = 'optimus'),
												       (select id from developers_available where start_work_hour = 17 limit 1));

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2013-07-16',(select id from users where users.nick = 'ronal633'),
												       (select id from developers_available where start_work_hour = 9 limit 1));

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2014-05-12',(select id from users where users.nick = 'rion'),
												       (select id from developers_available where start_work_hour = 9 limit 1));

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2014-05-12',(select id from users where users.nick = 'magnus'),
												       (select id from developers_available where start_work_hour = 8 limit 1));

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2013-07-16',(select id from users where users.nick = 'ronal777'),
												       (select id from developers_available where start_work_hour = 9 limit 1));

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2014-05-12',(select id from users where users.nick = 'lars667'),
												       (select id from developers_available where start_work_hour = 8 limit 1));												       

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2014-05-12',(select id from users where users.nick = 'wicio'),
												       (select id from developers_available where start_work_hour = 8 limit 1));

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2013-07-16',(select id from users where users.nick = 'fenek31'),
												       (select id from developers_available where start_work_hour = 9 limit 1));

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2014-05-12',(select id from users where users.nick = 'checix76'),
												       (select id from developers_available where start_work_hour = 8 limit 1));

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2013-07-16',(select id from users where users.nick = 'zielen689'),
												       (select id from developers_available where start_work_hour = 8 limit 1));

insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2014-05-12',(select id from users where users.nick = 'snakus92'),
												       (select id from developers_available where start_work_hour = 6 limit 1));												     												       												       												       
												       
insert into developers_list (experience_from, id_users, fk_id_developers_avaible) values ('2013-07-16',(select id from users where users.nick = 'razor88'),
												       (select id from developers_available where start_work_hour = 6 limit 1));

--developers_skills


insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'patrykj123'),
									                              (select id from skills_technologies where skills_technologies.tech_name = 'C#'),70);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'patrykj123'),
									                              (select id from skills_technologies where skills_technologies.tech_name = 'JavaScript'),50);									                              

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'kuba455'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'Java'),90);												       

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'terry'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'C#'),70);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'terry'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'HTML'),50);												       												       

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'warrior'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'C#'),99);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'warrior'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'PHP'),99);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'warrior'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'JavaScript'),80);												       												       

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'janek999'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'C#'),80);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'pawel344'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'PHP'),90);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'optimus'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'C#'),75);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'optimus'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'SQL'),60);												       

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'ronal633'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'C#'),55);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'rion'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'C#'),63);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'magnus'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'C#'),71);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'ronal777'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'PHP'),60);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'lars667'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'PHP'),65);												       

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'wicio'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'PHP'),80);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'wicio'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'HTML'),90);												       

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'fenek31'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'Java'),75);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'checix76'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'Java'),70);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'zielen689'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'Java'),84);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'snakus92'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'Java'),67);												     												       												       												       
												       
insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'razor88'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'PHP'),80);

insert into developers_skills (id_users, id_skills_technologies, skill_level) values ((select id from users where users.nick = 'razor88'),
												       (select id from skills_technologies where skills_technologies.tech_name = 'HTML'),70);												       



--portfolio_skills_technologies

insert into portfolio_skills_technologies (fk_id_portfolio, fk_id_skills_technologies) values((select id from portfolio where portfolio.project_name = 'pentagram' limit 1),
											      (select id from skills_technologies where skills_technologies.tech_name = 'C#'));

insert into portfolio_skills_technologies (fk_id_portfolio, fk_id_skills_technologies) values((select id from portfolio where portfolio.project_name = 'pentagram' limit 1),
											      (select id from skills_technologies where skills_technologies.tech_name = 'SQL'));

insert into portfolio_skills_technologies (fk_id_portfolio, fk_id_skills_technologies) values((select id from portfolio where portfolio.project_name = 'philadelphia' limit 1),
											      (select id from skills_technologies where skills_technologies.tech_name = 'PHP'));

insert into portfolio_skills_technologies (fk_id_portfolio, fk_id_skills_technologies) values((select id from portfolio where portfolio.project_name = 'philadelphia' limit 1),
											      (select id from skills_technologies where skills_technologies.tech_name = 'HTML'));

insert into portfolio_skills_technologies (fk_id_portfolio, fk_id_skills_technologies) values((select id from portfolio where portfolio.project_name = 'phoenix' limit 1),
											      (select id from skills_technologies where skills_technologies.tech_name = 'C#'));

insert into portfolio_skills_technologies (fk_id_portfolio, fk_id_skills_technologies) values((select id from portfolio where portfolio.project_name = 'phoenix' limit 1),
											      (select id from skills_technologies where skills_technologies.tech_name = 'SQL'));

insert into portfolio_skills_technologies (fk_id_portfolio, fk_id_skills_technologies) values((select id from portfolio where portfolio.project_name = 'phoenix' limit 1),
											      (select id from skills_technologies where skills_technologies.tech_name = 'JavaScript'));											      

insert into portfolio_skills_technologies (fk_id_portfolio, fk_id_skills_technologies) values((select id from portfolio where portfolio.project_name = 'cambridge' limit 1),
											      (select id from skills_technologies where skills_technologies.tech_name = 'Java'));

insert into portfolio_skills_technologies (fk_id_portfolio, fk_id_skills_technologies) values((select id from portfolio where portfolio.project_name = 'cambridge' limit 1),
											      (select id from skills_technologies where skills_technologies.tech_name = 'SQL'));											      
											      									      

--delete from  portfolio_skills_technologies;											      
											      

--user portfolio

insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'warrior'),(select id from portfolio where portfolio.project_name = 'phoenix')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'patrykj123'),(select id from portfolio where portfolio.project_name = 'phoenix')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'kuba455'),(select id from portfolio where portfolio.project_name = 'phoenix')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'terry'),(select id from portfolio where portfolio.project_name = 'phoenix')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'optimus'),(select id from portfolio where portfolio.project_name = 'phoenix')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'janek999'),(select id from portfolio where portfolio.project_name = 'pentagram')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'ronal633'),(select id from portfolio where portfolio.project_name = 'pentagram')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'rion'),(select id from portfolio where portfolio.project_name = 'pentagram')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'magnus'),(select id from portfolio where portfolio.project_name = 'pentagram')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'ronal777'),(select id from portfolio where portfolio.project_name = 'philadelphia')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'lars667'),(select id from portfolio where portfolio.project_name = 'philadelphia')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'wicio'),(select id from portfolio where portfolio.project_name = 'philadelphia')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'razor88'),(select id from portfolio where portfolio.project_name = 'philadelphia')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'kuba455'),(select id from portfolio where portfolio.project_name = 'cambridge')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'fenek31'),(select id from portfolio where portfolio.project_name = 'cambridge')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'checix76'),(select id from portfolio where portfolio.project_name = 'cambridge')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'zielen689'),(select id from portfolio where portfolio.project_name = 'cambridge')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'snakus92'),(select id from portfolio where portfolio.project_name = 'cambridge')); 

insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'warrior'),(select id from portfolio where portfolio.project_name = 'cambridge')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'warrior'),(select id from portfolio where portfolio.project_name = 'pentagram'));  
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'patrykj123'),(select id from portfolio where portfolio.project_name = 'pentagram')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'patrykj123'),(select id from portfolio where portfolio.project_name = 'philadelphia')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'terry'),(select id from portfolio where portfolio.project_name = 'philadelphia')); 
insert into users_portfolio (id_users, id_portfolio) values((select id from users where nick = 'terry'),(select id from portfolio where portfolio.project_name = 'cambridge')); 

--EO TeamLeasing seed

-- TeamLeasing navigate


----user portfolio view

create or replace view users_portfolio_view as
	select u.nick, p.project_name
	from users_portfolio up
	join users u on u.id = up.id_users 
	join portfolio p on p.id = up.id_portfolio; 

-- developer_skills_view


CREATE OR REPLACE VIEW developer_skills_view AS 
       SELECT developers_skills.id_users,
       developers_skills.skill_level,
       skills_technologies.tech_name
       FROM developers_skills
       JOIN skills_technologies ON developers_skills.id_skills_technologies = skills_technologies.id;

-- developer_list_view

create or replace view developer_list_view as 
	select u.id as user_id, u.nick, u.name, u.surname, dev.experience_from, dev_available.availble_for,
	dev_available.start_work_hour, dev_available.end_work_hour
	from developers_list dev
	join users u on u.id = dev.id_users
	join developers_available dev_available on dev_available.id = dev.fk_id_developers_avaible


---------------------------------------

select * from skills_view;

select * from developer_list_view;

select * from developer_skills_view order by nick desc;

select * from users_portfolio_view;

create or replace view developer_skill_and_portfolio as

select developer_skills_view.nick, developer_skills_view.tech_name, developer_skills_view.skill_level, users_portfolio_view.project_name
	from developer_skills_view join users_portfolio_view on developer_skills_view.nick = users_portfolio_view.nick;


select nick, count(nick) as liczba, sum(skill_level) / count(nick) as average from developer_skills_view where nick like '%a%3%' group by nick having count(nick) = 1 order by nick desc;


select * from developer_skills_view

select nick, project_name from users_portfolio_view

select * from developer_skills_view 

select nick, project_name, (select nick from users_portfolio_view where project_name = upv1.project_name limit 1) 

from users_portfolio_view upv1 where project_name in (select project_name from users_portfolio_view where nick = upv1.nick);

---- bierzemy grupe z 1 projektu, dobrac info jaki jest ich skill
--, (select nick from users_portfolio_view where nick != upv1.nick and project_name = upv1.project_name limit 1)

--create language plpgsql;




select nick, project_name 
from users_portfolio_view upv1 where project_name in 
(select project_name from users_portfolio_view where nick = upv1.nick) 



select nick, project_name from users_portfolio_view group by nick, project_name having count(nick) > 1;



and 
(select sum(skill_level) / count(skill_level) from developer_skills_view where nick = upv1.nick group by nick) > 80;




-- [0-9]{3,5}

-- warriorr@ala.poczta.fm

--regexp

--- [a-zA-Z0-9]{1,*}[\@]{1}[a-zA-Z0-9]{1,*}[\.]{1}

--regex coach

--select * from roles;
---select * from users;
--delete from users;

--select * from portfolio;

--select * from developers_available;
--select * from developers_list;
--select * from developers_skills;

--select * from users_portfolio;
--select * from skills_technologies;

--delete from skills_technologies where id > 4;
--select * from portfolio_skills_technologies;


--select * from developer_skills_view;
--select * from users_portfolio_view;

--- ktoery dev ile kiedy siezdial


-- EO TeamLeasing navigate




create table time_log (
	id serial primary key,
	fk_id_user integer references users(id) not null, -- 1
	fk_id_skills_technologies integer references skills_technologies(id) not null, --5
	hours integer   -- 4
);

insert into time_log (fk_id_user, fk_id_skills_technologies, hours) values (1, 1, 4);

create trigger UpdateSkillLevelForTimeLog BEFORE INSERT ON time_log 
FOR EACH ROW EXECUTE PROCEDURE UpdateSkillLevelForTimeLogProcedure();


drop function UpdateSkillLevelForTimeLogProcedure() cascade;

create function UpdateSkillLevelForTimeLogProcedure() RETURNS trigger AS $$
DECLARE
	
BEGIN
	update developers_skills set skill_level = skill_level * NEW.hours where id_skills_technologies = NEW.fk_id_skills_technologies and id_users = NEW.fk_id_user;
	RETURN NEW;
END;
$$ LANGUAGE plpgsql;


select * from user_statistics 

select * from developers_skills


