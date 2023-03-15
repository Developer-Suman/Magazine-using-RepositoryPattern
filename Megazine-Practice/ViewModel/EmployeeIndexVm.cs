using Megazine_Practice.Helper;

namespace Megazine_Practice.ViewModel
{
    public class EmployeeIndexVm
    {
        public EmployeeViewModel EmployeeViewModel { get; set; }
        public List<EmployeeViewModel> EmployeeViewModels { get; set; }

        public PaginatedList<EmployeeViewModel> EmployeePagedList { get; set; }
    }
}
