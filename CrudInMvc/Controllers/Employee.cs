using CrudInMvc.DbConnection;
using CrudInMvc.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace CrudInMvc.Controllers
{
    public class Employee : Controller
    {
        private IConfiguration _configuration;

        public Employee(IConfiguration configuration) { 
            _configuration = configuration;
            }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ViewResult> Add()
        {
            MvcDataContext mvc = new MvcDataContext(_configuration);
            List<EmployeeController> list = new List<EmployeeController>();
            using (var conn = mvc.getOpenConection())
            {
                
                var sql = "SELECT * FROM org_member ";
                var result=await conn.QueryAsync(sql);
                foreach(var item in result)
                {
                    var res = new EmployeeController
                    {
                        Id = item.id,
                        organaisation_id=item.organaisation_id,
                        device_id=item.device_id,
                        member_id=item.member_id,
                        is_active = item.is_active,
                        created_date=item.created_date

                    }; list.Add(res);
                }
            }return View(list);
        }
      

    }
}
