using System.ComponentModel.DataAnnotations;

namespace MVC___31._05._2023.ViewModels
{
	// Login: Uzivatel1
	// Heslo: Heslo-1234
	public class LoginVM
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }
		public string? ReturnUrl { get; set; }
		public bool Remember { get; set; }
	}
}
