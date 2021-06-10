using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebLibrary.Models
{
    public class BookViewModelsError
    {
        
        [Required(ErrorMessage ="Вкажіть назву книги")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Вкажіть автора книги")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Додайте опис книги")]
        public string Description { get; set; }
        [Range(1500, 2021, ErrorMessage = "Не допустиме значення для року видання книги")]
        public int Year { get; set; }
    }
}
