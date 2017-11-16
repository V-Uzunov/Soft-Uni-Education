CREATE DATABASE Minions
CREATE TABLE Minions
(
Id int,
Name varchar(50),
Age int
)

CREATE TABLE Towns
(
Id int,
Name varchar(50)
)

ALTER TABLE Minions
ALTER COLUMN Id INT NOT NULL 

ALTER TABLE Minions
ADD CONSTRAINT PK_Id PRIMARY KEY(Id)

ALTER TABLE Towns
ALTER COLUMN Id INT NOT NULL

ALTER TABLE Towns
ADD CONSTRAINT PrimaryKey_Id PRIMARY KEY (Id)


ALTER TABLE Minions
ADD TownId int 

ALTER TABLE Minions
ADD FOREIGN KEY  (TownId)
REFERENCES Towns(Id)

INSERT INTO Towns(Id, Name)
VALUES (1, 'Sofia'),
		(2, 'Plovdiv'),
		(3, 'Varna');

INSERT INTO Minions(Id, Name, Age, TownId)
VALUES 
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward',Null ,2)

TRUNCATE TABLE Minions

DROP TABLE Minions

CREATE TABLE People
(
Id BIGINT UNIQUE NOT NULL IDENTITY,
Name nvarchar(200) NOT NULL,
Picture varbinary(max) ,
Height decimal(10, 2),
Weight decimal(10, 2),
Genger varchar(1) NOT NULL,
Birthdate date,
Biography nvarchar(max) 
)
ALTER TABLE People
ADD CONSTRAINT PK_Id PRIMARY KEY(Id)

ALTER TABLE People
ADD CONSTRAINT CH_Pictire CHECK(DATALENGTH(Picture) < 20000000) 

ALTER TABLE People
ADD CONSTRAINT CH_Gender CHECK (Genger = 'f' OR Genger = 'm')

INSERT INTO People (Name, Picture, Height, Weight, Genger, Birthdate, Biography)
VALUES 
('Valentin', Null, 185.2, 81.5, 'm', '1997-01-30', 'Много съм умен'),
('Veselin',Null, 150.65, 79, 'm', '2000-05-29','Бърз като стрела'),
('Filip', Null, 190.55, 60, 'm', '2001-06-29', 'Много умен'),
('Temcho', Null, 160.23, 60, 'm', '1997-08-15','Предател'),
('Vanesa', Null, 198.23, 100, 'f', '2000-03-08','Луда')


CREATE TABLE Users
(
Id BIGINT UNIQUE NOT NULL IDENTITY,
Username nvarchar(30) NOT NULL,
Password varchar(26) NOT NULL,
ProfilePicture varbinary(max),
LastLoginTime date,
isDeleted bit
)

ALTER TABLE Users
ADD CONSTRAINT PrK_Id PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CH_Pictire_Users CHECK(DATALENGTH(ProfilePicture) < 900 * 1024) 

INSERT INTO Users (Username, Password, ProfilePicture, LastLoginTime, isDeleted)
VALUES 
('veso', '12345', Null,'2017-01-20', NULL),
('vesoo', '123445', Null, '2017-02-20', Null),
('vesooo', '123446665', Null, '2017-02-20', Null),
('vesoooo', '1234456787', Null, '2017-03-20', Null),
('vesooooo', '12344577', Null, '2017-04-20', Null)







ALTER TABLE Users
DROP CONSTRAINT [PrK_Id]

ALTER TABLE Users
ADD CONSTRAINT PK_UserId
PRIMARY KEY (Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CH_PasswordLenght CHECK (LEN(Password) >= 5)

ALTER TABLE Users
ADD CONSTRAINT DF_CurentTime
DEFAULT GETDATE() FOR LastLoginTime

ALTER TABLE Users 
DROP CONSTRAINT [PK_UserId]

ALTER TABLE Users
ADD CONSTRAINT PK_UserId PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CH_UsernameLenght CHECK (LEN(Username) >= 3)

CREATE DATABASE Movies

CREATE TABLE Directors
(
Id int PRIMARY KEY IDENTITY,
DirectorName varchar(50) NOT NULL,
Notes varchar(max)
)

CREATE TABLE Genres
(
Id int PRIMARY KEY IDENTITY,
GenreName varchar(50) NOT NULL,
Notes varchar(max)
)

CREATE TABLE Categories
(
Id int PRIMARY KEY IDENTITY,
CategoryName varchar(50) NOT NULL,
Notes varchar(MAX)
)

CREATE TABLE Movies
(
Id int PRIMARY KEY IDENTITY,
Title varchar(50),
DirectorId int ,
CopyrightYear varchar(50),
Length int ,
GenreId int,
CategoryId int ,
Rating decimal(2,1)
CONSTRAINT CH_Ratings CHECK (Rating >= 0 AND Rating <=5),
Notes varchar(max )
)

INSERT INTO Directors (DirectorName, Notes)
VALUES 
('Valentin', 'Mnogo e lud'),
('Lazar', 'Mnogo e umen'),
('Filip', 'Mnogo e tup'),
('Tencho', 'Mnogo e umen'),
('Veselin', 'Umen')

INSERt INTO Genres (GenreName, Notes)
VALUES
('Lud', 'Lud'),
('Umen', 'Mnogo e umen'),
('Kak se kazvah', 'Naistina'),
('Plovdiv', 'Nai qkiq grad'),
('Sofiq', 'Otvrat')

INSERT INTO Categories (CategoryName, Notes)
VALUES
('Movie', Null),
('Movie', Null),
('Movie', Null),
('Movie', Null),
('Movie', Null)

INSERT INTO Movies (Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
VALUES
('Veselin',1 , 'No', 300, 1, 1, 2.4,'Kkk'),
('KAK SE KAZVAH',2 , 'Yes', 400, 2, 2, 3,'Kk'),
('KAK SE KAZVAH',3 , 'No', 500, 3, 3, 4,'k'),
('KAK SE KAZVAH',4 , 'Yes', 600, 4, 4, 5,'KKkk'),
('KAK SE KAZVAH',5 , 'No', 300, 5, 5, 5,'KKKkk')

CREATE DATABASE CarRental

CREATE TABLE Categories
(
Id int PRIMARY KEY IDENTITY,
CategoryName varchar(50) NOT NULL,
DailyRate decimal NOT NULL,
WeeklyRate decimal NOT NULL,
MonthlyRate decimal NOT NULL,
WeekendRate decimal
)

CREATE TABLE Cars
(
Id int PRIMARY KEY IDENTITY,
PlateNumber varchar(50) NOT NULL,
Manufacturer varchar(50) NOT NULL,
Model varchar(50) NOT NULL,
CarYear DATE NOT NULL,
CategoryId INT NOT NULL
CONSTRAINT FK_Cars_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
Doors int NOT NULL,
Picture VARBINARY(MAX),
Condition varchar(MAX),
Available BIT NOT NULL 
)

CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL,
Title varchar(50),
Notes nvarchar(max)
)

CREATE TABLE Customers
(
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber NVARCHAR(30) NOT NULL UNIQUE,
FullName NVARCHAR(30) NOT NULL,
Address NVARCHAR(30) NOT NULL,
City NVARCHAR(50) NOT NULL,
ZIPCode INT NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders 
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT NOT NULL,
CONSTRAINT FK_RentalOrders_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
CustomerId INT NOT NULL,
CONSTRAINT FK_RentalOrders_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
CarId INT NOT NULL, 
CONSTRAINT FK_RentalOrders_Cars FOREIGN KEY (CarId) REFERENCES Cars(Id),
TankLevel nvarchar(10) NOT NULL DEFAULT 'No Full',
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage INT NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL DEFAULT GETDATE(),
CONSTRAINT CH_Date CHECK (EndDate >= StartDate),
TotalDays INT NOT NULL,
RateApplied DECIMAL NOT NULL DEFAULT 0,
TaxRate DECIMAL NOT NULL DEFAULT 0,
OrderStatus NVARCHAR(200) NOT NULL DEFAULT 'Confirmed',
Notes NVARCHAR(MAX)
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES 
('Cheap', 10, 50, 200, 18.34),
('Low', 6, 30, 150, 15.66),
('Lux', 20, 50, 400 , 30)

INSERT INTO Cars (PlateNumber,Manufacturer, Model, CarYear,CategoryId, Doors,Picture, Condition, Available)
VALUES
('PB00102010CA', 'Honda', 'Civic', '2015', 1, 4, Null, 'good', 1),
('PB003010CA', 'Opel', 'Astra', '2014', 2, 4, Null, 'best', 1),
('PB00402010CA', 'Mercedes', 'CLA', '2013', 3, 4, Null, 'good', 1)


INSERT INTO Employees (FirstName, LastName, Notes)
VALUES 
('Valentin', 'Parvanov', Null),
('Georgi', 'Tanev', Null),
('Pe6o', 'Petkanov', Null)

INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode)
VALUES
('BC1015AA', 'Veselin Uzunov', 'Oborishte 61','Plovdiv', 4000),
('BC1016AA', 'Veselin Uzunov', 'Oborishte 60','Plovdiv', 4000),
('BC1017AA', 'Veselin Uzunov', 'Oborishte 50','Plovdiv', 4000)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 2, 3, DEFAULT, 100, 200, 100, '2017-01-17', DEFAULT, 1, 10.0, 10.0, DEFAULT, 'None'),
(1, 2, 3, DEFAULT, 100, 200, 100, '2017-01-17', DEFAULT, 1, 10.0, 10.0, DEFAULT, 'None'),
(1, 2, 3, DEFAULT, 100, 200, 100, '2017-01-17', DEFAULT, 1, 10.0, 10.0, DEFAULT, 'None')

CREATE DATABASE Hotel

CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Title VARCHAR(50),
Notes VARCHAR(MAX)
)

CREATE TABLE Customers
(
AccountNumber NVARCHAR(25) PRIMARY KEY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
PhoneNumber NVARCHAR(50) NOT NULL,
EmergencyName NVARCHAR(50),
EmergencyNumber NVARCHAR(50),
Notes VARCHAR(MAX)
)

CREATE TABLE RoomStatus
(
RoomStatus NVARCHAR(10) PRIMARY KEY,
Notes VARCHAR(MAX)
)

CREATE TABLE RoomTypes
(
RoomType NVARCHAR(50) PRIMARY KEY,
Notes VARCHAR(MAX)
)

CREATE TABLE BedTypes
(
BedType NVARCHAR(50) PRIMARY KEY,
Notes VARCHAR(MAX)
)

CREATE TABLE Rooms
(
RoomNumber INT IDENTITY PRIMARY KEY,
RoomType NVARCHAR(50) NOT NULL,
BedType NVARCHAR(50) NOT NULL,
Rate decimal,
CONSTRAINT CH_Rate CHECK (Rate >=0 AND Rate <=5),
RoomStatus NVARCHAR(10) NOT NULL,
Notes NVARCHAR(MAX)
)
 
 CREATE TABLE Payments
(
Id INT IDENTITY PRIMARY KEY,
EmployeeID INT NOT NULL,
PaymentDate DATE NOT NULL,
AccountNumber NVARCHAR(25) NOT NULL,
FirstDateOccupied DATE,
LastDateOccupied DATE,
TotalDays INT,
AmountCharged DECIMAL NOT NULL,
TaxRate DECIMAL,
TaxAmount DECIMAL NOT NULL,
PaymentTotal DECIMAL NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies
(
Id INT IDENTITY PRIMARY KEY,
EmployeeId INT NOT NULL,
CONSTRAINT FK_Occupancies_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
DateOccupied DATE NOT NULL,
AccountNumber NVARCHAR(25) NOT NULL,
RoomNumber INT NOT NULL,
RateApplied INT,
PhoneCharge DECIMAL,
Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES
('Veselin', 'Uzunov', 'fast', null),
('Veselin', 'Uzunov', 'low', null),
('Veselin', 'Uzunov', 'best', null)

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber,EmergencyName, EmergencyNumber, Notes)
VALUES
('C', ' 2D', 'tUm', 'XA', '0989999', '222', NULL),
('B', '3SD', 'tUm', 'XAm','0989999', '222', NULL),
('D', 'KSK ', 'tUm', 'XA','0989999', '222', NULL)

INSERT INTO RoomStatus (RoomStatus, Notes)
VALUES
('0', 'zaeta'),
('1', 'zaeta'),
('3', 'zaeta')

INSERT INTO RoomTypes(RoomType, Notes) 
VALUES
('A', 'A'),
('b', 'b'),
('c', 'c')

INSERT INTO BedTypes(BedType, Notes) 
VALUES
('A', 'A'),
('b', 'b'),
('c', 'c')

INSERT INTO Rooms ( RoomType, BedType, Rate, RoomStatus, Notes)
 VALUES
 ('B', '0', 1, 'xx',Null),
 ('d', '0', 3, 'xx', Null),
 ('a', '0', 5, 'xx',Null)

 INSERT INTO Payments (EmployeeID, PaymentDate,AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays,AmountCharged, TaxRate,TaxAmount, PaymentTotal, Notes)
 VALUES
(1, GETDATE(), 'b', '2017-12-11', '2017-12-12',1,  100, 50, 50, 300, null),
(2, GETDATE(), 'c', '2016-12-11', '2016-12-12',1,  100, 50, 50, 300, null),
(3, GETDATE(), 'a', '2015-12-11', '2015-12-12',1,  100, 50, 50, 300, null)


INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES
(1,'2017-01-30', 'a', 2, 5.6, 08958944, NULL),
(2,'2016-01-30', 'B', 3, 5.6, 08958944, NULL),
(3,'2015-01-30', 'C', 4, 4, 08958944, NULL)


--Задача 16
CREATE DATABASE SoftUni

CREATE TABLE Towns
(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL,
)

CREATE TABLE Addresses 
(
Id INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR(MAX) NOT NULL,
TownId INT,
CONSTRAINT FK_Addresses_Towns FOREIGN KEY (TownId) REFERENCES Towns(Id)
)

CREATE TABLE Departments 
(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees 
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
JobTitle NVARCHAR(50) NOT NULL,
DepartmentId INT,
CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
HireDate DATE,
Salary DECIMAL,
AddressId INT,
CONSTRAINT FK_Employees_Addresses FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
)


--Задача 18
INSERT INTO Towns (Name)
VALUES
('Sofia'), 
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments (Name)
VALUES
('Engineering'), 
('Sales'), 
('Marketing'), 
('Software Development'), 
('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2014-03-02', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2,'2007-12-09', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-26', 599.88)

--Задача 19
SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

--Задача 20
SELECT * FROM Towns
ORDER BY Name ASC;

SELECT * FROM Departments
ORDER BY Name ASC;

SELECT * FROM Employees
ORDER BY Salary DESC;


SELECT Name FROM Towns
ORDER BY Name ASC;

SELECT Name FROM Departments
ORDER BY NAME ASC;

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC;

UPDATE Employees
SET Salary = Salary + (salary * 0.1);

SELECT Salary FROM Employees


SELECT TaxRate FROM Payments 

UPDATE Payments
SET TaxRate = TaxRate  -(TaxRate * 0.03);

SELECT TaxRate FROM Payments

TRUNCATE TABLE Occupancies 
