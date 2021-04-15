use RentACar
GO

truncate table Cars
GO

insert into Cars(BrandId,ColorId,ModelYear,DailyPrice,Description) values(1,2,300,2012,'Bmw x 31')
insert into Cars(BrandId,ColorId,ModelYear,DailyPrice,Description) values(1,1,500,2014,'Toyota Pikap')
insert into Cars(BrandId,ColorId,ModelYear,DailyPrice,Description) values(2,1,700,2011,'Mercedes C 45')
insert into Cars(BrandId,ColorId,ModelYear,DailyPrice,Description) values(3,3,350,2008,'Audi A 5')
insert into Cars(BrandId,ColorId,ModelYear,DailyPrice,Description) values(3,2,200,2005,'Tofaþ')
GO

insert into Brands(Name) values('Spor')
insert into Brands(Name) values('Arazi')
insert into Brands(Name) values('Normal')
GO

insert into Colors(Name) values('Mavi')
insert into Colors(Name) values('Beyaz')
insert into Colors(Name) values('Siyah')

