﻿namespace MVC___31._05._2023.Models
{
	public class Grade
	{
		public int Id { get; set; }
		public Student Student { get; set; }
		public Subject Subject { get; set; }
		public string What { get; set; }
		public int Mark { get; set; }
		public DateTime Date { get; set; }

	}
}