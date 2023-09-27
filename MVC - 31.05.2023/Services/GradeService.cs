using MVC___31._05._2023.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using MVC___31._05._2023.ViewModels;

namespace MVC___31._05._2023.Services
{
	public class GradeService
	{
		ApplicationDbContext dbContext;
		public GradeService(ApplicationDbContext context)
		{
			dbContext = context;
		}

		public async Task<IEnumerable<Grade>> GetAllAsync()
		{
			return await dbContext.Grades.Include(st => st.Student).Include(Subject => Subject.Subject).ToListAsync();
		}
		public async Task<GradesDropdownsViewModel> GetGradesDropdownsValues()
		{
			var gradesDropDownsdata = new GradesDropdownsViewModel()
			{
				Students = await dbContext.Students.ToListAsync(),
				Subjects = await dbContext.Subjects.ToListAsync(),
			};
			return gradesDropDownsdata;
		}
		internal async Task CreateAsync(GradesViewModel newGrade)
		{
			var gradeToInsert = new Grade()
			{
				Student = dbContext.Students.FirstOrDefault(st => st.Id == newGrade.StudentId),
				Subject = dbContext.Subjects.FirstOrDefault(sub => sub.Id == newGrade.SubjectId),
				Mark = newGrade.Mark,
				What = newGrade.What,
				Date = DateTime.Today
			};
			if (gradeToInsert.Subject != null && gradeToInsert.Student != null)
			{
				await dbContext.Grades.AddAsync(gradeToInsert);
				await dbContext.SaveChangesAsync();
			}
		}
		public async Task<Grade> GetByIdAsync(int id)
		{
			return await dbContext.Grades.Include(st => st.Student).Include(sub => sub.Subject).FirstOrDefaultAsync(g => g.Id == id);
		}

		internal async Task UpdateAsync(int id, GradesViewModel updatedGrade)
		{
			var dbGrade = await dbContext.Grades.FirstOrDefaultAsync(gr => gr.Id == id);
			if (dbGrade != null)
			{
				dbGrade.Student = await dbContext.Students.FirstOrDefaultAsync(st => st.Id == updatedGrade.StudentId);
				dbGrade.Subject = await dbContext.Subjects.FirstOrDefaultAsync(sub => sub.Id == updatedGrade.SubjectId);
				dbGrade.What = updatedGrade.What;
				dbGrade.Mark = updatedGrade.Mark;
				dbGrade.Date = updatedGrade.Date;
			}
			dbContext.Update(dbGrade);
			await dbContext.SaveChangesAsync();
		}
		internal async Task DeleteAsync(int id)
		{
			var gradeToDelete = await dbContext.Grades.FirstOrDefaultAsync(gr => gr.Id == id);
			dbContext.Grades.Remove(gradeToDelete);
			await dbContext.SaveChangesAsync();
		}



		//public async Task<IActionResult> Edit(int id) { }

	}
}
