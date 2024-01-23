namespace CrudInMvc.Models
{
    public class EmployeeController
    {
      public List<EmployeeController> List { get; set; }
        public int Id { get; set; }
        public int organaisation_id { get; set; }
        public string device_id { get; set; }
        public int    member_id { get; set; }
        public int is_active {  get; set; }
        public DateTime? created_date { get; set; }
    }
}
