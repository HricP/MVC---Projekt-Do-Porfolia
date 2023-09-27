using MVC___31._05._2023.Models;
using System.ComponentModel;

namespace MVC___31._05._2023.ViewModels
{
	public class GradesViewModel
	{
		public int Id { get; set; }
		[DisplayName("Student Name")]
		public int StudentId { get; set; }
		[DisplayName("Subject")]
		public int SubjectId { get; set; }
		public string What { get; set; }
		[DisplayName("Grade")]
		public int Mark { get; set; }
		public DateTime Date { get; set; }
	}
}
