CREATE DATABASE RentACar

USE RentACar

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY(1,1),
BrandId INT,
ColorId INT,
ModelYear smallint,
DailyPrice money,
Description nvarchar(100)
);

CREATE TABLE Brands(
Id int PRIMARY KEY IDENTITY(1,1),
Name nvarchar(50),
);

CREATE TABLE Colors(
Id int PRIMARY KEY IDENTITY(1,1),
Name nvarchar(50),
);

