using CrudInMvc.Controllers;

namespace CrudInMvc.Models
{
    public class AddEmployee
    {
        public List<EmployeeController> employeeControllers { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Phone { get; set; }
    }
}
