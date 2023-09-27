using Microsoft.AspNetCore.Mvc;
using MVC___31._05._2023.Services;
using MVC___31._05._2023.Models;
using Microsoft.AspNetCore.Authorization;

namespace MVC___31._05._2023.Controllers
{
    [Authorize(Roles = "Admin, Teacher")]
    public class StudentsController : Controller
    {
        public StudentService service;
        public StudentsController(StudentService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var allStudents= await service.GetAllAsync();
            return View(allStudents);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(Student newStudent)
        {
            await service.CreateAsync(newStudent);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>Edit(int id)
        {
            var studentToEdit= await service.GetByIdAsync(id);
            if (studentToEdit == null ) 
            {
                return View("NotFound");
            }
            return View(studentToEdit);
        }
		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth")] Student student)
		{
            await service.UpdateAsync(id, student);
            return RedirectToAction("Index");
		}
		public async Task<IActionResult>Delete(int id)
        {
            var studentToDelete= await service.GetByIdAsync(id);
            if(studentToDelete == null)
            {
                return View("NotFound");
            }
            await service.DeleteAsync(id);
            return RedirectToAction("Index");
        } 

	}
}
