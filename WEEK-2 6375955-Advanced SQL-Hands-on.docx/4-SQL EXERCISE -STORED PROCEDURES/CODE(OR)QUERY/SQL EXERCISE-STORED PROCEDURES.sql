USE EmployeeManagement;
go


DROP TABLE IF EXISTS EMPLOYEES;
DROP TABLE IF EXISTS DEPARTMENTS;

 CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),  -- Added IDENTITY for auto-increment
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);
 -- Insert into Departments
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');

-- Insert into Employees
INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
('John', 'Doe', 1, 5000.00, '2020-01-15'),
('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
('Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
('Emily', 'Davis', 4, 5500.00, '2021-11-05');

SELECT * FROM DEPARTMENTS;
SELECT * FROM Employees;

USE EmployeeManagement;
GO

DROP PROCEDURE if exists sp_GetEmployeesByDepartment;
DROP PROCEDURE IF EXISTS SP_INSERTEMPLOYEE;
go

--CREATE A STORED PROCEDURE
CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DeptID INT
AS
BEGIN
    SELECT EmployeeID, FirstName, LastName, JoinDate
    FROM Employees
    WHERE DepartmentID = @DeptID;
END;

GO

 CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;

--EXECUTE STORED PROCEDURE
 EXEC sp_GetEmployeesByDepartment @DeptID = 3;
 EXEC sp_InsertEmployee 
    @FirstName = 'Sarah',
    @LastName = 'Lee',
    @DepartmentID = 2,
    @Salary = 6200.00,
    @JoinDate = '2022-05-01';

	

	DROP PROCEDURE IF EXISTS sp_CountEmployeesInDepartment;
	GO
--RETURN TOTAL NUMBER OF EMPLOYEES IN A DEPARTMENT
 CREATE PROCEDURE sp_CountEmployeesInDepartment
    @DeptID INT
AS
BEGIN
    SELECT COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DeptID;
END;

GO
 EXEC sp_CountEmployeesInDepartment @DeptID = 2;


