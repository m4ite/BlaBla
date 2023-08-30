drop database Blabla

create database Blabla

use Blabla
go

create table Person
(
	ID int identity primary key,
	Email varchar(30),
	NickName varchar(30),
	WordPass varchar(100),
	BirthDate date,
	Foto varchar(30),
	Salt varchar (16)
);



create table Community
(
	ID int identity primary key,
	Foto varchar(300),
	Title varchar(30),
	Descrip varchar(300),
	Criacao date DEFAULT GETDATE()
);
insert into Community (Foto, Title, Descrip, Criacao) values ('./assets/communityDefautl.png', 'BlaBla', 'Welcome to our Social Media', '2023-07-07')

create table Cargo
(	
	ID int identity primary key,
	Nome varchar(100),
	EditMembers bit,
	AddPost bit,
	CreateCargo bit,
	EditCommunity bit,
	DeleteCommunity bit,
	Community int foreign key references Community(ID)
);
insert into Cargo(Nome,EditMembers,AddPost, CreateCargo, EditCommunity, DeleteCommunity, Community) values('Owner', 1,1,1,1,1,1);



create table Member
(
	ID int identity primary key,
	Cargo int foreign key references Cargo(ID),
	Person int foreign key references Person(ID),
	Community int foreign key references Community(ID)
);


create table Post
(
	ID int identity primary key,
	Title varchar(30),
	Foto varchar(100),
	Descrip varchar(300),
	Community_id int foreign key references Community(ID),
	Person_id int foreign key references Person(ID)	
);



create table Likes
(
	ID int identity primary key,
	Person int foreign key references Person(ID),
	Post int foreign key references Post (ID)
);




select * from Person
select * from Community
select * from Post
select * from Cargo
select * from Member
select * from Likes

insert into Member (Cargo, Person, Community) values (3,1,1)


delete from Community where ID= 4
delete from Member where ID= 9

delete from Likes where ID < 4

drop table Likes
drop table Member
drop table Post
drop table Cargo
drop table Person
drop table Community

