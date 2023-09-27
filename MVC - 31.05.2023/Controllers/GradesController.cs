using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC___31._05._2023.Models;
using MVC___31._05._2023.Services;
using MVC___31._05._2023.ViewModels;

namespace MVC___31._05._2023.Controllers
{
	[Authorize]
	public class GradesController : Controller
	{
		
		GradeService service;
		public GradesController(GradeService service)
		{
			this.service = service;
		}

		//public IActionResult Index()
		//{
		//	return View();
		//}

		[Authorize(Roles ="Techer")]
		public async Task<IActionResult> Index()
		{
			var allGrades = await service.GetAllAsync();
			return View(allGrades);
		}
		//public async Task<IActionResult> Create()
		//{
		//	return View();
		//}

		[Authorize(Roles = "Techer")]
		public async Task<IActionResult> Create()
		{
			var gradesDropDownsData = await service.GetGradesDropdownsValues();
			ViewBag.Students = new SelectList(gradesDropDownsData.Students, "Id", "LastName");
			ViewBag.Subjects = new SelectList(gradesDropDownsData.Subjects, "Id", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(GradesViewModel newGrade)
		{
			await service.CreateAsync(newGrade);
			return RedirectToAction("Index");
		}

		[Authorize(Roles = "Techer")]
		public async Task<IActionResult> Edit(int id)
		{
			var gradeToEdit = await service.GetByIdAsync(id);
			if (gradeToEdit == null)
			{
				return View("NotFound");
			}
			var gradesDropdownsData = await service.GetGradesDropdownsValues();
			ViewBag.Students = new SelectList(gradesDropdownsData.Students, "Id", "LastName");
			ViewBag.Subjects = new SelectList(gradesDropdownsData.Subjects, "Id", "Name");
			var gradeVMtoEdit = new GradesViewModel()
			{
				Id = gradeToEdit.Id,
				Date = gradeToEdit.Date,
				Mark = gradeToEdit.Mark,
				StudentId = gradeToEdit.Student.Id,
				SubjectId = gradeToEdit.Subject.Id,
				What = gradeToEdit.What,
			};
			return View(gradeVMtoEdit);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, GradesViewModel updatedGrade)
		{
			await service.UpdateAsync(id, updatedGrade);
			return RedirectToAction("Index");
		}

		[Authorize(Roles = "Techer")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			await service.DeleteAsync(id);
			return RedirectToAction("Index");
		}
	}

}

