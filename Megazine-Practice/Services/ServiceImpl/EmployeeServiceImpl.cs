using AutoMapper;
using Megazine_Practice.Models;
using Megazine_Practice.Repository.RepoImplementation;
using Megazine_Practice.Repository.RepoInterface;
using Megazine_Practice.Services.ServiceInterface;
using Megazine_Practice.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;

namespace Megazine_Practice.Services.ServiceImpl
{
    public class EmployeeServiceImpl : IEmployeeService
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UnitOfWorkRepoImpl _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeServiceImpl(IWebHostEnvironment webHostEnvironment, UnitOfWorkRepoImpl unitOfWorkRepoImpl, IMapper mapper)
        {
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWorkRepoImpl;
            _mapper = mapper;

        }

        public void delete(EmployeeViewModel employeeViewModel)
        {
            try
            {
                Employee employe = new Employee();
                var employeestobedeleted = _mapper.Map<Employee>(employeeViewModel);
                _unitOfWork.Repository<Employee>().delete(employeestobedeleted);
                _unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public List<EmployeeViewModel> GetAll()
        {
            try
            {
                var employee = _unitOfWork.Repository<Employee>().getAll();
                List<EmployeeViewModel> employeeViewModel = Mapping(employee);
                return employeeViewModel;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private List<EmployeeViewModel> Mapping(List<Employee> Employeemodel)
        {
            List<EmployeeViewModel> employeemodels = new List<EmployeeViewModel>();
            foreach (var items in Employeemodel)
            {
                var employeeviewmodel = _mapper.Map<EmployeeViewModel>(items);
                employeemodels.Add(employeeviewmodel);
            }
            return employeemodels;
        }




        public EmployeeViewModel GetById(int Employee_Id)
        {
            try
            {
                var employee = _unitOfWork.Repository<Employee>().getById(Employee_Id);
                EmployeeViewModel employeeVm = _mapper.Map<EmployeeViewModel>(employee);
                return employeeVm;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);  
                throw;
            }
        }

        public void save(EmployeeViewModel employeeViewModel)
        {
            try
            {
                employeeViewModel.Employee_Image = UploadFile(employeeViewModel);
                var EmployeeToBeInserted = _mapper.Map<Employee>(employeeViewModel);
                _unitOfWork.Repository<Employee>().insert(EmployeeToBeInserted);
                _unitOfWork.Commit();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private string UploadFile(EmployeeViewModel employeeViewModel)
        {
            string fileName = null;
            if(employeeViewModel.File!=null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "_" + employeeViewModel.File.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    employeeViewModel.File.CopyTo(fileStream);
                }
            }

            return fileName;
        }

        public void update(EmployeeViewModel employeeViewModel)
        {
            try
            {
                employeeViewModel.Employee_Image = UploadFile(employeeViewModel);
                Employee employee = new Employee();
                var EmployeeToBeUploaded = _mapper.Map<Employee>(employeeViewModel);
                _unitOfWork.Repository<Employee>().update(EmployeeToBeUploaded); ;
                _unitOfWork.Commit();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
                throw;
            }
        }

        public bool ChangeEmployeeStatus(int Employee_id)
        {
            try
            {
                var employee = _unitOfWork.Repository<Employee>().getById(Employee_id);

                if(employee == null)
                {
                    throw new Exception();
                }

                if(employee.Is_Active == true)
                {
                    employee.Is_Active = false;
                }
                if(employee.Is_Active == false)
                {
                    employee.Is_Active = true;
                }

                _unitOfWork.Repository<Employee>().update(employee);
                _unitOfWork.Commit();
                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}


