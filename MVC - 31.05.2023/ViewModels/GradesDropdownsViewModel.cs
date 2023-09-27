using MVC___31._05._2023.Models;

namespace MVC___31._05._2023.ViewModels
{
	public class GradesDropdownsViewModel
	{
		public List<Student>Students { get; set; }
		public List<Subject> Subjects { get; set; }
		public GradesDropdownsViewModel() {
			Students = new List<Student>();
			Subjects = new List<Subject>();
		}
	}
}
