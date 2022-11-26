using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebDataStore.Models
{
    public class CreateDocumentModel
    {
        [Required(ErrorMessage = "Введите название документа")]
        [Display(Name = "Название документа")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Выберите файл")]
        public HttpPostedFileBase File { get; set; }
    }
}