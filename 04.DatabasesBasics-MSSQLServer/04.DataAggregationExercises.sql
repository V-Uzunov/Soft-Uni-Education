-----------------------------------------------------
/*01. Records’ Count*/
SELECT COUNT(DepositCharge) AS Count FROM WizzardDeposits

-----------------------------------------------------
/*02. Longest Magic Wand*/
SELECT MAX([MagicWandSize]) AS [LongestMagicWand] FROM WizzardDeposits

-----------------------------------------------------
/*03. Longest Magic Wand per Deposit Groups*/
SELECT [DepositGroup], MAX([MagicWandSize]) 
AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup

-----------------------------------------------------
/*04. Smallest Deposit Group per Magic Wand Size*/
SELECT DepositGroup
FROM WizzardDeposits
GROUP BY [DepositGroup]
HAVING AVG(MagicWandSize) <
(
SELECT AVG(MagicWandSize) FROM WizzardDeposits
)

-----------------------------------------------------
/*05. Deposits Sum*/
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
GROUP BY [DepositGroup]

-----------------------------------------------------
/*06. Deposits Sum for Ollivander Family*/
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE [MagicWandCreator]='Ollivander family'
GROUP BY [DepositGroup]

-----------------------------------------------------
/*07. Deposits Filter*/
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE [MagicWandCreator]='Ollivander family'
GROUP BY [DepositGroup]
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

-----------------------------------------------------
/*08. Deposit Charge*/
SELECT [DepositGroup], [MagicWandCreator], MIN([DepositCharge]) AS MinDepositCharge FROM WizzardDeposits
GROUP BY DepositGroup , MagicWandCreator
ORDER BY [MagicWandCreator],
[DepositGroup]

-----------------------------------------------------
/*09. Age Groups*/
SELECT w.AgeGroup, COUNT(*) AS 'WizardCount' 
FROM
(
SELECT 'AgeGroup'=
CASE
WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
WHEN Age >= 61 THEN '[61+]'
END
FROM WizzardDeposits
) AS w
GROUP BY w.AgeGroup

-----------------------------------------------------
/*10. First Letter*/
SELECT DISTINCT(SUBSTRING(FirstName, 1, 1)) AS FirstLetter FROM WizzardDeposits
WHERE DepositGroup='Troll Chest'
GROUP BY FirstName
ORDER BY FirstLetter

-----------------------------------------------------
/*11. Average Interest*/
SELECT DepositGroup, IsDepositExpired, AVG([DepositInterest]) AS AverageInterest FROM WizzardDeposits
WHERE YEAR('1985-01-01')<= YEAR(DepositStartDate)
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC,
IsDepositExpired

-----------------------------------------------------
/*12. Rich Wizard, Poor Wizard*/
SELECT SUM(SumDiff.SumDifference)
FROM
    (SELECT h.DepositAmount -
        (SELECT DepositAmount 
        FROM WizzardDeposits
        WHERE Id = h.Id + 1)
AS SumDifference
     FROM WizzardDeposits h) 
	 AS SumDiff

-----------------------------------------------------
/*13. Departments Total Salaries*/
USE  SoftUni

SELECT DepartmentId, SUM(Salary) AS TotalSalary FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

-----------------------------------------------------
/*14. Employees Minimum Salaries*/
SELECT DepartmentId, MIN(Salary) AS MinimumSalary FROM Employees
WHERE YEAR('2000-01-01')<= YEAR(HireDate)
GROUP BY DepartmentId
HAVING DepartmentId=2 OR DepartmentId=5 OR DepartmentId=7

-----------------------------------------------------
/*15. Employees Average Salaries*/
SELECT * INTO NewTable FROM Employees 
WHERE Salary > 30000

DELETE FROM NewTable
WHERE ManagerID = 42

UPDATE NewTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary FROM NewTable
GROUP BY DepartmentID

-----------------------------------------------------
/*16. Employees Maximum Salaries*/
SELECT DepartmentId, MAX(Salary) AS [MaxSalary] FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) < 30000 OR MAX(Salary) >70000

-----------------------------------------------------
/*17. Employees Count Salaries*/
SELECT COUNT(Salary) AS Count FROM Employees
WHERE ManagerID IS NULL