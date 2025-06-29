IF OBJECT_ID('fn_CalculateAnnualSalary', 'FN') IS NOT NULL
    DROP FUNCTION fn_CalculateAnnualSalary;
GO

CREATE FUNCTION fn_CalculateAnnualSalary
(
    @EmployeeID INT
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @AnnualSalary DECIMAL(10,2);

    SELECT @AnnualSalary = Salary * 12
    FROM Employees
    WHERE EmployeeID = @EmployeeID;

    RETURN @AnnualSalary;
END;
GO

SELECT dbo.fn_CalculateAnnualSalary(1) AS AnnualSalary;
