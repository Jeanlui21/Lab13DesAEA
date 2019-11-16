using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using Domain;
using Service;
using MVCAJAX.Models;

namespace MVCAJAX.Controllers
{
    public class StudentController : Controller
    {
        private StudentService service = new StudentService();
        // GET: Student
        public ActionResult IndexRazor()
        {
            var model = (from c in service.Get()
                         select new StudentModel
                         {
                             ID = c.studentID,
                             Name = c.studentName,
                             LastName = c.studentLastName,
                             Address = c.studentAddress,
                             CreatedDate = c.CreatedDate,
                             UpdatedDate = c.UpdatedDate
                         }).ToList();
            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetStudent(string id)
        {
            return Json(service.Get(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            service.Insert(student);
            string message = "SUCCESS";
            return Json(new { Message = message, newStudent = student, JsonRequestBehavior.AllowGet });
        }
    }
}