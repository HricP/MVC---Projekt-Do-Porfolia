using Microsoft.AspNetCore.Mvc;
using MVC___31._05._2023.Services;
using MVC___31._05._2023.Models;

namespace MVC___31._05._2023.Controllers
{
	public class SubjectsController : Controller
	{
		public SubjectsService service2;

		public SubjectsController(SubjectsService service2)
		{
			this.service2 = service2;
		}

		public async Task<IActionResult> IndexAsync()
		{
			var allSubjects = await service2.GetAllAsync();
			return View(allSubjects);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Subject newSubject)
		{
			if (ModelState.IsValid)
			{
				await service2.CreateAsync(newSubject);
				return RedirectToAction("Index");
			}
			else { return View(); }
		}


		public async Task<IActionResult> Edit(int id)
		{
			var subjectToEdit = await service2.GetByIdAsync(id);
			if (subjectToEdit == null)
			{
				return View("NotFound");
			}
			return View(subjectToEdit);
		}
		//_________________
		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Subject subject)
		{
			await service2.UpdateAsync(id, subject);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(int id)
		{
			var subjectToDelete = await service2.GetByIdAsync(id);
			if (subjectToDelete == null)
			{
				return View("NotFound");
			}
			await service2.DeleteAsync(id);
			return RedirectToAction("Index");
		}
	}
}
