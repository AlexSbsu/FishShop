using System.ComponentModel.DataAnnotations;

namespace Fish_Shop
{
	public class Person
	{
		[Required(ErrorMessage = "*Required field")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
		public string Name { get; set; }
		
		[Required(ErrorMessage = "Не указан электронный адрес")]
		public string? Email { get; set; }
		
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }		

		[Range(1, 110, ErrorMessage = "Недопустимый возраст")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]
		public string? PasswordConfirm { get; set; }
		public int Age { get; set; }

	}
}
