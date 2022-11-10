using Microsoft.AspNetCore.Mvc;
using SampleCore.Core.IServices;
using SampleCore.Core.Model;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentAPIController : Controller
    {
        private readonly IStudentServices _studentServices;
        public StudentAPIController(IStudentServices services)
        {

            _studentServices = services;
        }

        #region   Create table

        [HttpGet]
        public IActionResult Index()
        {
            
            return Ok();

           

        }

        [HttpPost]
        public IActionResult Index(Student data)
        {
            _studentServices.CreateStudentEntry(data);

             return Ok(data);

        }

        #endregion


        #region Read data from table
        [HttpGet]
        public IActionResult Read()
        {

            var value = _studentServices.Reads();
            return Ok(value);

        }
        #endregion



         #region Edit data
            [HttpGet]
        public IActionResult Edit(int id)
            {
                var value = _studentServices.EditForm(id);
                return Ok(value);
            }
       
        #endregion

        #region Delete 
        [HttpDelete]
        public IActionResult Delete(int student_id)
            {
             _studentServices.Delete(student_id);
            return Ok();
            }
        #endregion
    }
}
