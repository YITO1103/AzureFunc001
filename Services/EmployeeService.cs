using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;



public class EmployeeService
{
    public List<Employee> GetEmployees()
    {
        using (var dbContext = new MyDbContext())
        {
            // Employeesテーブルから全てのレコードを取得
            var employees =  dbContext.Employees.ToList();
            return employees;
        }
    }
}
