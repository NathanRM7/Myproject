namespace CrudInMvc.Models
{
    public class memberdata
    {
        public List<memberdata> memberdatas = new List<memberdata>();
        public int member_id { get; set; }
        public string first_name { get; set;}
        public string last_name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
