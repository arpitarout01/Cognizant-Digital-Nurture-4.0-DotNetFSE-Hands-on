-- Departments Table
CREATE TABLE Departments ( 
	DepartmentID INT PRIMARY KEY, 
	DepartmentName VARCHAR(100) 
);

-- Employess Table
CREATE TABLE Employees ( 
	EmployeeID INT PRIMARY KEY NOT NULL, 
	FirstName VARCHAR(50), 
	LastName VARCHAR(50), 
	DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID), 
	Salary DECIMAL(10,2), 
	JoinDate DATE 
);

-- Departments Data
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES 
	(1, 'HR'), 
	(2, 'Finance'), 
	(3, 'IT'), 
	(4, 'Marketing');

-- Employees Data
INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES 
	(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'), 
	(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
	(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'), 
	(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05');

IF OBJECT_ID('sp_GetEmployeesByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetEmployeesByDepartment;
GO

CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        E.EmployeeID,
        E.FirstName,
        E.LastName,
        D.DepartmentName,
        E.Salary,
        E.JoinDate
    FROM Employees E
    INNER JOIN Departments D ON E.DepartmentID = D.DepartmentID
    WHERE E.DepartmentID = @DepartmentID;
END;
GO

-- Drop if already exists (optional but safe)
IF OBJECT_ID('sp_InsertEmployee', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertEmployee;
GO

CREATE PROCEDURE sp_InsertEmployee
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@EmployeeID, @FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;
GO

EXEC sp_InsertEmployee 
    @EmployeeID = 5,
    @FirstName = 'Neha', 
    @LastName = 'Kumar', 
    @DepartmentID = 1, 
    @Salary = 5800.00, 
    @JoinDate = '2023-12-01';

