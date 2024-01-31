using CrudInMvc.DbConnection;
using CrudInMvc.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace CrudInMvc.Controllers
{
    public class Employee : Controller
    {
        private IConfiguration _configuration;

        public Employee(IConfiguration configuration)
        {
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

                var sql = "SELECT * FROM org_member_device ";
                var result = await conn.QueryAsync(sql);
                foreach (var item in result)
                {
                    var res = new EmployeeController
                    {
                        Id = item.id,
                        organaisation_id = item.organaisation_id,
                        device_id = item.device_id,
                        member_id = item.member_id,
                        is_active = item.is_active,
                        created_date = item.created_date

                    }; list.Add(res);
                }
            }
            return View(list);
        }


        public async Task<IActionResult> Diplay()
        {

            MvcDataContext mvc = new MvcDataContext(_configuration);
            List<ErrorLog> list = new List<ErrorLog>();
            using (var conn = mvc.getOpenConection())
            {

                var sql = "SELECT * FROM error_log order by id desc ";
                var result = await conn.QueryAsync(sql);
                foreach (var item in result)
                {
                    var res = new ErrorLog
                    {
                        id = item.id,
                        app_module = item.app_module,
                        error_message = item.error_message,
                        created_date = item.created_date


                    }; list.Add(res);
                }
            }
            return View(list);
        }
        [HttpGet]
        public ViewResult Insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(ErrorLog es)
        {
            var list = new List<ErrorLog>();
            MvcDataContext mvc = new MvcDataContext(_configuration);
            using (var conn = mvc.getOpenConection())
            {

                var sql = "Insert into error_log (app_module,error_message,created_date,payload_files,user_id) values (@app_module,@error_message,@created_date,@payload_files,@user_id) ";
                var parameter = new DynamicParameters();
                //parameter.Add("@id", es.id, System.Data.DbType.Int32);
                parameter.Add("@user_id", es.user_id, System.Data.DbType.Int32);
                parameter.Add("@app_module", es.app_module, System.Data.DbType.String);
                parameter.Add("@payload_files", es.payload, System.Data.DbType.String);
                parameter.Add("@error_message", es.error_message, System.Data.DbType.String);
                parameter.Add("@created_date", DateTime.UtcNow, System.Data.DbType.DateTime);
                var results = await conn.ExecuteAsync(sql, parameter);



                return RedirectToAction("Diplay");

            }



        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var pa = new Login()
            {
                firstName = login.firstName,
                password=login.password
            };
          
            MvcDataContext mvc = new MvcDataContext(_configuration);
            List<ErrorLog> list = new List<ErrorLog>();
            using (var conn = mvc.getOpenConection())
            {
                var param=new DynamicParameters();
                param.Add("@email", pa.firstName, System.Data.DbType.String);

                var sql = "SELECT * FROM org_member WHERE EMAIL=@email";
                var result = await conn.QueryFirstOrDefaultAsync(sql,param);
                if (result != null)
                {
                    if (result.password == pa.password)
                    {
                        return RedirectToAction("Add");
                    }
                    return RedirectToAction("Login");

                }
                else {
                    return RedirectToAction("Login");
                }

            }



        }
    }
}
