use workshop

drop table if exists Televisions

create table Televisions(
    ID INT IDENTITY (1,1) PRIMARY KEY,
    NAME VARCHAR(20),
    PRICE FLOAT
)