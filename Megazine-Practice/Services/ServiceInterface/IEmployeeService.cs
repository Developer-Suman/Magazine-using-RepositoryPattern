using Megazine_Practice.ViewModel;

namespace Megazine_Practice.Services.ServiceInterface
{
    public interface IEmployeeService
    {
        void save(EmployeeViewModel employeeViewModel);
        void update(EmployeeViewModel employeeViewModel);

        void delete(EmployeeViewModel employeeViewModel);
        List<EmployeeViewModel> GetAll();
        EmployeeViewModel GetById(int Employee_Id);

        bool ChangeEmployeeStatus(int Employee_id);

    }
}
