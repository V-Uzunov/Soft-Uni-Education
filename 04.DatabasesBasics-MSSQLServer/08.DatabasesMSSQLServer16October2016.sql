--Databases MSSQL Server Exam - 16 October 2016
CREATE DATABASE AMS
USE AMS

CREATE TABLE Towns (
	TownID INT,
	TownName VARCHAR(30) NOT NULL,
	CONSTRAINT PK_Towns PRIMARY KEY(TownID)
)

CREATE TABLE Airports (
	AirportID INT,
	AirportName VARCHAR(50) NOT NULL,
	TownID INT NOT NULL,
	CONSTRAINT PK_Airports PRIMARY KEY(AirportID),
	CONSTRAINT FK_Airports_Towns FOREIGN KEY(TownID) REFERENCES Towns(TownID)
)

CREATE TABLE Airlines (
	AirlineID INT,
	AirlineName VARCHAR(30) NOT NULL,
	Nationality VARCHAR(30) NOT NULL,
	Rating INT DEFAULT(0),
	CONSTRAINT PK_Airlines PRIMARY KEY(AirlineID)
)

CREATE TABLE Customers (
	CustomerID INT,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	DateOfBirth DATE NOT NULL,
	Gender VARCHAR(1) NOT NULL CHECK (Gender='M' OR Gender='F'),
	HomeTownID INT NOT NULL,
	CONSTRAINT PK_Customers PRIMARY KEY(CustomerID),
	CONSTRAINT FK_Customers_Towns FOREIGN KEY(HomeTownID) REFERENCES Towns(TownID)
)

INSERT INTO Towns(TownID, TownName)
VALUES
(1, 'Sofia'),
(2, 'Moscow'),
(3, 'Los Angeles'),
(4, 'Athene'),
(5, 'New York')

INSERT INTO Airports(AirportID, AirportName, TownID)
VALUES
(1, 'Sofia International Airport', 1),
(2, 'New York Airport', 5),
(3, 'Royals Airport', 1),
(4, 'Moscow Central Airport', 2)

INSERT INTO Airlines(AirlineID, AirlineName, Nationality, Rating)
VALUES
(1, 'Royal Airline', 'Bulgarian', 200),
(2, 'Russia Airlines', 'Russian', 150),
(3, 'USA Airlines', 'American', 100),
(4, 'Dubai Airlines', 'Arabian', 149),
(5, 'South African Airlines', 'African', 50),
(6, 'Sofia Air', 'Bulgarian', 199),
(7, 'Bad Airlines', 'Bad', 10)

INSERT INTO Customers(CustomerID, FirstName, LastName, DateOfBirth, Gender, HomeTownID)
VALUES
(1, 'Cassidy', 'Isacc', '19971020', 'F', 1),
(2, 'Jonathan', 'Half', '19830322', 'M', 2),
(3, 'Zack', 'Cody', '19890808', 'M', 4),
(4, 'Joseph', 'Priboi', '19500101', 'M', 5),
(5, 'Ivy', 'Indigo', '19931231', 'F', 1)

----------------------------------
--Section 1: DDL
CREATE TABLE Flights
(
FlightID int,
DepartureTime datetime NOT NULL,
ArrivalTime datetime NOT NULL,
Status varchar(9) CHECK (Status IN ('Departing','Delayed', 'Arrived', 'Cancelled')),
OriginAirportID int,
DestinationAirportID int,
AirlineID int,
CONSTRAINT PK_FlightID PRIMARY KEY (FlightID),
CONSTRAINT FK_OriginAirportID_Airports
FOREIGN KEY (OriginAirportID)
REFERENCES Airports(AirportID),
CONSTRAINT FK_DestinationAirportID_Airports 
FOREIGN KEY (DestinationAirportID) 
REFERENCES Airports(AirportID),
CONSTRAINT FK_AirlineID_Airlines 
FOREIGN KEY (AirlineID)
REFERENCES Airlines(AirlineID)
)

CREATE TABLE Tickets
(
TicketID int,
Price decimal(8, 2) NOT NULL,
Class varchar(6) CHECK (CLASS IN ('First','Second', 'Third')),
Seat varchar(5) NOT NULL,
CustomerID int,
FlightID int,
CONSTRAINT PK_TicketID PRIMARY KEY (TicketID),
CONSTRAINT FK_CustomerID_Customer 
FOREIGN KEY (CustomerID) 
REFERENCES Customers(CustomerID),
CONSTRAINT FK_FlightID_Flights 
FOREIGN KEY (FlightID) 
REFERENCES Flights(FlightID)
)

-----------------------------
--Section 2: DML - 01. Data Insertion
INSERT INTO Flights (FlightID, DepartureTime, ArrivalTime, Status, OriginAirportID, DestinationAirportID, AirlineID)
VALUES
(1,	'2016-10-13 06:00 AM', '2016-10-13 10:00 AM', 'Delayed', 1,	4, 1),
(2,	'2016-10-12 12:00 PM', '2016-10-12 12:01 PM', 'Departing', 1, 3, 2),
(3,	'2016-10-14 03:00 PM', '2016-10-20 04:00 AM','Delayed', 4, 2, 4),
(4,	'2016-10-12 01:24 PM', '2016-10-12 4:31 PM', 'Departing', 3, 1, 3),
(5,	'2016-10-12 08:11 AM', '2016-10-12 11:22 PM', 'Departing', 4, 1, 1),
(6,	'1995-06-21 12:30 PM', '1995-06-22 08:30 PM', 'Arrived', 2, 3, 5),
(7,	'2016-10-12 11:34 PM', '2016-10-13 03:00 AM', 'Departing', 2, 4, 2),
(8,	'2016-11-11 01:00 PM', '2016-11-12 10:00 PM', 'Delayed', 4, 3, 1),
(9,	'2015-10-01 12:00 PM', '2015-12-01 01:00 AM', 'Arrived', 1, 2, 1),
(10,'2016-10-12 07:30 PM', '2016-10-13 12:30 PM', 'Departing', 2, 1, 7)

INSERT INTO Tickets (TicketID, Price, Class, Seat, CustomerID, FlightID)
VALUES
(1,	3000.00, 'First', '233-A', 3, 8),
(2,	1799.90, 'Second', '123-D', 1, 1),
(3,	1200.50, 'Second', '12-Z', 2, 5),
(4,	410.68,	'Third', '45-Q', 2, 8),
(5,	560.00, 'Third', '201-R', 4, 6),
(6,	2100.00, 'Second', '13-T', 1, 9),
(7,	5500.00, 'First', '98-O', 2, 7)

------------------------------------------
--Section 2: DML - 02. Update Flights
UPDATE Flights
SET AirlineID=1
WHERE Status='Arrived'

-----------------------------------------
--Section 2: DML - 03. Update Tickets

SELECT MAX(a.Rating) FROM Airlines AS a
UPDATE Tickets
SET Price+=Price*0.5 

-----------------------------------------
--Section 2: DML - 04. Table Creation
CREATE TABLE CustomerReviews
(
ReviewID int,
ReviewContent varchar(255) NOT NULL,
ReviewGrade smallint,
AirlineID int,
CustomerID int,
CONSTRAINT PK_ReviewID 
PRIMARY KEY (ReviewID),
CONSTRAINT FK_CRAirlineID_Airlines
FOREIGN KEY (AirlineID)
REFERENCES Airlines(AirlineID),
CONSTRAINT FK_CRCustomerID_Customers
FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)
)

CREATE TABLE CustomerBankAccounts
(
AccountID int,
AccountNumber varchar(10) NOT NULL UNIQUE,
Balance decimal(10, 2) NOT NULL,
CustomerID int
CONSTRAINT PK_AccountID
PRIMARY KEY (AccountID),
CONSTRAINT FK_CBACustomerID_Customers
FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)
)

---------------------------------------
--Section 2: DML - 05. Fillin New Tables

INSERT INTO CustomerReviews (ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID)
VALUES
(1, 'Me is very happy. Me likey this airline. Me good.', 10, 1, 1),
(2, 'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!', 10, 1, 4),
(3, 'Meh...', 5, 4, 3),
(4, 'Well Ive seen better, but Ive certainly seen a lot worse...', 7, 3, 5)

INSERT INTO CustomerBankAccounts (AccountID, AccountNumber, Balance, CustomerID)
VALUES 
(1, '123456790', 2569.23, 1),
(2, '18ABC23672', 14004568.23, 2),
(3, 'F0RG0100N3', 19345.20, 5)

-----------------------------------


--Section 3: Querying 

-------------------------------
--01. Extract All Tickets
SELECT t.TicketID, t.Price,	t.Class, t.Seat FROM Tickets AS t
ORDER BY TicketID


--02. Extract All Customers
SELECT c.CustomerID, c.FirstName +' '+c.LastName AS FullName, c.Gender FROM Customers AS c
ORDER BY FullName, c.CustomerID

--03. Extract Delayed Flights
SELECT f.FlightID, f.DepartureTime, f.ArrivalTime FROM Flights AS f
WHERE f.Status='Delayed'
ORDER BY f.FlightID

--04. Top 5 Airlines
SELECT DISTINCT top(5) a.AirlineID, a.AirlineName, a.Nationality, a.Rating FROM Flights AS f
INNER JOIN Airlines AS a
ON a.AirlineID = f.AirlineID
ORDER BY a.Rating DESC, a.AirlineID

-- 05. All Tickets Below 5000
SELECT t.TicketID, a.AirportName AS Destination, c.FirstName+' '+c.LastName AS CustomerName FROM Tickets AS t
INNER JOIN Flights AS f
ON f.FlightID=t.FlightID
INNER JOIN Airports AS a
ON f.DestinationAirportID=a.AirportID
INNER JOIN Customers AS c
ON t.CustomerID=c.CustomerID
WHERE t.Class='First' AND t.Price<5000
ORDER BY t.TicketID

--06. Customers From Home
SELECT  c.CustomerID, 
	   c.FirstName + ' ' + c.LastName AS [FullName],
	   tow.TownName AS [HomeTown]
		 FROM Flights AS f
INNER JOIN Tickets AS t
ON f.FlightID = t.FlightID
INNER JOIN Customers AS c
ON t.CustomerID = c.CustomerID
INNER JOIN Towns AS tow
ON c.HomeTownID = tow.TownID
INNER JOIN Airports AS ai
ON f.OriginAirportID = ai.AirportID AND ai.TownID = tow.TownID
WHERE f.Status = 'Departing' AND ai.TownID = c.HomeTownID 
ORDER BY c.CustomerID

--07. Customers who will fly
SELECT DISTINCT c.CustomerID,
c.FirstName+' '+c.LastName AS FullName,
DATEDIFF(YEAR, c.DateOfBirth, '2016-01-01' ) AS Age FROM Flights AS f
INNER JOIN Tickets As t
ON f.FlightID=t.FlightID
INNER JOIN Customers AS c
ON t.CustomerID=c.CustomerID
WHERE f.Status='Departing'
ORDER BY Age, c.CustomerID

--08. Top 3 Customers Delayed
SELECT DISTINCT TOP(3) c.CustomerID,
c.FirstName+' '+c.LastName AS FullName,
t.Price AS TicketPrice,
a.AirportName AS Destination FROM Flights AS f
INNER JOIN Tickets AS t
ON t.FlightID=f.FlightID
INNER JOIN Customers AS c
ON c.CustomerID=t.CustomerID
INNER JOIN Airports AS a
ON f.DestinationAirportID = a.AirportID
WHERE f.Status='Delayed'
ORDER BY TicketPrice DESC, c.CustomerID

--09. Last 5 Departing Flights
SELECT f.FlightID,
 f.DepartureTime,
 f.ArrivalTime,
 ao.AirportName AS Origin,
 ad.AirportName AS Destination FROM (SELECT TOP(5) * FROM Flights AS f WHERE  f.Status = 'Departing' 
			ORDER BY f.DepartureTime DESC) AS f
INNER JOIN Airports AS ao
ON f.OriginAirportID=ao.AirportID
INNER JOIN Airports AS ad
ON f.DestinationAirportID=ad.AirportID
WHERE f.Status='Departing'
ORDER BY f.DepartureTime, f.FlightID

--10. Customers Below 21
SELECT DISTINCT c.CustomerID,
c.FirstName+' '+c.LastName AS FullName,
DATEDIFF(YEAR, c.DateOfBirth, '2016-01-01' ) AS Age FROM Flights AS f
INNER JOIN Tickets AS t
ON f.FlightID=t.FlightID
INNER JOIN Customers AS c
ON t.CustomerID=c.CustomerID
WHERE f.Status='Arrived' AND DATEDIFF(YEAR, c.DateOfBirth, '2016-01-01' )<21
ORDER BY Age DESC, c.CustomerID

--11. AIrports and Passengers
SELECT a.AirportID,
	   a.AirportName,
	   COUNT(a.AirportName) AS 'Passengers'
FROM Flights AS f
INNER JOIN Airports AS a
ON f.OriginAirportID = a.AirportID
INNER JOIN Tickets AS t
ON t.FlightID = f.FlightID
WHERE f.Status = 'Departing'
GROUP BY a.AirportID, a.AirportName
ORDER BY a.AirportID 


-----------------------------------
--Section 4: Programmibility 

--01. Submit Review
CREATE PROCEDURE usp_SubmitReview(@CustomerID INT, @ReviewContent VARCHAR(255), @ReviewGrade INT, @AirlineName VARCHAR(30))
AS
BEGIN 
BEGIN TRAN 

DECLARE @Index INT 
IF((SELECT COUNT(*) FROM CustomerReviews) = 0)
SET @Index = 1
ELSE
SET @Index = (SELECT MAX(ReviewID) FROM CustomerReviews) + 1
DECLARE @AirlineId INT = (SELECT AirlineID FROM Airlines WHERE AirlineName = @AirlineName)

INSERT INTO CustomerReviews  (ReviewID, ReviewContent, ReviewGrade, CustomerID, AirlineID)
VALUES
(@Index, @ReviewContent, @ReviewGrade, @CustomerID, @AirlineId)

IF NOT EXISTS(SELECT AirlineName FROM Airlines
			  WHERE AirlineName = @AirlineName)
BEGIN
RAISERROR('Airline does not exist.', 16, 1)
ROLLBACK
END
ELSE
	BEGIN
	  COMMIT
	END
END

--02. Ticket Purchase
CREATE PROCEDURE usp_PurchaseTicket (@CustomerID INT, @FlightID INT, @TicketPrice MONEY, @Class VARCHAR (50), @Seat VARCHAR(5))
AS
BEGIN 
BEGIN TRAN

DECLARE @index INT 
IF((SELECT COUNT(*) FROM Tickets) = 0)
	SET @index = 1
ELSE
	SET @index = (SELECT MAX(TicketID) FROM Tickets) + 1

INSERT INTO Tickets(TicketID, Price, Class, Seat, CustomerID, FlightID)
VALUES 
(@index, @TicketPrice, @Class, @Seat, @CustomerID, @FlightID)

DECLARE @customerBallance MONEY = (SELECT cba.Balance FROM CustomerBankAccounts AS cba
							      LEFT JOIN Customers AS c
							      ON c.CustomerID = cba.CustomerID
							      WHERE c.CustomerID = @CustomerID)

IF(@customerBallance IS NULL)
SET @customerBallance = 0

IF(@TicketPrice > @customerBallance)
	BEGIN
		RAISERROR('Insufficient bank account balance for ticket purchase.', 16, 1) 
		ROLLBACK
	END

	

		UPDATE CustomerBankAccounts
		SET Balance -= @TicketPrice
		WHERE CustomerID = (SELECT c.CustomerID FROM CustomerBankAccounts AS cba
							INNER JOIN Customers AS c
							ON c.CustomerID = cba.CustomerID
							WHERE c.CustomerID = @CustomerID)
						COMMIT
	
END