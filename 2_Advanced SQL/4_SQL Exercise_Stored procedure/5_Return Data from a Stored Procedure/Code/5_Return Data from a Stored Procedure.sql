-- Drop it first if it already exists
IF OBJECT_ID('sp_GetEmployeeCountByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetEmployeeCountByDepartment;
GO

CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        D.DepartmentName,
        COUNT(E.EmployeeID) AS TotalEmployees
    FROM Departments D
    LEFT JOIN Employees E ON D.DepartmentID = E.DepartmentID
    WHERE D.DepartmentID = @DepartmentID
    GROUP BY D.DepartmentName;
END;
GO

EXEC sp_GetEmployeeCountByDepartment @DepartmentID = 2;