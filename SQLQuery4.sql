Use RentACar

CREATE TABLE CarImages(
Id INT PRIMARY KEY IDENTITY(1,1),
CarId INT,
ImageGUID UNIQUEIDENTIFIER,
ImagePath varchar(100),
Date_ DATETIME
)