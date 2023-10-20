using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Entity;

public class EmployeeService
{
    public List<Employee> GetEmployees()
    {
        using (var dbContext = new MyDbContext())
        {
            // Employeesテーブルから全てのレコードを取得
            var employees = dbContext.Employees.ToList();
            return employees;
        }
    }
}
