﻿namespace G4.WcfService.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.ServiceModel.Web;

    public class EmployeeService : IEmployeeService
    {
        private static readonly IList<Employee> Employees = new List<Employee>
                                                       {
                                                           new Employee
                                                               {
                                                                   Id = "001",
                                                                   Name = "张三",
                                                                   Department = "开发部",
                                                                   Grade = "G7"
                                                               },
                                                           new Employee
                                                               {
                                                                   Id = "002",
                                                                   Name = "李四",
                                                                   Department = "人事部",
                                                                   Grade = "G6"
                                                               }
                                                       };

        public Employee Get(string id)
        {
            Employee employee = Employees.FirstOrDefault(e => e.Id == id);
            if (null == employee)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
            }
            return employee;
        }

        public void Create(Employee employee)
        {
            Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            this.Delete(employee.Id);
            Employees.Add(employee);
        }

        public void Delete(string id)
        {
            Employee employee = this.Get(id);
            if (null != employee)
            {
                Employees.Remove(employee);
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            return Employees;
        }
    }
}