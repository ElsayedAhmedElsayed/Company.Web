using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Department.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(Interfaces.Department.Dto.DepartmentDto entity)
        {
            //var MappedDepartment = new Department
            //{
            //    Code = entity.Code,
            //    Name = entity.Name,
            //    CreatedAt = DateTime.Now,
            //    Id = entity.Id
            //};
            var mappedDept = _mapper.Map<Data.Models.Department>(entity);

            _unitOfWork.departmentRepository.Add(mappedDept);
            _unitOfWork.Complete();
        }

        public void Delete(Interfaces.Department.Dto.DepartmentDto entity)
        {
            //var MappedDepartment = new Department
            //{
            //    Code = entity.Code,
            //    Name = entity.Name,
            //    CreatedAt = DateTime.Now,
            //    Id = entity.Id
            //};
            var mappedDept = _mapper.Map<Data.Models.Department>(entity);

            _unitOfWork.departmentRepository.Delete(mappedDept);
            _unitOfWork.Complete();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var dept = _unitOfWork.departmentRepository.GetAll()/*.Where(x => x.IsDeleted != true)*/;
            //var MappedDepartment = dept.Select(x => new DepartmentDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    CreatedAt = DateTime.Now,
            //    Code = x.Code

            //});
            var mappedDept = _mapper.Map<IEnumerable<DepartmentDto>>(dept);
            return mappedDept;
        }
        public Interfaces.Department.Dto.DepartmentDto GetById(int? id)
        {
            if (id is null)
            {
                return null;
            }
            var dept =_unitOfWork.departmentRepository.GetById(id.Value) ;
            if (id is null)
                return null;
            //DepartmentDto departmenDto = new DepartmentDto
            //{
            //    Id = id.Value,
            //    Code = dept.Code,
            //    Name = dept.Name,
            //    CreatedAt = DateTime.Now,
            //};
            var mappedDept = _mapper.Map<Interfaces.Department.Dto.DepartmentDto>(dept);

            return mappedDept;
        }



        //public void Update(DepartmenDto entity)
        //{
        //    var dept = GetById(entity.Id);

        //    if (dept.Name != entity.Name)
        //    {
        //        if (GetAll().Any(x => x.Name == entity.Name))
        //        {
        //            throw new Exception("Dublicated Department");
        //        }
        //    }
        //    dept.Name = entity.Name;
        //    dept.Code = entity.Code;

        //    _unitOfWork.departmentRepository.Update(dept);
        //    _unitOfWork.Complete();
        //}
    }
}
