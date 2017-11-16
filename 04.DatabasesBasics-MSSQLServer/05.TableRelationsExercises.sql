CREATE DATABASE TableRelations

-----------------------------------
/*01. One-To-One Relationship*/

CREATE TABLE Passports
(
PassportID INT PRIMARY KEY,
PassportNumber VARCHAR(50) NOT NULL
)

CREATE TABLE Persons
(
PersonID INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
Salary DECIMAL(10,2) NOT NULL,
PassportID INT UNIQUE,
CONSTRAINT FK_Persons_Passport
FOREIGN KEY (PassportID) 
REFERENCES Passports(PassportID)
)


INSERT INTO Passports(PassportID, PassportNumber)
VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons (FirstName,Salary, PassportID)
Values
('Roberto', 43300.00, 102),
('Tom', 56100.00,103),
('Yana', 60200.00, 101)

-----------------------------------
/*02. One-To-Many Relationship*/
CREATE TABLE Manufacturers
(
ManufacturerID int PRIMARY KEY IDENTITY(1, 1),
Name varchar(50) NOT NULL,
EstablishedOn date NOT NULL
)

CREATE TABLE Models
(
ModelID int PRIMARY KEY,
Name varchar(20) not null,
ManufacturerID int,
CONSTRAINT FK_Manufacturers_Models
FOREIGN KEY (ManufacturerID)
REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers(Name, EstablishedOn)
VALUES 
('BMW','07/03/1916'),
('Tesla','01/01/2003'),
('Lada','01/05/1966')

INSERT INTO Models(ModelID, Name, ManufacturerID)
VALUES
(101, 'X1',	1),
(102, 'i6',	1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)


-----------------------------------
/*03. Many-To-Many Relationship*/
CREATE TABLE Students
(
StudentID INT PRIMARY KEY IDENTITY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Exams
(
ExamID INT PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
StudentID INT,
ExamID INT,
CONSTRAINT PK_StudentsExams 
PRIMARY KEY (StudentID, ExamID),
CONSTRAINT FK_StudentsExams_Students
FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_StudentsExams_Exams
FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)


INSERT INTO Students (Name)
VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams (ExamID, Name)
VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

INSERT INTO StudentsExams (StudentID, ExamID)
VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

-----------------------------------
/*04. Self-Referencing*/
CREATE TABLE Teachers
(
TeacherID int PRIMARY KEY,
Name varchar(50) NOT NULL,
ManagerID int,
CONSTRAINT FK_TeachersID_ManagerID
FOREIGN KEY (ManagerID)
REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers(TeacherID, Name, ManagerID)
VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)

-----------------------------------
/*05. Online Store Database*/
CREATE DATABASE OnlineStore
USE OnlineStore

CREATE TABLE Cities
(
CityID int PRIMARY KEY IDENTITY,
Name varchar(50) NOT NULL
)

CREATE TABLE Customers
(
CustomerID int PRIMARY KEY,
Name varchar(50) NOT NULL,
Birthday date,
CityID int,
CONSTRAINT FK_Customers_City
FOREIGN KEY (CityID)
REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
OrderID int PRIMARY KEY,
CustomerID int,
CONSTRAINT FK_Orders_Customers
FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes
(
ItemTypeID INT PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Items
(
ItemID int PRIMARY KEY,
Name varchar(50) NOT NULL,
ItemTypeID INT,
CONSTRAINT FK_Items_ItemType
FOREIGN KEY (ItemTypeID)
REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
OrderID int,
ItemID int,
CONSTRAINT PK_Order_Items
PRIMARY KEY(OrderID, ItemID),
CONSTRAINT FK_Order_Items_Orders
FOREIGN KEY (OrderID)
REFERENCES Orders(OrderID),
CONSTRAINT FK_Order_Item_Items
FOREIGN KEY (ItemID)
REFERENCES Items(ItemID)
)

-----------------------------------
/*06. University Database*/
CREATE DATABASE UniversityDataBase

CREATE TABLE Majors
(
MajorID int PRIMARY KEY,
Name varchar(50) NOT NULL
)

CREATE TABLE Students
(
StudentID int PRIMARY KEY,
StudentNumber int NOT NULL,
StudentName varchar(50) NOT NULL,
MajorID int,
CONSTRAINT FK_Major
FOREIGN KEY (MajorID)
REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
PaymentID int PRIMARY KEY,
PaymentDate date NOT NULL,
PaymentAmount decimal(10, 2) NOT NULL,
StudentID int,
CONSTRAINT FK_StudentId
FOREIGN KEY (StudentID)
REFERENCES Students(StudentID)
)

CREATE TABLE Subjects
(
SubjectID int PRIMARY KEY,
SubjectName varchar(50) NOT NULL
)

CREATE TABLE Agenda
(
StudentID int,
SubjectID int,
CONSTRAINT PK_Student_Subject
PRIMARY KEY (StudentID, SubjectID),
CONSTRAINT FK_Student_Subject_Student
FOREIGN KEY (StudentID)
REFERENCES Students(StudentID),
CONSTRAINT FK_Student_Subject_Subject
FOREIGN KEY (SubjectID)
REFERENCES Subjects(SubjectID)
)

-----------------------------------
/*09. *Peaks in Rila*/
USE Geography

SELECT MountainRange, PeakName, Elevation FROM Mountains AS m
JOIN Peaks AS p ON p.MountainId=m.Id
WHERE m.MountainRange='Rila'
ORDER BY Elevation DESC