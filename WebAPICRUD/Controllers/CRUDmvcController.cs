using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPICRUD.Models;

namespace WebAPICRUD.Controllers
{
    public class CRUDmvcController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: CRUDmvc
        public ActionResult Index()
        {
            List<Employee> empList = new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44306/api/CRUDAPI");
            var responses = client.GetAsync("CRUDAPI");
            responses.Wait();

            var responseTest = responses.Result;
            if (responseTest.IsSuccessStatusCode)
            {
                var display = responseTest.Content.ReadAsAsync<List<Employee>>();
                display.Wait();
                empList = display.Result;
            }

            return View(empList);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}