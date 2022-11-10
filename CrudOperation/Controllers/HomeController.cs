using CrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleCore.Core.IServices;
using SampleCore.Core.Model;
namespace CrudOperation.Controllers
{
    public class HomeController : Controller
    {

        private readonly IStudentServices _studentServices;
        public HomeController(IStudentServices services)
        {

            _studentServices = services;
        }

        #region create
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

      
        [HttpPost]
        public IActionResult Index(Student data)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7105/api/StudentAPI/Index");
                var PostTask = client.PostAsJsonAsync<Student>(client.BaseAddress, data);
                PostTask.Wait();
                var checkresult = PostTask.Result;
              //  _studentServices.CreateStudentEntry(data);
                return RedirectToAction("Read");

            }
        }
        #endregion

        #region Read data from table
        [HttpGet]
        public IActionResult Read()
        {

            using (HttpClient client = new HttpClient())
            {
                IEnumerable<Student> emp = null;
                client.BaseAddress = new Uri("https://localhost:7105/api/StudentAPI/Read");
                var GetTask = client.GetAsync(client.BaseAddress);
                GetTask.Wait();
                var result = GetTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<Student>>();
                    readTask.Wait();
                    emp = readTask.Result;
                }
                return View(emp);


            }
        }
        #endregion

        #region Edit data
        [HttpGet]
        public IActionResult Edit(int id)
        {

            Index();
            Student emp = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7105/api/StudentAPI/Edit?id=");
                var GetTask = client.GetAsync(client.BaseAddress + id.ToString());
                GetTask.Wait();
                var result = GetTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<Student>();
                    readTask.Wait();
                    emp = readTask.Result;
                }
            }
            //ViewBag.edit = 1; for button hiding
            ViewBag.edit = 1;
            return View("Index", emp);

        }


        #endregion

        #region Delete 
        [HttpGet]
        public IActionResult Delete(int student_id)
        {
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:7105/api/StudentAPI/Delete?student_id=");

                var deleteTask = client.DeleteAsync(client.BaseAddress + student_id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Read");
                }
            }
            return RedirectToAction("Read");

        }


        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}