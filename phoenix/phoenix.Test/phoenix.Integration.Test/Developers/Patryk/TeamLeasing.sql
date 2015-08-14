drop view users_portfolio_view;
drop view developer_skills_view;
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
											      									      

delete from  portfolio_skills_technologies;											      
											      

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


----user portfolio view

create or replace view users_portfolio_view as
	select u.nick, p.project_name
	from users_portfolio up
	join users u on u.id = up.id_users 
	join portfolio p on p.id = up.id_portfolio; 

-- developer_skills_view

create or replace view developer_skills_view as
	select users.nick, st.tech_name, ds.skill_level 
	from developers_skills ds
	join skills_technologies st on st.id = ds.id_skills_technologies
	join users on users.id = ds.id_users;


select * from roles;
select * from users;
delete from users;

select * from portfolio;

select * from developers_available;
select * from developers_list;
select * from developers_skills;

select * from users_portfolio;
select * from skills_technologies;

delete from skills_technologies where id > 4;
select * from portfolio_skills_technologies;


select * from developer_skills_view;
select * from users_portfolio_view;








