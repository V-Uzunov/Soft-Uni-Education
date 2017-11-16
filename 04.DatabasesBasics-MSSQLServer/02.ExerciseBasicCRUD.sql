---
/*Part I – Queries for SoftUni Database*/

/*02.Find All Information About Departments*/
SELECT * FROM Departments

-------------------------
/*03. Find all Department Names*/
SELECT Name FROM Departments

----------------------------
/*04. Find Salary of Each Employee*/
SELECT FirstName, LastName, Salary FROM Employees

---------------------------------
/*05. Find Full Name of Each Employee*/
SELECT FirstName, MiddleName, LastName FROM Employees

-------------------------------------
/*06. Find Email Address of Each Employee*/
SELECT FirstName + '.' +LastName + '@softuni.bg' 
AS 'Full Email Address'
 FROM Employees 

 ------------------------------------------------
 /*07. Find All Different Employee’s Salaries*/
 SELECT DISTINCT Salary FROM Employees

 --------------------------------------------------
 /*08. Find all Information About Employees*/
SELECT * FROM Employees
WHERE JobTitle='Sales Representative'

----------------------------------------------------
/*09. Find Names of All Employees by Salary in Range*/
SELECT FirstName, LastName, JobTitle 
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

-----------------------------------------------
/*10. Find Names of All Employees */
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS 'Full Name'
FROM Employees
WHERE Salary = 25000 OR Salary= 14000 OR Salary= 12500 OR Salary = 23600

-------------------------------------------------
/*11. Find All Employees Without Manager */
SELECT FirstName, LastName FROM Employees
WHERE ManagerId IS NULL

-------------------------------------------------
/* 12. Find All Employees with Salary More Than*/
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary > 50000 
ORDER BY Salary DESC

-------------------------------------------------
/*13. Find 5 Best Paid Employees */
SELECT TOP (5) FirstName, LastName FROM Employees
ORDER BY Salary DESC

-------------------------------------------------
/*14. Find All Employees Except Marketing */
SELECT FirstName, LastName FROM Employees
WHERE DepartmentID <> 4

-------------------------------------------------
/*15. Sort Employees Table */
SELECT * FROM Employees
ORDER BY Salary DESC,
FirstName,
LastName DESC,
MiddleName

-------------------------------------------------
/*16. Create View Employees with Salaries */
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary 
FROM Employees

-------------------------------------------------
/*17. Create View Employees with Job Titles */
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS 'Full Name', JobTitle
FROM Employees

SELECT * FROM V_EmployeeNameJobTitle

-------------------------------------------------
/*18. Distinct Job Titles */
SELECT DISTINCT JobTitle 
FROM Employees

-------------------------------------------------
/*19. Find First 10 Started Projects */
SELECT TOP (10) [ProjectID], [Name], [Description], [StartDate], [EndDate]
FROM Projects
ORDER BY StartDate, 
Name

-------------------------------------------------
/* 20. Last 7 Hired Employees*/
SELECT TOP(7) FirstName, LastName, HireDate 
FROM Employees
ORDER BY HireDate DESC

-------------------------------------------------
/*21. Increase Salaries */
UPDATE Employees
SET Salary = Salary + (Salary * 0.12)
WHERE DepartmentID IN (SELECT DepartmentId
	   FROM Departments
	  WHERE Name IN 
		('Engineering', 'Tool Design', 'Marketing', 'Information Services'))

SELECT Salary FROM Employees


/*Part II – Queries for Geography Database*/
-------------------------------------------------
/*22. All Mountain Peaks */
SELECT PeakName FROM Peaks
ORDER BY PeakName

-------------------------------------------------
/*23. Biggest Countries by Population */
SELECT TOP(30) CountryName, Population FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY Population DESC

-------------------------------------------------
/*24. Countries and Currency (Euro / Not Euro) */
SELECT  CountryName, CountryCode, 
CASE
WHEN CurrencyCode = 'EUR' THEN 'Euro'
ELSE 'Not Euro'
END AS Currency
FROM Countries
ORDER BY CountryName


/*Part III – Queries for Diablo Database*/
-------------------------------------------------
/*25. All Diablo Characters */
SELECT Name FROM Characters
ORDER BY Name

