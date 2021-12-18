

create database aptechdb

use aptechdb

create table Student(
Id int identity primary key,
Name nvarchar(50) not null,
Phone nvarchar(50),
Age int check(Age>=18) not null, 
Email nvarchar(50)unique not null,
Password nvarchar(50),
Country nvarchar(50),
City nvarchar(50),
Gender nvarchar(50),
Subjects nvarchar(50)
)

