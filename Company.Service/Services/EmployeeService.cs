using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Repository.Repositories;
using Company.Service.Helper;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public void Add(EmployeeDto entitiy)
        {
            //Manual Mapping
            //Employee employee = new Employee
            //{

            //    Address = entitiy.Address,
            //    Age = entitiy.Age,
            //    DepartmentId = entitiy.DepartmentId,
            //    Email = entitiy.Email,
            //    HiringDate = entitiy.HiringDate,
            //    ImgeUrl = entitiy.ImgeUrl,
            //    Name = entitiy.Name,
            //    PhoneNumber = entitiy.PhoneNumber,
            //    Salary = entitiy.Salary
            //};
            entitiy.ImgeUrl = DocumentSettings.UploadFile(entitiy.Image, "Images");
            Employee employee=_mapper.Map<Employee>(entitiy);

           _unitOfWork.employeeRepository.Add(employee);
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDto entitiy)
        {
            //Employee employee = new Employee
            //{

            //    Address = entitiy.Address,
            //    Age = entitiy.Age,
            //    DepartmentId = entitiy.DepartmentId,
            //    Email = entitiy.Email,
            //    HiringDate = entitiy.HiringDate,
            //    ImgeUrl = entitiy.ImgeUrl,
            //    Name = entitiy.Name,
            //    PhoneNumber = entitiy.PhoneNumber,
            //    Salary = entitiy.Salary
            //};
            Employee employee = _mapper.Map<Employee>(entitiy);

            _unitOfWork.employeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {


            var emp=_unitOfWork.employeeRepository.GetAll();

            //var MappedEmployer = emp.Select(x => new EmployeeDto
            //{
            //    Name = x.Name,
            //    Address = x.Address,
            //    Salary= x.Salary,
            //    Age= x.Age,
            //    DepartmentId= x.DepartmentId,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    ImgeUrl = x.ImgeUrl,
            //    PhoneNumber= x.PhoneNumber,
            //    CreatedAt= x.CreatedAt


            //});
            IEnumerable<EmployeeDto> MappedEmployer =_mapper.Map<IEnumerable<EmployeeDto>>(emp);
            return MappedEmployer;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id is null)
            {
                return null;
            }
            var emp = _unitOfWork.employeeRepository.GetById(id.Value);
            if (emp is null)
                return null;

            //EmployeeDto employeeDto = new EmployeeDto
            //{

            //    Address = emp.Address,
            //    Age = emp.Age,
            //    DepartmentId = emp.DepartmentId,
            //    Email = emp.Email,
            //    HiringDate = emp.HiringDate,
            //    ImgeUrl = emp.ImgeUrl,
            //    Name = emp.Name,
            //    PhoneNumber = emp.PhoneNumber,
            //    Salary = emp.Salary
            //};
            EmployeeDto employeeDto=_mapper.Map<EmployeeDto>(emp);
            return employeeDto;
        }




        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
           var emp= _unitOfWork.employeeRepository.GetEmployeeByName(name);

            //var employeeDto =emp.Select(x=> new EmployeeDto
            //{
            //    Address = x.Address,
            //    Age = x.Age,
            //    DepartmentId = x.DepartmentId,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    ImgeUrl = x.ImgeUrl,
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    Salary = x.Salary
            //});
            IEnumerable<EmployeeDto> MappedEmployer = _mapper.Map<IEnumerable<EmployeeDto>>(emp);
            return MappedEmployer;
        }
        //public void Update(EmployeeDto entity)
        //{
        //    _unitOfWork.employeeRepository.Update(entity);
        //    _unitOfWork.Complete();
        //}
    }
}
