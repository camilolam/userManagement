using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using userManagement.data;
using userManagement.Models;

namespace userManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Views
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        // requests

        [HttpGet]
        public JsonResult newUser( )
        {

            string response = "{\"msg\":1} ";

            return Json(response);
        }


        [HttpGet]
        public JsonResult showUsers()
        {

            List<string> userList = new List<string>();
            dbConn conn = new dbConn();
            userList = conn.listUsers(conn);

            return Json(userList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
