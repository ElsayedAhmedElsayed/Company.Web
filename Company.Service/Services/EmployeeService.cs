using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class EmployeeService : IEmployeeRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Employee entitiy)
        {
           _unitOfWork.employeeRepository.Add(entitiy);
            _unitOfWork.Complete();
        }

        public void Delete(Employee entitiy)
        {
            _unitOfWork.employeeRepository.Delete(entitiy);
            _unitOfWork.Complete();
        }

        public IEnumerable<Employee> GetAll()
        {
            var dept=_unitOfWork.employeeRepository.GetAll();
            return dept;
        }

        public Employee GetById(int? id)
        {
            if (id is null)
            {
                return null;
            }
            var dept = _unitOfWork.employeeRepository.GetById(id.Value);
            if (id is null)
            {
                return null;
            }
            return dept;
        }


        

        public IEnumerable<Employee> GetEmployeeByName(string name)
        =>_unitOfWork.employeeRepository.GetEmployeeByName(name);

        public void Update(Employee entity)
        {
            _unitOfWork.employeeRepository.Update(entity);
            _unitOfWork.Complete();
        }
    }
}
