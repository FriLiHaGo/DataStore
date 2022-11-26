using System.ComponentModel.DataAnnotations;

namespace WebDataStore.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Вы не ввели логин")]
        [Display(Name = "Логин")]
        public string Login { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Вы забыли ввести пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}