using System.Collections.Generic;

namespace ViewModels
{
    public class EmployeeListViewModel :BaseViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
        
    }
}