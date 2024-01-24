namespace CrudInMvc.Models
{
    public class ErrorLog
    {
        public List<ErrorLog> Errors { get; set; }
        public int id { get; set; }
        public string app_module { get; set; }
        public string error_message { get; set;}
        public int user_id { get; set; }
        public string payload { get; set; }
        public DateTime created_date { get; set; }
    }
}
