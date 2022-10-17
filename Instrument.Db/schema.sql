drop table if exists Instruments
create table Instruments (id int IDENTITY(1,1) primary key, name varchar(64), price float)