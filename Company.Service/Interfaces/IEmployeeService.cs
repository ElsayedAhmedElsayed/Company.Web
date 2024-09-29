using Company.Data.Models;
using Company.Service.Interfaces.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Interfaces
{
    public  interface IEmployeeService
    {
        EmployeeDto GetById(int? id);

        IEnumerable<EmployeeDto> GetAll();

        void Add(EmployeeDto entity);

        //void Update(EmployeeDto entity);

        void Delete(EmployeeDto entity);

        IEnumerable<EmployeeDto> GetEmployeeByName(string name);
    }
}
