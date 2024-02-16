using System.ComponentModel.DataAnnotations;

namespace Fish_Shop
{
    public class User
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]                            // <----Required
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string? Surname { get; set; }
        public int? Age { get; set; }
        [MaxLength(20)]
        public string? Patronymic { get; set; }
        public List<Order>? Orders { get; set; } = new List<Order>();

        [Required]                            // <----Required  EMAIL
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]                            // <----Required
        [Display(Name = "Год рождения")]
        public int BirthDate { get; set; }

        [Required]                            // <----Required
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]                            // <----Required
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }    
}


/*
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
 */