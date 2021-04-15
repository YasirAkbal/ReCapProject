USE RentACar

create table Users(
Id int primary key identity(1,1),
FirstName varchar(50),
LastName varchar(50),
Email varchar(50),
Password varchar(32)
);

create table Customers(
CustomerId int primary key,
UserId int,
CompanyName varchar(100)
);

ALTER TABLE Customers
ADD FOREIGN KEY (UserId) REFERENCES Users(Id);


create table Rentals(
Id int primary key identity(1,1),
CarId int,
RentDate Datetime,
ReturnDate Datetime
);


