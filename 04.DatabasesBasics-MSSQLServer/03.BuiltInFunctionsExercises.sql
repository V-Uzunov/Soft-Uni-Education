------------------------------------------
/*01. Find Names of All Employees by First Name*/
SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'SA%'

------------------------------------------
/*02. Find Names of All Employees by Last Name*/
SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

------------------------------------------
/*03. Find First Names of All Employess*/
SELECT FirstName FROM Employees
WHERE DepartmentID=3 OR DepartmentID=10 AND
HireDate BETWEEN '1995' AND '2005'

------------------------------------------
/*04. Find All Employees Except Engineers*/
SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

------------------------------------------
/*05. Find Towns with Name Length*/
SELECT Name FROM Towns
WHERE LEN(Name) IN(5,6)
ORDER BY Name

------------------------------------------
/*06. Find Towns Starting With*/
SELECT TownId, Name FROM Towns
WHERE Name  LIKE '[MKBE]%' 
ORDER BY Name

------------------------------------------
/*07. Find Towns Not Starting With*/
SELECT TownId, Name FROM Towns
WHERE Name NOT LIKE '[RBD]%' 
ORDER BY Name

------------------------------------------
/*08. Create View Employees Hired After*/
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE Year(HireDate) > 2000

------------------------------------------
/*09. Length of Last Name*/
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) IN (5)




/*Part II – Queries for Geography Database */

------------------------------------------
/*10. Countries Holding 'A'*/
SELECT CountryName, IsoCode FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

------------------------------------------
/*11. Mix of Peak and River Names*/
SELECT PeakName, RiverName, LOWER(PeakName + RIGHT(RiverName, LEN(RiverName)- 1)) AS Mix FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix



/*Part III – Queries for Diablo Database*/

------------------------------------------
/*12. Games From 2011 and 2012 Year*/
SELECT TOP(50) Name, FORMAT(Start, 'yyyy-MM-dd') AS Started  FROM Games
WHERE YEAR(Start)='2011' OR YEAR(Start)='2012'
ORDER BY Start,
Name

------------------------------------------
/*13. User Email Providers*/
SELECT UserName, SUBSTRING(Email,CHARINDEX('@',Email,1)+1,LEN(Email)) AS [Email Provider] FROM Users
ORDER BY [Email Provider],
UserName


------------------------------------------
/*14. Get Users with IPAddress Like Pattern*/
SELECT UserName, IpAddress AS [IP Address] FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username


------------------------------------------
/*15. Show All Games with Duration*/
SELECT Name AS Game, [Part of The Day] = 
CASE
 WHEN (DATEPART(HOUR, Start) BETWEEN 0 AND 11) THEN 'Morning'
 WHEN (DATEPART(HOUR, Start) BETWEEN 12 AND 17) THEN 'Afternoon'
 WHEN (DATEPART(HOUR, Start) BETWEEN 18 AND 24) THEN 'Evening'
 END,
Duration =
CASE
   WHEN Duration <=3 THEN 'Extra Short'
   WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
   WHEN Duration >6 THEN 'Long'
   WHEN Duration IS NUll THEN 'Extra Long'
   END
FROM Games
ORDER BY Game, Duration, [Part of The Day]


------------------------------------------
/*16. Orders Table*/
SELECT ProductName, OrderDate,
DATEADD(DAY, 3, OrderDate) AS 'Pay Due',
DATEADD(MONTH, 1, OrderDate) AS 'Deliver Due'
FROM Orders