CREATE TABLE Articles(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Title nvarchar(50) NOT NULL ,
Details nvarchar(max) not null,
CategoryId INT not null FOREIGN KEY REFERENCES Categories(Id)
)